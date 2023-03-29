namespace OnlineTest.Models.Interfaces
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> GetAnswers();
        IEnumerable<Answer> GetAnswersByQuestionId(int questionId);
        Answer GetAnswerById(int id);
        Answer AnswerExists(int testId, int questionId, string ans);
        int AddAnswer(Answer answer);
        bool UpdateAnswer(Answer answer);
        bool DeleteAnswer(Answer answer);
    }
}