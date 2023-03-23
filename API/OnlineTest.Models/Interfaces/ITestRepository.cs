namespace OnlineTest.Models.Interfaces
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetTests();
        Test GetTestById(int id);
        IEnumerable<Test> GetTestsPaginated(int page, int limit);
        IEnumerable<Test> GetTestsByTechnologyId(int technologyId);
        bool IsTestExists(int technologyId, string testName);
        int AddTest(Test test);
        bool UpdateTest(Test test);
        bool DeleteTest(Test test);
    }
}