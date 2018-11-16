using System.Collections;
using System.Collections.Generic;
using pollster.domain.Enumerations;

namespace pollster.domain.Entities
{
    public class Question : Audit
    {
        public Question()
        {
            PossibleAnswers = new HashSet<PossibleAnswer>();
        }
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public string QuestionText { get; set; }
        public bool IsRequired { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        public QuestionResponseType QuestionResponseType { get; set; }

        public Survey Survey { get; set; }
        public ICollection<PossibleAnswer> PossibleAnswers { get; private set; }

    }
}