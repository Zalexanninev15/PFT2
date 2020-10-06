# PFT2 | [Official Telegram Channel (RU)](https://t.me/PFT2_Channel)
## [Download the latest version](https://github.com/Zalexanninev15/PFT2/releases/tag/1.20.3.5) | [All versions](https://github.com/Zalexanninev15/PFT2/releases) | [Download source (ZIP)](https://github.com/Zalexanninev15/PFT2/archive/master.zip)

## Screenshot
![](https://github.com/Zalexanninev15/PFT2/blob/master/pft2_screenshot.png?raw=true)

## Supported 💰 this project

* [SnowCloudyPie](https://4pda.ru/forum/index.php?showuser=1506787)
* kilovar337
* [MuchelTy6](https://forum.xda-developers.com/member.php?u=11046943)

## Description

Partitions Flashing Tool 2 - application for flash and dump partitions, disable Google FRP and remote by ADB for ZTE Blade V9 Vita, ZTE Blade A7 Vita and other smartphones on Qualcomm chipset (like as emmcdl tool) | [PFT2_Flasher](https://github.com/Zalexanninev15/PFT2/blob/master/Flasher%20commands.md)

## Features

* Fast firmware and backup of partitions (one partition or all (except "userdata")), disabling Google FRP protection
* Switch your smartphone to EDL mode using 2 options: emmcdl (DFU) or ADB
* Work with your smartphone using minimal ADB functionality (installing and deleting apps, restarting and viewing the current status of the device)
* A "Firmwares Manager" is also available for ZTE Blade V9 Vita, which contains information about stock firmware (all versions) and [LineageOS 15.1](https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=86029984)
* Support for other smartphones (which are also flashed using emmcdl), thanks to the ability to change the EDL code. You can also change the application code and scripts that are used to interact with emmcdl
* Material design and Dark mode
* Automatically check for updates for new versions
* Support for the Russian language using a separate Russifier

## System requirements
* **OS:** Windows 7 (SP1)/8/8.1/10
* **Additional:** Microsoft .NET Framework 4.8, [emmcdl](https://github.com/Zalexanninev15/PFT2/releases/download/1.20.3/emmcdl.exe), [ADB](https://github.com/Zalexanninev15/PFT2/releases/download/1.20.3/ADB.zip), [ZTE + Qualcomm USB Drivers + ADB Drivers](https://mega.nz/file/MhdGwYKb#00MsgumREKAUc20Ot_wy4FlnAOi0nNqW2ZNUpDnVqSI) (or others for your device) and [MBN file [only for ZTE Blade V9 Vita]](https://github.com/Zalexanninev15/PFT-Linux/raw/master/tools/emmc.mbn) (or other for your device), original USB cabel (I don't recommend using magnetic cables)

## How to use it?

For Russian speakers: [FAQ on 4PDA](https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=93484684), [Video on YouTube](https://youtu.be/NCe7R45jYhM)

**I recommend reading this information in [Typora](https://typora.io/) or any other MARKDOWN editor or viewer.**

### Preparing to configure the app:

1. Download the necessary files: [emmcdl](https://github.com/Zalexanninev15/PFT2/releases/download/1.20.3/emmcdl.exe), [ADB](https://github.com/Zalexanninev15/PFT2/releases/download/1.20.3/ADB.zip), [MBN file [only for ZTE Blade V9 Vita]](https://github.com/Zalexanninev15/PFT-Linux/raw/master/tools/emmc.mbn) (or other for your device) and [ZTE + Qualcomm USB Drivers + ADB Drivers](https://mega.nz/file/MhdGwYKb#00MsgumREKAUc20Ot_wy4FlnAOi0nNqW2ZNUpDnVqSI) (or others for your device)
2. Extract all archives in any places (the main thing is that there are no spaces in the path), it is best to create a folder next to PFT2 (again, without spaces) and throw everything there
3. Install the drivers

### Setting up the app for you:

1. Launch `PFT2.exe` and configure the app ("Settings")
2. Now specify the necessary files, folders, and other settings and click "APPLY". To reset all settings, click "RESET"

*You can open advanced settings by entering "more" (without quotes) in the text field for EDL code.*

![](https://i.imgur.com/ukvCzIF.png)

### Flash & Dump:

### **!!!There should be no "spaces" in the path to PFT2, FDFmini, the file for flash and other files, otherwise all sorts of errors will occur!!!**

1. Switching the device to firmware mode (EDL) from:

   **a) DFU (this manual is provided only for ZTE Blade V9 Vita and ZTE Blade A7 Vita)**

   1. Connect the smartphone in DFU mode (connect the cable to the PC and hold all 3 buttons, the red light will light up). 

      ***Here's how it should be (original photo by [Ambernic](http://t.me/Ampernic_offical)):***

      <img src="https://i.imgur.com/mDxNwWF.png" style="zoom: 60%;" />

   2. The COM port should appear in the Device Manager

      <img src="https://cs5-1.4pda.to/19426622.png" style="zoom:100%;" />

      *If there was, but not the one (I mean in a different way called, the number after COM can be any), which is on the screenshot, then put the driver that was previously unpacked*

   3. Click "UPD" in the app or enter the COM port number yourself from the Device Manager

      *It looks like this: COMX, where X is the number*

   4. Click "DFU", your smartphone will reconnect. We check the com port number, **it must change**

      What it looks like

      ![](https://cs5-1.4pda.to/19426769.png)

      *If it hasn't changed, try reinstalling the drivers/messing with Windows/changing the USB wire*

   5. Repeat **step 2**
      

    **b) ADB**

   1. Connecting an **enabled smartphone** with a **loaded Android** to a PC

   2. Click on the "ADB" button, if for the first time, we allow debugging on the phone, waiting for"hanging" PFT2. You may need to "kill" the ADB process and click the button again

   3. The COM port should appear in the Device Manager

      ![](https://cs5-1.4pda.to/19426622.png)

      *If there was, but not the one (I mean in a different way called, the number after COM can be any), which is on the screenshot, then put the driver that was previously unpacked*

   4.  Click "UPD" in the app or enter the COM port number yourself from the Device Manager

      *It looks like this: COMX, where X is the number*
      

2. In the end, it should turn out to the right "**YES YES**", so you have done everything😊

3. Select the action you need from "Actions"

4. Fill in the necessary fields in "Dump and Flash"

   *To wipe "userdata" (or other partitions), you can flash the file "Wipe_userdata.pdf" (located in the folder with the application) in the "userdata" partition (or other partition)*

5. Click button (before "Do IT!") and wait for the end of the process

   **P.S.** In some cases, especially when after creating a dump you take to firmware, errors may pop up in the command line. If everything ends with success, reading/writing sectors will reach 0 and there will be no errors at the end - then with a 99.7% probability you will have everything*👌
   *If you still want to be safe (or you have a mistake), then **you should**:*
   *1) Check the firmware files (they may be damaged/do not fit your device)*
   *2) Disconnect the phone from the PC and reconnect it, then re-enter into EDL mode and perform the desired action*

### If your smartphone has become a brick:

1. **Dismantle the device ([original](https://4pda.ru/forum/index.php?act=findpost&pid=94081175&anchor=Spoil-94081175-2)):**

   1. Remove the SIM card and microSD tray

   2. We warm up the phone, and carefully open the cover
      Start from the bottom, then slowly click off the latches starting from the left side, because on the right-the trail of the fingerprint scanner

   3. **CAREFULLY** remove the cover (**very carefully, otherwise you will be left without a fingerprint scanner!!!**)

   4. We peel off the black film, and these 2 contacts should appear to our eyes. These are **EDL test points**

      <img src="https://cs5-1.4pda.to/18887438.png" style="zoom:80%;" />

   5. Close the data 2 contacts with tweezers and connect the smartphone to the PC

   6. Go to the instructions for switching to EDL mode using the DFU. Performing **step 1** (but do not pinch the buttons, just look at the COM port in the Device Manager). If you are doing this for the first time, first install the drivers

   7. Repeat **step 2** (DFU)

   8. Skip everything else and quickly, but very carefully, start to restore the smartphone firmware (flash partitions, **step 3**) of all partitions | Download firmwares (versions 9, 11, 12) for ZTE Blade V9 Vita: [**2/16**](https://4pda.ru/forum/index.php?showtopic=952274&view=findpost&p=92021946) or [**3/32**](https://4pda.ru/forum/index.php?showtopic=952274&view=findpost&p=92437481)

### What is the FDF format, which is used for flash and create dumps?

FDF (Firmware Data File) is a file format for firmware that was created to replace firmware file formats (dump, bin, img), since it is the best for storing dumps. In fact, it is a special archive for dumps (more precisely the usual GZip archive (gz)), which allows you to upload dumps to the hosting/cloud without data loss, without compression to the archive. To work with this format, you need more space than for a normal IMG / BIN dump (the dump is converted to a temporary format for firmware in the device), but the FDF file will be better stored. PFT2 support this format since version **[1.3](https://github.com/Zalexanninev15/PFT2/releases/tag/1.3)**

For example: `system.img`  → `system.fdf`, 3.5 GB → 1.4 GB. Temporary file(s) are deleted after work.

The utility for working with this format and converting IMG/BIN files to it is located in the folder with the PTT2 application called FDFmini (created by Zalexanninev15 and Alexander927). The utility does not support "spaces" in the path and in the names of the files themselves, and also does not know how to create new folders.
For normal operation, the "userdata" partition uses regular IMG, because there may be problems with converting too large files.

#### GUI:

You can use the official GUI. To do this, activate it in the advanced settings *(you can open advanced settings by entering "more" (without quotes) in the text field for EDL code)*. Next, in the same field, enter "con" (without quotes) and use :)

![](https://i.imgur.com/4f0ZXPb.png)

#### CMD:

**To convert IMG to FDF use the command:**

```
FDFmini -img [Path to IMG/BIN file] [Path to new FDF file] -c
```

*Example:* 

```
FDFmini -img boot.img boot.fdf -c
```

*If you have more than 2 IMG files to convert to FDF, and you don't want to waste time typing commands, then extract the contents of [this](https://github.com/Zalexanninev15/PFT2/releases/download/1.20.3/IMG_to_FDF.zip) archive to the folder with dumps. Run the batch file and wait...*

**To convert FDF to IMG use the command:**

```
FDFmini -fdf [Path to FDF file] [Path to new IMG/BIN file] -u
```

*Example:*

```
FDFmini -fdf D:\PFT2_DATA\system.fdf D:\PFT2_DATA\img\system.img -u
```

#### Other way (tests):

You can also "unarchive" a FDF file with firmware using an archiver that supports the GZip format. After the process is complete, you will only need to add the ".img" extension to the file.

To create an FDF file, I still recommend using FDFmini, so that there are no problems, but you can try to create an archive in a normal GZip archiver, the main thing is to first remove the extension from the current dump file, so that there are no problems during firmware.

### Where do I get the firmware from? Getting root and TWRP 

### (this is only for ZTE Blade V9 Vita)

* [Official firmware dumps for revision 3/32 and 2/16](https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92437481)
* [Unofficial, verified](https://4pda.ru/forum/index.php?act=findpost&pid=85228170&anchor=Spoil-85228170-3)
* [Unofficial, many unverified and not working](https://4pda.ru/forum/index.php?showtopic=892755) (**only type ARM64-A**)

#### **About ROOT and TWRP:**

- root - incomplete due to a blocked bootloader (no access to system and vendor) | [Post on XDA](https://forum.xda-developers.com/showpost.php?p=83652475&postcount=7)
  1. Download patched boot and Magisk Manager: https://mega.nz/file/B5MxQSJY#mAbsKzcTr28nPVMyHQqJjepjmai3fA9Mj2tLQ5jT9pM
  2. Extract ZIP archive, flash "bootmagisk160.fdf" to "boot" partition
  3. Through device recovery mode, erase all data
  3. Install the file "magisk591.apk" on Android and check for root rights
  
- TWRP - test build with very limited features (you need to unlock the loader to get more functionality in TWRP)
  1. Download TWRP recovery: https://mega.nz/file/Y0UTxSDA#Sb6ZzVRepeISKR3a7P5cYMJysE8mmkt_U1PVYQ5VJQE
  2. Extract ZIP archive and flash FDF file in "recovery" partition
  

 *Notes:*
 *After flashing FDF files (ROOT and/or TWRP), you will need to erase all your data (userdata) from your phone, otherwise you will get a bootloop or they will just !!!encrypt without the possibility of decryption!!! (dump "userdata").*

 **Also, for users of stock firmware version 12 (v12), we make the flash of all partitions (except system and userdata) from the dumps of stock firmware version 11 (v11) (links for each revision of the smartphone above), otherwise grab the bootloop (!!!even if you erase all the data!!!)**

#### Modifying image of the "system" partition

* ***Unpacking an image***

You can unpack the image using the FDFmini utility (starting from **version 1.4**). This utility will use another utility called "ImgExtractor" (by And_PDA).

**For FDF file:**

```
FDFmini -fdf [Path to FDF file] [Full path to the new folder] -system
```

*Example:* 

```
FDFmini -fdf system.fdf D:\PFT2_DATA\UnSystemFDF -system
```

**For IMG file:**

```
FDFmini -img [Path to IMG/BIN file] [Full path to the new folder] -system
```

*Example:* 

```
FDFmini -img system.img D:\PFT2_DATA\UnSystemIMG -system
```

## All Errors of Flasher (emmcdl)

**Status: 21 The device is not ready**
Most likely your smartphone has left EDL mode, enter this mode again.

**WARNING: Flash programmer failed to load trying to continue**
Maybe this is a crash in emmcdl. If the flash/dump is on, then you should not worry, but if not, then it is worth putting your smartphone back into EDL mode.

**Status: 2 The system cannot find the file specified**
An error may occur due to spaces in the path (folder) to something. You should also check for the availability of the file.

**Status: 6 The handle is invalid**
Failure to work with COM port. You should again transfer the smartphone to EDL mode.

*In short, there is a 97% chance that you can fix any problem by re-switching your smartphone to the EDL firmware mode. Another 3% - problems with drivers (for the COM port), "corrupted" dumps for firmware, brick, gaps in the path, missing files. Also, don't forget that PFT2 doesn't support "spaces" in file paths (or names with them).*

### FDFmini

If the utility refuses to work, check the file paths and file names for "spaces". You can also try deleting the file "System.IO.Compression.dll", which is located next to "FDFmini.exe".

## Used libraries and other

* [MaterialSkin](https://github.com/IgnaceMaes/MaterialSkin) ([MIT License](https://github.com/IgnaceMaes/MaterialSkin/blob/master/LICENSE), by [Ignace Maes](https://github.com/IgnaceMaes))
* Shadow Fix ([code](https://jailbreakvideo.ru/shadow-and-mouse-move-for-borderless-windows-forms-application) by [XpucT](https://www.youtube.com/channel/UC2CiWFIOjQix4E6WrARzDZg))
* System.IO.Compression ([MS-.NET-Library License](https://go.microsoft.com/fwlink/?LinkId=329770))
* ImgExtractor (by And_PDA)

## Build

Compile using Visual Studio 2017-2019
