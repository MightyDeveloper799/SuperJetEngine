using System;
using System.IO;

namespace SuperJet
{
    public class AddMaterials
    {
        public static void AddMaterial(string sourceFilePath, string destinationFolderPath)
        {
            if (!File.Exists(sourceFilePath)) 
                throw new FileNotFoundException("Material file was not found.", sourceFilePath); 

            if (!Directory.Exists(destinationFolderPath)) 
                Directory.CreateDirectory(destinationFolderPath); 

            string fileName = Path.GetFileName(sourceFilePath);
            string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

            File.Copy(sourceFilePath, destinationFilePath, true); 
            Console.WriteLine($"Material added: {destinationFilePath}");

        }

        public static void ListMaterials(string folderPath)
        {
            if(Directory.Exists(folderPath))
            {
                Console.WriteLine($"Materials in folder: {folderPath}");
                foreach (var file in Directory.GetFiles(folderPath))
                {
                    Console.WriteLine(file);
                }
            }

            else
            {
                Console.WriteLine($"Folder not found: {folderPath}");
            }
        }

        public static void DeleteMaterial(string filePath)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine($"Material deleted: {filePath}");
            }

            else
            {
                Console.WriteLine($"Material not found: {filePath}");
            }
        }
    }
}
