using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class TechnologyRepository : ITechnologyRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion

        #region Constructor
        public TechnologyRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public IEnumerable<Technology> GetTechnologies()
        {
            return _context.Technologies.Where(t => t.IsActive == true).ToList();
        }

        public Technology GetTechnologyById(int id)
        {
            return _context.Technologies.FirstOrDefault(t => t.Id == id && t.IsActive == true);
        }
        
        public Technology GetTechnologyByName(string technologyName)
        {
            return _context.Technologies.FirstOrDefault(t => t.TechName == technologyName && t.IsActive == true);
        }

        public IEnumerable<Technology> GetTechnologiesPaginated(int page, int limit)
        {
            return _context.Technologies.Where(t => t.IsActive == true).Skip((page - 1) * limit).Take(limit).ToList();
        }

        public int AddTechnology(Technology technology)
        {
            _context.Add(technology);
            if (_context.SaveChanges() > 0)
                return technology.Id;
            else
                return 0;
        }

        public bool UpdateTechnology(Technology technology)
        {
            _context.Entry(technology).Property("TechName").IsModified = true;
            _context.Entry(technology).Property("ModifiedBy").IsModified = true;
            _context.Entry(technology).Property("ModifiedOn").IsModified = true;
            return _context.SaveChanges() > 0;
        }

        public bool DeleteTechnology(Technology technology)
        {
            _context.Entry(technology).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}