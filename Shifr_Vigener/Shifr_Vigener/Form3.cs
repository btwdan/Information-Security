using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shifr_Vigener
{
    public partial class Form3 : Form
    {
        static string EU_Decrypt(string message, string key)
        {
            string result = "";

            // Приводим зашифрованное сообщение и ключ к верхнему регистру
            message = message.ToUpper();
            key = key.ToUpper();

            int keyIndex = 0;

            // Расшифровываем каждую букву зашифрованного сообщения
            foreach (char symbol in message)
            {
                if (symbol >= 'A' && symbol <= 'Z')
                {
                    // Получаем порядковый номер текущей буквы зашифрованного сообщения
                    int messageIndex = (symbol - 'A') % 26;
                    // Получаем порядковый номер буквы ключа, которым расшифровываем текущую букву зашифрованного сообщения
                    int keySymbol = (key[keyIndex] - 'A') % 26;
                    // Получаем порядковый номер расшифрованной буквы
                    int decSymbol = (messageIndex - keySymbol + 26) % 26;
                    // Получаем символ расшифрованной буквы и добавляем ее к результату
                    result += (char)(decSymbol + 'A');
                    // Увеличиваем индекс ключа
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    // Если символ не буква, то добавляем его к результату без расшифровки
                    result += symbol;
                }
            }

            return result;
        }
        static string RU_Decrypt(string message, string key)
        {
            string result = "";

            // Приводим зашифрованное сообщение и ключ к верхнему регистру
            message = message.ToUpper();
            key = key.ToUpper();

            int keyIndex = 0;

            // Расшифровываем каждую букву зашифрованного сообщения
            foreach (char symbol in message)
            {
                if (symbol >= 'А' && symbol <= 'Я')
                {
                    // Получаем порядковый номер текущей буквы зашифрованного сообщения
                    int messageIndex = (symbol - 'А') % 32;
                    // Получаем порядковый номер буквы ключа, которым расшифровываем текущую букву зашифрованного сообщения
                    int keySymbol = (key[keyIndex] - 'А') % 32;
                    // Получаем порядковый номер расшифрованной буквы
                    int decSymbol = (messageIndex - keySymbol + 32) % 32;
                    // Получаем символ расшифрованной буквы и добавляем ее к результату
                    result += (char)(decSymbol + 'А');
                    // Увеличиваем индекс ключа
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    // Если символ не буква, то добавляем его к результату без расшифровки
                    result += symbol;
                }
            }

            return result;
        }
        public Form3()
        {
            InitializeComponent();
        }

        public bool checkText(string str1, string str2)
        {
            if (str1 == "" || str2 == "") return false;
            else return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > textBox1.Text.Length) MessageBox.Show("Ключ шифрования должен быть короче фразы которую вы хотите расшифровать!");
            else
            {
                if (textBox3.Text.Length > textBox1.Text.Length) MessageBox.Show("Ключ шифрования должен быть короче фразы которую вы хотите расшифровать!");
                else
                {
                    if (checkBox1.Checked && checkBox2.Checked == false)
                    {
                        if (checkText(textBox1.Text, textBox3.Text))
                            textBox2.Text = RU_Decrypt(textBox1.Text, textBox3.Text);
                        else MessageBox.Show("Заолните все необходимые данные!");
                    }
                    else if (checkBox2.Checked && checkBox1.Checked == false)
                    {
                        if (checkText(textBox1.Text, textBox3.Text))
                            textBox2.Text = EU_Decrypt(textBox1.Text, textBox3.Text);
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

        private void Form3_Load(object sender, EventArgs e)
        {
            checkBox1.Text = "Русский";
            checkBox2.Text = "English";
        }
    }
}
