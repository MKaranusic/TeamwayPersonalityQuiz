using Microsoft.AspNetCore.Mvc;
using TeamwayPersonalityQuiz.DataAccess.Entities;
using TeamwayPersonalityQuiz.DTOs;
using TeamwayPersonalityQuiz.Services.Interfaces;

namespace TeamwayPersonalityQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IResultService _resultService;
        public QuestionController(IQuestionService questionService, IResultService resultService)
        {
            _questionService = questionService;
            _resultService = resultService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Question>>> GetQuestionsAsync()
        {
            var result = await _questionService.GetQuestions();
            return Ok(result.Select(QuestionDTO.Select).ToList());
        }

        [HttpGet]
        [Route("{score}")]
        public async Task<ActionResult<string>> GetQuizResultAsync(int score)
        {
            var result = await _resultService.CheckPersonality(score);
            return Ok(result);
        }
    }
}
