using System;
using System.Collections.Generic;
using HeseQuiz.Domain;

namespace HeseQuiz
{
    public interface IQuiz
    {
        Guid StartQuiz();
        
        IList<Question> AddQuestion(Question question);

        bool SubmitQuiz(Guid quizId, DateTime? answerDate, IList<Answer> answerss);

        double CalucatePoints(IList<Answer> answerss);
    }
}
