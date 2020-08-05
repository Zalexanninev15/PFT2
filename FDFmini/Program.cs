using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace FDFmini
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "FDFmini [Version 1.4.1]";
            if (args.Length != 0) 
            {
                try
                {
                    if (((args[0] == "-fdf") || (args[0] == "-img")) && (args[1] != "") && (args[2] != "") && ((args[3] == "-u") || (args[3] == "-c") || (args[3] == "-system")))
                    {
                        if ((args[0] == "-fdf") && (args[3] == "-u"))
                           Unpack(@args[1], @args[2]);
                        if ((args[0] == "-fdf") && (args[3] == "-system"))
                            UnSystem(@args[1], @args[2]); 
                        if ((args[0] == "-img") && (args[3] == "-c")) 
                            Pack(@args[1], @args[2]);
                        if ((args[0] == "-img") && (args[3] == "-system"))
                            UnSystemIMG(@args[1], @args[2]);
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
                Console.WriteLine("FDFmini v1.4.1 by Zalexanninev15, Alexander927 and And_PDA (ImgExtractor)");
                Console.WriteLine();
                Console.WriteLine("FDFmini [Argument 1] [path_to_file] [Argument 2] [Argument 3]");
                Console.WriteLine();
                Console.WriteLine("Argument 1:");
                Console.WriteLine("-img = for IMG or BIN file");
                Console.WriteLine("-fdf = for FDF file");
                Console.WriteLine();
                Console.WriteLine("Argument 2:");
                Console.WriteLine("name of new FDF file, for Argument 3: -c");
                Console.WriteLine("name of convertible (new IMG) file, for Argument 3 = -u");
                Console.WriteLine("name of new folder (FULL PATH) for unpack FDF file, for Argument 3 = -system");
                Console.WriteLine();
                Console.WriteLine("Argument 3:");
                Console.WriteLine("-c = convert IMG to FDF, for Argument 1: -img");
                Console.WriteLine("-system = unpack IMG file in new folder, for Argument 1: -img");
                Console.WriteLine("-u = convert FDF to IMG, for Argument 1: -fdf");
                Console.WriteLine("-system = convert FDF to IMG and unpack this IMG file in new folder, for Argument 1: -fdf");
                Console.WriteLine();
                Console.WriteLine("Examples:");
                Console.WriteLine("FDFmini -img system.img system.fdf -c");
                Console.WriteLine(@"FDFmini -img system.img D:\PFT2_DATA\UnSystemIMG -system");
                Console.WriteLine("FDFmini -fdf boot.fdf boot.img -u");
                Console.WriteLine(@"FDFmini -fdf system.fdf D:\PFT2_DATA\UnSystemFDF -system");
                Console.WriteLine();
            }
            Console.WriteLine("Press Enter for Exit");
            Console.Read();
        }

        static void UnSystemIMG(string fileIMG, string targetDir)
        {
        	Console.WriteLine("Creating folder...");
            if (Directory.Exists(@targetDir))
            {
                Directory.Delete(@targetDir, true);
            }
            Directory.CreateDirectory(@targetDir);
            Console.WriteLine("OK!");
            Console.WriteLine("Preparing the utility to work...");
            if (File.Exists(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe"))
            {
                File.Delete(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe");
            }
            File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe", Properties.Resources.ImgExtractor);
            Console.WriteLine("OK!");
            Console.WriteLine("Unpacking IMG file to the folder...");
            ProcessStartInfo psiOpt = new ProcessStartInfo(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe", @fileIMG + " " + @targetDir + " -i");
            Process procCommand = Process.Start(psiOpt);
            procCommand.WaitForExit();
            Console.WriteLine("OK!");
            Console.WriteLine("Shutting down my work...");
            if (File.Exists(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe"))
            {
                File.Delete(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe");
            }
            if (File.Exists(@targetDir + "_statfile.txt"))
            {
                File.Move(@targetDir + "_statfile.txt", @targetDir + ".log");
            }
            Console.WriteLine("OK!");
        }

        static void UnSystem(string compressedFile, string targetDir)
        {
            Unpack(@compressedFile, @compressedFile + ".img");
            Console.WriteLine("Creating folder...");
            if (Directory.Exists(@targetDir))
            {
                Directory.Delete(@targetDir, true);
            }
            Directory.CreateDirectory(@targetDir);
            Console.WriteLine("OK!");
            Console.WriteLine("Preparing the utility to work...");
            if (File.Exists(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe"))
            {
                File.Delete(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe");
            }
            File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe", Properties.Resources.ImgExtractor);
            Console.WriteLine("OK!");
            Console.WriteLine("Unpacking IMG file to the folder...");
            ProcessStartInfo psiOpt = new ProcessStartInfo(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe", @compressedFile + ".img" + " " + @targetDir + " -i");
            Process procCommand = Process.Start(psiOpt);
            procCommand.WaitForExit();
            Console.WriteLine("OK!");
            Console.WriteLine("Shutting down my work...");
            if (File.Exists(@compressedFile + ".img"))
            {
                File.Delete(@compressedFile + ".img");
            }
            if (File.Exists(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe"))
            {
                File.Delete(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe");
            }
            if (File.Exists(@targetDir + "_statfile.txt"))
            {
                File.Move(@targetDir + "_statfile.txt", @targetDir + ".log");
            }
            Console.WriteLine("OK!");
        }

        static void Pack(string sourceFile, string compressedFile)
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

        static void Unpack(string compressedFile, string targetFile)
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
