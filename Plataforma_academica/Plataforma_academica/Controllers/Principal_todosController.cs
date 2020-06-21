using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class Principal_todosController : Controller
    {
        // GET: Principal_todos
        public ActionResult Principal_todos()
        {
            Models.Login user = Session["usuario"] as Models.Login;
            Models.Niveles nivel = new Models.Niveles();
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                String codig = Request.Form["ir"];

                if (codig != null)
                {
                    TempData["mensaje1"] = codig;
                    return View();
                }
                else
                {
                    String codig2 = Request.Form["irr"];

                    if (codig2 != null)
                    {
                        TempData["mensaje2"] = codig2;
                        return View();
                    }
                }
            }
            return View();
        }
    }
}