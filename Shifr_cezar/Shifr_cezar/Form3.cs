using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shifr_cezar
{
    public partial class Form3 : Form
    {
        const string RUalfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        const string ENGalfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string reShhifr__RU(string str, int key)
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
                    return error;
                }
                else
                {
                    var codeIndex = (letterQty + index - key) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }
            return retVal;
        }

        public string reShhifr__ENG(string str, int key)
        {
            //добавляем в алфавит маленькие буквы
            var fullAlfabet = ENGalfabet + ENGalfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (c.ToString() == " ") { retVal += c.ToString(); continue; }
                var index = fullAlfabet.IndexOf(c);
                var error = "Недопустимые значения!";
                if (index < 0)
                {
                    return error;
                }
                else
                {
                    var codeIndex = (letterQty + index - key) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }
            return retVal;
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "") MessageBox.Show("Вы не указали необходимые данные!\nНужно ввести фразу и ключ.");
            else if (checkBox1.Checked == true && textBox1.Text != "" && textBox3.Text != "")
            {
                var str = textBox3.Text;
                var key = int.Parse(textBox1.Text);
                textBox4.Text = reShhifr__ENG(str, key);
            }
            else if (checkBox2.Checked == true && textBox1.Text != "" && textBox3.Text != "")
            {
                var str = textBox3.Text;
                var key = int.Parse(textBox1.Text);
                textBox4.Text = reShhifr__RU(str, key);
            }
            else MessageBox.Show("Вы не указали язык.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
    }
}