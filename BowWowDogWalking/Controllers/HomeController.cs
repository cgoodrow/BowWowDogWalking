using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BowWowDogWalking.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BowWowDogWalking.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _ContactPartial(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Name: {0}</p> <p>Email: {1}</p> <p> Phone: {2} </p> <p>Address: {3} </p> <p>Schedule Date: {4}</p> <p>Hour: {5}</p> <p>Half Hour: {6}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("jessicamclark1988@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("jessicamclark1988@gmail.com");  // replace with valid value
                message.Subject = "Dog Walking Sign Up";
                message.Body = string.Format(body, model.Name, model.Email, model.Phone, model.Address, model.ScheduleDate, model.SixtyMin, model.ThirtyMin);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "jessicamclark1988@gmail.com",  // replace with valid value
                        Password = "Jessicamarie"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(message);
                    ViewBag.Message = "Message Sent";
                    ModelState.Clear();
                    return View("Index");
                }
            }
            return View(model);
        }
    }
}