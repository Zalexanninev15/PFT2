# PFT2
## Description
Application for flash/dump partitions for ZTE Blade V9 Vita and ZTE Blade A7 Vita.
## Features
* Flash and dump partitions
* Switching the device to EDL mode in two ways (emmcdl or ADB)
* Minimal work with the device via ADB
* Support for localization in different languages
* Material Design and black theme
## System requirements
* OS: Windows 7/8/8.1/10
* Additional: Microsoft .NET Framework 4.5
## Using EWT2 Flash Tool
1. Install the drivers for your device (usually written in the topic about the device and firmware for it). I use [these](https://mega.nz/#!p9sgQYbB!kJbQnpaPH1LYC9GcP0Ffy1ypS5aDf6xyh-DA3A-8KG0).
2. We translate our smartphone into flash mode (EDL):
* ADB: Connect the smartphone to the computer, enable debugging (on the smartphone) and press the "ADB -> EDL" button.
* DFU: Put the smartphone into DFU mode (I have to hold down 3 buttons), then click on the "DFU" button (make sure that the COM port is found in the text box with the heading "COMpn", if not, enter the port number yourself or click the "UPD" button to get the result).
3. Update the COM port number ("UPD" button) or enter it yourself.
4. In the field with the heading "Section", enter the necessary section of the device (if you do not know which sections are available, then you can click on the "Partition Information" button (requires a smartphone in EDL mode).
5. Choose actions with the section (dump or firmware), dump format (BIN or IMG). There is a function of indicating which partitions you need to dump (needed if there are many such partitions).
6. Click "Do it" and wait for the dump/flash process to complete.
## All Errors of EWT2 (emmcdl)
* Status: 21 The device is not ready:
Most likely your smartphone has left EDL mode, enter this mode again.
* WARNING: Flash programmer failed to load trying to continue:
* Status: 2 The system cannot find the file specified:
* Status: 6 The handle is invalid:
