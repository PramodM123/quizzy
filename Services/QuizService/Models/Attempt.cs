using System;
using System.Collections.Generic;

namespace QuizService.Models
{
    public class Attempt
    {
        public Guid AttemptId { get; set; }
        public int AttemptScore { get; set; }
    }
}
