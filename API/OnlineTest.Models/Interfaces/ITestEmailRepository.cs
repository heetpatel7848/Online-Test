namespace OnlineTest.Model.Interface
{
    public interface ITestEmailRepository
    {
        int AddUserToTest(TestEmailLink testEmailLink);
        TestEmailLink GetTest(Guid token);
        TestEmailLink GetTest(int userId, int testId);
        bool AddSubmitOn(Guid token);
        bool AddAccessCountOn(Guid token);
    }
}