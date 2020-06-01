echo off
title PFT2_Flasher
%1 -p COM%2 -f %3 -d aboot -o %4\aboot.temp
FDFmini -img %5\aboot.temp %6\aboot.fdf -c
del %7\aboot.temp
%1 -p COM%2 -f %3 -d abootbak -o %4\abootbak.temp
FDFmini -img %5\abootbak.temp %6\abootbak.fdf -c
del %7\abootbak.temp
%1 -p COM%2 -f %3 -d apdp -o %4\apdp.temp
FDFmini -img %5\apdp.temp %6\apdp.fdf -c
del %7\apdp.temp
%1 -p COM%2 -f %3 -d rpm -o %4\rpm.temp
FDFmini -img %5\rpm.temp %6\rpm.fdf -c
del %7\rpm.temp
%1 -p COM%2 -f %3 -d rpmbak -o %4\rpmbak.temp
FDFmini -img %5\rpmbak.temp %6\rpmbak.fdf -c
del %7\rpmbak.temp
%1 -p COM%2 -f %3 -d batweak -o %4\batweak.temp
FDFmini -img %5\batweak.temp %6\batweak.fdf -c
del %7\batweak.temp
%1 -p COM%2 -f %3 -d boot -o %4\boot.temp
FDFmini -img %5\boot.temp %6\boot.fdf -c
del %7\boot.temp
%1 -p COM%2 -f %3 -d cache -o %4\cache.temp
FDFmini -img %5\cache.temp %6\cache.fdf -c
del %7\cache.temp
%1 -p COM%2 -f %3 -d cmnlib -o %4\cmnlib.temp
FDFmini -img %5\cmnlib.temp %6\cmnlib.fdf -c
del %7\cmnlib.temp
%1 -p COM%2 -f %3 -d cmnlib64 -o %4\cmnlib64.temp
FDFmini -img %5\cmnlib64.temp %6\cmnlib64.fdf -c
del %7\cmnlib64.temp
%1 -p COM%2 -f %3 -d cmnlib64bak -o %4\cmnlib64bak.temp
FDFmini -img %5\cmnlib64bak.temp %6\cmnlib64bak.fdf -c
del %7\cmnlib64bak.temp
%1 -p COM%2 -f %3 -d cmnlibbak -o %4\cmnlibbak.temp
FDFmini -img %5\cmnlibbak.temp %6\cmnlibbak.fdf -c
del %7\cmnlibbak.temp
%1 -p COM%2 -f %3 -d config -o %4\config.temp
FDFmini -img %5\config.temp %6\config.fdf -c
del %7\config.temp
%1 -p COM%2 -f %3 -d DDR -o %4\DDR.temp
FDFmini -img %5\DDR.temp %6\DDR.fdf -c
del %7\DDR.temp
%1 -p COM%2 -f %3 -d devcfg -o %4\devcfg.temp
FDFmini -img %5\devcfg.temp %6\devcfg.fdf -c
del %7\devcfg.temp
%1 -p COM%2 -f %3 -d devcfgbak -o %4\devcfgbak.temp
FDFmini -img %5\devcfgbak.temp %6\devcfgbak.fdf -c
del %7\devcfgbak.temp
%1 -p COM%2 -f %3 -d devinfo -o %4\devinfo.temp
FDFmini -img %5\devinfo.temp %6\devinfo.fdf -c
del %7\devinfo.temp
%1 -p COM%2 -f %3 -d dip -o %4\dip.temp
FDFmini -img %5\dip.temp %6\dip.fdf -c
del %7\dip.temp
%1 -p COM%2 -f %3 -d dpo -o %4\dpo.temp
FDFmini -img %5\dpo.temp %6\dpo.fdf -c
del %7\dpo.temp
%1 -p COM%2 -f %3 -d dsp -o %4\dsp.temp
FDFmini -img %5\dsp.temp %6\dsp.fdf -c
del %7\dsp.temp
%1 -p COM%2 -f %3 -d factory -o %4\factory.temp
FDFmini -img %5\factory.temp %6\factory.fdf -c
del %7\factory.temp
%1 -p COM%2 -f %3 -d fingerid -o %4\fingerid.temp
FDFmini -img %5\fingerid.temp %6\fingerid.fdf -c
del %7\fingerid.temp
%1 -p COM%2 -f %3 -d fsg -o %4\fsg.temp
FDFmini -img %5\fsg.temp %6\fsg.fdf -c
del %7\fsg.temp
%1 -p COM%2 -f %3 -d keymaster -o %4\keymaster.temp
FDFmini -img %5\keymaster.temp %6\keymaster.fdf -c
del %7\keymaster.temp
%1 -p COM%2 -f %3 -d keymasterbak -o %4\keymasterbak.temp
FDFmini -img %5\keymasterbak.temp %6\keymasterbak.fdf -c
del %7\keymasterbak.temp
%1 -p COM%2 -f %3 -d keystore -o %4\keystore.temp
FDFmini -img %5\keystore.temp %6\keystore.fdf -c
del %7\keystore.temp
%1 -p COM%2 -f %3 -d limits -o %4\limits.temp
FDFmini -img %5\limits.temp %6\limits.fdf -c
del %7\limits.temp
%1 -p COM%2 -f %3 -d logdump -o %4\logdump.temp
FDFmini -img %5\logdump.temp %6\logdump.fdf -c
del %7\logdump.temp
%1 -p COM%2 -f %3 -d mcfg -o %4\mcfg.temp
FDFmini -img %5\mcfg.temp %6\mcfg.fdf -c
del %7\mcfg.temp
%1 -p COM%2 -f %3 -d mdtp -o %4\mdtp.temp
FDFmini -img %5\mdtp.temp %6\mdtp.fdf -c
del %7\mdtp.temp
%1 -p COM%2 -f %3 -d misc -o %4\misc.temp
FDFmini -img %5\misc.temp %6\misc.fdf -c
del %7\misc.temp
%1 -p COM%2 -f %3 -d modem -o %4\modem.temp
FDFmini -img %5\modem.temp %6\modem.fdf -c
del %7\modem.temp
%1 -p COM%2 -f %3 -d modemst1 -o %4\modemst1.temp
FDFmini -img %5\modemst1.temp %6\modemst1.fdf -c
del %7\modemst1.temp
%1 -p COM%2 -f %3 -d modemst2 -o %4\modemst2.temp
FDFmini -img %5\modemst2.temp %6\modemst2.fdf -c
del %7\modemst2.temp
%1 -p COM%2 -f %3 -d mota -o %4\mota.temp
FDFmini -img %5\mota.temp %6\mota.fdf -c
del %7\mota.temp
%1 -p COM%2 -f %3 -d msadp -o %4\msadp.temp
FDFmini -img %5\msadp.temp %6\msadp.fdf -c
del %7\msadp.temp
%1 -p COM%2 -f %3 -d oem -o %4\oem.temp
FDFmini -img %5\oem.temp %6\oem.fdf -c
del %7\oem.temp
%1 -p COM%2 -f %3 -d persist -o %4\persist.temp
FDFmini -img %5\persist.temp %6\persist.fdf -c
del %7\persist.temp
%1 -p COM%2 -f %3 -d recovery -o %4\recovery.temp
FDFmini -img %5\recovery.temp %6\recovery.fdf -c
del %7\recovery.temp
%1 -p COM%2 -f %3 -d sbl1 -o %4\sbl1.temp
FDFmini -img %5\sbl1.temp %6\sbl1.fdf -c
del %7\sbl1.temp
%1 -p COM%2 -f %3 -d sbl1bak -o %4\sbl1bak.temp
FDFmini -img %5\sbl1bak.temp %6\sbl1bak.fdf -c
del %7\sbl1bak.temp
%1 -p COM%2 -f %3 -d sec -o %4\sec.temp
FDFmini -img %5\sec.temp %6\sec.fdf -c
del %7\sec.temp
%1 -p COM%2 -f %3 -d splash -o %4\splash.temp
FDFmini -img %5\splash.temp %6\splash.fdf -c
del %7\splash.temp
%1 -p COM%2 -f %3 -d ssd -o %4\ssd.temp
FDFmini -img %5\ssd.temp %6\ssd.fdf -c
del %7\ssd.temp
%1 -p COM%2 -f %3 -d syscfg -o %4\syscfg.temp
FDFmini -img %5\syscfg.temp %6\syscfg.fdf -c
del %7\syscfg.temp
%1 -p COM%2 -f %3 -d tz -o %4\tz.temp
FDFmini -img %5\tz.temp %6\tz.fdf -c
del %7\tz.temp
%1 -p COM%2 -f %3 -d tzbak -o %4\tzbak.temp
FDFmini -img %5\tzbak.temp %6\tzbak.fdf -c
del %7\tzbak.temp
%1 -p COM%2 -f %3 -d vendor -o %4\vendor.temp
FDFmini -img %5\vendor.temp %6\vendor.fdf -c
del %7\vendor.temp
%1 -p COM%2 -f %3 -d ztecfg -o %4\ztecfg.temp
FDFmini -img %5\ztecfg.temp %6\ztecfg.fdf -c
del %7\ztecfg.temp
%1 -p COM%2 -f %3 -d fsc -o %4\fsc.temp
FDFmini -img %5\fsc.temp %6\fsc.fdf -c
del %7\fsc.temp
%1 -p COM%2 -f %3 -d system -o %4\system.temp
FDFmini -img %5\system.temp %6\system.fdf -c
del %7\system.temp
pause