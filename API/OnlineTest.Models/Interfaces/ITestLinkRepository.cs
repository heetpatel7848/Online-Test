namespace OnlineTest.Model.Interface
{
    public interface ITestLinkRepository
    {
        TestLink GetTestLink(Guid token);
        int AddTestLink(TestLink testLink);
        bool IsTestLinkExists(int testId, int userId);
        bool UpdateTestLink(TestLink testLink);
    }
}