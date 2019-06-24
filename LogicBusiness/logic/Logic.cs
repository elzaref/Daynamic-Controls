using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.DataStores;
using Infrastructure.Models;
using Infrastructure.Repository;

namespace LogicBusiness.logic
{
    public class Logic : ILogic
    {
        private readonly IRepository _repository;
        public Logic(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> SaveMCQ(string[] AnswersText, string CorrectAnswer, string QuestionBody)
        {
            List<Answer> answers = new List<Answer>();
            foreach (string textboxValue in AnswersText)
            {
                answers.Add(new Answer() { AnswerBody = textboxValue });
            }

            // check if question exist
            // if not save it and if exist update his answers.
            Question question = _repository.GetMCQByQuestionBody(QuestionBody).Result;

            if (question == null)
               await _repository.SaveMCQ(new Question() { QuestionBody = QuestionBody, Answers = answers, CorrectAnswer = CorrectAnswer });
            else
            {
                question.Answers = answers;
                question.CorrectAnswer = CorrectAnswer;
                await _repository.UpdateQuestion(question);
            }
            return await _repository.SaveMCQ(question);
        }
    }
}
