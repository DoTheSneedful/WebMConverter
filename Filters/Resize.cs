﻿using System;
using System.Globalization;
using System.Windows.Forms;

namespace WebMConverter
{
    public partial class ResizeForm : Form
    {
        float inwidth;
        float inheight;

        public ResizeFilter GeneratedFilter { get; set; }

        public ResizeForm()
        {
            InitializeComponent();
        }

        public ResizeForm(ResizeFilter ResizeFilter)
        {
            InitializeComponent();
            inwidth = ResizeFilter.TargetWidth;
            inheight = ResizeFilter.TargetHeight;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            int targetwidth;
            int targetheight;
            
            try
            {
                targetwidth = int.Parse(textWidthOut.Text);
            }
            catch
            {
                MessageBox.Show("Invalid width!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                targetheight = int.Parse(textHeightOut.Text);
            }
            catch
            {
                MessageBox.Show("Invalid height!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GeneratedFilter = new ResizeFilter(targetwidth, targetheight);
            DialogResult = DialogResult.OK;
        }

        private void textWidthOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textWidthOut_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxProportions.Checked)
                {
                    float i = float.Parse(textWidthOut.Text, CultureInfo.InvariantCulture);

                    textHeightOut.TextChanged -= textHeightOut_TextChanged;
                    textHeightOut.Text = ((int)(inheight / inwidth * i)).ToString();
                    textHeightOut.TextChanged += textHeightOut_TextChanged;
                }
            }
            catch
            { 
                // ignored
            }
        }

        private void textHeightOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textHeightOut_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxProportions.Checked)
                {
                    float i = float.Parse(textHeightOut.Text, CultureInfo.InvariantCulture);

                    textWidthOut.TextChanged -= textWidthOut_TextChanged;
                    textWidthOut.Text = ((int)(inwidth / inheight * i)).ToString();
                    textWidthOut.TextChanged += textWidthOut_TextChanged;
                }
            }
            catch
            {
                // ignored
            }
        }

        void ResizeForm_Load(object sender, EventArgs e)
        {
            FFMSSharp.Frame frame = Program.VideoSource.GetFrame((Filters.Trim == null) ? 0 : Filters.Trim.TrimStart); // the video may have different frame resolutions

            if (Filters.Crop != null)
            {
                inwidth = Filters.Crop.finalWidth;
                inheight = Filters.Crop.finalHeight;
            }
            else if (inwidth == 0 && inheight == 0)
            {
                if ((Owner as MainForm).SarCompensate)
                {
                    inwidth = (Owner as MainForm).SarWidth;
                    inheight = (Owner as MainForm).SarHeight;
                }
                else
                {
                    inwidth = frame.EncodedResolution.Width;
                    inheight = frame.EncodedResolution.Height;
                }
            }

            labelWidthIn.Text = inwidth.ToString(CultureInfo.InvariantCulture);
            textWidthOut.Text = inwidth.ToString(CultureInfo.InvariantCulture);
            labelHeightIn.Text = inheight.ToString(CultureInfo.InvariantCulture);
            textHeightOut.Text = inheight.ToString(CultureInfo.InvariantCulture);

            textWidthOut.TextChanged += textWidthOut_TextChanged;
            textHeightOut.TextChanged += textHeightOut_TextChanged;
        }
    }

    public class ResizeFilter
    {
        public int TargetWidth { get; } 
        public int TargetHeight { get; }

        public ResizeFilter(int targetWidth, int targetHeight)
        {
            TargetWidth = (targetWidth / 2) * 2; // make it even
            TargetHeight = (targetHeight / 2) * 2;
        }

        public override string ToString() => $"LanczosResize({TargetWidth}, {TargetHeight})";

        public string FFmpeg() => $"scale={TargetWidth}:{TargetHeight}";
    }
}
