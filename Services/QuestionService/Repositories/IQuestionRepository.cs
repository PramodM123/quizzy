using System;
using System.Collections.Generic;
using QuestionService.Models;

namespace QuestionService.Repositories
{
    public interface IQuestionRepository
    {
        List<Question> GetQuestionQuestions();
        Question GetQuestionQuestion(Guid questionId);
        void InsertQuestionQuestion(Question question);
        void UpdateQuestionQuestion(Question question);
        void DeleteQuestionQuestion(Guid questionId);
    }
}
