using System.Collections;
using System.Collections.Generic;

namespace pollster.domain.Entities
{
    public class Survey : Audit
    {
        public Survey()
        {
            Questions = new HashSet<Question>();
            AnswerSets = new HashSet<AnswerSet>();
        }
        public int SurveyId { get; set; }
        public int ClientId { get; set; }
        public string SurveyName { get; set; }
        public bool IsActive { get; set; }

        public Client Client { get; set; }
        public ICollection<Question> Questions { get; private set; }
        public ICollection<AnswerSet> AnswerSets { get; private set; }
    }
}