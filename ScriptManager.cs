using System;
using System.Diagnostics;
using System.IO;

namespace SuperJetEngine
{
    public static class ScriptManager
    {
        public static bool CompileJavaFile(string javaFilePath, string outputDirectory)
        {
            if (!File.Exists(javaFilePath))
                throw new FileNotFoundException("Java file not found.", javaFilePath);

            string javacPath = Path.Combine(Environment.GetEnvironmentVariable("JAVA_HOME"), "bin", "javac.exe");

            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = javacPath,
                Arguments = $"-d \"{outputDirectory}\" \"{javaFilePath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = processStartInfo })
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    Console.WriteLine("Compilation successful.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Compilation failed:\n{error}");
                    return false;
                }
            }
        }

        public static void AddJavaFile(string sourceDirectory, string javaFileName)
        {
            string javaFilePath = Path.Combine(sourceDirectory, javaFileName);
            string outputDirectory = "compiled_scripts";

            if (CompileJavaFile(javaFilePath, outputDirectory))
            {
                Console.WriteLine($"Java file {javaFileName} added and compiled successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to compile Java file {javaFileName}.");
            }
        }

        public static void AddJavaClass(string sourceDirectory, string javaClassName)
        {
            string javaClassPath = Path.Combine(sourceDirectory, javaClassName);
            string outputDirectory = "compiled_scripts";

            if(CompileJavaClass(javaClassName, outputDirectory))
            {
                Console.WriteLine($"Java class {javaClassName} added and compiled successfully.");
            }

            else
            {
                Console.WriteLine($"Failed to compile the Java Class {javaClassName}.");
            }
        }

        public static bool CompileJavaClass(string javaClassPath, string outputDirectory)
        {
            if (!File.Exists(javaClassPath))
                throw new FileNotFoundException("Java file not found.", javaClassPath);

            string javacPath = Path.Combine(Environment.GetEnvironmentVariable("JAVA_HOME"), "bin", "javac.exe");

            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = javacPath,
                Arguments = $"-d \"{outputDirectory}\" \"{javaClassPath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = processStartInfo })
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    Console.WriteLine("Compilation successful.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Compilation failed:\n{error}");
                    return false;
                }
            }
        }
    }
}
