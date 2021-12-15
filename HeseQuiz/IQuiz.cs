using System;
using System.Collections.Generic;
using HeseQuiz.Domain;

namespace HeseQuiz
{
    public interface IQuiz
    {
        Guid StartQuiz();
        
        IList<Question> GetQuestions(Guid quizId, int? area);

        bool SubmitQuiz(Guid quizId, DateTime? answerDate, IList<Answer> answerss);
    }
}
