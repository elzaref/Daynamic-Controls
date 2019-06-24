using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepository
    {
        Task<bool> SaveMCQ(Question question);
        Task<Question> GetMCQByQuestionBody(string questionbody);
        Task<bool> UpdateQuestion(Question question);
    }
}
