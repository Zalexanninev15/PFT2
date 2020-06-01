# PFT2 | [Official Telegram Channel (RU)](https://t.me/PFT2_Channel)
## [Download the latest version](https://github.com/Zalexanninev15/PFT2/releases/tag/1.14) | [All versions](https://github.com/Zalexanninev15/PFT2/releases)
## [Download source (ZIP)](https://github.com/Zalexanninev15/PFT2/archive/master.zip) | [MBN file for ZTE Blade V9 Vita](https://github.com/Zalexanninev15/PFT-Linux/raw/master/tools/emmc.mbn)

## Screenshot
<img src="https://i.imgur.com/D086BF2.jpg" style="zoom:16;" />

## Description
Application for flash and dump partitions, disable Google FRP and remote by ADB for ZTE Blade V9 Vita, ZTE Blade A7 Vita and other smartphone on Qualcomm chipset (like as emmcdl tool) | [Commands in BAT files](https://github.com/Zalexanninev15/PFT2/blob/master/About%20all%20commands%20in%20BAT%20files%20(PFT2_Flasher).md).

## Features
* Flash and Dump partitions (1 partition or all partitions (Full Dump), Disable Google FRP
* Switching the device to EDL mode in two ways (emmcdl or ADB)
* Material Design and Dark mode
* Working with a smartphone using the ADB functionality (installing and deleting apps, rebooting)
* Support for other smartphones (like emmcdl), thanks to the ability to change the EDL code

## System requirements
* **OS:** Windows 7/8/8.1/10
* **Additional:** [Microsoft .NET Framework 4.5](https://www.microsoft.com/en-us/download/details.aspx?id=30653), [emmcdl](https://mega.nz/#!Q5kmSI7K!1coqsqWf0SIG6ejFoftd1WU8oyBA3Z0y-oTmnRbQW60), [ADB](https://mega.nz/file/dwdWgYZY#J2LV6nNwIj3jnIsPgCpD2dBAKkkRTk45PXfGnJU6nQY), [ZTE + Qualcomm USB Drivers](https://cloud.mail.ru/public/CSQ9/4y878mma8) (or others for your device) and MBN file

## How to use it? (or [FAQ on 4PDA](https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=93484684))

### Preparing to configure the app:

1. Download the necessary files: [emmcdl](https://mega.nz/#!Q5kmSI7K!1coqsqWf0SIG6ejFoftd1WU8oyBA3Z0y-oTmnRbQW60), [ADB](https://mega.nz/file/dwdWgYZY#J2LV6nNwIj3jnIsPgCpD2dBAKkkRTk45PXfGnJU6nQY), MBN file and [ZTE + Qualcomm USB Drivers](https://cloud.mail.ru/public/CSQ9/4y878mma8) (or others for your device)
2. Extract all archives in any places (the main thing is that there are no spaces in the path), it is best to create a folder next to PFT2 (again, without spaces) and throw everything there
3. Install the drivers

### Setting up the app for you:

1. Launch `PFT2.exe` and immediately configure the app (point "Settings")
2. Now specify the necessary files, folders, and other settings and click "APPLY". To reset all settings, click "RESET"

*You can open advanced settings by entering "more" (without quotes) in the text field for EDL code.*

![](https://i.imgur.com/ZKH2asb.jpg)

### Flash & Dump:

1. Switching the device to firmware mode (EDL) from:

   **a) DFU (only for ZTE Blade V9 Vita and ZTE Blade A7 Vita)**

   1. Connect the smartphone in DFU mode (connect the cable to the PC and hold all 3 buttons, the red light will light up). 

      ***Here's how it should be (original photo by [Ambernic](http://t.me/Ampernic_offical)):***

      <img src="https://i.imgur.com/2DN27kS.jpg" style="zoom: 67%;" />

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

5. Click button (before "Do IT!") and wait for the end of the process

   **P.S.** *In some cases, especially when after creating a dump you take to firmware, errors may pop up in the command line. If everything ends with success, reading/writing sectors will reach 0 and there will be no errors at the end - then with a 99.7% probability you will have everything*👌
   *If you still want to be safe (or you have a mistake), then **you should**:*
   *1) Check the firmware files (they may be damaged/do not fit your device)*
   *2) Disconnect the phone from the PC and reconnect it, then re-enter into EDL mode and perform the desired action*

### If your smartphone has become a brick:

1. **Dismantle the device ([original](https://4pda.ru/forum/index.php?act=findpost&pid=94081175&anchor=Spoil-94081175-2)):**

   1. Remove the SIM card and microSD tray

   2. We warm up the phone, and carefully poddevaem cover
      Start from the bottom, then slowly click off the latches starting from the left side, because on the right-the trail of the fingerprint scanner

   3. **CAREFULLY** remove the cover (**very carefully, otherwise you will be left without a fingerprint scanner!!!**)

   4. We peel off the black film, and these 2 contacts should appear to our eyes. These are **EDL test points**

      <img src="https://cs5-1.4pda.to/18887438.png" style="zoom:80%;" />

   5. Close the data 2 contacts with tweezers and connect the smartphone to the PC

   6. Go to the instructions for switching to EDL mode using the DFU. Performing **step 1** (but do not pinch the buttons, just look at the COM port in the Device Manager). . If you are doing this for the first time, first install the drivers

   7. Repeat **step 2** (DFU)

   8. Skip everything else and quickly, but very carefully, start to restore the smartphone firmware (flash partitions, step **3**) of all partitions | Download firmwares (versions 9, 11, 12) for ZTE Blade V9 Vita: [**2/16**](https://4pda.ru/forum/index.php?showtopic=952274&view=findpost&p=92021946) or [**3/32**](https://4pda.ru/forum/index.php?showtopic=952274&view=findpost&p=92437481)

### What is the FDF format? (which is used for firmware)

FDF (Firmware Data File) is a file format for firmware that was created to replace the DUMP (later BIN and IMG) firmware file format, since it is the best for storing images. In fact, it is a special archive for dumps, which allows you to upload dumps to the hosting/cloud without data loss, without compression to the archive. To work with this format, you need more space than for a normal IMG / BIN dump (the dump is converted to a temporary format for firmware in the device), but the FDF file will be better stored. 

For example: `system.img`  → `system.fdf`, 3.5 GB → 1.4 GB. Temporary files are deleted after work.
The utility for working with this format and converting IMG/BIN files to it is located in the folder with the PTT2 application called `FDFmini` (created by Zalexanninev15 and Alexander927).
PFT2 supports this format since version **1.3**
For normal operation, the "userdata" section uses regular IMG, because there may be problems with converting too large files (5 GB or more)

#### GUI:

You can use the official GUI. To do this, activate it in the advanced settings *(you can open advanced settings by entering "more" (without quotes) in the text field for EDL code)*. Next, in the same field, enter "gui" (without quotes) and use :)

![](https://i.imgur.com/nev4qiW.jpg)

#### CMD:

**To convert a FDF file, use the command:**

```
FDFmini -img [Path to IMG/BIN file] [Path to new FDF file] -c
```

*Example:* 

```
FDFmini -img boot.img boot.fdf -c
```

*If you have more than 2 IMG files to convert to FDF, and you don't want to waste time typing commands, then extract the contents of [this](https://github.com/Zalexanninev15/PFT2/raw/master/IMG_to_FDF.zip) archive to the folder with dumps. Run the batch file and wait...*

**To convert to an IMG file use the command:**

```
FDFmini -fdf [Path to FDF file] [Path to new IMG/BIN file] -u
```

*Example:*

```
FDFmini -fdf system.fdf system.img -u
```

### Where do I get the firmware from? Getting root and TWRP 

### (this is only for ZTE Blade V9 Vita)

* [Official firmware dumps for revision 3/32 and 2/16](https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92437481)
* [Unofficial, verified](https://4pda.ru/forum/index.php?act=findpost&pid=85228170&anchor=Spoil-85228170-3)
* [Unofficial, many unverified and not working](https://4pda.ru/forum/index.php?showtopic=892755) (**only type ARM64-A**)

- [About root and TWRP recovery](https://4pda.ru/forum/index.php?act=findpost&pid=93484684&anchor=Spoil-93484684-20)

## All Errors of Flasher (emmcdl)

**Status: 21 The device is not ready**
Most likely your smartphone has left EDL mode, enter this mode again.

**WARNING: Flash programmer failed to load trying to continue**
Maybe this is a crash in emmcdl. If the flash/dump is on, then you should not worry, but if not, then it is worth putting your smartphone back into EDL mode.

**Status: 2 The system cannot find the file specified**
An error may occur due to spaces in the path (folder) to something. You should also check for the availability of the file.

**Status: 6 The handle is invalid**
Failure to work with COM port. You should again transfer the smartphone to EDL mode.

*In short, there is a 97% chance that you can fix any problem by re-switching your smartphone to the EDL firmware mode. Another 3% - problems with drivers (for the COM port), "corrupted" dumps for firmware, brick, gaps in the path, missing files. Also, don't forget that PFT2 doesn't support spaces in file paths (or names with them).*
