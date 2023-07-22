﻿using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.XPath;
using WebMConverter.Objects;

namespace WebMConverter
{
    static class NativeMethods
    {
        [DllImport("kernel32", SetLastError = true)]
        public static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName([MarshalAs(UnmanagedType.LPTStr)] string path, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder shortPath, int shortPathLength);
        [DllImport("gdi32", CharSet = CharSet.Auto)]
        public static extern int AddFontResourceEx(string lpszFilename, uint fl, IntPtr pdv);
        [DllImport("gdi32", CharSet = CharSet.Auto)]
        public static extern bool RemoveFontResourceEx(string lpFileName, uint fl, IntPtr pdv);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr window, int message, int wparam, int lparam);
    }

    static class Utility
    {
        public static int TimeToFrame(double time)
        {
            int frame = (int)(Program.VideoSource.FPSNumerator / (float)Program.VideoSource.FPSDenominator * time);
            double closest = double.MaxValue;

            FFMSSharp.Track VideoTrack = Program.VideoSource.Track;
            FFMSSharp.FrameInfo frameinfo;
            while (true)
            {
                frameinfo = VideoTrack.GetFrameInfo(frame);
                double difference;

                try
                {
                    // To convert this to a timestamp in wallclock milliseconds, use the relation int64_t timestamp = (int64_t)((FFMS_FrameInfo->PTS * FFMS_TrackTimeBase->Num) / (double)FFMS_TrackTimeBase->Den).
                    difference = ((frameinfo.PTS * VideoTrack.TimeBaseNumerator) / VideoTrack.TimeBaseDenominator / 1000) - time;
                }
                catch (NullReferenceException) // We've seeked out of bounds -- the user likely requested a time longer than the video.
                {
                    frame = VideoTrack.NumberOfFrames - 1;
                    break;
                }

                if (Math.Abs(difference) <= closest && Math.Abs(difference) >= closest) break; // We've seeked as close as possible.

                if (Math.Abs(difference) < closest)
                    closest = Math.Abs(difference);

                if (difference < 0)
                    frame += 1;

                else
                    frame -= 1;
            }
            return frame;
        }

        public static int TimeSpanToFrame(TimeSpan time) => TimeToFrame(time.TotalSeconds);
        public static long FrameToTime(int frame) => Program.VideoSource.Track.GetFrameInfo(frame).PTS * Program.VideoSource.Track.TimeBaseNumerator / Program.VideoSource.Track.TimeBaseDenominator;
        public static TimeSpan FrameToTimeSpan(int frame) => new TimeSpan(FrameToTime(frame) * 10000);
        public static string FrameToTimeStamp(int frame) => FrameToTimeSpan(frame).ToString(@"hh\:mm\:ss");
        public static string FrameToLongTimeStamp(int frame) => FrameToTimeSpan(frame).ToString(@"hh\:mm\:ss\.ff");

        public static double ProbeDuration(string filename, bool avs)
        {
            if (string.IsNullOrEmpty(filename))
                return 1;

            using (var prober = new FFprobe(filename, format: avs ? "-f avisynth" : "", argument: "-show_format"))
            {
                string streamInfo = prober.Probe();

                try
                {
                    using (var s = new System.IO.StringReader(streamInfo))
                    {
                        var doc = new XPathDocument(s);
                        var format = doc.CreateNavigator()
                            .SelectSingleNode("//ffprobe/format");

                        if (format == null)
                            return -1;

                        var duration = Convert.ToDouble(format.GetAttribute("duration", ""), CultureInfo.InvariantCulture);
                        var startTime = Convert.ToDouble(format.GetAttribute("start_time", ""), CultureInfo.InvariantCulture);
                        return duration - startTime;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to get duration from file. Error: ${ex.Message}\nstreamInfo: ${streamInfo}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return -1;
                }
            }
        }

        public static void KillProcessAndChildren(int pid)
        {
            var processSearcher = new System.Management.ManagementObjectSearcher
              ("Select * From Win32_Process Where ParentProcessID=" + pid);
            var processCollection = processSearcher.Get();

            try
            {
                var proc = System.Diagnostics.Process.GetProcessById(pid);
                if (!proc.HasExited) proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }

            foreach (var mo in processCollection)
            {
                KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"])); //kill child processes(also kills childrens of childrens etc.)
            }

        }

        public static string GetCompatiblePath(string input)
        {
            // AviSynth and various plugins can't deal with utf-8 paths, so we convert the possibly weird path into 8.3 notation
            var compatible = new StringBuilder(255);
            NativeMethods.GetShortPathName(@"\\?\" + input, compatible, compatible.Capacity);
            // the \\?\ is added because GetShortPathName will fail if input is longer than 256 characters otherwise.
            return compatible.ToString();
        }

        public static bool CheckVC2010x86()
        {
            try
            {
                var parametersVc2010x86 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\Installer\Products\1D5E3C0FEDA1E123187686FED06E995A", false);
                if (parametersVc2010x86 == null) return false;
                var vc2010x86Version = parametersVc2010x86.GetValue("Version");
                if ((int)vc2010x86Version > 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsConnectedToInternet()
        {
            string host = "8.8.8.8";
            bool result = false;
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch
            {
                // ignored    
            }
            return result;
        }

        public static string SizeSuffix(long value)
        {
            int decimalPlaces = 1;
            string[] SizeSuffixes = { "bytes", "KB", "MB", "GB" };
            if (value < 0)
                return "-" + SizeSuffix(-value);
            if (value == 0)
                return string.Format("{0:n" + decimalPlaces + "} bytes", 0);

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }

        public static string GetVersion()
        {
            return Application.ProductVersion.Substring(0, Application.ProductVersion.LastIndexOf('.'));
        }

        public static string Dot(decimal number)
        {
            return number.ToString(CultureInfo.InvariantCulture).Replace(',', '.');
        }

        public static int CorrectCrop(int border1, int border2, int expected, int lenght)
        {
            int aux = border1 + Math.Abs(border2) + expected;
            if (aux == lenght)
                return border2;
            else
                return border2 - (lenght - aux);
        }

        public static int[] CorrectCrop(int border1, int border2)
        {
            int temp1 = border1;
            int temp2 = border2;
            if (border1 % 2 != 0 || border2 % 2 != 0)
            {
                if (border1 - 1 != 0)
                {
                    temp1 = border1 - 1;
                    temp2 = border2 - 1;
                }
                else
                {
                    temp1 = border1 + 1;
                    temp2 = border2 + 1;
                }
            }
            return new int[] { temp1, temp2 };
        }

        public static int Mod2(int number)
        {
            return (number / 2) * 2;
        }

        public static string GetWebRequest(string url)
        {
            WebRequest httpWRequest = WebRequest.Create(url);
            httpWRequest.ContentType = "application/json";
            httpWRequest.Method = "GET";
            httpWRequest.Headers.Add("Authorization", "Bearer " + Program.token);
            return new StreamReader(httpWRequest.GetResponse().GetResponseStream()).ReadToEnd();
        }

        public static string PostWebRequest(string url, string body)
        {
            WebRequest httpWRequest = WebRequest.Create(url);
            httpWRequest.ContentType = "application/json";
            httpWRequest.Method = "POST";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(body);
            httpWRequest.GetRequestStream().Write(byte1, 0, byte1.Length);
            return new StreamReader(httpWRequest.GetResponse().GetResponseStream()).ReadToEnd();
        }

        public static string D(double value)
        {
            string specifier = "G";
            CultureInfo culture = CultureInfo.CreateSpecificCulture("eu-ES");
            return value.ToString(specifier, CultureInfo.InvariantCulture);
        }

        public static void ExecuteFFmpegCommand(String command)
        {
            using (var ffmpeg = new FFmpeg(command))
            {
                ffmpeg.Start();
                ffmpeg.WaitForExit();
            }
        }
    }

    public enum FileType
    {
        Video,
        Avisynth
    }

    public enum SubtitleType
    {
        TextSub,
        VobSub,
        PgsSub,
        VTTSub
    }

    public enum EncodingMode
    {
        Constant,
        Variable
    }

    public enum Token
    {
        New = 1,
        Refresh = 2
    }

    public enum AspectRatio
    {
        None,
        SixteenNine,
        NineSixteen,
        OneOne,
        FourThree,
        TwentyoneNine
    }

    public enum DropOptions
    {
        None,
        Merge,
        Convert
    }
    public static class Extensions
    {
        // http://stackoverflow.com/a/12179408/174466
        static readonly object[] EmptyObjectArray = new object[0];
        public static void InvokeIfRequired(this System.ComponentModel.ISynchronizeInvoke obj, System.Windows.Forms.MethodInvoker action)
        {
            if (obj.InvokeRequired)
            {
                obj.Invoke(action, EmptyObjectArray);
            }
            else
            {
                action();
            }
        }
    }
}
