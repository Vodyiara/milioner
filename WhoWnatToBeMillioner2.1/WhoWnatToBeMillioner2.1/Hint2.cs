using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WhoWnatToBeMillioner2._1
{
    public partial class Hint2 : Form
    {
        int k1,i,j,y ;
        string text;
        public Hint2(int k)
        {
            InitializeComponent();
         k1 = k;
            if(k1 == 1)
            {
                text = "A";
            }
            if (k1 == 2)
            {
                text = "B";
            }
            if (k1 == 3)
            {
                text = "C";
            }
            if (k1 == 4)
            {
                text = "D";
            }
            Random n = new Random();
             i = n.Next(1, 5);
             j = n.Next(1, 5);
            y = n.Next(1, 5);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (i ==1 || j==1 || y == 1)
            {
                MessageBox.Show("Я думаю правильный ответ "+ text);
            }
            else
            {
                MessageBox.Show("Я думаю правильный ответ" + (char)rand.Next('A', 'D' ));
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (i == 2 || j == 2 || y == 2)
            {
                MessageBox.Show("Сложный вопрос, но я знаю, что ответ " + text);
            }
            else
            {
                MessageBox.Show("Наверное ответ" + (char)rand.Next('A', 'D'));
            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (i == 3 || j == 3 || y == 3)
            {
                MessageBox.Show("Я слышал об этом правилный ответ " + text);
            }
            else
            {
                MessageBox.Show("Точно не знаю, предопложу что " + (char)rand.Next('A', 'D'));
            }
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (i == 4 || j == 4 || y == 4)
            {
                MessageBox.Show("Тыыы дыщщ, ответ  " + text);
            }
            else
            {
                MessageBox.Show("Не ребятушки, ответа я не знаю " );
            }
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (i == 5 || j == 5 || y == 5)
            {
                MessageBox.Show("Да, нам сказали, правильный ответ " + text);
            }
            else
            {
                MessageBox.Show("Точно не знаю, предопложу что " + (char)rand.Next('A', 'D'));
            }
            this.Close();
        }
    }
}
