namespace pollster.domain.Enumerations
{
    public enum QuestionResponseType
    {
        MultipleChoice_SelectOne = 1, // Yes/No is included in here! 
        Date = 2,
        NumberInt = 3, 
        NumberDec = 4, 
        NumberAny = 5,
        Image = 6,
        TextStandard = 7,
        TextCapitaliseWords = 8,
        TextWebsite = 9,
        TextEmail = 10,
        TextPhone = 11, 
        TextNoAutoCorrect = 12,
        MultipleChoice_SelectMany = 13,
        TextStandard_Large = 14
    }
}