# About all commands in BAT files (PFT2_Flasher)

### DFU → EDL ([this](https://github.com/Zalexanninev15/PFT2/blob/master/PFT2_Flasher/edl.bat))

```
[emmcdl.exe] -p com[com_port] -raw [code]
```

### Dump ([this](https://github.com/Zalexanninev15/PFT2/blob/master/PFT2_Flasher/dump.bat))

```
[emmcdl.exe] -p COM[com_port] -f [firehose] -d [partition] -o [dump_file]
```

### Full Dump: ([this](https://github.com/Zalexanninev15/PFT2/blob/master/PFT2_Flasher/full_dump.bat))

```
[emmcdl.exe] -p COM[com_port] -f [firehose] -d "partition" -o "dump_file".[file_extension]
```

### Flash ([this](https://github.com/Zalexanninev15/PFT2/blob/master/PFT2_Flasher/flash.bat))

```
[emmcdl.exe] -p COM[com_port] -f [firehose] -b [partition] [file]
```

### Disable Google FRP ([this](https://github.com/Zalexanninev15/PFT2/blob/master/PFT2_Flasher/dgfrp.bat))

```
[emmcdl.exe] -p COM[com_port] -f [firehose] -e config
```

***Information is taken from here:*** [Pikabu](http://tinyurl.com/tewzyyv)
