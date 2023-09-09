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
    public partial class Form3 : Form
    {
        class RSAKeyGenerator
        {
            private static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            public static string PrivateKey
            {
                get
                {
                    return rsa.ToXmlString(true);
                }
            }

            public static string PublicKey
            {
                get
                {
                    return rsa.ToXmlString(false);
                }
            }
        }

        class RSADecrypt
        {
            public static byte[] Decrypt(byte[] dataToDecrypt, string privateKey)
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privateKey);
                    decryptedData = rsa.Decrypt(dataToDecrypt, true);
                }
                return decryptedData;
            }
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string privateKey = RSAKeyGenerator.PrivateKey;
            string str = textBox1.Text;
            byte[] encryptedMessage = Encoding.ASCII.GetBytes(str);
            byte[] decryptedMessage = RSADecrypt.Decrypt(encryptedMessage, privateKey);
            textBox2.Text = Encoding.UTF8.GetString(decryptedMessage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
