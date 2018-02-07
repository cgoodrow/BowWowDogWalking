using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BowWowDogWalking.Models;
using System.Net;
using SendGrid;
using System.Net.Mail;

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
        public ActionResult _ContactPartial(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Name: {0}</p> <p>Email: {1}</p> <p> Phone: {2} </p> <p>Address: {3} </p> <p>Schedule Date: {4}</p> <p>Hour: {5}</p> <p>Half Hour: {6}</p>";
                var message = new SendGridMessage();
                message.AddTo("jessicamclark1988@gmail.com");  // replace with valid value 
                message.From = new MailAddress("jessicamclark1988@gmail.com");  // replace with valid value
                message.Subject = "Dog Walking Sign Up";
                message.Text = string.Format(body,  model.Name, model.Email, model.Phone, model.Address, model.ScheduleDate, model.SixtyMin, model.ThirtyMin);
                var username = "azure_8b8a64638c6bdacad86023f15c2e402b@azure.com";
                var pswd = "Cg090482?";

                var credentials = new NetworkCredential(username, pswd);
                // Create an Web transport for sending email.
                var transportWeb = new Web(credentials);

                // Send the email, which returns an awaitable task.
                transportWeb.DeliverAsync(message);

                ViewBag.Message = "Message Sent";
                ModelState.Clear();
                return View("Index");

            }
            return View(model);
        }
    }
}