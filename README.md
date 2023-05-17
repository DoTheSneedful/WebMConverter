WebM for Lazys 
=============
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/ab09accc7a9c478badac99fed7ca52cf)](https://www.codacy.com/gh/argorar/WebMConverter/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=argorar/WebMConverter&amp;utm_campaign=Badge_Grade)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Downloads](https://img.shields.io/github/downloads/argorar/WebMConverter/total.svg)]()
[![CodeLines](https://tokei.rs/b1/github/argorar/WebMConverter)]()

If you want to support this project.

<a href='https://ko-fi.com/argorar' target='_blank'><img height='35' style='border:0px;height:46px;' src='https://az743702.vo.msecnd.net/cdn/kofi3.png?v=0' border='0' alt='Buy Me a Coffee at ko-fi.com' /></a> 

A wrapper around ffmpeg and AviSynth made for converting videos to WebM without having to use the command line, fork of [this project](https://gitgud.io/nixx/WebMConverter#webm-for-retards-).

- **Download it [here][LatestDownload].**

_Important to know:_
* Requires .NET Framework 4.8
* Requires [AviSynth][AviSynth] (2.6.0, 32-bit)
* Already includes ffmpeg
* Only works on Windows 

## About WebM

WebM is an open, royalty-free, media file format designed for the web.
WebM defines the file container structure, video and audio formats. WebM files consist of video streams compressed with the VP8 or VP9 video codecs and audio streams compressed with the Vorbis or Opus audio codecs. The WebM file structure is based on the Matroska container.

For more information about WebM, see the [FAQ][FAQ].

## Benefits of WebM

* _Openness and innovation_. A key factor in the web's success is that its core technologies such as HTML, HTTP, and TCP/IP are open for anyone to implement and improve.  With video being core to the web experience, a high-quality, open video format choice is needed. WebM is 100% free, and open-sourced under a BSD-style license.

* _Optimized for the web_. Serving video on the web is different from traditional broadcast and offline mediums. Existing video formats were designed to serve the needs of these mediums and do it very well. WebM is focused on addressing the unique needs of serving video on the web.

    * Low computational footprint to enable playback on any device, including low-power netbooks, handhelds, tablets, etc

    * Simple container format

    * Highest quality real-time video delivery

    * Click and encode. Minimal codec profiles and sub-options. When possible, let the encoder make the tough choices.

# WebM for Lazys features

## Updates

Get the last update with just one click.

![update](img/update.JPG)

## What can i do?

You can get and edit your video easly with the next options.

### Download

Paste the url of the video you want and press enter, the download will start. You will get the best quality.
* Support for [+1000 sites][Sites]
* You can choose the default path for all your new videos
* Load the new video in the app with just one click

![download](img/download.JPG)

Disable option in *general* tab to select manually the format do you want.

![format](img/format.png)
### Trim

Trim precisely the length, with a simple interface. You can do multiple trims if you need.
**Go to..** the exact frame or time you want to start the trim, also save the current frame to source path. 

![trim](img/trim.JPG)

### Crop

Crop what is just important for you, you can see in real time the new resolution also you can set the exact size that you want or set an aspect ratio like 16:9, 9:16 and more under *Set dimensions*. 
Just move the edges with the mouse or use the keyboard.
* ```Row keys``` to move
* ```Shift + Row keys``` to move faster
* ```Alt + Row Keys``` to increase/decrease the size 
* ```Ctrl + Row Keys``` to resize keeping aspect ratio
* You can use mouse wheel over time line to change of frame

![crop](img/crop.JPG)

### Dynamic Crop

Follow an object on the canvas easly. Steps for a correct workflow:
    
1. Use trim to define the clip lenght

2. Open Crop filter and define the crop size, use ```New resolution``` as guide. **Even numbers are required**. You can use ```Set dimensions``` for exact values
    ![new resolution](img/newResolution.png)
    ![set dimensions](img/setDimensions.png)
3. Select click ```Dynamic Crop```. When it is actived will be green which means that each movement will be registered
    ![dynamicCrop](img/dynamicCrop.png)
4. Set stabilitation level on ```Advanced>Processing``` to get a smooth effect

#### Tutorial

For this example the edition requires 30 seconds. 
<video style="width:100%" controls src="https://giant.gfycat.com/AridComplexKawala.mp4" type="video/mp4" autoplay loop></video>

[External link](https://gfycat.com/AridComplexKawala)

#### Final result

Right side was processed  with dynamic crop.
<video style="width:100%" controls src="https://giant.gfycat.com/WeeklyEmptyDalmatian.mp4" type="video/mp4" autoplay loop></video>

[External link](https://gfycat.com/WeeklyEmptyDalmatian)

### Grid

Make grid videos to compare or shared different views. You can choose between horizontal or vertical. It requires that both videos share codecs, dimensions, length. Output file is in same path as video #1. Above you can find an example.

![grid](img/grid.png)

### Filter

If your video looks dark, you can try with some pre-set filters. Now you can create your own filter using *Advanced* option, change gamma, contrast and saturation.

![filter](img/light.JPG)

### Caption

Add text, change font, size, position, also set when it start and end.

![caption](img/caption.JPG)

### Rotate
Rotate your video to any direction with just one click.

![rotate](img/rotate.JPG)

### Loop

Loop function, forward and reverse making an infinite effect. You _can't_ use filter or interpolation with it.
<video style="width:100%" controls src="https://giant.gfycat.com/AnimatedUnimportantAlligatorsnappingturtle.mp4" type="video/mp4" autoplay loop></video>

[External link](https://gfycat.com/AnimatedUnimportantAlligatorsnappingturtle)

### Stabilization

Use different levels of stabilization for your clip. Left side original, right side processed. Find it in Advanced>Processing.

<video style="width:100%" controls src="https://giant.gfycat.com/DentalAnchoredHedgehog.mp4" type="video/mp4" autoplay loop></video>

[External link](https://gfycat.com/DentalAnchoredHedgehog)

### Merge and Convert
Drag and drop two or more video files inside the application, select what do you want to do. Search for the result in source path. 
* For merge: *The group of videos must have the same encodes / dimensions*.
* For convert: *The current settings will be apply to all video files*

![options](img/options.png)

### There is More that you can do

* Export frames
* Add subtitle
* Resize 
* Reverse
* Overlay your logo
* Change the speed
* Fade
* Disable audio
* Delay audio
* Get specific filesize in final result
* Get high quality video in webm and mp4 format
* Interpolate, more frames to your video
* Deinterlace

### Upload to Gfycat

Upload your new masterpiece with just one click. *A Gfycat account is required.*
See user details in tab *General*. If you are creating several gfys of the same topic, tags can be usefull for you.

### Shortcut keys

* Trim: ```Alt + t```
* MultiTrim: ```Alt + Shift + t```
* Crop: ```Alt + c```
* Change Rate: ```Alt + Shift + c```

### Supporters
* bouteloua
* ManletPride
* 3nly

## Changelog

#### Version 3.25.1
* Fix incorrectly cropped subtitles, to [see more](https://github.com/argorar/WebMConverter/pull/43)

#### Version 3.25.0
* Add option to disable set metadata automatically
* Upgrade .Net framework to 4.8

#### Version 3.24.0
* Add convert files in batch. Check for [more](#merge-and-convert). See related [request](https://github.com/argorar/WebMConverter/issues/34)

#### Version 3.23.4
* Add 4:3 aspect ratio
* Add 21:9 aspect ratio

#### Version 3.23.3
* Add 1:1 aspect ratio
* Improved edit *Crop* size with keyboard. keep aspect ratio with ```Ctrl + arrowKey```

#### Version 3.23.2
* Fix *Crop* top negative values. See related [issue](https://github.com/argorar/WebMConverter/issues/36)

#### Version 3.23.1
* Fix *Rotate* filter preview

#### Version 3.23.0
* Add Aspect Ratio format in set dimensions. Initially 16:9 and 9:16 format
* Fix centering frame in *Trim*, *Crop* & *Caption*
* Cleaning code
* Improved memory management to prevent crash visualizing frames. See related [issue](https://github.com/argorar/WebMConverter/issues/33)
* A special gretting for the [supporters](#supporters) of this project

#### Version 3.22.0
* Cache system implemented. Now move smoother in *Trim* & *Crop* filters
* Add original Frame Per Second in *Change Rate* filter
* Fix crop interface
* Fix pixels added to editing crop as in final result. See related [issue](https://github.com/argorar/WebMConverter/issues/27)
* Fix grid tab

#### Version 3.21.0
* Add option to disable extract subtitles. Big videos will load faster. See related [issue](https://github.com/argorar/WebMConverter/issues/32)
* Fix icons
* Add option to disable check for updates
* Fix error handling in request to check new version

#### Version 3.20.0
* Add feature to download specific format from youtube. Check *general* tab
* Fix constant arguments for mp4
* Fix update arguments to advanced filter
* Add option to disable pop in front when convert process is finished. Check *general* tab. See related [issue](https://github.com/argorar/WebMConverter/issues/25)
* Enable option to play and upload result of merge and grid after finish the process
* Fix false error in merge
* Fix a minor bug with interface

To see more [changelog](CHANGELOG.md).

## License
This software is released under the MIT license.


## Issues
If you have any issues with this program, you may report them on [here][NewIssue]. Add the respective video to test.

 [LatestDownload]: https://github.com/argorar/WebMConverter/releases/latest
 [DotNet45]: https://www.microsoft.com/en-us/download/details.aspx?id=30653
 [AviSynth]: http://avisynth.nl/index.php/Main_Page#Official_builds
 [NewIssue]: https://github.com/argorar/WebMConverter/issues
 [Sites]: https://ytdl-org.github.io/youtube-dl/supportedsites.html
 [FAQ]: https://www.webmproject.org/about/faq/