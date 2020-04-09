using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Plataforma_academica.Models;
using System.Web.Mvc;
using System.Net;

namespace Plataforma_academica.Controllers
{
    public class ActividadesController : Controller
    {
        
        Actividades act = new Actividades();

        // GET: Actividades
        public ActionResult Actividades()
        {
            Models.Login user = Session["usuario"] as Models.Login;
            Models.principalP actividad = Session["usuario3"] as Models.principalP;
            DataTable datos2 = null;
            DataTable datos3 = null;

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
                    //cargar y aumentar en uno la seccion de la tabla y el porcentaje aumentarlo como si ya se hubiera realizado uno
                    if (actividad != null)
                    {
                        datos2 = act.Buscar_porcentaje_seccion(actividad.codigo_actividad);
                        if (Convert.ToInt32(datos2.Rows[0]["seccion"].ToString()) == 0)
                        {
                            datos3 = act.Buscar_cantidad_secciones(actividad.codigo_actividad);
                            double porce = (1 * 100) / Convert.ToInt32(datos3.Rows[0]["numero secciones"].ToString());
                            act.id_curso_actividad = Convert.ToInt32(datos2.Rows[0]["id tabla"].ToString());
                            act.Actualizar_porcentaje(porce, Convert.ToInt32(actividad.codigo_actividad), 1, act.id_curso_actividad);
                        }
                    }
                    TempData["Autosize"] = "<script>AjustarTextArea()</script>";
                    return View();//Pagina de actividad
                }
            }
            
        }

        [HttpPost]
        public JsonResult porcentaje()
        {
            Models.principalP actividad = Session["usuario3"] as Models.principalP;
            Models.Actividades sec1 = Session["seccion1"] as Models.Actividades;
            Actividades usu = new Actividades();
            DataTable datos = null;            
            DataTable datos1 = null;
            var x = 2;

            datos1 = usu.Buscar_porcentaje_seccion(actividad.codigo_actividad);
            usu.id_curso_actividad = Convert.ToInt32(datos1.Rows[0]["id tabla"].ToString());
            Session["seccion1"] = usu;

            if (Convert.ToDouble(datos1.Rows[0]["porcentaje"].ToString()) < 100)
                {
                    datos = usu.Buscar_cantidad_secciones(actividad.codigo_actividad);
                    usu.seccion = Convert.ToInt32(datos.Rows[0]["numero secciones"].ToString());
                    usu.cont_seccion++;
                    Session["seccion1"] = usu;
                    int countseccion = Convert.ToInt32(datos1.Rows[0]["seccion"].ToString());
                    countseccion++;

                if (countseccion <= Convert.ToInt32(datos.Rows[0]["numero secciones"].ToString()))
                {
                    double porce = (countseccion*100) / Convert.ToInt32(datos.Rows[0]["numero secciones"].ToString());
                    if (countseccion == Convert.ToInt32(datos.Rows[0]["numero secciones"].ToString()))
                    {
                        usu.Actualizar_porcentaje_estado(Convert.ToInt32(actividad.codigo_actividad), usu.id_curso_actividad);
                    }
                    usu.Actualizar_porcentaje(porce, Convert.ToInt32(actividad.codigo_actividad),countseccion, usu.id_curso_actividad);
                }


            }
            return Json(x);
        }
    }
}