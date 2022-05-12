using System;
using System.Collections.Generic;
using System.Text;

namespace WhoWnatToBeMillioner2._1
{
    internal class Question
    {
        public string Text { get; private set; }
        public string[] Answers { get; private set; }
        public int RightAnswer { get; private set; }
        public int Level { get; private set; }
        public Question(string T, string [] A, int R, int L)
        {
            Text = T;
            Answers = A;
            RightAnswer = R;
            Level = L;
        }

    }
}
