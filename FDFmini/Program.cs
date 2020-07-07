using System;
using System.IO;
using System.IO.Compression;

namespace FDFmini
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "FDFmini [Version 1.3.1]";
            if (args.Length != 0) 
            {
                try
                {
                    if (((args[0] == "-fdf") || (args[0] == "-img")) && (args[1] != "") && (args[2] != "") && ((args[3] == "-u") || (args[3] == "-c")))
                    {
                        if ((args[0] == "-fdf") && (args[3] == "-u")) { Unpack(@args[1], @args[2]); }
                        if ((args[0] == "-img") && (args[3] == "-c")) { Pack(@args[1], @args[2]); }
                    }
                    else { Console.WriteLine("ERROR"); }
                }
                catch
                {
                    Console.WriteLine("ERROR");
                }
            }    
            else
            {
                Console.WriteLine();
                Console.WriteLine("FDFmini by Zalexanninev15 and Alexander927");
                Console.WriteLine();
                Console.WriteLine("FDFmini [Argument 1] [path_to_file] [Argument 2] [Argument 3]");
                Console.WriteLine();
                Console.WriteLine("Argument 1:");
                Console.WriteLine("-img (for IMG or BIN file)");
                Console.WriteLine("-fdf (for FDF file)");
                Console.WriteLine();
                Console.WriteLine("Argument 2:");
                Console.WriteLine("name of new FDF file (for Argument 3 = -c)");
                Console.WriteLine("name of convertible (new IMG) file (for Argument 3 = -u)");
                Console.WriteLine();
                Console.WriteLine("Argument 3:");
                Console.WriteLine("-c (convert IMG to FDF, for Argument 1 = -img)");
                Console.WriteLine("-u (convert FDF to IMG, for Argument 1 = -fdf)");
                Console.WriteLine();
                Console.WriteLine("Examples:");
                Console.WriteLine("FDFmini -img boot.img boot.fdf -c");
                Console.WriteLine("FDFmini -fdf boot.fdf boot.img -u");
                Console.WriteLine();
                Console.WriteLine("Press Enter for Exit");
                Console.Read();
            }
        }

        private static void Pack(string sourceFile, string compressedFile)
        {
            try
            {
                FileInfo fileInf = new FileInfo(sourceFile);
                if (fileInf.Exists)
                {
                    if ((fileInf.Extension == ".img") || (fileInf.Extension == ".temp"))
                    {
                        Console.WriteLine("Converting IMG file to FDF...");
                        using (FileStream sourceStream = new FileStream(@sourceFile, FileMode.OpenOrCreate))
                        {
                            using (FileStream targetStream = File.Create(@compressedFile))
                            {
                                using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                                {
                                    sourceStream.CopyTo(compressionStream);
                                    Console.WriteLine("OK!");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
                    
            }
            catch { Console.WriteLine("ERROR"); }
        }

        private static void Unpack(string compressedFile, string targetFile)
        {
            try
            {
                FileInfo fileInf = new FileInfo(compressedFile);
                if (fileInf.Exists)
                {
                    if (fileInf.Extension == ".fdf")
                    {
                        Console.WriteLine("Converting FDF file to IMG...");
                        using (FileStream sourceStream = new FileStream(@compressedFile, FileMode.OpenOrCreate))
                        {
                            using (FileStream targetStream = File.Create(@targetFile))
                            {
                                using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                                {
                                    decompressionStream.CopyTo(targetStream);
                                    Console.WriteLine("OK!");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
            }
            catch { Console.WriteLine("ERROR"); }
        }
    }
}
