using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoMandatory.ViewModels;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace UmbracoMandatory.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            return PartialView("ContactForm", new ContactForm());
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            GuidUdi currentPageUdi = new GuidUdi(CurrentPage.ContentType.ItemType.ToString(), CurrentPage.Key);

            IContent message = Services.ContentService.CreateContent(model.Subject, currentPageUdi, "message");
            message.SetValue("messageName", model.Name);
            message.SetValue("email", model.Email);
            message.SetValue("subject", model.Subject);
            message.SetValue("messageContent", model.Message);
            message.SetValue("umbracoNaviHide", true);

            Services.ContentService.Save(message);

            TempData["success"] = true;

            return RedirectToCurrentUmbracoPage();
        }
    }
}