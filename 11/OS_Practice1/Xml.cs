using System;
using System.IO;
using System.Xml.Linq;

namespace gubanovach
{
    internal static class Xml
    {
        internal static void Create()
        {
            bool flag = Menu.Ask();
            string message = flag ? @"Введите полный путь файла, например c:\temp\temp.xml" : "Введите название файла";
            string path = Pather.Enter(message, flag);
            bool directoryNotExists = Pather.DirectoryNotExist(path);
            path = Pather.Converter(path, ".xml");
            Console.WriteLine($"Место расположения файла {Path.GetFullPath(path)}");

            Console.WriteLine("Введите компанию:");
            string company = Console.ReadLine();

            XDocument xdoc = new XDocument();
            XElement user1 = new XElement("user1");
            XAttribute userAttribute = new XAttribute("name", Menu.Name());
            XElement ageElement = new XElement("age", $"{Menu.Age()}");
            XElement compElement = new XElement("company", company);
            user1.Add(userAttribute);
            user1.Add(ageElement);
            user1.Add(compElement);
            XElement users = new XElement("users");
            users.Add(user1);
            xdoc.Add(users);
            xdoc.Save(path);

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
