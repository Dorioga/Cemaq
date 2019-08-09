﻿using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class Seleccionar_para_subir_contenidoController : Controller
    {
        // GET: Seleccionar_para_subir_contenido
        public ActionResult seleccionar_unidad_para_contenido()
        {
            Models.Login user = Session["usuario"] as Models.Login;
            Models.Niveles nivel = new Models.Niveles();
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                String codig = Request.Form["ir1"];

                if (codig != null)
                {
                    TempData["mensaje10"] = codig;
                    return View();
                }
                else
                {
                    String codig2 = Request.Form["ir2"];

                    if (codig2 != null)
                    {
                        TempData["mensaje11"] = codig2;
                        return View();
                    }
                    else
                    {
                        String codig3 = Request.Form["ir3"];

                        if (codig3 != null)
                        {
                            TempData["mensaje12"] = codig3;
                            return View();
                        }
                        else
                        {                            
                            String codig5 = Request.Form["ir5"];
                            if (codig5 != null)
                            {
                                TempData.Keep("mensaje10");
                                TempData.Keep("mensaje11");
                                TempData.Keep("mensaje12");
                                String unidad = Convert.ToString(TempData["mensaje12"]);
                                String curso = Convert.ToString(TempData["mensaje10"]);
                                String nivel1 = Convert.ToString(TempData["mensaje11"]);
                                Subir_contenidos unid1 = new Subir_contenidos();
                                unid1.codigo_unidad = unidad;
                                unid1.codigo_curso = curso;
                                unid1.codigo_nivel = nivel1;
                                Session["usuario11"] = unid1;
                                return RedirectToAction("Cargar_contenido", "Contenido");
                            }
                            else
                            {
                                String codig4 = Request.Form["ir4"];

                                if (codig4 != null)
                                {
                                    //TempData["mensaje3"] = codig3;
                                    principalP act1 = new principalP();
                                    act1.codigo_actividad = codig4;
                                    Session["usuario10"] = act1;
                                    return RedirectToAction("Actividad", "Actividades"); 
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