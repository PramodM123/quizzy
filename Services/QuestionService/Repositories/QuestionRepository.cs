using MongoDB.Driver;
using QuestionService.Models;
using System;
using System.Collections.Generic;

namespace QuestionService.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IMongoCollection<Question> _repository;

        public QuestionRepository(IMongoDatabase db)
        {
            _repository = db.GetCollection<Question>(Question.DocumentName);
        }

        public void DeleteQuestionQuestion(Guid questionId)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestionQuestion(Guid questionId)
        {
            return _repository.Find(x => x.Id == questionId).FirstOrDefault();
        }

        public List<Question> GetQuestionQuestions()
        {
            throw new NotImplementedException();
        }

        public void InsertQuestionQuestion(Question question)
        {
            _repository.InsertOne(question);
        }

        public void UpdateQuestionQuestion(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
