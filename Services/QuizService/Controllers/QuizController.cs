using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizService.Models;
using QuizService.Repositories;

namespace QuizService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly ILogger<QuizController> _logger;
        private readonly IQuizRepository _quizRepository;

        public QuizController(ILogger<QuizController> logger, IQuizRepository repository)
        {
            _logger = logger;
            _quizRepository = repository;
        }

        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public ActionResult<QuizDetails> Get(Guid userId)
        {
            var details = _quizRepository.GetQuizDetailsByUser(userId);
            return Ok(details);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpPost("{userId}")]
        public ActionResult Post(Guid userId, [FromBody] Attempt attempt)
        {
            _quizRepository.InsertUserAttempt(userId, attempt);
            return Ok(userId);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet("{userId}/attempts")]
        public ActionResult<IEnumerable<QuizDetails>> GetQuestions(Guid userId)
        {
            var attempts = _quizRepository.GetAttemptsByUser(userId);
            return Ok(attempts);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpPut("{userId}")]
        public ActionResult Put(Guid userId, [FromBody] Attempt attempt)
        {
            if (attempt == null)
            {
                return new BadRequestResult();
            }
            _quizRepository.UpdateUserAttempt(userId, attempt);
            return Ok(userId);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{userId}/{attemptId}")]
        public ActionResult Delete(Guid userId, Guid attemptId)
        {
            _quizRepository.DeleteUserAttempt(userId, attemptId);
            return Ok();
        }
    }
}
