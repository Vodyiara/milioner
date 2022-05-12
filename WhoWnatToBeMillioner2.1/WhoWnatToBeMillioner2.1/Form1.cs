
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoWnatToBeMillioner2._1
{
    public partial class Form1 : Form
    {
        List<Question> questions = new List<Question>();
        string nikname;
        private Random rnd = new Random();
        int level = 0;
        int nesgor = -1;
        int sum;

      
        Question currentQuestion;

        public Form1( string Nik)
        {
            InitializeComponent();
            nikname = Nik;
            label6.Text = "Игрок:  " + Nik;
            //string sqlExpression = @"CREATE TABLE table1
            //                    (Nikname TEXT NOT NULL,
            //                     Sco//                    )";
            //using (var connection = new SqliteConnection("Data Source=vadimik.db"))
            //{
            //    connection.Open();

            //    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            //    command.ExecuteNonQuery();
            //    MessageBox.Show("Таблица Files  создана");
            //}re INTEGER NOT NULL
            


            //using (var connection = new SqliteConnection("Data Source=filesdata.db"))
            //{
            //    connection.Open();

            //    SqliteCommand command = new SqliteCommand();
            //    command.Connection = connection;
            //    command.CommandText = @"INSERT INTO Files (Title, FileName, ImageData)
            //                            VALUES (@FileName, @Title, @ImageData)";
            //    command.Parameters.Add(new SqliteParameter("@FileName", shortFileName));
            //    command.Parameters.Add(new SqliteParameter("@Title", title));
            //    command.Parameters.Add(new SqliteParameter("@ImageData", imageData));
            //    int number = command.ExecuteNonQuery();
            //    Console.WriteLine($"Добавлено объектов: {number}");
            //}





            label1.Text = "A";
            label2.Text = "B";
            label3.Text = "C";
            label4.Text = "D";
            ReadFile();
            startGame();

        }

        private void ReadFile()
        {
            string sql = "SELECT * FROM Files";

            using (var connection = new SqliteConnection("Data Source=filesdata4.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(sql, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            string text = reader.GetString(0);
                            string a1 = reader.GetString(1);
                            string a2 = reader.GetString(2);
                            string a3 = reader.GetString(3);
                            string a4 = reader.GetString(4);

                            int v = reader.GetInt32(5);
                            int h = reader.GetInt32(6);
                            string[] ans = new string[4] { a1, a2, a3, a4 };

                            questions.Add(new Question(text, ans, v, h));




                        }
                    }

                }
            }


            




        }

        private void ShowQuestion(Question q)
        {
            lblQuestion.Text = q.Text;
            btnAnswerA.Text = q.Answers[0];
            btnAnswerB.Text = q.Answers[1];
            btnAnswerC.Text = q.Answers[2];
            btnAnswerD.Text = q.Answers[3];
        }

        private Question GetQuestion(int level)
        {
            var questionsWithLevel = questions.Where(q => q.Level == level).ToList();
            return questionsWithLevel[rnd.Next(questionsWithLevel.Count)];
        }

        private void NextStep()
        {
            Button[] btns = new Button[] { btnAnswerA, btnAnswerB,
btnAnswerC, btnAnswerC };

            foreach (Button btn in btns)
                btn.Enabled = true;

            level++;
            currentQuestion = GetQuestion(level);
            ShowQuestion(currentQuestion);
            lstLevel.SelectedIndex = lstLevel.Items.Count - level;
        }

        private void startGame()
        {

            Zapiss();
            lstLevel.Enabled = true;
            nesgor = 0;
            button1.Enabled = true;
            button1.BackgroundImage = WhoWnatToBeMillioner2._1.Properties.Resources._50_50_blank ;
            button2.Enabled = true;
            button2.BackgroundImage = WhoWnatToBeMillioner2._1.Properties.Resources.zamenaкопия;
            button3.Enabled = true;
            button3.BackgroundImage = WhoWnatToBeMillioner2._1.Properties.Resources.zalкопия;
            button4.Enabled = true;
            button4.BackgroundImage = WhoWnatToBeMillioner2._1.Properties.Resources.telephonrкопия;
            label5.Text = "Несгораемая сумма :  ";
            level = 0;
            NextStep();
   
        }

        private void btnAnswerA_Click(object sender, EventArgs e)
        {
            if (nesgor == 0) { MessageBox.Show("Выберите несогораемую сумму!"); }
            else
            {
                Button button = (Button)sender;
                if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                    NextStep();
                else
                {
                    MessageBox.Show("Неверный ответ! К сожалению, вы поигрываете");
                    string t = lstLevel.Items[lstLevel.Items.Count - level].ToString();
                    t = t.Replace(" ", "");
                   int  p = Convert.ToInt32(t);
                    if ( p  < nesgor)
                    {
                        MessageBox.Show("Ваш выйгрышь сотавил 0 рублей");
                        sum = 0;
                    }
                    else
                    {
                        MessageBox.Show("Ваш выйгршь составил "+ nesgor);
                        sum = nesgor;
                    }
                    

                    using (var connection = new SqliteConnection("Data Source=vadimik.db"))
                    {
                        connection.Open();

                        SqliteCommand command = new SqliteCommand();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO table1 (Nikname, Score) VALUES (@N, @S)";
                        command.Parameters.Add(new SqliteParameter("@N", nikname));
                        command.Parameters.Add(new SqliteParameter("@S", sum));
                         command.ExecuteNonQuery();

                       
                    }

                    string message = "Вы хотите сыграть еще раз?";
                    
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message,"" ,buttons);
                    if (result == DialogResult.Yes)
                    {
                        Zapiss();
                        startGame();
                    }
                    else
                    {
                        Authorization k = new Authorization();
                        k.Show();
                        this.Close();

                    }
                  

                  
                }
            }

        }

        private void btnAnswerB_Click(object sender, EventArgs e)
        {
            if (nesgor == 0) { MessageBox.Show("Выберите несогораемую сумму!"); }
            else
            {
                Button button = (Button)sender;
                if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                    NextStep();
                else
                {
                    MessageBox.Show("Неверный ответ! К сожалению, вы поигрываете");
                    string t = lstLevel.Items[lstLevel.Items.Count - level].ToString();
                    t = t.Replace(" ", "");
                    int p = Convert.ToInt32(t);
                    if (p < nesgor)
                    {
                        MessageBox.Show("Ваш выйгрышь сотавил 0 рублей");
                        sum = 0;
                    }
                    else
                    {
                        MessageBox.Show("Ваш выйгршь составил " + nesgor);
                        sum = nesgor;
                    }
                    using (var connection = new SqliteConnection("Data Source=vadimik.db"))
                    {
                        connection.Open();

                        SqliteCommand command = new SqliteCommand();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO table1 (Nikname, Score) VALUES (@N, @S)";
                        command.Parameters.Add(new SqliteParameter("@N", nikname));
                        command.Parameters.Add(new SqliteParameter("@S", sum));
                        command.ExecuteNonQuery();


                    }

                    string message = "Вы хотите сыграть еще раз?";

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, "", buttons);
                    if (result == DialogResult.Yes)
                    {
                        Zapiss();
                        startGame();
                    }
                    else
                    {
                        Authorization k = new Authorization();
                        k.Show();
                        this.Close();
                    }

                   
                }
            }

        }

        private void btnAnswerC_Click(object sender, EventArgs e)
        {
            if (nesgor == 0) { MessageBox.Show("Выберите несогораемую сумму!"); }
            else
            {
                Button button = (Button)sender;
                if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                    NextStep();
                else
                {
                    MessageBox.Show("Неверный ответ! К сожалению, вы поигрываете");
                    string t = lstLevel.Items[lstLevel.Items.Count - level].ToString();
                    t = t.Replace(" ", "");
                    int p = Convert.ToInt32(t);
                    if (p < nesgor)
                    {
                        MessageBox.Show("Ваш выйгрышь сотавил 0 рублей");
                        sum = 0;
                    }
                    else
                    {
                        MessageBox.Show("Ваш выйгршь составил " + nesgor);
                        sum = nesgor;
                    }
                    using (var connection = new SqliteConnection("Data Source=vadimik.db"))
                    {
                        connection.Open();

                        SqliteCommand command = new SqliteCommand();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO table1 (Nikname, Score) VALUES (@N, @S)";
                        command.Parameters.Add(new SqliteParameter("@N", nikname));
                        command.Parameters.Add(new SqliteParameter("@S", sum));
                        command.ExecuteNonQuery();


                    }

                    string message = "Вы хотите сыграть еще раз?";

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, "", buttons);
                    if (result == DialogResult.Yes)
                    {
                        Zapiss();
                        startGame();
                    }
                    else
                    {
                        Authorization k = new Authorization();
                        k.Show();
                        this.Close();
                    }

                   
                }
            }

        }

        private void btnAnswerD_Click(object sender, EventArgs e)
        {
            if (nesgor == 0) { MessageBox.Show("Выберите несогораемую сумму!"); }
            else
            {
                Button button = (Button)sender;
                if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                    NextStep();
                else
                {
                    MessageBox.Show("Неверный ответ! К сожалению, вы поигрываете");
                    string t = lstLevel.Items[lstLevel.Items.Count - level].ToString();
                    t = t.Replace(" ", "");
                    int p = Convert.ToInt32(t);
                    if (p < nesgor)
                    {
                        MessageBox.Show("Ваш выйгрышь сотавил 0 рублей");
                        sum = 0;
                    }
                    else
                    {
                        MessageBox.Show("Ваш выйгршь составил " + nesgor);
                        sum = nesgor;
                    }
                    using (var connection = new SqliteConnection("Data Source=vadimik.db"))
                    {
                        connection.Open();

                        SqliteCommand command = new SqliteCommand();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO table1 (Nikname, Score) VALUES (@N, @S)";
                        command.Parameters.Add(new SqliteParameter("@N", nikname));
                        command.Parameters.Add(new SqliteParameter("@S", sum));
                        command.ExecuteNonQuery();


                    }

                    string message = "Вы хотите сыграть еще раз?";

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, "", buttons);
                    if (result == DialogResult.Yes)
                    {
                        Zapiss();
                        startGame();
                    }
                    else
                    {
                        Authorization k = new Authorization();
                        k.Show();
                        this.Close();
                    }
                   
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nesgor == 0) { MessageBox.Show("Выберите несогораемую сумму!"); }
            else
            {
                Button[] btns = new Button[] { btnAnswerA, btnAnswerB,
                btnAnswerC, btnAnswerC };

                int count = 0;
                while (count < 2)
                {
                    int n = rnd.Next(4);
                    int answer = int.Parse(btns[n].Tag.ToString());

                    if (answer != currentQuestion.RightAnswer && btns[n].Enabled)
                    {
                        btns[n].Enabled = false;

                        count++;
                    }
                }
                button1.Enabled = false;
                if(button1.Enabled == false)
                {
                    button1.BackgroundImage = WhoWnatToBeMillioner2._1.Properties.Resources._50_50_blanker;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nesgor == 0) { MessageBox.Show("Выберите несогораемую сумму!"); }
            else
            {
                Button[] btns = new Button[] { btnAnswerA, btnAnswerB,
btnAnswerC, btnAnswerD };

                foreach (Button btn in btns)


                    currentQuestion = GetQuestion(level);
                ShowQuestion(currentQuestion);
                lstLevel.SelectedIndex = lstLevel.Items.Count - level;
                button2.Enabled = false;
                button2.BackgroundImage = WhoWnatToBeMillioner2._1.Properties.Resources.zamena;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nesgor == 0) { MessageBox.Show("Выберите несогораемую сумму!"); }
            else
            {
                int p1 = 200 - currentQuestion.Level * 10;
                int p2 = p1 - p1 / 2;
                int p3 = p2 - p2 / 2;
                int p4 = p2 - p3 / 2;
                Hint1 k = new Hint1(p1, p2, p3, p4, currentQuestion.RightAnswer);
                k.Show();
                button3.Enabled = false;
                button3.BackgroundImage = WhoWnatToBeMillioner2._1.Properties.Resources.zal;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (nesgor == 0) { MessageBox.Show("Выберите несогораемую сумму!"); }
            else
            {
                Hint2 t = new Hint2(currentQuestion.RightAnswer);
                t.Show();
                button4.Enabled = false;
            }
            button4.BackgroundImage = WhoWnatToBeMillioner2._1.Properties.Resources.telephonr;
        }

        private void Nesgor(object sender, MouseEventArgs e)
        {

           string u = lstLevel.SelectedItem.ToString();
            if (u == "0") { MessageBox.Show("Такую сумму поставить нельзя!"); }
            else
            {
                label5.Text = "Несгораемая сумма :   " + u;

                u = u.Replace(" ", "");
                nesgor = Convert.ToInt32(u);
                lstLevel.Enabled = false;
            }
         



        }

        private void button5_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотиет забрать деньги?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, "", buttons);
            if (result == DialogResult.Yes)
            {
                string t = lstLevel.Items[lstLevel.Items.Count - level ].ToString();
                t = t.Replace(" ", "");
                int p = Convert.ToInt32(t);
                sum = p;
                if (p == 0) { MessageBox.Show("Вы уходите ни с чем! "); }
                else
                {

                    MessageBox.Show("Поздравляю! Ваш выйгрышь составил " + t+" Спасибо за игру!");

                    using (var connection = new SqliteConnection("Data Source=vadimik.db"))
                    {
                        connection.Open();

                        SqliteCommand command = new SqliteCommand();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO table1 (Nikname, Score) VALUES (@N, @S)";
                        command.Parameters.Add(new SqliteParameter("@N", nikname));
                        command.Parameters.Add(new SqliteParameter("@S", sum));
                        command.ExecuteNonQuery();
                        this.Close();
                        Authorization i = new Authorization();
                        i.Show();

                    }
                }

                Zapiss();
            }
            else
            {
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Zapiss()
        {
            string sql1 = "SELECT * FROM table1  ORDER BY Score DESC";

            using (var connection1 = new SqliteConnection("Data Source=vadimik.db"))
            {
                connection1.Open();

                SqliteCommand command = new SqliteCommand(sql1, connection1);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            if (dataGridView1.Rows.Count > 10) { break; }
                            dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1));

                        }
                    }

                }
            }
        }
    }
}
