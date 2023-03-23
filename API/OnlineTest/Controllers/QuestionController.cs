﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        #region Fields
        private readonly IQuestionService _questionService;
        #endregion

        #region Constructor
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetQuestionsByTestId(int id)
        {
            return Ok(_questionService.GetQuestionsByTestId(id));
        }

        [HttpGet("id")]
        public IActionResult GetQuestionById(int id)
        {
            return Ok(_questionService.GetQuestionById(id));
        }

        [HttpPost]
        public IActionResult AddQuestion(AddQuestionDTO question)
        {
            return Ok(_questionService.AddQuestion(question));
        }

        [HttpPut]
        public IActionResult UpdateQuestion(UpdateQuestionDTO question)
        {
            return Ok(_questionService.UpdateQuestion(question));
        }

        [HttpDelete]
        public IActionResult DeleteQuestion(int id)
        {
            return Ok(_questionService.DeleteQuestion(id));
        }
        #endregion
    }
}