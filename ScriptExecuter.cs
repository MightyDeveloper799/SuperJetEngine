using System;
using System.Diagnostics;
using System.IO;

namespace SuperJetEngine
{
    public static class ScriptExecuter
    {
        public static void ExecuteJavaClass(string javaClassName, string classPath)
        {
            string javaPath = Path.Combine(Environment.GetEnvironmentVariable("JAVA_HOME"), "bin", "java.exe");

            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = javaPath,
                Arguments = $"-cp \"{classPath}\" {javaClassName}",
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
                    Console.WriteLine($"Execution output:\n{output}");
                }
                else
                {
                    Console.WriteLine($"Execution failed:\n{error}");
                }
            }
        }

        public static void ExecuteJavaFile(string javaClassPath, string classPath)
        {
            string javaClassName = Path.GetFileNameWithoutExtension(javaClassPath);
            ExecuteJavaClass(javaClassName, classPath);
        }
    }
}
