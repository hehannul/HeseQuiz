using System.Collections.Generic;

namespace HeseQuiz.Domain
{
    public class Question
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public QuestionType Type { get; set; }
        public int? Area { get; set; }
        public IList<MultiChoice>? MultiChoices { get; set; }
        
    }
}
