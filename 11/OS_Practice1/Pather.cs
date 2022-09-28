using System;
using System.IO;
using System.Text.RegularExpressions;

namespace gubanovach
{
    internal static class Pather
    {
        
        internal static string Enter(string message, bool flag)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) || input.Trim() == string.Empty) // проверка на пустую строку
            {
                Console.Clear();
                Console.WriteLine($"{message}");
                input = Console.ReadLine();
            }

            return EnterCheck(input.Replace(" ", ""), flag);
        }

        
        private static string EnterCheck(string path, bool flag)
        {
            if ((!Regex.IsMatch(path, @"[""<>\?|*]") && flag) 
                || (!Regex.IsMatch(path, @"[<>:\\?\/|*]") && !flag)) 
            {
                return path;
            }

            Console.WriteLine("Кажется вы используете запрещенные символы");
            if (flag)
            {
                path = Trim(path, true);
                return path;
            }

            path = Trim(path, false);
            return path;
        }

        
        private static string Trim(string path, bool flag)
        {
            if (flag)
            {
                string[] charsToRemove = {"\"", "<", ">", "?", "|", "*"};
                foreach (string c in charsToRemove)
                {
                    path = path.Replace(c, string.Empty);
                }
            }
            else
            {
                string[] charsToRemove = {"\"", "<", ">", ":", "\\", "?", "/", "|", "*"};
                foreach (string c in charsToRemove)
                {
                    path = path.Replace(c, string.Empty);
                }
            }

            if (string.IsNullOrEmpty(path) || path.Trim() == string.Empty)
            {
                return Enter("Некорректные символы", flag);
            }

            Console.WriteLine($"Но ничего страшного, теперь путь выглядит так {path}");
            return path;
        }

        internal static bool DirectoryNotExist(string path)
        {
            if (Directory.Exists(Convert.ToString(Directory.GetParent(path)))) return false;
            Console.WriteLine("Такого пути не было, но теперь есть!");
            Directory.CreateDirectory(Convert.ToString(Directory.GetParent(path)));
            return true;
        }

        /// <summary>
        /// Удаление созданного пути для файла
        /// </summary>
        /// <param name="directoryNotExisted">
        /// Существовал такой путь до выполнения программы
        /// </param>
        /// <param name="path">
        /// Путь до файла
        /// </param>
        internal static void Delete(bool directoryNotExisted, string path)
        {
            if (directoryNotExisted)
            {
                Directory.Delete(Convert.ToString(Directory.GetParent(path)));
                Console.WriteLine("Созданный путь для файла был удалён!");
            }
            else
            {
                Console.WriteLine("Созданный путь для файла не был удалён!");
            }
        }

        /// <summary>
        /// Конвертация файла в другое расширение
        /// </summary>
        /// <param name="path">
        /// Путь файла</param>
        /// <param name="extension">
        /// Расширение требуемого файла
        /// </param>
        /// <returns>
        /// Путь конвертированного файла
        /// </returns>
        internal static string Converter(string path, string extension)
        {
            if (Path.GetExtension(path) != extension)
            {
                path += extension;
            }

            return path;
        }
    }
}