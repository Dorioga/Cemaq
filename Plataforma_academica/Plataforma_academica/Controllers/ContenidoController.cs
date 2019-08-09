using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class ContenidoController : Controller
    {
        // GET: Contenido
        public ActionResult Cargar_contenido(contenido obj)
        {
            Login user = Session["usuario"] as Login;
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Convert.ToInt32(user.rol) > 3)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            if (ValidarDatos(obj))
            {

                if (obj.Registrar_Contenido(obj))
                {
                    ViewBag.mensaje = "Registro exitoso";

                }
                else
                {
                   
                        ViewBag.mensaje = "No se registro el trabajador";
                    
                }
            }
            return View();
        }
        public bool ValidarDatos(contenido obj)
        {
            if (obj.nombre_contenido != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}