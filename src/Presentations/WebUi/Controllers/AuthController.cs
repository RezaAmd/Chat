using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers;

public class AuthController : Controller
{
    public IActionResult Signin()
    {
        return View();
    }
}