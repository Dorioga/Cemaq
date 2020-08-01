using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class Diplomados_matriculadosController : Controller
    {
        // GET: Diplomados_matriculados
        public ActionResult Diplomados_matriculados()
        {
            Models.Login user = Session["usuario"] as Models.Login;
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }else
            {
                return View();
            }
            
        }
    }
}