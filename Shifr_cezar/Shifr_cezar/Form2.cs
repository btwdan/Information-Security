using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shifr_cezar
{
    public partial class Form2 : Form
    {
        const string RUalfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        const string ENGalfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string Shhifr__RU(string str, int key)
        {
            //добавляем в алфавит маленькие буквы
            var fullAlfabet = RUalfabet + RUalfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            var error = "Недопустимые значения!";
            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (c.ToString() == " ") { retVal += c.ToString(); continue; }
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    //если символ не найден то выводим ошибку
                    return error;
                }
                else
                {
                    var codeIndex = (letterQty + index + key) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }
            return retVal;
        }

        public string Shhifr__ENG(string str, int key)
        {
            //добавляем в алфавит маленькие буквы
            var fullAlfabet = ENGalfabet + ENGalfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            var error = "Недопустимые значения!";
            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (c.ToString() == " ") { retVal += c.ToString(); continue; }
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    //если мы встретили непонятный символ
                    return error;
                }
                else
                {
                    var codeIndex = (letterQty + index + key) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }
            return retVal;
        }


        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == true) MessageBox.Show("Выберите только один язык!");
            else
            {
                if (textBox1.Text == "" || textBox3.Text == "") MessageBox.Show("Вы не указали необходимые данные!\nНужно ввести фразу и ключ.", "Ошибка");
                else if (checkBox1.Checked == true && textBox1.Text != "" && textBox3.Text != "")
                {
                    var str = textBox1.Text;
                    var key = int.Parse(textBox3.Text);
                    textBox2.Text = Shhifr__ENG(str, key);
                }
                else if (checkBox2.Checked == true && textBox1.Text != "" && textBox3.Text != "")
                {
                    var str = textBox1.Text;
                    var key = int.Parse(textBox3.Text);
                    textBox2.Text = Shhifr__RU(str, key);
                }
                else if (checkBox1.Checked == true && checkBox2.Checked == true) MessageBox.Show("Выберите только один язык!");
                else MessageBox.Show("Вы не указали язык.", "Ошибка");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
