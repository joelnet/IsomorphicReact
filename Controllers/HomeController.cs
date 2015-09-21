namespace IsomorphicReact.Controllers
{
    using System;
    using System.Web.Mvc;
    using Helpers;
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new IndexViewModel
            {
                Props = new { start = JintHelpers.DateGetTime(DateTime.Now) }
            };

            return this.View(model);
        }
    }
}