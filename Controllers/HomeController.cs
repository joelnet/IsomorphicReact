namespace IsomorphicReact.Controllers
{
    using Helpers;
    using Models;
    using Services;
    using System;
    using System.Diagnostics;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var react = new ReactService();
            var props = new { start = JintHelpers.DateGetTime(DateTime.Now) };
            var model = new IndexViewModel
            {
                Props = props,
                TimerHtml = react.ExecuteComponent("Timer", props)
            };

            return View(model);
        }

        public static void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}