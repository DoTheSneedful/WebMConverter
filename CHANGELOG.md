v2.26.1
=======
- Fade filter will now be properly reset upon loading a new file.

v2.26.0
=======
- Added support for Blu-ray PGS subtitles (.sup)
- Add some failsafes for getting file duration.

v2.25.0
=======
- Add Fade filter.
- Add icon for Rotate filter.

v2.24.2
=======
- Now uses HTTPS for update checking.
- Added an "Upload through ShareX" button to the converter dialog if that's installed.
  - *Caveat*: The only way I could find if you have ShareX installed is to look if you've got the "Upload with ShareX" context menu thing. If you don't have that feature enabled, you won't see the converter button even if you've got ShareX installed.
- v2.24.0 was released and then taken down as it had an issue with TLS 1.2. .1 is the hotfix which addresses that issue.
- .2 is a hotfix that fixes the resize filter.

v2.23.0
=======
- Added progress bars!
 - Downloading and Converting dialogs now have a progress bar in the window.
 - Additionaly, the taskbar icon will show progress during Indexing, Downloading and Converting.
- You can now drag and drop subtitles and stuff onto the program with a video loaded to instantly add them as a filter!
 - Dropping a .srt or .ass file will add a Subtitle filter
 - Dropping a .png, .jpeg or .jpg file will add an Overlay filter
 - Dropping a .wav, .mp3 or .ogg file will add a Dub filter
- Added drag and drop support to Subtitle filter dialog.
- Downloading and Converting dialogs will now scroll the output even if they don't have focus.
- Updater will now warn if downloaded certificate does not match current one.
- Fixed Subtitle and Overlay filters breaking with non-english filenames.
- The program will no longer disappear from alt-tabbing during a conversion.

v2.22.0
=======
- Will now automatically download and load videos if your input is a link.
 - Uses Youtube-DL for downloading magic. If you do not already have it installed, you will be required to do so.
- Double-fixed cutoff detection.
- Fixed an issue with cutoff detection where a broken input file would cause an application crash.

v2.21.1
=======
- Fixed cutoff detection.
- Will now detect and convert Hi444p video if you wanna hardsub something, cause xy-VSFilter doesn't support it.

v2.21.0
=======
- Update FFMS2 to 2.23
 - FRAPS videos work again!
 - GIFs work again!
 - Hi444p videos work!
- Double-fix default values of CTF and Tolerance.
- You now get a warning if your file was cut off during encoding, due to too harsh constraints.
- You can now use your arrow keys for greater precision when editing Caption, Overlay and Crop filters.
 - Hold Shift to go faster and Alt to resize (Crop only)
- You can now right click filters in the list view for a context menu.

v2.20.3
=======
- Improve automatic bitrate generation. It *should* be good now.
- Fix default values of CRF and Tolerance.
- Fixed a crash if you tried to Play Result after you moved the output file.
- Fixed an issue where some encoding settings wouldn't update the ffmpeg arguments properly if you pressed Enter to encode.

v2.20.2
=======
- Fixed Dub filter (broken since 2.20.1).

v2.20.1
=======
- Updated FFMS# to 3.0.1.
- Tweaked ffmpeg arguments. Filesize targeting may be better now.
- You can now type the name of an input file and press Enter to load it without browsing.

v2.20.0
=======
- Added a **Rotate** filter.
- Updated FFMS2 to 2.22.
 - This should fix some issues such as audio possibly going out-of-sync on ShadowPlay files and some videos repeating their first 10 frames or so.
- Fixed a bug where the Change Rate filter would sneakily stay around if you loaded a new input file.
- Fixed a bug where SAR compensation settings would not be reset if you loaded a new input file.
- Added a workaround for files with corrupted audio.
 - *You will not be able to make audio webms out of these, but you can use the video.*
- Improved(?) automatic bitrate generation

v2.19.1
=======
- Fixed a bug where update checker would say "Up to date!" if Updater.exe was removed.
- Fixed a bug where Updater.exe would crash if downloaded executable was untrusted.
- Fixed a bug where 2-pass log files would be left behind in your %temp% folder after encoding.
- Fixed a bug where updating would fail if %temp% was on a different drive than the program.
- Updated ffmpeg to git-1bbb5ea (2015-08-13)
 - Fixes issue introduced in 2.19.0 where Previewing filters would be laggy

