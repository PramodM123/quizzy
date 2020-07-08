using System;
using System.Collections.Generic;
using QuestionService.Models;

namespace QuestionService.Repositories
{
    public interface IQuestionRepository
    {
        List<Question> GetQuestions();
        Question GetQuestion(Guid questionId);
        void InsertQuestion(Question question);
        void UpdateQuestion(Question question);
        void DeleteQuestion(Guid questionId);
    }
}
