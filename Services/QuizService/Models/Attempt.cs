using System;
using System.Collections.Generic;

namespace QuizService.Models
{
    public class Attempt
    {
        public Guid Id { get; set; }
        public List<string> Answers { get; set; }
        public int AttemptScore { get; set; }
    }
}
