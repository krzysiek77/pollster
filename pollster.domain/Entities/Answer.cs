namespace pollster.domain.Entities
{
    public class Answer : Audit
    {
        public int AnswerId { get; set; }
        public int AnswerSetId { get; set; }
        public int PossibleAnswerId { get; set; }
        public string AnswerText { get; set; }
    }
}