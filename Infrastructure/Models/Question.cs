using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Question
    {
        [Key]
        public int ID { get; set; }
        public string QuestionBody { get; set; }
        public List<Answer> Answers { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
