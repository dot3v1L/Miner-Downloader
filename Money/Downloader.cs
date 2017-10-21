using System;
using System.Net;
using System.Windows.Forms;

namespace Money
{
    class Downloader
    {
        public static void Download(string link, string filePath)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(link, filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
