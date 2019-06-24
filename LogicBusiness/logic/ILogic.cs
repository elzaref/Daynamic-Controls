using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicBusiness.logic
{
    public interface ILogic
    {
        Task<bool> SaveMCQ(string[] AnswersText, string CorrectAnswer, string QuestionBody);
    }
}
