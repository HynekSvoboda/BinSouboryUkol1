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

namespace BinSouboryUkol1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream tok = new FileStream("znaky.dat", FileMode.Open, FileAccess.Read);
            BinaryReader cteni = new BinaryReader(tok, Encoding.UTF8);
            bool prvni = false;
            char predchozi = '\0';
            cteni.BaseStream.Position = 0;
            while(cteni.BaseStream.Position<cteni.BaseStream.Length)
            {
                char znak=cteni.ReadChar();
                if (znak=='?'&&!prvni)
                {
                    label2.Text = cteni.BaseStream.Position.ToString();
                    label4.Text = predchozi.ToString();
                    prvni = true;
                }
                predchozi = znak;
            }
            tok.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Na disku je soubor znaky.dat. Najdi první výskyt znaku '?', zobraz jeho pořadí v souboru a\r\nznak, který je v souboru před ním.\r\n", "INFO");
        }
    }
}