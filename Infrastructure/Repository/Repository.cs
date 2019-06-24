using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.DataStores;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class Repository : IRepository
    {
        private readonly IMCQContext _mCQContext;
        public Repository(IMCQContext mCQContext)
        {
            _mCQContext = mCQContext;
        }

        public async Task<Question> GetMCQByQuestionBody(string questionbody)
        {
            try
            {
                var question=_mCQContext.Questions.Where(q => q.QuestionBody == questionbody)
                    .Include(q=>q.Answers).FirstOrDefault();
                
                return question;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SaveMCQ(Question question)
        {
            try
            {
                _mCQContext.Questions.Add(question);
                await _mCQContext.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateQuestion(Question question)
        {
            try
            {
                var answers= _mCQContext.Answers.Where(a=>a.QuestionID==question.ID).ToList();
                _mCQContext.Answers.RemoveRange(answers);
                _mCQContext.Answers.AddRange(question.Answers);
               await _mCQContext.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
