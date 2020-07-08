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

        public void DeleteQuestion(Guid questionId)
        {
            _repository.DeleteOne(q => q.Id == questionId);
        }

        public Question GetQuestion(Guid questionId)
        {
            return _repository.Find(q => q.Id == questionId).FirstOrDefault();
        }

        public List<Question> GetQuestions()
        {
            return _repository.Find(FilterDefinition<Question>.Empty).ToList();
        }

        public void InsertQuestion(Question question)
        {
            question.Id = Guid.NewGuid(); //auto-generating id to avoid conflicts
            _repository.InsertOne(question);
        }

        public void UpdateQuestion(Question question)
        {
            _repository.UpdateOne(q => q.Id == question.Id, Builders<Question>.Update
                .Set(q => q.Answer, question.Answer)
                .Set(q => q.Description, question.Description)
                .Set(q => q.Options, question.Options)
                .Set(q => q.Tag, question.Tag));
        }
    }
}
