using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace devcop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            inputConsola.Hide();
            inputArchivo.Show();
            btnCarga.Location = new Point(656, 18);
            listBox1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                inputConsola.Show();
                inputArchivo.Hide();
                btnCarga.Location = new Point(336, 351);
                

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                btnCarga.Location = new Point(656, 18);
                inputArchivo.Show();
                inputConsola.Hide();
            }
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.RestoreDirectory = true;

            listBox1.Show();
        }


        private void onpenfile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();






            // Create a temporary file, and put some data into it.
            string path = Path.GetTempFileName();
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

            // Open the stream and read it back.
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }
        }
    }
}
