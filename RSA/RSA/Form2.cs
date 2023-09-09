using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        static public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            //Create a new instance of RSACryptoServiceProvider.
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            //Import the RSA Key information. This only needs
            //toinclude the public key information.
            RSA.ImportParameters(RSAKeyInfo);

            //Encrypt the passed byte array and specify OAEP padding.  
            //OAEP padding is only available on Microsoft Windows XP or
            //later.  
            return RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
        }

        static public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            //Create a new instance of RSACryptoServiceProvider.
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            //Import the RSA Key information. This needs
            //to include the private key information.
            RSA.ImportParameters(RSAKeyInfo);

            //Decrypt the passed byte array and specify OAEP padding.  
            //OAEP padding is only available on Microsoft Windows XP or
            //later.  
            return RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
        }
        //Зашировать
        private void button2_Click(object sender, EventArgs e)
        {
            RSAParameters privateKey;
            RSAParameters publicKey;

            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            //Пункт 2
            publicKey = RSA.ExportParameters(false);

            UnicodeEncoding byteConverter = new UnicodeEncoding();
            string toEncrypt = textBox1.Text;

            byte[] encBytes = RSAEncrypt(byteConverter.GetBytes(toEncrypt), publicKey, false);

            string encrypt = byteConverter.GetString(encBytes);
            textBox2.Text = encrypt;
        }
        //Расшифровать
        private void button3_Click(object sender, EventArgs e)
        {
            RSAParameters privateKey;
            RSAParameters publicKey;

            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            privateKey = RSA.ExportParameters(true);
            publicKey = RSA.ExportParameters(false);

            UnicodeEncoding byteConverter = new UnicodeEncoding();
            string toEncrypt = textBox1.Text;
            Console.WriteLine($"To encode: {toEncrypt}");

            byte[] encBytes = RSAEncrypt(byteConverter.GetBytes(toEncrypt), publicKey, false);
            byte[] decBytes = RSADecrypt(encBytes, privateKey, false);

            textBox2.Text = byteConverter.GetString(decBytes);
        }
    }
}
