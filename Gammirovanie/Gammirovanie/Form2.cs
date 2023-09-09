using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gammirovanie
{
    public partial class Form2 : Form
    {
        private void Shifr_Load(object sender, EventArgs e)
        {
            this.InitializeComponent();
        }
        static int GetHashCode(byte[] bytes)
        {
            int hash = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                hash = hash * 31 + bytes[i];
            }
            return hash;
        }
        public string Coding(string letter, string key)
        {
            string res = "";
            byte[] messageBytes = System.Text.Encoding.ASCII.GetBytes(letter);
            byte[] keyBytes = System.Text.Encoding.ASCII.GetBytes(key);

            // создаем генератор псевдослучайной последовательности на основе ключа
            Random random = new Random(GetHashCode(keyBytes));

            // шифруем сообщение байт в байт, используя гаммирование
            for (int i = 0; i < messageBytes.Length; i++)
            {
                byte encryptedByte = (byte)(messageBytes[i] ^ random.Next(256)); // XOR с очередным байтом гаммы
                res += encryptedByte.ToString("X2"); // добавляем зашифрованный байт в зашифрованное сообщение
            }
            return res;
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Text == "" && label3.Text == "") MessageBox.Show("Обязательно нужно запонить поля такста и ключа шифрования.");
            else label2.Text = Coding(label1.Text, label3.Text);
            
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {


        }
    }
}
