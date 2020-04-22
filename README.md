# PFT2 | [Full FAQ on 4PDA (Russian to English by Translate)](https://translate.google.ru/translate?sl=ru&tl=en&u=https%3A%2F%2F4pda.ru%2Fforum%2Findex.php%3Fshowtopic%3D952274%26st%3D1160%23entry93484684)
## [Download the latest version](https://github.com/Zalexanninev15/PFT2/releases/tag/1.5) | [All versions](https://github.com/Zalexanninev15/PFT2/releases)
## [Download source (ZIP)](https://github.com/Zalexanninev15/PFT2/archive/master.zip) | [MBN file for ZTE Blade V9 Vita](https://github.com/Zalexanninev15/PFT-Linux/raw/master/tools/emmc.mbn)

## Screenshot
![](https://i.imgur.com/Nw0eiUF.jpg)

## Description
Application for flash/dump partitions for ZTE Blade V9 Vita and ZTE Blade A7 Vita. [Commands in BAT files](https://github.com/Zalexanninev15/PFT2/blob/master/About%20all%20commands%20in%20BAT%20files%20(PFT2_Flasher).md).

## Features
* Flash and dump partitions, Disable Google FRP
* Switching the device to EDL mode in two ways (emmcdl or ADB)
* Material Design and black theme

## System requirements
* OS: Windows 7/8/8.1/10
* Additional: [Microsoft .NET Framework 4.5](https://www.microsoft.com/en-us/download/details.aspx?id=30653), [emmcdl](https://mega.nz/#!Q5kmSI7K!1coqsqWf0SIG6ejFoftd1WU8oyBA3Z0y-oTmnRbQW60), [ADB](https://mega.nz/#!lptQyI5R!HxOVPUO2mYPmI5vWI00c5SRe5883-1H8_ZNiTKnH4J0), [ZTE + Qualcomm USB Drivers](https://cloud.mail.ru/public/CSQ9/4y878mma8) and MBN file

## All Errors of Flasher (emmcdl)
#### Status: 21 The device is not ready: 
Most likely your smartphone has left EDL mode, enter this mode again.
#### WARNING: Flash programmer failed to load trying to continue:
Maybe this is a crash in emmcdl. If the flash/dump is on, then you should not worry, but if not, then it is worth putting your smartphone back into EDL mode.
#### Status: 2 The system cannot find the file specified:
An error may occur due to spaces in the path (folder) to something. You should also check for the availability of the file.
#### Status: 6 The handle is invalid:
Failure to work with COM port. You should again transfer the smartphone to EDL mode.
