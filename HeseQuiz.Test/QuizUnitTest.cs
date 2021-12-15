using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Reflection.Emit;
using HeseQuiz.Domain;
using NSubstitute;
using Xunit;

namespace HeseQuiz.Test
{
    public class QuizUnitTest
    {
        private readonly IQuiz _quiz;

        public QuizUnitTest()
        {
            _quiz = new Quiz();
        }

        [Fact]
        public void Given_Valiad_Ansqers_WhenSubmitAnswers_Then_Except_Ok()
        {
            // Given
            var quizId = _quiz.StartQuiz();
            var answers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                    Text = "Hese",
                },
                new Answer()
                {
                    Id = 2,
                    Value = 10
                }
            };

            // When
            var status = _quiz.SubmitQuiz(quizId, DateTime.UtcNow, answers);

            // Then
            Assert.True(status);

        }

        [Fact]
        public void Given_Invaliad_TextAnsqer_WhenSubmitAnswers_Then_Except_Fail()
        {
            // Given
            var quizId = _quiz.StartQuiz();
            var answers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                    Text = "asdflksjflsjföasdöfjasödklfjsdwfwefwfwefwefwefwefwefwefwefwefwefwefwefwefwefwefwefwefwefwefwefwefwfwefwefwefwefwefwefwefwefwefwefwefwefwelkfjaslkfjasldkfjaslkdfjsaldfjalkfjiowejjsakldjfaslkdfjsldfjsldfjsldfjsldfjaslfjsldfjasldfjslkdfjasldjfaslkdfjieojfsldkfjsldkfjasldfkjeiejklsdjfiewj",
                },
                new Answer()
                {
                    Id = 2,
                    Value = 10
                }
            };

            // When
            var status = _quiz.SubmitQuiz(quizId, DateTime.UtcNow, answers);

            // Then
            Assert.False(status);

        }

        [Fact]
        public void Given_Invaliad_ValueAnsqer_WhenSubmitAnswers_Then_Except_Fail()
        {
            // Given
            var quizId = _quiz.StartQuiz();
            var answers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                    Text = "Hese",
                },
                new Answer()
                {
                    Id = 2,
                    Value = 100000
                }
            };

            // When
            var status = _quiz.SubmitQuiz(quizId, DateTime.UtcNow, answers);

            // Then
            Assert.False(status);

        }
    }
}
