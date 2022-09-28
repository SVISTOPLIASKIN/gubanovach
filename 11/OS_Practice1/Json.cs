using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace gubanovach
{
    internal sealed class Person
    {
        [JsonPropertyName("Firstname")]
        public string Name { get; set; }

        public int Age { get; set; }
    }

    internal static class Json
    {
        internal static void Create()
        {
            bool flag = Menu.Ask();
            string message = flag ? @"Введите полный путь файла, например c:\temp\temp.json" : "Введите название файла";
            string path = Pather.Enter(message, flag);
            bool directoryNotExists = Pather.DirectoryNotExist(path);
            path = Pather.Converter(path, ".json");
            Console.WriteLine($"Место расположения файла {Path.GetFullPath(path)}");

            Person person = new Person() {Name = Menu.Name(), Age = Menu.Age()};
            string json = JsonSerializer.Serialize(person);

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(json);
            }

            using (StreamReader sr = new StreamReader(path, false))
            {
                Console.WriteLine("\nТекст в файле:");
                Console.WriteLine(sr.ReadToEnd());
            }

            Menu.Delete(path);
            Pather.Delete(directoryNotExists, path);
        }
    }
}