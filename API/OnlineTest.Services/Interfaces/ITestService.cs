using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;

namespace OnlineTest.Services.Interfaces
{
    public interface ITestService
    {
        ResponseDTO GetTests();
        ResponseDTO GetTestById(int id);
        ResponseDTO GetTestsPaginated(int page, int limit);
        ResponseDTO GetTestsByTechnologyId(int technologyId);
        ResponseDTO AddTest(AddTestDTO test);
        ResponseDTO UpdateTest(UpdateTestDTO test);
        ResponseDTO DeleteTest(int id);
    }
}