using System;
using System.Windows.Forms;

namespace Money
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pool = "[pool:port]";
                string username = "[username]";
                string password = "[password]";
                int num = 50;
                bool gPU = true;
                int nCores = checked((int)Math.Round(Environment.ProcessorCount / 100.0 * num));
                Run.Start(pool, username, password, nCores, gPU);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
