using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class ZoomconferenciaController : Controller
    {
        // GET: Zoomconferencia
        public ActionResult Zoomconferencia()
        {
            Plataforma_academica.Models.Login usu = Session["usuario"] as Plataforma_academica.Models.Login;
            if (usu != null)
            {
                ViewBag.mensaje = usu.rol;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }
    }
}