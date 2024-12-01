using System;
using System.IO;

namespace SuperJet
{
    public class AddJavaClass
    {
        public static void CreateJavaClass(string folderPath, string javaClassName, string javaClassContent)
        {
            string javaClassPath = Path.Combine(folderPath, $"{javaClassName}.java");

            if(!File.Exists(javaClassPath))
            {
                File.WriteAllText(javaClassPath, javaClassContent);
                Console.WriteLine($"Java class was created: {javaClassPath}");
            }
            else
            {
                Console.WriteLine($"Java class already exists. {javaClassPath}");
            }
        }

        public static void DeleteJavaClass(string javaClassPath)
        {
            if(File.Exists(javaClassPath))
            {
                File.Delete(javaClassPath);
                Console.WriteLine($"Java class deleted: {javaClassPath}");
            }
            else
            {
                Console.WriteLine($"Java class not found {javaClassPath}");
            }
        }

        public static void ReadJavaClass(string javaClassPath)
        {
            if(File.Exists(javaClassPath))
            {
                string javaClassContent = File.ReadAllText(javaClassPath);
                Console.WriteLine($"Contents of {javaClassPath}");
                Console.WriteLine(javaClassContent);
            }

            else
            {
                Console.WriteLine($"Java class not found: {javaClassPath}");
            }
        }
    }
}
