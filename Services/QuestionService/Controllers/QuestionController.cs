using System;
using System.Collections.Generic;
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
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(ILogger<QuestionController> logger, IQuestionRepository repository)
        {
            _logger = logger;
            _questionRepository = repository;
        }

        /// <summary>
        /// GET api/Question/8ee9f9e3-182a-445d-8739-de9a90a714f2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Question> Get(Guid id)
        {
            var question = _questionRepository.GetQuestion(id);
            return Ok(question);
        }

        /// <summary>
        /// POST api/Question
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Question question)
        {
            _questionRepository.InsertQuestion(question);
            return CreatedAtAction(nameof(Get), new { id = question.Id }, question);
        }

        /// <summary>
        /// GET api/Question/
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Question>> GetQuestions()
        {
            var questions = _questionRepository.GetQuestions();
            return Ok(questions);
        }

        /// <summary>
        /// PUT api/Question
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put([FromBody] Question question)
        {
            if (question == null)
            {
                return new BadRequestResult();
            }
            _questionRepository.UpdateQuestion(question);
            return CreatedAtAction(nameof(Get), new { id = question.Id }, question);
        }

        /// <summary>
        /// DELETE api/Question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _questionRepository.DeleteQuestion(id);
            return Ok();
        }
    }
}
