using System;
using System.IO;

namespace gubanovach
{
    internal static class Menu
    {
        private static void PrintOptions()
        {
            Console.Clear();
            Console.WriteLine("Выберете пункт:");
            Console.WriteLine("1. Информация о дисках");
            Console.WriteLine("2. Файлы");
            Console.WriteLine("3. JSON");
            Console.WriteLine("4. XML");
            Console.WriteLine("5. ZIP архив");
            Console.WriteLine("6. Выход");
        }

        private static void PrintFileOptions()
        {
            Console.Clear();
            Console.WriteLine("Выберете как Вы хотите сохранить файл");
            Console.WriteLine("1. По опредёленному пути");
            Console.WriteLine("2. В папке по умолчанию ");
            Console.WriteLine("3. Вернуться");
        }

        internal static void Delete(FileInfo file)
        {
            Console.WriteLine("Нажмите любую клавишу, чтобы удалить файл и продолжить...");
            Console.ReadKey();
            file.Delete();
            Console.WriteLine("Файл удален");
        }

        internal static void Delete(string path)
        {
            Console.WriteLine("Нажмите любую клавишу, чтобы удалить файл и продолжить...");
            Console.ReadKey();
            File.Delete(path);
            Console.WriteLine("Файл удален");
        }

        internal static void Show()
        {
            while (true)
            {
                Console.Clear();
                PrintOptions();
                string choice = Console.ReadLine();

                Console.WriteLine(choice);
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Drives.ShowDrive();
                        break;
                    case "2":
                        Files.Write();
                        break;
                    case "3":
                        Json.Create();
                        break;
                    case "4":
                        Xml.Create();
                        break;
                    case "5":
                        Archive.Create();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверное значение");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу для повторного выбора");
                Console.ReadKey();
            }
        }

        internal static bool Ask()
        {
            while (true)
            {
                PrintFileOptions();
                string choice = Console.ReadLine();

                Console.WriteLine(choice);
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        return true;
                    case "2":
                        Console.Clear();
                        return false;
                    case "3":
                        Show();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверное значение. Введите 1, 2 или 3");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу для повторного выбора");
                Console.ReadKey();
            }
        }

        internal static int Age()
        {
            while (true)
            {
                Console.WriteLine("Введите возраст:");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int _))
                {
                    return Convert.ToInt32(input);
                }
            }
        }

        internal static string Name()
        {
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();
            while (string.IsNullOrEmpty(name) || name.Trim() == string.Empty)
            {
                Console.WriteLine("Введите имя:");
                name = Console.ReadLine();
            }

            return name;
        }
    }
}