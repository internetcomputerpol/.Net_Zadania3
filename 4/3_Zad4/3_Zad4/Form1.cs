using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace _3_Zad4
{
    public partial class Form1 : Form
    {
        private const string PrivateKeyFileName = "privateKey.xml";

        public Form1()
        {
            InitializeComponent();
            GenerujKlucz();
        }

        private void GenerujKlucz()
        {
           
            if (!File.Exists(PrivateKeyFileName))
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    string privateKey = rsa.ToXmlString(true);
                    File.WriteAllText(PrivateKeyFileName, privateKey);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = textBox1.Text;
                string OdszPlik = textBox1.Text + ".enc";

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(File.ReadAllText(PrivateKeyFileName));

                    byte[] d = File.ReadAllBytes(path);
                    byte[] EncDane = rsa.Encrypt(d, true);
                    File.WriteAllBytes(OdszPlik, EncDane);
                }

                MessageBox.Show("Plik Zaszyfrowany");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wyst¹pi³ b³¹d: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Wybierz plik";
            openFileDialog.Filter = "Wszystkie pliki (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string SzyfrowanyPlik_Nazwa = textBox1.Text;
                string Deszyfrowany_Nazwa = SzyfrowanyPlik_Nazwa.Substring(0, SzyfrowanyPlik_Nazwa.Length - 4); 

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(File.ReadAllText(PrivateKeyFileName));

                    byte[] dF = File.ReadAllBytes(SzyfrowanyPlik_Nazwa);
                    byte[] dD = rsa.Decrypt(dF, true);
                    File.WriteAllBytes(Deszyfrowany_Nazwa+"_decrypt", dD);
                }

                MessageBox.Show("Plik Odszyfrowany");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wyst¹pi³ b³¹d: " + ex.Message);
            }
        }

          private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}




       