v2.19.0
=======
- Improved updater usability and security.
- Improved icon. (Thanks, unknown-- on GitHub)
- Updated FFMS to 2.21
 - You can now load videos with more than 32 tracks/attachments.
 - Animated gifs will now preview correctly in filter forms.
- Updated ffmpeg to git-5750d6c (2015-08-03)
 - Is now Large Address Aware

v2.18.0
=======
- Added **Change Rate** filter.
 - Lets you speed up or slow down your video.
- Reduced automatic bitrate target, which should make it easier to fit your entire video in the size you specified.
- Disabled annoying popups informing you that your picture does not, in fact, have an audio track.
- Fix possible crash when converting.

v2.17.1
=======
- Fixed non-ASS text subtitles not being extracted properly.
  - Regression introduced in 2.17.0.
- Improved handling of temporary files (will now leave slightly less shit in your %temp%)

v2.17.0
=======
- DVD subtitles can now be extracted from mkv files.
- Improved file size limit field.
  - Now represented in MiB rather than MB.
  - Certain file size limits will no longer freak out ffmpeg.
- Fix audio being locked enabled in certain scenarios.

v2.16.9
=======
- Fixed update dialog doing nothing when you press **Yes**.

v2.16.8
=======
- Fixed an issue with the audio default setting.

v2.16.7
=======
- Fixed distribution of 2.16.6 (Wrong dll shipped)

v2.16.6
=======
- If your FFMS2.dll is a CPlugin, it will still load.
- You can now remember your Audio enabled setting.

v2.16.5
=======
- Default settings will now be loaded whenever you load a new input file.

v2.16.4
=======
- Transparency is now removed from videos by default.
  - If you want transparent video, remove `-pix_fmt yuv420p` from the list of arguments in the Advanced tab.
- Preview window will now be muted if you have audio disabled.
- Fixed Loop video mode in DubFilter.

v2.16.3
=======
- Added another mode to DubFilter; you can now Dub static images without having a huge output file.
- Fixed a bug where your output file would have audio even though you hadn't enabled it.

v2.16.2
=======
- DubFilter will now loop video if you're not trimming the audio.

v2.16.1
=======
- Various Dub filter fixes.
   - You can now choose to not trim audio past the end of the video.

v2.16.0
=======
- **Added Dub filter.**
- **Improved Subtitle filter rendering** (now uses VSFilter to render subtitles)
- Improved Opus quality scaling warnings.
- Fix crashes with Overlay and Caption filters.

v2.15.0
=======
- Will now remember the last folder you used for input and output separately
- Less noise in the converter output (ffmpeg banner now hidden)

v2.14.0
=======
- Fix the crash when you try to edit a crop.
- Audio quality scaling is now disabled when using Opus audio.
- You can now view details on indexing progress, in case you were wondering what the hold up was.
- Attachments are now extracted in a smarter way.

v2.13.0
=======
- Will now report AviSynth scripting errors when previewing or converting.

v2.12.3
=======
- Fix FRAPS video color levels.
- Fix SAR compensation for some aspect ratios.

v2.12.2
=======
- Fixed an issue when running the program from a path containing weird characters.
- Fixed constant mode encoding still looking ugly in the first second or so in HQ mode.

v2.12.1
=======
- Fixed a crash issue with the PreviewFrame in the Trim, Caption and Overlay dialogs.

v2.12.0
=======
- Title metadata of your input file will now be used instead of using the filename, if it's set.
- DVD subtitles (VobSub, .idx/.sub) can now be hardsubbed onto your WebM.
- The indexing progress bar will no longer start at 30% and then skip back to 0%.
- The Trim timing buttons now work as intended in the Caption and Overlay filters.
- Your Trim filters will now update right after you edit them in the Multiple Trim filter list.

v2.11.1
=======
- There is now a proper loading screen when you load an .avs file.
- You will now be prevented from changing the input file while the program is running.

