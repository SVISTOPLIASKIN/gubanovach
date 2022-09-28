using System;
using System.IO;

namespace gubanovach
{
    internal static class Files
    {
        internal static void Write()
        {
            bool flag = Menu.Ask();
            string message = flag ? @"Введите полный путь файла, например c:\temp\temp.txt" : "Введите название файла";
            string path = Pather.Enter(message, flag);
            FileInfo file = new FileInfo(path);

            Console.WriteLine($"Место расположения файла {Path.GetFullPath(path)}");
            Console.WriteLine("Введите строку для записи в файл:");
            string text = Console.ReadLine();
            bool directoryNotExists = Pather.DirectoryNotExist(path);

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(text);
            }

            using (StreamReader sr = new StreamReader(path, false))
            {
                Console.WriteLine("\nТекст в файле:");
                Console.WriteLine(sr.ReadToEnd());
            }

            Menu.Delete(file);
            Pather.Delete(directoryNotExists, path);
        }
    }
}