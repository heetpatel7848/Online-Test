using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;

namespace OnlineTest.Services.Interfaces
{
    public interface ITechnologyService
    {
        ResponseDTO GetTechnologies();
        ResponseDTO GetTechnologyById(int id);
        ResponseDTO GetTechnologyByName(string technologyName);
        ResponseDTO GetTechnologiesPaginated(int page, int limit);
        ResponseDTO AddTechnology(AddTechnologyDTO technology);
        ResponseDTO UpdateTechnology(UpdateTechnologyDTO technology);
        ResponseDTO DeleteTechnology(int id);
    }
}