v2.11.0
=======
- You can now use AviSynth scripts as an input file again. (#75)
- You can now export your processing settings as an AviSynth script file for reference, or later use.

v2.10.1
=======
- You will now be warned if you enter an invalid audio bitrate instead of getting scary ffmpeg error messages.
- The Go To->Time... dialog no longer breaks if you press Delete.
- The video CRF box now has the correct minimum value.

v2.10.0
=======
- Added a Frame rate field to the Advanced tab.
- Fixed a crash when FFmpeg proxying fails.
- Fixed Constant mode encoding with Audio enabled.

v2.9.0
======
- Go To->Time dialog now seeks accurately in files with variable framerate
- You can now set an encoding mode as default, saving your preference for later use
- Improved Constant mode encoding; The start of the video will no longer have a comparatively low bitrate

v2.8.0
======
- Fix subtitle extraction for users with spaces in their names.
- Skip extracting subtitles that have been extracted previously.
- FFmpeg arguments will now properly update if you change the video duration with a Trim filter.
- Minor backend improvements.
- **There are now 2 encoding modes: Constant and Variable.**
 - Constant targets a specific filesize despite what the video may look like in the end.
 - Variable lets the encoder decide how many bits to use per frame, and uses CRF to determine output quality.

v2.7.6
======
- Added workaround for UTF-8 filenames (åäö, おはよう)

v2.7.5
======
- Encoding an input file with more than 2 audio channels no longer causes encoding to fail.
- Update FFMS2 to 2.20.

v2.7.4
======
- Update checking no longer crashes the program if it fails for any reason.
- If you select a file with an unsupported file name, you're now warned when you open it, instead of getting a nasty surprise when you press Encode.
- Updated ffmpeg to `42a92a2`.

v2.7.3
======
- Processing filter dialogs should now deal with anamorphic encodes (SAR) properly.
- Fixed a rare bug where every file claimed it didn't have any video tracks.

v2.7.2
======
- Now stores the 2-pass encoding log file in a temporary folder.
- Properly scales videos with Sample Aspect Ratio metadata.

v2.7.1
======
- Caption filter now works in advanced processing.
- Subtitle filter now shows codec name if the metadata title is not specified.
- Workaround for files with changing audio format until FFMS2 2.20.

v2.7.0
======
- Caption and Overlay filters now have icons.
- VP9/Opus encoding is now available (but don't use it unless you know what you're getting into)
- Go to... -> Time is now smarter (the input field is much improved)
- UI improvements.

v2.6.2
======
- Inputting a size limit while a video is not loaded will no longer cause a crash.
- Cancelling the file picker in the Overlay filter will no longer cause a crash.
- Fix a regression where saving a Multiple Trim would not disable the Trim button.

v2.6.1
======
- Fixed the crash bug when saving a filter.

v2.6.0
======
- Audio bitrate can now be specified, and automatic bitrate generation now takes audio bitrate into account.
- Subtitle filter now shows the title of subtitle tracks, if available.
- Subtitle form checkbox now properly toggles between Yes and No.
- DenoiseFilter (in Advanced)
- CRF field (in Advanced)

v2.5.1
======
- Manual seeking in the Trim form has been improved
 - Pressing Set Start/End no longer breaks manual seeking until you deselect the buttons
 - The first button press is no longer ignored
- Instead of crashing when no video tracks could be indexed, there is now an error message.

v2.5.0
======
- Caption filter now works even if you're cropping and/or resizing at the same time.
- Added Overlay filter.

v2.4.0
======
- **Now requires [.NET Framework 4.5][.NET 4.5]**.
- Update checking on launch.
- Subtitle filter no longer crashes the program if no internal subtitles are present in the videofile.

v2.3.0
======
- Improved two-pass encoding.
- Threaded encoding now works even on 64-bit systems.

v2.2.1
======
- Your task bar is no longer invaded by filter dialogs.
- Select Track dialog is now centered in the main form.
- Subtitles are now extracted when the video is loaded.

v2.2.0
======
- Added Multiple Trim filter.
- Added Caption filter.
- Can now handle videos with more that one video/audio track.

v2.1.0
======
- Advanced settings are now in an Advanced tab (processing and encoding settings alike)
- Automatic bitrate generation now works in advanced processing mode.
- Added `-slices n` setting, which is automatically set based on your settings.
- Indexing failing will no longer cause the program to crash.

v2.0.1
======
- You will now get a proper notification if you have not installed AviSynth.
- Improved Resize form.

v2.0.0
======
- Now requires [AviSynth][AviSynth].
- Easy-to-use dialogs for common video processing tasks (Trimming, Cropping, et.c.)
- Hardsubbing with full support for fonts and internal subtitles.
- Access to everything you can do with AviSynth just by the press of a button.
- Updated ffmpeg, which means that exported WebMs will play in Internet Explorer.
- Alive!

 [AviSynth]: http://avisynth.nl/index.php/Main_Page#Official_builds
 [.NET 4.5]: http://www.microsoft.com/en-us/download/details.aspx?id=30653