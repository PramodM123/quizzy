using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuestionService.Models;
using QuestionService.Repositories;

namespace QuestionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IQuestionRepository _QuestionRepository;

        public QuestionController(ILogger<QuestionController> logger, IQuestionRepository repository)
        {
            _logger = logger;
            _QuestionRepository = repository;
        }

        /// <summary>
        /// GET api/Question/8ee9f9e3-182a-445d-8739-de9a90a714f2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Question> Get(Guid id)
        {
            var QuestionQuestion = _QuestionRepository.GetQuestionQuestion(id);
            return Ok(QuestionQuestion);
        }

        /// <summary>
        /// POST api/Question
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Question question)
        {
            _QuestionRepository.InsertQuestionQuestion(question);
            return CreatedAtAction(nameof(Get), new { id = question.QuestionId }, question);
        }
    }
}
