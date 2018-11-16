using System;
using System.Collections;
using System.Collections.Generic;

namespace pollster.domain.Entities
{
    public class AnswerSet : Audit
    {
        public AnswerSet()
        {
            Answers = new HashSet<Answer>();
        }
        public int AnswerSetId { get; set; }
        public int SurveyId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }

        public Survey Survey { get; set; }
        // public User Creator { get; set; }
        public ICollection<Answer> Answers { get; private set; }

    }
}