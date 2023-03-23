using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public UserRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Where(u => u.IsActive == true).ToList();
        }
        
        public IEnumerable<User> GetUsersPaginated(int page, int limit)
        {
            return _context.Users.Where(u => u.IsActive == true).Skip((page - 1) * limit).Take(limit).ToList();
        }
        
        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id && u.IsActive == true);
        }
        
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.IsActive == true);
        }

        public int AddUser(User user)
        {
            _context.Add(user);
            if (_context.SaveChanges() > 0)
                return user.Id;
            else
                return 0;
        }

        public bool UpdateUser(User user)
        {
            _context.Entry(user).Property("Name").IsModified = true;
            _context.Entry(user).Property("MobileNo").IsModified = true;
            _context.Entry(user).Property("Email").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public bool DeleteUser(User user)
        {
            _context.Entry(user).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}