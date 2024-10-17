using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // This serves the Views/Home/Index.cshtml Razor page
        return View();
    }
}
