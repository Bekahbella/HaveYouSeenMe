using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaveYouSeenMe.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Send()
        {
            var name = (string)RouteData.Values["id"];
            ViewBag.PetName = name;
            ViewBag.IsSent = false;
            return View();
        }
    }
}