using System;
using System.IO;

namespace NoLongerLocatedFix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("This is no longer located in...\nInput your path:");
            String path = Console.ReadLine();
            path = path.Replace("\"", "");
            FileInfo f = new FileInfo(path);
            string drive = Path.GetPathRoot(f.FullName);
            runCmd(" rd /s \"\\\\?\\" + path + "\"", drive[0] + "");

        }
        static void runcmd(String cmd, String drive)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = drive + ":&&" + cmd;
            process.StartInfo = startInfo;
            process.Start();
        }
        static void runCmd(String cmd, String drive)
        {
            Console.WriteLine("\nRun this command from CMD:\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(drive + ":&&" + cmd + "\n");
            Console.ResetColor();
            Console.WriteLine("Hit enter to open CMD...");
            Console.Read();
            System.Diagnostics.Process.Start("CMD");
        }
    }

}
