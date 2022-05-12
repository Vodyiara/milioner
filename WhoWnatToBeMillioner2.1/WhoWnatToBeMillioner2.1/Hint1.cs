using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WhoWnatToBeMillioner2._1
{
    public partial class Hint1 : Form
    {
        int t1, t2, t3, t4, v1;
        public Hint1(int i1, int i2, int i3, int i4, int v)
        {
            InitializeComponent();
            t1 = i1;    
            t2 = i2;
            t3 = i3;
                t4 = i4;
            v1 = v;
            label1.Text = "         A                                      B                                      C                                                 D";
            pictureBox1.Paint += PictureBox1_Paint;
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap pic = new Bitmap(615, 330);
            using (Graphics gr = Graphics.FromImage(pic))
            {
                //Заливаем красным цветом фон (по умолчанию он прозрачный)
              
                //Рисуем залитый прямоугольник
                if(v1 == 1)
                {
                    gr.FillRectangle(Brushes.Black, new Rectangle(5, 30 + 200-t1, 100, t1));
                    gr.FillRectangle(Brushes.Black, new Rectangle(139, 30 + 200 - t2, 100, t2));
                    gr.FillRectangle(Brushes.Black, new Rectangle(273, 30 + 200 - t3, 100, t3));
                    gr.FillRectangle(Brushes.Black, new Rectangle(400, 30 + 200 - t4, 100, t4));
                }
                else {if(v1 == 2)
                    {
                        gr.FillRectangle(Brushes.Black, new Rectangle(50, 30 + 200 - t2, 100, t2));
                        gr.FillRectangle(Brushes.Black, new Rectangle(184, 30 + 200 - t1, 100, t1));
                        gr.FillRectangle(Brushes.Black, new Rectangle(318, 30 + 200 - t4, 100, t4));
                        gr.FillRectangle(Brushes.Black, new Rectangle(452, 30 + 200 - t3, 100, t3));
                    } }
                if(v1 == 3)
                {
                    gr.FillRectangle(Brushes.Black, new Rectangle(50, 30 + 200 - t2, 100, t2));
                    gr.FillRectangle(Brushes.Black, new Rectangle(184, 30 + 200 - t3, 100, t3));
                    gr.FillRectangle(Brushes.Black, new Rectangle(318, 30 + 200 - t1, 100, t1));
                    gr.FillRectangle(Brushes.Black, new Rectangle(452, 30 + 200 - t4, 100, t4));
                }
                else
                {
                    if(v1 == 4)
                    {
                        gr.FillRectangle(Brushes.Black, new Rectangle(50, 30 + 200 - t4, 100, t4));
                        gr.FillRectangle(Brushes.Black, new Rectangle(184, 30 + 200 - t2, 100, t2));
                        gr.FillRectangle(Brushes.Black, new Rectangle(318, 30 + 200 - t3, 100, t3));
                        gr.FillRectangle(Brushes.Black, new Rectangle(452, 30 + 200 - t1, 100, t1));
                    }
                }
               
                //Рисуем обводку поверх него

            }
            //Цвет можно выбрать из стандартных, либо проинициализировать
            Color col = Color.FromArgb(20, 50, 200);
            //Чтобы создать свою кисть - можно использовать SolidBrush
            SolidBrush sb = new SolidBrush(col);
            //Карандаш - ещё прощще
            Pen pn = new Pen(col);
            //Для заливки используется кисть, а для контуров - карандаш
            //А ещё, кисти разные бывают. Например - GradientBrush.

            //Итоговый Bitmap можно воткнуть (например) в PictureBox
            pictureBox1.Image = pic;
            //Или - отрисовать где нужно
            //gr.DrawImage(pic, new Rectangle(0, 0, 150, 150));
            //Ну, или даже - сохранить в один из стандартных форматов (jpg, bmp, png):
            pic.Save("{path_to_save}");
            //Если что - формат вторым аргументом указывается.
        }
    }
}
