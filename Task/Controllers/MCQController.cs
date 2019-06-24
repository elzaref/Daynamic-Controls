using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LogicBusiness.logic;

namespace Task.Controllers
{
    public class MCQController : Controller
    {
        private readonly ILogic _logic;
        public MCQController(ILogic logic)
        {
            _logic = logic;
        }
        public IActionResult Index()
        {
            //to view question page
            return View();
        }
        [HttpPost]
        public IActionResult Index(string[] AnswersText, string CorrectAnswer, string QuestionBody)
        {
            // when return from "Preview" page or refresh
            ViewBag.Values = JsonConvert.SerializeObject(AnswersText); // to can get data in js
            ViewBag.questionbody = QuestionBody;
            ViewBag.correctanswer = CorrectAnswer;
            return View();//to view question page
        }

        [HttpPost]
        public ActionResult Post(string[] AnswersText, string CorrectAnswer, string QuestionBody,string submitbutton)
        {
            // this post handle submit button save or preview

            ViewBag.Values = JsonConvert.SerializeObject(AnswersText);
            ViewBag.questionbody = QuestionBody;
            ViewBag.correctanswer = CorrectAnswer;
            //if this request from save button data will be saved in DB
            if (submitbutton == "Save")
            {
                _logic.SaveMCQ(AnswersText, CorrectAnswer, QuestionBody);
                return View("~/Views/MCQ/Save.cshtml");// go to save page 
            }
            
            return View("~/Views/MCQ/Preview.cshtml");//go to preview page
        }
    }

}