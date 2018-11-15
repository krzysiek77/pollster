using System.Collections;
using System.Collections.Generic;

namespace pollster.domain.Entities
{
    public class Client : Audit
    {
        public Client()
        {
            Users = new HashSet<User>();
            Surveys = new HashSet<Survey>();
        }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public bool IsActive { get; set; }
        
        public ICollection<User> Users { get; private set; }
        public ICollection<Survey> Surveys { get; private set; }
        
    }
}