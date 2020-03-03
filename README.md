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
## Using
1. Install the drivers for your device: [MEGA](https://mega.nz/#!p9sgQYbB!kJbQnpaPH1LYC9GcP0Ffy1ypS5aDf6xyh-DA3A-8KG0)
2. We translate our smartphone into flash mode (EDL):
* ADB: Connect the smartphone to the computer, enable debugging (on the smartphone) and press the "ADB" button. If you are doing this for the first time, first go to the settings and specify the path to ADB (if it is not specified, then click "Apply").
* DFU: Put the smartphone into DFU mode (I have to hold down 3 buttons), then click on the "DFU" button (make sure that the COM port is found in the text box with the heading "COM Port Number", if not, enter the port number yourself or click the "UPD" button to get the result).
3. Update the COM port number ("UPD" button) or enter it yourself.
4. 
5.
6.
## All Errors of EWT2 (emmcdl)
* Status: 21 The device is not ready:
Most likely your smartphone has left EDL mode, enter this mode again.
* WARNING: Flash programmer failed to load trying to continue:
* Status: 2 The system cannot find the file specified:
* Status: 6 The handle is invalid:
