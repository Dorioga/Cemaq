using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class Editar_ActividadController : Controller
    {
        Editar_Actividad act = new Editar_Actividad();
        // GET: Editar_Actividad
        public ActionResult Editar_Actividad()
        {
            Models.Login user = Session["usuario"] as Models.Login;
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Convert.ToInt32(user.rol) > 10)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    return View();//Pagina de actividad               

                }
            }
        }
    }
}