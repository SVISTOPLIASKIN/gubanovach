using System;
using System.IO;

namespace gubanovach
{
    internal static class Drives
    {
        internal static void ShowDrive()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize} байт");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace} байт");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }

                Console.WriteLine();
            }
        }
    }
}