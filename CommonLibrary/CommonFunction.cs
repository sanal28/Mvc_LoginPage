using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartSheet_V._1._0.CommonLibrary
{
    public class CommonFunctions
    {

        public bool SendEmail(string ToAddress, string CcAddress, string BccAddress, string Subject, string MessageBody)
        {
            MailAddress email;
            string[] AddressArray;
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("sanal@nuvento.com");
                if (ToAddress != string.Empty)
                {
                    AddressArray = ToAddress.Split(',');
                    foreach (string item in AddressArray)
                    {
                        email = new MailAddress(item);
                        if (!mail.To.Contains(email))
                            mail.To.Add(item);
                    }
                }
                if (CcAddress != string.Empty)
                {
                    AddressArray = CcAddress.Split(',');
                    foreach (string item in AddressArray)
                    {
                        email = new MailAddress(item);
                        if (!mail.CC.Contains(email))
                            mail.CC.Add(item);
                    }
                }
                if (BccAddress != string.Empty)
                {
                    AddressArray = BccAddress.Split(',');
                    foreach (string item in AddressArray)
                    {
                        email = new MailAddress(item);
                        if (!mail.Bcc.Contains(email))
                            mail.Bcc.Add(item);
                    }
                }
                mail.Subject = Subject;
                mail.Body = MessageBody + "<br/><br/>Thanks,<br/>SmartSheet";
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("sanal@nuvento.com", "sanal2806");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                AddressArray = null;
                email = null;
            }
        }

    }

    public class Constants
    {

        public const string JsonSuccess = "{\"Result\":\"Success\"}";
        public const string JsonError = "{\"Result\":\"Error\"}";
    }
    public class SessionAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return (httpContext.Session["EmployeeID"] != null);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                                  new RouteValueDictionary
                                  {
                                   { "action", "Login" },
                                   { "controller", "Login" }
                                  });
        }
    }
}
