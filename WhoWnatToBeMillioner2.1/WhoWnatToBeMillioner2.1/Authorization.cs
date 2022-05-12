using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WhoWnatToBeMillioner2._1
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Введите никнейм!");

            }
            else
            {
                Form1 k = new Form1(textBox1.Text);
                k.Show();
                this.Close();
               
            }
        }
    }
}
