using CultureGroupUmbraco.Models;
using Microsoft.AspNetCore.Mvc;

using System.Net.Mail;

using System.Text;

using Umbraco.Cms.Web.Common.Controllers;

namespace CultureGroupUmbraco.Controllers
{
    public class ContactUsController : UmbracoApiController
    {
        [HttpPost]
        public IActionResult ContactForm(Contact con)
        {
            try
            {
                //var secrateKey = "6LcEKj4iAAAAAIMuuFbQvC4qBIvFzh0ZZV0zVIeG";
                //if (!Contact.IsCaptchaValid(secrateKey, con.Recapcha))
                //{
                //    return BadRequest("Recaptcha not validated");
                //}
                if (con.Email != null)
                {
                    var subject = "Contact Us - " + con.FirstName.ToUpper() + " " + con.LastName.ToUpper();
                    System.Text.StringBuilder body = new StringBuilder();
                    body.Append("Hi<br/><br/> " + "Contact Us Details <br/>");
                    body.Append("<table>");
                    body.Append("<tr><th>Name</th><th></th><th>Email</th><th></th><th>Message</th></tr>");
                    body.Append("<tr>");
                    body.Append("<td>" + con.FirstName.ToUpper() + " " + con.LastName.ToUpper() + "</td>");
                    body.Append("<td></td>");
                    body.Append("<td>" + con.Email + "</td>");
                    body.Append("<td></td>");
                    body.Append("<td>" + con.Message + "</td>");
                    body.Append("</tr></table><br/> Regards, <br/>Creative Factory.");
                    SendEmail(body.ToString(), subject);
                }
                else
                {
                    return BadRequest("Wrong Email");
                }
                return Ok("Email Sent Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        private void SendEmail(string body, string subject)
        {
            //var client = new SendGridClient("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");
            //var msg = new SendGridMessage()
            //{
            //    From = new EmailAddress("devops@creativefactory.com.au", "Creative Factory"),
            //    Subject = subject,
            //    HtmlContent = body
            //};
            //msg.AddTo(new EmailAddress("ally@creativefactory.com.au"));
            //msg.AddTo(new EmailAddress("anuj@creativefactory.com.au "));
            //var response = client.SendEmailAsync(msg).Result;
        }
    }
}
