using HeseQuiz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseQuiz
{
    public class Quiz : IQuiz
    {
        private IList<Question> _questions;

        public Quiz()
        {
            _questions = new List<Question>();
        }

        public IList<Question> AddQuestion(Question question)
        {
            _questions.Add(question);
            return _questions;
        }

        public Guid StartQuiz()
        {
            _questions.Clear();
            return Guid.NewGuid();
        }

        public bool SubmitQuiz(Guid quizId, DateTime? answerDate, IList<Answer> answerss)
        {
            var id = quizId;
            foreach (var answer in answerss)
            {
                if (answer.Value > 10000)
                {
                    return false;
                }

                if (!string.IsNullOrEmpty(answer.Text) && answer.Text.Length > 256)
                {
                    return false;
                }
            }

            return true;
        }

        public double CalucatePoints(IList<Answer> answerss)
        {
            var points = 0;
            foreach (var answers in answerss)
            {
                if (answers.Points.HasValue)
                {
                    points += answers.Points.Value;
                }
            }

            return points;
        }
    }
}
