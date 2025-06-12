using DevExpress.Utils.CommonDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CERtoPFX
{
    public partial class Form1 : Form
    {
        
        private string certificateFileName;
        private string certificatePostfix;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog filed = new OpenFileDialog();
            filed.Title = "Choose .CER file";
            filed.Filter = "cer files (*.cer)|*.cer";
            filed.Multiselect= false;
            if (filed.ShowDialog() == DialogResult.OK)
            {
                certificateFileName = filed.FileName;
                X509Certificate x509Certificate = new X509Certificate(textBox1.Text);
                byte[] bytes = x509Certificate.Export(X509ContentType.Pfx, textBox1.Text);
                this.certificateFileName = this.certificateFileName.Replace(this.certificatePostfix, "pfx");
                File.WriteAllBytes(this.certificateFileName, bytes);
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("You Canceled this Operation!!!", "CERtoPFX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(34);
        }
    }
}
