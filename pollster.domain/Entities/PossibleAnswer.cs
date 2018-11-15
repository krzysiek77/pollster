using System.Collections.Generic;

namespace pollster.domain.Entities
{
    public class PossibleAnswer
    {
        public PossibleAnswer()
        {
            Answers = new HashSet<Answer>();
        }
        public int PossibleAnswerId { get; set; }
        public string PossibleAnswerText { get; set; }
        public int QuestionId { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}