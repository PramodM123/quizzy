using System;
using System.Collections.Generic;

namespace QuestionService.Models
{
    public class Question
    {
        public static readonly string DocumentName = "QuestionBank";

        public Guid QuestionId { get; set; }
        public string Description { get; set; }
        public List<string> Options { get; set; }
        public string Answer { get; set; }
        public string Tag { get; set; }
    }
}
