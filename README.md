# PFT2
## [Download the latest version](https://github.com/Zalexanninev15/PFT2/releases/tag/0.0.0.3)

## Description
Application for flash/dump partitions for ZTE Blade V9 Vita and ZTE Blade A7 Vita. [Commands in BAT files](https://github.com/Zalexanninev15/PFT2/blob/master/About%20all%20commands%20in%20BAT%20files%20(PFT2_Flasher).md).

## Features
* Flash and dump partitions
* Switching the device to EDL mode in two ways (emmcdl or ADB)
* Support for localization in different languages
* Material Design and black theme

## System requirements
* OS: Windows 7/8/8.1/10
* Additional: [Microsoft .NET Framework 4.5](https://www.microsoft.com/en-us/download/details.aspx?id=30653)

## Using
1. Install the drivers for your device: [MEGA](https://mega.nz/#!p9sgQYbB!kJbQnpaPH1LYC9GcP0Ffy1ypS5aDf6xyh-DA3A-8KG0)
2. Go to settings and fill in all fields for further work. Click "Apply".
3. Now choose the necessary way to put your smartphone in EDL mode: ADB | EDL
4. We begin the flash/dump partitions of the device.

## All Errors of Flasher (emmcdl)
#### Status: 21 The device is not ready: 
Most likely your smartphone has left EDL mode, enter this mode again.
#### WARNING: Flash programmer failed to load trying to continue:
Maybe this is a crash in emmcdl. If the flash/dump is on, then you should not worry, but if not, then it is worth putting your smartphone back into EDL mode.
#### Status: 2 The system cannot find the file specified:
An error may occur due to spaces in the path (folder) to something. You should also check for the availability of the file.
#### Status: 6 The handle is invalid:
Failure to work with COM port. You should again transfer the smartphone to EDL mode.
