using System.Collections;
using System.Collections.Generic;
using pollster.domain.Enumerations;

namespace pollster.domain.Entities
{
    public class User : Audit
    {
        public User()
        {
            Surveys = new HashSet<Survey>();
            AnswerSets = new HashSet<AnswerSet>();
        }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public UserType UserType { get; set; }
        
        public ICollection<Survey> Surveys { get; private set; }
        public ICollection<AnswerSet> AnswerSets { get; set; }
    }
}