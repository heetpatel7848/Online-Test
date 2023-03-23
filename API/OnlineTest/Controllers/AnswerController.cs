using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerController : ControllerBase
    {
        #region Fields
        private readonly IAnswerService _answerService;
        #endregion

        #region Constructor
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetAnswers()
        {
            return Ok(_answerService.GetAnswers());
        }

        [HttpPost]
        public IActionResult AddAnswer(AddAnswerDTO answer)
        {
            return Ok(_answerService.AddAnswer(answer));
        }

        [HttpPut]
        public IActionResult UpdateAnswer(UpdateAnswerDTO answer)
        {
            return Ok(_answerService.UpdateAnswer(answer));
        }
        #endregion
    }
}