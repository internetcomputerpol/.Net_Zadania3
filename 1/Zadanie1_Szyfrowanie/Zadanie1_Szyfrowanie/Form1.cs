using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Zadanie1_Szyfrowanie
{
    public partial class Form1 : Form
    {
        private SymmetricAlgorithm algorytm;
        private byte[] klucz;
        private byte[] iv;

        public Form1()
        {
            InitializeComponent();
            Wybor_algorytmuComboBox.SelectedIndex = 0;
        }

        private void GenerujKlucz_Button_Click_1(object sender, EventArgs e)
        {
            switch (Wybor_algorytmuComboBox.SelectedItem.ToString())
            {
                case "DES":
                    algorytm = DES.Create();
                    break;
                case "3DES":
                    algorytm = TripleDES.Create();
                    break;
               
            }

            algorytm.GenerateKey();
            algorytm.GenerateIV();
            klucz = algorytm.Key;
            iv = algorytm.IV;

            Klucz_TextBox.Text = BitConverter.ToString(klucz).Replace("-", "");
            IV_TextBox.Text = BitConverter.ToString(iv).Replace("-", "");
        }

        private void Zaszyfruj_Button_Click_1(object sender, EventArgs e)
        {
            if (algorytm == null || string.IsNullOrWhiteSpace(TextDoZaszyfrowania_Button.Text))
            {
                MessageBox.Show("Wygeneruj najpierw klucz i iv i wpisz cos w wiadomosc gosciu ...");
                return;
            }

            var plaintext = Encoding.UTF8.GetBytes(TextDoZaszyfrowania_Button.Text);
            byte[] ciphertext;

            var stopwatch = Stopwatch.StartNew();
            using (var encryptor = algorytm.CreateEncryptor(klucz, iv))
            {
                ciphertext = encryptor.TransformFinalBlock(plaintext, 0, plaintext.Length);
            }
            stopwatch.Stop();
            Zaszyfrowanie_Label.Text = $"Czas Zaszyfrowania: {stopwatch.ElapsedMilliseconds} ms";

            Cipher_TextBox.Text = Convert.ToBase64String(ciphertext);
            Cipher_HexTextBox.Text = BitConverter.ToString(ciphertext).Replace("-", "");
        }

        private void Odszyfruj_Button_Click_1(object sender, EventArgs e)
        {
            var stopwatch = Stopwatch.StartNew();
            
            if (algorytm == null || string.IsNullOrWhiteSpace(Cipher_TextBox.Text))
            {
                MessageBox.Show("Najpierw zaszyfruj wiadomosc");
        
                return;
            }

            byte[] ciphertext;
            try
            {
                ciphertext = Convert.FromBase64String(Cipher_TextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Niewlasciwy format ");
              
                return;
            }

            byte[] plaintext;
            stopwatch.Start();

            using (var decryptor = algorytm.CreateDecryptor(klucz, iv))
            {
                try
                {
                    plaintext = decryptor.TransformFinalBlock(ciphertext, 0, ciphertext.Length);
                }
                catch (CryptographicException)
                {
                    MessageBox.Show("Odszyfrowywanie nie powiodlo sie");
                    return;
                }
            }
            stopwatch.Stop();
            Odszyfrowanie_Label.Text = $"Czas Odszyfrowania: {stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Restart();

            textBox4.Text = Encoding.UTF8.GetString(plaintext);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
