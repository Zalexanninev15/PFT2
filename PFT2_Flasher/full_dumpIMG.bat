echo off
title PFT2_Flasher
%1 -p COM%2 -f %3 -d aboot -o %4\aboot.img
%1 -p COM%2 -f %3 -d abootbak -o %4\abootbak.img
%1 -p COM%2 -f %3 -d apdp -o %4\apdp.img
%1 -p COM%2 -f %3 -d rpm -o %4\rpm.img
%1 -p COM%2 -f %3 -d rpmbak -o %4\rpmbak.img
%1 -p COM%2 -f %3 -d batweak -o %4\batweak.img
%1 -p COM%2 -f %3 -d boot -o %4\boot.img
%1 -p COM%2 -f %3 -d cache -o %4\cache.img
%1 -p COM%2 -f %3 -d cmnlib -o %4\cmnlib.img
%1 -p COM%2 -f %3 -d cmnlib64 -o %4\cmnlib64.img
%1 -p COM%2 -f %3 -d cmnlib64bak -o %4\cmnlib64bak.img
%1 -p COM%2 -f %3 -d cmnlibbak -o %4\cmnlibbak.img
%1 -p COM%2 -f %3 -d config -o %4\config.img
%1 -p COM%2 -f %3 -d DDR -o %4\DDR.img
%1 -p COM%2 -f %3 -d devcfg -o %4\devcfg.img
%1 -p COM%2 -f %3 -d devcfgbak -o %4\devcfgbak.img
%1 -p COM%2 -f %3 -d devinfo -o %4\devinfo.img
%1 -p COM%2 -f %3 -d dip -o %4\dip.img
%1 -p COM%2 -f %3 -d dpo -o %4\dpo.img
%1 -p COM%2 -f %3 -d dsp -o %4\dsp.img
%1 -p COM%2 -f %3 -d factory -o %4\factory.img
%1 -p COM%2 -f %3 -d fingerid -o %4\fingerid.img
%1 -p COM%2 -f %3 -d fsg -o %4\fsg.img
%1 -p COM%2 -f %3 -d keymaster -o %4\keymaster.img
%1 -p COM%2 -f %3 -d keymasterbak -o %4\keymasterbak.img
%1 -p COM%2 -f %3 -d keystore -o %4\keystore.img
%1 -p COM%2 -f %3 -d limits -o %4\limits.img
%1 -p COM%2 -f %3 -d logdump -o %4\logdump.img
%1 -p COM%2 -f %3 -d mcfg -o %4\mcfg.img
%1 -p COM%2 -f %3 -d mdtp -o %4\mdtp.img
%1 -p COM%2 -f %3 -d misc -o %4\misc.img
%1 -p COM%2 -f %3 -d modem -o %4\modem.img
%1 -p COM%2 -f %3 -d modemst1 -o %4\modemst1.img
%1 -p COM%2 -f %3 -d modemst2 -o %4\modemst2.img
%1 -p COM%2 -f %3 -d mota -o %4\mota.img
%1 -p COM%2 -f %3 -d msadp -o %4\msadp.img
%1 -p COM%2 -f %3 -d oem -o %4\oem.img
%1 -p COM%2 -f %3 -d persist -o %4\persist.img
%1 -p COM%2 -f %3 -d recovery -o %4\recovery.img
%1 -p COM%2 -f %3 -d sbl1 -o %4\sbl1.img
%1 -p COM%2 -f %3 -d sbl1bak -o %4\sbl1bak.img
%1 -p COM%2 -f %3 -d sec -o %4\sec.img
%1 -p COM%2 -f %3 -d splash -o %4\splash.img
%1 -p COM%2 -f %3 -d ssd -o %4\ssd.img
%1 -p COM%2 -f %3 -d syscfg -o %4\syscfg.img
%1 -p COM%2 -f %3 -d tz -o %4\tz.img
%1 -p COM%2 -f %3 -d tzbak -o %4\tzbak.img
%1 -p COM%2 -f %3 -d ztecfg -o %4\ztecfg.img
%1 -p COM%2 -f %3 -d fsc -o %4\fsc.img
%1 -p COM%2 -f %3 -d vendor -o %4\vendor.img
%1 -p COM%2 -f %3 -d system -o %4\system.img
pause
