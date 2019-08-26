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
        public ActionResult Editar_Actividad(lista_tipo_multimedia tipo, Editar_Actividad obj)
        {
            if (Request.Form["listar"] != null)
            {
               tipo.codigo = Request.Form["listar"].ToString();
            }
            List<SelectListItem> prueba = ViewData["lista"] as List<SelectListItem>;
            if (prueba == null)
            {
                Plataforma_academica.Models.lista_tipo_multimedia ti = new Plataforma_academica.Models.lista_tipo_multimedia();
                Plataforma_academica.Models.lista_tipo_multimedia[] tid;

                tid = ti.Consultar_tipo_multimedia();

                List<SelectListItem> lista = new List<SelectListItem>();
                foreach (lista_tipo_multimedia i in tid)
                {
                    lista.Add(new SelectListItem
                    {                        
                        Text = i.nombre,
                        Value = i.codigo,
                        Selected = false
                    });
                }
                ViewData["lista"] = lista;
            }
            Models.Login user = Session["usuario"] as Models.Login;
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
                else
                {
                    String codig = Request.Form["ir1"];

                    if (codig != null)
                    {
                        //TempData["mensaje100"] = codig;
                                                
                        if (obj.Actualizar_nombre_actividad(codig,obj))
                        {
                            ViewBag.mensaje = "Registro exitoso";

                        }else
                        {
                            ViewBag.mensaje = "no se realizo la actualización";
                        }
                        
                    }                               

                }
            }
            return View();
        }
    }
}