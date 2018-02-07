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
                var body = "Name: {0} <br />  Email: {1} <br /> Phone: {2} <br />  Address: {3} <br /> Schedule Date: {4} <br /> Hour: {5} <br /> Half Hour: {6}";
                var message = new SendGridMessage();
                message.AddTo("jessicamclark1988@gmail.com");  // replace with valid value 
                message.From = new MailAddress("jessicamclark1988@gmail.com");  // replace with valid value
                message.Subject = "Dog Walking Sign Up";
                message.Html = string.Format(body ,model.Name, model.Email, model.Phone, model.Address, model.ScheduleDate, model.SixtyMin, model.ThirtyMin);
                //Azure credentials
                var username = "azure_8b8a64638c6bdacad86023f15c2e402b@azure.com";
                var pswd = "Cg090482?";
                
                // variable to store azure credentials
                var credentials = new NetworkCredential(username, pswd);
                // Create an Web transport for sending email.
                var transportWeb = new Web(credentials);

                // Send the email, which returns an awaitable task.
                transportWeb.DeliverAsync(message);

                ViewBag.Message = "Message Sent";
                ModelState.Clear(); //clears form when page reload
                return View("Index");

            }
            return View(model);
        }
    }
}