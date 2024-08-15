using Microsoft.AspNetCore.Mvc;

namespace Task2.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult SaveSession(string name)
        {
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", 21);
            return Content("Data Session Save Success");
        }

        public IActionResult GetSession()
        {
            
            string n = HttpContext.Session.GetString("Name");
            int? a = HttpContext.Session.GetInt32("Age");
            return Content($"name={n} \t age={a}");
        }
    }
}
