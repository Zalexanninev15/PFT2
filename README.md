# PFT2
## [Download the latest version](https://github.com/Zalexanninev15/PFT2/releases/tag/0.0.9.0) | [All versions](https://github.com/Zalexanninev15/PFT2/releases)
## [Download source (ZIP)](https://github.com/Zalexanninev15/PFT2/archive/master.zip)

## Screenshot
[Screenshot](https://i.imgur.com/mHzH5Vp.jpg)

## Description
Application for flash/dump partitions for ZTE Blade V9 Vita and ZTE Blade A7 Vita. [Commands in BAT files](https://github.com/Zalexanninev15/PFT2/blob/master/About%20all%20commands%20in%20BAT%20files%20(PFT2_Flasher).md).

## Features
* Flash and dump partitions, Disable Google FRP
* Switching the device to EDL mode in two ways (emmcdl or ADB)
* Material Design and black theme

## System requirements
* OS: Windows 7/8/8.1/10
* Additional: [Microsoft .NET Framework 4.5](https://www.microsoft.com/en-us/download/details.aspx?id=30653)

## All Errors of Flasher (emmcdl)
#### Status: 21 The device is not ready: 
Most likely your smartphone has left EDL mode, enter this mode again.
#### WARNING: Flash programmer failed to load trying to continue:
Maybe this is a crash in emmcdl. If the flash/dump is on, then you should not worry, but if not, then it is worth putting your smartphone back into EDL mode.
#### Status: 2 The system cannot find the file specified:
An error may occur due to spaces in the path (folder) to something. You should also check for the availability of the file.
#### Status: 6 The handle is invalid:
Failure to work with COM port. You should again transfer the smartphone to EDL mode.
