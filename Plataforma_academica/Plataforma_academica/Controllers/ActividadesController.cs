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
            DataTable datos = null;
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
                    principalP cActi = Session["usuario3"] as principalP;
                    String codig = cActi.codigo_actividad;

                    if (codig != null)
                    {
                        //TempData["mensaje1"] = codig;
                        //return View();
                        datos = act.Consultar_contenido_actividad(codig);
                        if (datos != null && datos.Rows.Count > 0)
                        {
                            act.id_actividad = datos.Rows[0]["id_actividad"].ToString();
                            act.Nombre_actividad = datos.Rows[0]["Nombre_actividad"].ToString();
                            act.descripcion = datos.Rows[0]["descripcion"].ToString();
                            act.titulo_seccion = datos.Rows[0]["titulo_seccion"].ToString();
                            act.contenido_seccion = datos.Rows[0]["contenido_seccion"].ToString();
                            act.id_multimedia = datos.Rows[0]["id_multimedia"].ToString();
                            act.url_multimedia = datos.Rows[0]["url_multimedia"].ToString();
                            Session["usuario2"] = act;
                            ViewBag.mensaje = "datos correctos";
                            return RedirectToAction("Actividades", "Actividades");//Pagina de actividad

                        }
                        else
                        {
                            ViewBag.mensaje = "datos incorrectos";
                        }
                    }

                }
            }            
            return View();
        }
    }
}