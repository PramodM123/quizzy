using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizService.Models;

namespace QuizService.Repositories
{
    public interface IQuizRepository
    {
        List<Attempt> GetAttemptsByUser(Guid userId);
        QuizDetails GetQuizDetailsByUser(Guid userId);
        Attempt GetAttemptByUserQuiz(Guid userId, Guid attemptId);
        void InsertUserAttempt(Guid userId, Attempt attempt);
        void UpdateUserAttempt(Guid userId, Attempt attempt);
        void DeleteUserAttempt(Guid userId, Guid attemptId);
    }
}
