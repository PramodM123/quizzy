using System;
using System.Collections.Generic;

namespace QuizService.Models
{
    public class QuizDetails
    {
        public static readonly string DocumentName = "quizDetails";

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int TotalScore { get; set; }
        public List<Attempt> Attempts { get; set; } = new List<Attempt>();
    }
}
