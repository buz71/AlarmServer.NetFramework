using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using static System.Console;

namespace AlertServerHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Start AlertServerHelper");

            while (true)
            {
                var processes = Process.GetProcessesByName("AlertService");

                if (processes.Length == 0)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Alert Server STOP");
                    Logger.WriteLog("Logger.txt");
                    ResetColor();
                    // Process.Start(@"C:\PROCON-WIN\AlertService.exe");
                }
                if (processes.Length > 0)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("Alert Server RUN");
                    ResetColor();
                }

                Thread.Sleep(30000);
            }

        }
    }

    public static class Logger 
    {
        public static void WriteLog(string path) 
        {
            File.WriteAllText(path, $"Program detected STOP at {DateTime.Now}\n");
        }
    }
}
