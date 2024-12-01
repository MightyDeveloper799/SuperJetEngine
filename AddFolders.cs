using System;
using System.IO;

namespace SuperJet
{
    public static class AddFolders
    {
        public static void CreateFolder(string folderPath)
        {
            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine($"Folder created: {folderPath}");
            }
            else
            {
                Console.WriteLine($"Folder already exists. {folderPath}");
            }
        }

        public static void DeleteFolder(string folderPath)
        {
            if(Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
                Console.WriteLine($"Folder deleted: {folderPath}");
            }

            else
            {
                Console.WriteLine($"Folder not founded: {folderPath}");
            }
        }

        public static void ListContents(string folderPath)
        {
            if(Directory.Exists(folderPath))
            {
                Console.WriteLine($"Contents of folder: {folderPath}");
                foreach(var dir in Directory.GetDirectories(folderPath))
                {
                    Console.WriteLine($"[DIR] {dir}");
                }

                foreach(var file in Directory.GetFiles(folderPath))
                {
                    Console.WriteLine($"[FILE] {file}");
                }
            }

            else
            {
                Console.WriteLine($"Folder not found: {folderPath}");
            }
        }
    }
}
