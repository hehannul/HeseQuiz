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
        public IList<Question> GetQuestions(Guid quizId, int? area)
        {
            return new List<Question>()
            {
                new Question()
                {
                    Id = 1,
                    Type = QuestionType.Number,
                    Text = "Age"
                },
                new Question()
                {
                    Id = 2,
                    Type = QuestionType.Text,
                    Text = "Name"
                }
            };
        }

        public Guid StartQuiz()
        {
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
    }
}
