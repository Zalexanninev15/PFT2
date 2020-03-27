@echo off
title PFT2_Flasher
@%1 -p COM%2 -f %3 -d userdata -o %4\userdata.%5 // Optional for dump
@%1 -p COM%2 -f %3 -d system -o %4\system.%5 // Optional for dump
@%1 -p COM%2 -f %3 -d aboot -o %4\aboot.%5
@%1 -p COM%2 -f %3 -d abootbak -o %4\abootbak.%5
@%1 -p COM%2 -f %3 -d apdp -o %4\apdp.%5
@%1 -p COM%2 -f %3 -d batweak -o %4\batweak.%5
@%1 -p COM%2 -f %3 -d boot -o %4\boot.%5
@%1 -p COM%2 -f %3 -d cache -o %4\cache.%5
@%1 -p COM%2 -f %3 -d cmnlib -o %4\cmnlib.%5
@%1 -p COM%2 -f %3 -d cmnlib64 -o %4\cmnlib64.%5
@%1 -p COM%2 -f %3 -d cmnlib64bak -o %4\cmnlib64bak.%5
@%1 -p COM%2 -f %3 -d cmnlibbak -o %4\cmnlibbak.%5
@%1 -p COM%2 -f %3 -d config -o %4\config.%5
@%1 -p COM%2 -f %3 -d DDR -o %4\DDR.%5
@%1 -p COM%2 -f %3 -d devcfg -o %4\devcfg.%5
@%1 -p COM%2 -f %3 -d devcfgbak -o %4\devcfgbak.%5
@%1 -p COM%2 -f %3 -d devinfo -o %4\devinfo.%5
@%1 -p COM%2 -f %3 -d dip -o %4\dip.%5
@%1 -p COM%2 -f %3 -d dpo -o %4\dpo.%5
@%1 -p COM%2 -f %3 -d dsp -o %4\dsp.%5
@%1 -p COM%2 -f %3 -d factory -o %4\factory.%5
@%1 -p COM%2 -f %3 -d fingerid -o %4\fingerid.%5
@%1 -p COM%2 -f %3 -d fsc -o %4\fsc.%5
@%1 -p COM%2 -f %3 -d fsg -o %4\fsg.%5
@%1 -p COM%2 -f %3 -d keymaster -o %4\keymaster.%5
@%1 -p COM%2 -f %3 -d keymasterbak -o %4\keymasterbak.%5
@%1 -p COM%2 -f %3 -d keystore -o %4\keystore.%5
@%1 -p COM%2 -f %3 -d limits -o %4\limits.%5
@%1 -p COM%2 -f %3 -d logdump -o %4\logdump.%5
@%1 -p COM%2 -f %3 -d mcfg -o %4\mcfg.%5
@%1 -p COM%2 -f %3 -d mdtp -o %4\mdtp.%5
@%1 -p COM%2 -f %3 -d misc -o %4\misc.%5
@%1 -p COM%2 -f %3 -d modem -o %4\modem.%5
@%1 -p COM%2 -f %3 -d modemst1 -o %4\modemst1.%5
@%1 -p COM%2 -f %3 -d modemst2 -o %4\modemst2.%5
@%1 -p COM%2 -f %3 -d mota -o %4\mota.%5
@%1 -p COM%2 -f %3 -d msadp -o %4\msadp.%5
@%1 -p COM%2 -f %3 -d oem -o %4\oem.%5
@%1 -p COM%2 -f %3 -d persist -o %4\persist.%5
@%1 -p COM%2 -f %3 -d recovery -o %4\recovery.%5
@%1 -p COM%2 -f %3 -d rpm -o %4\rpm.%5
@%1 -p COM%2 -f %3 -d rpmbak -o %4\rpmbak.%5
@%1 -p COM%2 -f %3 -d sbl1 -o %4\sbl1.%5
@%1 -p COM%2 -f %3 -d sbl1bak -o %4\sbl1bak.%5
@%1 -p COM%2 -f %3 -d sec -o %4\sec.%5
@%1 -p COM%2 -f %3 -d splash -o %4\splash.%5
@%1 -p COM%2 -f %3 -d ssd -o %4\ssd.%5
@%1 -p COM%2 -f %3 -d syscfg -o %4\syscfg.%5
@%1 -p COM%2 -f %3 -d tz -o %4\tz.%5
@%1 -p COM%2 -f %3 -d tzbak -o %4\tzbak.%5
@%1 -p COM%2 -f %3 -d vendor -o %4\vendor.%5
@%1 -p COM%2 -f %3 -d ztecfg -o %4\ztecfg.%5
pause