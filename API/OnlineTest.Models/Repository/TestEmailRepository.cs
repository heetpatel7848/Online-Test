using OnlineTest.Model.Interface;
using OnlineTest.Models;

namespace OnlineTest.Model.Repository
{
    public class TestEmailRepository : ITestEmailRepository
    {
        private readonly OnlineTestContext _context;
        public TestEmailRepository(OnlineTestContext context)
        {
            _context = context;
        }

        public bool AddAccessCountOn(Guid token)
        {
            var data = _context.TestEmailLinks.Where(i => i.Token == token).FirstOrDefault();
            if (data.AccessOn == null)
                data.AccessOn = DateTime.UtcNow;
            data.LastAccessOn = DateTime.UtcNow;
            data.AccessCount++;
            _context.Entry(data).Property("AccessOn").IsModified = true;
            _context.Entry(data).Property("AccessCount").IsModified = true;
            _context.Entry(data).Property("LastAccessOn").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public bool AddSubmitOn(Guid token)
        {
            var data = _context.TestEmailLinks.Where(i => i.Token == token).FirstOrDefault();
            data.SubmitedOn = DateTime.UtcNow;
            _context.Entry(data).Property("SubmitedOn").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public int AddUserToTest(TestEmailLink testEmailLink)
        {
            _context.Add(testEmailLink);
            if (_context.SaveChanges() > 0)
                return testEmailLink.Id;
            return 0;
        }

        public TestEmailLink GetTest(Guid token)
        {
            return _context.TestEmailLinks.Where(i => i.Token == token && i.Active).FirstOrDefault();
        }

        public TestEmailLink GetTest(int userId, int testId)
        {
            return _context.TestEmailLinks.Where(i => i.TestId == testId && i.UserId == userId && i.Active).FirstOrDefault();
        }
    }
}