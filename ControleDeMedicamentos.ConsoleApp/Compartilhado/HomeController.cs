using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Compartilhado;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}
