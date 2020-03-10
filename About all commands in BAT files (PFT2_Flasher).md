# About all commands in BAT files (PFT2_Flasher)

### DFU → EDL

```
[emmcdl.exe] -p com[com_port] -raw [code]
```

### All Partitions

```
[emmcdl.exe] -p COM[com_port] -f [firehose] -gpt
```

### Dump

```
[emmcdl.exe] -p COM[com_port] -f [firehose] -d [partition] -o [dump_file]
```

### Full Dump:

```
[emmcdl.exe] -p COM[com_port] -f [firehose] -d "partition" -o "dump_file".[file_extension]
```

### Flash

```
[emmcdl.exe] -p COM[com_port] -f [firehose] -b [partition] [file]
```

### Disable Google FRP

```
[emmcdl.exe] -p COM[com_port] -f [firehose] -e config
```

***Information is taken from here:*** [Pikabu](http://tinyurl.com/tewzyyv)
