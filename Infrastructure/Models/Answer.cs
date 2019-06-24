using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Answer
    {
        [Key]
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public string AnswerBody { get; set; }
    }
}
