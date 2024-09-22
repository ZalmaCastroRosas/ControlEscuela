// Controllers/AccountController.cs
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ControlEscolar.Models;

public class AccountController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: Account/Login
    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    // POST: Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(string nombreUsuario, string contrasena)
    {
        if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contrasena))
        {
            ModelState.AddModelError("", "El nombre de usuario y la contraseña son requeridos.");
            return View();
        }
        using (var db = new ApplicationDbContext())
        {
            var usuario = db.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena);
        if (usuario != null)
        {
            FormsAuthentication.SetAuthCookie(usuario.NombreUsuario, false);
            return RedirectToAction("Index", "Alumnos");
        }
        else
        {
            ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
            return View();
        }
        }
       
    }

    // GET: Account/Logout
    public ActionResult Logout()
    {
        FormsAuthentication.SignOut();
        return RedirectToAction("Login");
    }
}
