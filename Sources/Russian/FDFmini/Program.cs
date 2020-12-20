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
            Console.Title = "FDFmini [Версия 1.5.1.2]";
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
                    else { Console.WriteLine("ОШИБКА"); }
                }
                catch
                {
                    Console.WriteLine("ОШИБКА");
                }
            }    
            else
            {
                Console.WriteLine();
                Console.WriteLine("FDFmini v1.5.1.2, создатели: Zalexanninev15, Alexander927 и And_PDA (ImgExtractor)");
                Console.WriteLine();
                Console.WriteLine("FDFmini [Аргумент 1] [путь_к_файлу] [Аргумент 2] [Аргумент 3]");
                Console.WriteLine();
                Console.WriteLine("Аргумент 1:");
                Console.WriteLine("-img = для IMG или BIN файла");
                Console.WriteLine("-fdf = для FDF файла");
                Console.WriteLine();
                Console.WriteLine("Аргумент 2:");
                Console.WriteLine("Имя нового FDF файла, для Аргумента 3: -c");
                Console.WriteLine("Имя конвертируемого (нового IMG) файла, для Аргумента 3: -u");
                Console.WriteLine("Имя новой папки (ПОЛНЫЙ ПУТЬ) для распаковки FDF/IMG/BIN файла, для Аргумента 3: -system");
                Console.WriteLine();
                Console.WriteLine("Аргумент 3:");
                Console.WriteLine("-c = конвертировать IMG в FDF, для Аргумента 1: -img");
                Console.WriteLine("-system = распаковать IMG файл в новую папку, для Аргумента 1: -img");
                Console.WriteLine("-u = конвертировать FDF в IMG, для Аргумента 1: -fdf");
                Console.WriteLine("-system = конвертировать FDF в IMG и распаковать этот IMG файл в новую папку, для Аргумента 1: -fdf");
                Console.WriteLine();
                Console.WriteLine("Примеры:");
                Console.WriteLine("FDFmini -img system.img system.fdf -c");
                Console.WriteLine(@"FDFmini -img system.img D:\PFT2_DATA\UnSystemIMG -system");
                Console.WriteLine("FDFmini -fdf boot.fdf boot.img -u");
                Console.WriteLine(@"FDFmini -fdf system.fdf D:\PFT2_DATA\UnSystemFDF -system");
                Console.WriteLine();
                Console.WriteLine("Нажмите Enter...");
                Console.ReadLine();
            }
        }

        static void UnSystemIMG(string fileIMG, string targetDir)
        {
        	Console.WriteLine("Создание папки...");
            if (Directory.Exists(@targetDir))
            {
                Directory.Delete(@targetDir, true);
            }
            Directory.CreateDirectory(@targetDir);
            Console.WriteLine("OK!");
            Console.WriteLine("Подготовка утилиты к работе...");
            if (File.Exists(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe"))
            {
                File.Delete(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe");
            }
            File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe", Properties.Resources.ImgExtractor);
            Console.WriteLine("OK!");
            Console.WriteLine("Распаковка IMG файла в папку...");
            ProcessStartInfo psiOpt = new ProcessStartInfo(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe", @fileIMG + " " + @targetDir + " -i");
            Process procCommand = Process.Start(psiOpt);
            procCommand.WaitForExit();
            Console.WriteLine("OK!");
            Console.WriteLine("Завершение работы...");
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
            Console.WriteLine("Создание папки...");
            if (Directory.Exists(@targetDir))
            {
                Directory.Delete(@targetDir, true);
            }
            Directory.CreateDirectory(@targetDir);
            Console.WriteLine("OK!");
            Console.WriteLine("Подготовка утилиты к работе...");
            if (File.Exists(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe"))
            {
                File.Delete(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe");
            }
            File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe", Properties.Resources.ImgExtractor);
            Console.WriteLine("OK!");
            Console.WriteLine("Распаковка IMG файла в папку...");
            ProcessStartInfo psiOpt = new ProcessStartInfo(@Environment.GetFolderPath(Environment.SpecialFolder.Templates) + @"\ImgExtractor.exe", @compressedFile + ".img" + " " + @targetDir + " -i");
            Process procCommand = Process.Start(psiOpt);
            procCommand.WaitForExit();
            Console.WriteLine("OK!");
            Console.WriteLine("Завершение работы...");
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
                        Console.WriteLine("Конвертация IMG файла в FDF...");
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
                        Console.WriteLine("ОШИБКА");
                    }
                }
                else
                {
                    Console.WriteLine("ОШИБКА");
                }
                    
            }
            catch { Console.WriteLine("ОШИБКА"); }
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
                        Console.WriteLine("Конвертация FDF файла в IMG...");
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
                        Console.WriteLine("ОШИБКА");
                    }
                }
                else
                {
                    Console.WriteLine("ОШИБКА");
                }
            }
            catch { Console.WriteLine("ОШИБКА"); }
        }
    }
}
