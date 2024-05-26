using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace _3_Zadanie2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static byte[] SzyfrujDane(SymmetricAlgorithm algorytm, byte[] dane)
        {
            var szyfrant = algorytm.CreateEncryptor(algorytm.Key, algorytm.IV);
            var memostr = new MemoryStream();
            var cryptostr = new CryptoStream(memostr, szyfrant, CryptoStreamMode.Write);

            try
            {
                cryptostr.Write(dane, 0, dane.Length);
                cryptostr.FlushFinalBlock();
                return memostr.ToArray();
            }
            finally
            {
                cryptostr.Close();
                memostr.Close();
                szyfrant.Dispose();
            }
        }

        static double RAMSzyfrowanie_Czas(SymmetricAlgorithm algorytm, byte[] dane)
        {
            var stoper = Stopwatch.StartNew();
            var encryptor = algorytm.CreateEncryptor(algorytm.Key, algorytm.IV);
            var milisec = new MemoryStream();
            var cryptostr = new CryptoStream(milisec, encryptor, CryptoStreamMode.Write);

            try
            {
                cryptostr.Write(dane, 0, dane.Length);
                cryptostr.FlushFinalBlock();
            }
            finally
            {
                cryptostr.Close();
                milisec.Close();
                encryptor.Dispose();
            }

            stoper.Stop();
            return stoper.Elapsed.TotalSeconds;
        }

        static double RAMDeszyfrowanie_Czas(SymmetricAlgorithm algorytm, byte[] dane)
        {
            var zaszyfr_dane = SzyfrujDane(algorytm, dane);
            var stoper = Stopwatch.StartNew();

            var dec = algorytm.CreateDecryptor(algorytm.Key, algorytm.IV);
            var memorystr = new MemoryStream(zaszyfr_dane);
            var cryptostr = new CryptoStream(memorystr, dec, CryptoStreamMode.Read);

            try
            {
                var decryptedData = new byte[dane.Length];
                cryptostr.Read(decryptedData, 0, decryptedData.Length);
            }
            finally
            {
                cryptostr.Close();
                memorystr.Close();
                dec.Dispose();
            }

            stoper.Stop();
            return stoper.Elapsed.TotalSeconds;
        }



        static double DeszyfrowanieHDD_Czas(SymmetricAlgorithm algorytm, byte[] dane)
        {
            var plik = "yogiTest.iso";
            var zaszyfrowaneDane = SzyfrujDane(algorytm, dane);
            File.WriteAllBytes(plik, zaszyfrowaneDane);
            var stoper = Stopwatch.StartNew();

            var fileStream = new FileStream(plik, FileMode.Open);
            var decryptor = algorytm.CreateDecryptor(algorytm.Key, algorytm.IV);
            var cryptoStream = new CryptoStream(fileStream, decryptor, CryptoStreamMode.Read);

            try
            {
                var buffer = new byte[8192];
                while (cryptoStream.Read(buffer, 0, buffer.Length) > 0) { }
            }
            finally
            {
                cryptoStream.Close();
                fileStream.Close();
                decryptor.Dispose();
            }

            stoper.Stop();
            return stoper.Elapsed.TotalSeconds;
        }

        static double SzyfrowanieHDD_Czas(SymmetricAlgorithm algorytm, byte[] dane)
        {
            var plik = "testData.bin";
            File.WriteAllBytes(plik, dane);
            var stoper = Stopwatch.StartNew();

            var filestr = new FileStream(plik, FileMode.Open);
            var encryptor = algorytm.CreateEncryptor(algorytm.Key, algorytm.IV);
            var cryptstr = new CryptoStream(filestr, encryptor, CryptoStreamMode.Read);

            try
            {
                var buffer = new byte[8192];
                while (cryptstr.Read(buffer, 0, buffer.Length) > 0) { }
            }
            finally
            {
                cryptstr.Close();
                filestr.Close();
                encryptor.Dispose();
            }

            stoper.Stop();
            return stoper.Elapsed.TotalSeconds;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int blok = 50 * 1024 * 1024;
            var dane = new byte[blok];
            new Random().NextBytes(dane);

            var algorytm = new (string Name, Func<SymmetricAlgorithm> CreateAlgorithm)[]
            {
             ("AES(CSP) 128BIT", () => new AesCryptoServiceProvider { KeySize = 128 }),
             ("AES(CSP) 256BIT", () => new AesCryptoServiceProvider { KeySize = 256 }),
            ("AES Man 256BIT", () => new AesManaged { KeySize = 256 }),
               ("Rijndael 256BIT", () => new RijndaelManaged { KeySize = 256 }),
            ("DES 56BIT", () => new DESCryptoServiceProvider()),
            ("3DES 168BIT", () => new TripleDESCryptoServiceProvider())
            };

            StringBuilder res = new StringBuilder();
            res.AppendLine("Algorytm\t\t\tSekundy na blok\t\tBajtów na sekundê RAM\t\tBajtów na sekundê HDD");

            foreach (var (nazwa, AlgorytmDany) in algorytm)
            {
                var algo = AlgorytmDany();
                algo.GenerateKey();
                algo.GenerateIV();

                double ramSzyfrowanie = RAMSzyfrowanie_Czas(algo, dane);
                double ramDeszyfrowanie = RAMDeszyfrowanie_Czas(algo, dane);
                double ramPrzepust = blok / (ramSzyfrowanie + ramDeszyfrowanie);

                double hddSzyfrowanie = SzyfrowanieHDD_Czas(algo, dane);
                double hddDeszyfrowanie = DeszyfrowanieHDD_Czas(algo, dane);
                double hddPrzepust = blok / (hddSzyfrowanie + hddDeszyfrowanie);

                res.AppendLine($"{nazwa}\t\t\t{ramSzyfrowanie + ramDeszyfrowanie:F6}\t\t\t{ramPrzepust:F2}\t\t\t{hddPrzepust:F2}");

                algo.Dispose();
            }

            textBox1.Text = res.ToString();

        }
    }
}
