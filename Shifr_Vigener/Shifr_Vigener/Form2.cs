using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shifr_Vigener
{
    public partial class Form2 : Form
    {
        static string EU_Encrypt(string message, string key)
        {
            string result = "";

            // Приводим исходное сообщение и ключ к верхнему регистру
            message = message.ToUpper();
            key = key.ToUpper();

            int keyIndex = 0;

            // Шифруем каждую букву исходного сообщения
            foreach (char symbol in message)
            {
                if (symbol >= 'A' && symbol <= 'Z')
                {
                    // Получаем порядковый номер текущей буквы исходного сообщения
                    int messageIndex = (symbol - 'A') % 26;
                    // Получаем порядковый номер буквы ключа, которым шифруем текущую букву исходного сообщения
                    int keySymbol = (key[keyIndex] - 'A') % 26;
                    // Получаем порядковый номер зашифрованной буквы
                    int encSymbol = (messageIndex + keySymbol) % 26;
                    // Получаем символ зашифрованной буквы и добавляем ее к результату
                    result += (char)(encSymbol + 'A');
                    // Увеличиваем индекс ключа
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    // Если символ не буква, то добавляем его к результату без шифровки
                    result += symbol;
                }
            }

            return result;
        }

        static string RU_Encrypt(string message, string key)
        {
            string result = "";

            // Приводим исходное сообщение и ключ к верхнему регистру
            message = message.ToUpper();
            key = key.ToUpper();

            int keyIndex = 0;

            // Шифруем каждую букву исходного сообщения
            foreach (char symbol in message)
            {
                if (symbol >= 'А' && symbol <= 'Я')
                {
                    // Получаем порядковый номер текущей буквы исходного сообщения
                    int messageIndex = (symbol - 'А') % 32;
                    // Получаем порядковый номер буквы ключа, которым шифруем текущую букву исходного сообщения
                    int keySymbol = (key[keyIndex] - 'А') % 32;
                    // Получаем порядковый номер зашифрованной буквы
                    int encSymbol = (messageIndex + keySymbol) % 32;
                    // Получаем символ зашифрованной буквы и добавляем ее к результату
                    result += (char)(encSymbol + 'А');
                    // Увеличиваем индекс ключа
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    // Если символ не буква, то добавляем его к результату без шифровки
                    result += symbol;
                }
            }

            return result;
        }

        private bool chekText(string str1, string str2)
        {
            if (str1 == "" || str2 == "") return false;
            else return true;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > textBox1.Text.Length) MessageBox.Show("Ключ шифрования должен быть короче фразы которую вы хотите зашифровать!");
            else
            {
                if (textBox3.Text.Length > textBox1.Text.Length) MessageBox.Show("Ключ шифрования должен быть короче фразы которую вы хотите зашифровать!");
                else
                {
                    if (checkBox1.Checked && checkBox2.Checked == false)
                    {
                        if (chekText(textBox1.Text, textBox3.Text))
                            textBox2.Text = RU_Encrypt(textBox1.Text, textBox3.Text);
                        else MessageBox.Show("Заолните все необходимые данные!");
                    }
                    else if (checkBox2.Checked && checkBox1.Checked == false)
                    {
                        if (chekText(textBox1.Text, textBox3.Text))
                            textBox2.Text = EU_Encrypt(textBox1.Text, textBox3.Text);
                        else MessageBox.Show("Заолните все необходимые данные!");
                    }
                    else if (checkBox1.Checked && checkBox2.Checked) MessageBox.Show("Выберите только один язык!");
                    else MessageBox.Show("Выберите язык!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            checkBox1.Text = "Русский";
            checkBox2.Text = "English";
        }
    }
}
