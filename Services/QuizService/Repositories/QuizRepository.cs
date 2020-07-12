using MongoDB.Driver;
using QuizService.Models;
using System;
using System.Collections.Generic;

namespace QuizService.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly IMongoCollection<QuizDetails> _repository;

        public QuizRepository(IMongoDatabase db)
        {
            _repository = db.GetCollection<QuizDetails>(QuizDetails.DocumentName);
        }

        public void DeleteUserAttempt(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<Attempt> GetAttemptsByUser(Guid userId)
        {
            var quizDetails = _repository.Find(q => q.UserId == userId).FirstOrDefault();
            if (quizDetails == null)
            {
                return new List<Attempt>();
            }
            return quizDetails.Attempts;
        }

        public QuizDetails GetQuizDetailsByUser(Guid userId)
        {
            var quizDetails = _repository.Find(q => q.UserId == userId).FirstOrDefault();
            return quizDetails;
        }

        public Attempt GetAttemptByUserQuiz(Guid userId, Guid attemptId)
        {
            var quizDetails = _repository.Find(q => q.UserId == userId).FirstOrDefault();
            if (quizDetails == null)
            {
                return null;
            }
            var attempt = quizDetails.Attempts.Find(x => x.AttemptId == attemptId);
            return attempt;
        }

        public void InsertUserAttempt(Guid userId, Attempt attempt)
        {
            var quizDetails = _repository.Find(q => q.UserId == userId).FirstOrDefault();
            if (quizDetails == null)
            {
                quizDetails = new QuizDetails() { UserId = userId, TotalScore = attempt.AttemptScore, Attempts = new List<Attempt> { attempt } };
                _repository.InsertOne(quizDetails);
            }
            else
            {
                quizDetails.Attempts.Add(attempt);
                var update = Builders<QuizDetails>.Update
                    .Set(c => c.Attempts, quizDetails.Attempts);
                _repository.UpdateOne(c => c.UserId == userId, update);
            }
        }

        public void UpdateUserAttempt(Guid userId, Attempt attempt)
        {
            var quizDetails = _repository.Find(q => q.UserId == userId).FirstOrDefault();
            if (quizDetails != null)
            {
                quizDetails.Attempts.RemoveAll(a => a.AttemptId == attempt.AttemptId);
                quizDetails.Attempts.Add(attempt);
                var update = Builders<QuizDetails>.Update
                    .Set(c => c.Attempts, quizDetails.Attempts);
                _repository.UpdateOne(c => c.UserId == userId, update);
            }
        }

        public void DeleteUserAttempt(Guid userId, Guid attemptId)
        {
            var quizDetails = _repository.Find(q => q.UserId == userId).FirstOrDefault();
            if (quizDetails != null)
            {
                quizDetails.Attempts.RemoveAll(a => a.AttemptId == attemptId);
                var update = Builders<QuizDetails>.Update
                    .Set(c => c.Attempts, quizDetails.Attempts);
                _repository.UpdateOne(c => c.UserId == userId, update);
            }
        }
    }
}
