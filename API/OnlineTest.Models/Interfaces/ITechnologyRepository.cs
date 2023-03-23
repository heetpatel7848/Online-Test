namespace OnlineTest.Models.Interfaces
{
    public interface ITechnologyRepository
    {
        IEnumerable<Technology> GetTechnologies();
        Technology GetTechnologyById(int id);
        Technology GetTechnologyByName(string technologyName);
        IEnumerable<Technology> GetTechnologiesPaginated(int page, int limit);
        int AddTechnology(Technology technology);
        bool UpdateTechnology(Technology technology);
        bool DeleteTechnology(Technology technology);
    }
}