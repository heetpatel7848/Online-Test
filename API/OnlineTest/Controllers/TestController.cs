using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interfaces;
using System.Security.Claims;

namespace OnlineTest.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        #region Fields
        private readonly ITestService _testService;
        #endregion

        #region Constructor
        public TestController(ITestService testService)
        {
            _testService = testService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetTestsByTechnologyId(int id)
        {
            return Ok(_testService.GetTestsByTechnologyId(id));
        }

        [HttpGet("paginated")]
        public IActionResult GetTestsPaginated(int page, int limit)
        {
            return Ok(_testService.GetTestsPaginated(page, limit));
        }

        [HttpGet("id")]
        public IActionResult GetTestById(int id)
        {
            return Ok(_testService.GetTestById(id));
        }

        [HttpPost]
        public IActionResult AddTest(AddTestDTO test)
        {
            return Ok(_testService.AddTest(test));
        }

        [HttpPut]
        public IActionResult UpdateTest(UpdateTestDTO test)
        {
            return Ok(_testService.UpdateTest(test));
        }

        [HttpDelete]
        public IActionResult DeleteTest(int id)
        {
            return Ok(_testService.DeleteTest(id));
        }

        [HttpPost("link")]
        public IActionResult AddTestLink(int testId, string email)
        {
            return Ok(_testService.AddTestLink(Convert.ToInt32(User.FindFirstValue("Id")), testId, email));
        }
        [HttpGet("link")]
        public IActionResult GetTestByLink(Guid token, string email)
        {
            return Ok(_testService.GetTestByLink(token, email));
        }

        [HttpPost("submit")]
        public IActionResult SubmitTest(AddAnswerSheetDTO answerSheet)
        {
            return Ok(_testService.SubmitTest(answerSheet));
        }
        #endregion


    }
}