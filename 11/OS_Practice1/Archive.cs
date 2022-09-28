using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace gubanovach
{
    internal static class Archive
    {
        internal static void Create()
        {
            const string sourceFolder = @"C:\Archive";
            const string message = "Введите название архива";
            string archiveName = Pather.Enter(message, false);
            archiveName = Pather.Converter(archiveName, ".zip");
            DirectoryInfo di = Directory.CreateDirectory(sourceFolder);
            try
            {
                ZipFile.CreateFromDirectory(sourceFolder, archiveName);
            }
            catch
            {
                archiveName = "tttempp" + archiveName;
                Console.WriteLine($"Упс, такой архив уже был создан, поэтому архив называется {Path.GetFileName(archiveName)}");
                ZipFile.CreateFromDirectory(sourceFolder, archiveName);
            }

            di.Delete();
            Console.WriteLine($"Архив {Path.GetFileName(archiveName)} создан {Path.GetFullPath(archiveName)}");
            const string message2 = "Введите путь файла для сжатия";
            string source = Pather.Enter(message2, true);

            using (FileStream zipToOpen = new FileStream(archiveName, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    if (File.Exists(source))
                    {
                        string fileName = Path.GetFileName(source);
                        StreamReader sr = new StreamReader(source, Encoding.Default);
                        ZipArchiveEntry file = archive.CreateEntry(fileName);
                        using (StreamWriter writer = new StreamWriter(file.Open()))
                        {
                            writer.Write(sr.ReadToEnd());
                        }

                        sr.Close();
                    }
                    else
                    {
                        archive.CreateEntry(source);
                        Console.WriteLine("Выбранный файл не существует, поэтому в архив был добавлен пустой файл с таким же названием");
                    }


                    Console.WriteLine($"Файл {Path.GetFullPath(source)} добавлен в архив {archiveName}");
                }
            }

            const string targetFolder = @"C:\Unzip\";
            Directory.CreateDirectory(targetFolder);
            try
            {
                ZipFile.ExtractToDirectory(archiveName, targetFolder);
                Console.WriteLine($"Содержимое архива {Path.GetFileName(archiveName)} распакован в папку {targetFolder}");
            }
            catch
            {
                Console.WriteLine($"Упс, {Path.GetFileName(archiveName)} уже был распакован в папку {targetFolder}");
            }

            Menu.Delete(targetFolder + Path.GetFileName(source));
            Menu.Delete(archiveName);
            Directory.Delete(targetFolder);
            Console.ReadLine();
        }
    }
}