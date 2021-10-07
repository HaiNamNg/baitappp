using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ltap.Areas.Admins.Controllers
{
    public class HomeAdmController : Controller
    {
        [Authorize(Roles ="Admin")]
        // GET: Admins/HomeAdm
        public ActionResult Index()
        {
            return View();
        }
    }
}