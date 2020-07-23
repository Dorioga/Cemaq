using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class PrincipalPlataformaController : Controller
    {
        // GET: PrincipalPlataforma

        public ActionResult principalplataforma()
        {
            Models.Login user = Session["usuario"] as Models.Login;
            //Plataforma_academica.Models.principalP principal = new Plataforma_academica.Models.principalP();
            //Plataforma_academica.Models.principalP[] arreglo;
            Models.Niveles nivel = new Models.Niveles();
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                //arreglo = principal.BuscarCursos(user.cedula);
                //if (arreglo.Length == 0)
                //{
                //    return RedirectToAction("Principal_todos", "Principal_todos");
                //}
                String codig = Request.Form["ir"];

                if (codig != null)
                {
                    TempData["mensaje1"] = codig;
                    return View();
                }
                else
                {
                        String codig3 = Request.Form["irrr"];

                        if (codig3 != null)
                        {
                            TempData["mensaje3"] = codig3;
                            return View();
                        }else
                        {
                            String codig4 = Request.Form["irrrr"];

                            if (codig4 != null)
                            {
                                //TempData["mensaje3"] = codig3;
                                principalP act1 = new principalP();
                                act1.codigo_actividad = codig4;
                                Session["usuario3"] = act1;
                            ViewBag.mensaje = "actividad";
                            return View();
                            //return RedirectToAction("Actividades", "Actividades"); 
                        }
                        else
                            {
                                String codig5 = Request.Form["irrrr5"];
                                if (codig5 != null)
                                {
                                    //Arreglar el codio para visualizar los examenes por parte de los alumnos
                                    principalP act2 = new principalP();
                                    act2.codigo_examen = codig5;
                                Session["usuarios2"] = act2;
                                return RedirectToAction("Practica", "Practica");
                            }else
                            {
                                String codigmo = Request.Form["irmodal"];
                                if (codigmo != null)
                                {
                                    principalP actuali = new principalP();
                                    actuali.Actualizar_saludo(codigmo,user.usuario);
                                }
                            }
                            }
                        }
                        

                }

            }
            

            return View();
        }

       
    }
}