using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Plataforma_academica.Models;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class ActividadesController : Controller
    {
        Actividades act = new Actividades();
        // GET: Actividades
        public ActionResult Actividades()
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