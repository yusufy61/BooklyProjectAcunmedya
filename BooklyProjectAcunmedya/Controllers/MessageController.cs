using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectAcunmedya.Data;
using BooklyProjectAcunmedya.Entities;

namespace BooklyProjectAcunmedya.Controllers
{
    public class MessageController : Controller
    {
        BooklyContext context = new BooklyContext();
        public ActionResult Index(string searchText)
        {
            var messages = new List<Message>();

            if(string.IsNullOrEmpty(searchText))
            {
                messages = context.Messages.ToList();
                return View(messages);
            }
            else
            {
                messages = context.Messages
                    .Where( x => x.Name.Contains(searchText) || x.Subject.Contains(searchText))
                    .ToList();
                return View(messages);
            }
        }

        [HttpGet]
        public ActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMessage(Message message)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Lütfen tüm alanları doldurunuz");
                return View(message);
            }
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdataMessage(int id)
        {
            var message = context.Messages.Find(id);
            return View(message);
        }

        [HttpPost]
        public ActionResult UpdateMessage(Message message)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "lütfen tüm alanları doldurunuz");
                return View(message);
            }
            var updatedMessage = context.Messages.Find(message.MessageId);
            updatedMessage.Name = message.Name;
            updatedMessage.Subject = message.Subject;
            updatedMessage.Email = message.Email;
            updatedMessage.MessageContent = message.MessageContent;

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteMessage(int id)
        {
            var message = context.Messages.Find(id);
            context.Messages.Remove(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}