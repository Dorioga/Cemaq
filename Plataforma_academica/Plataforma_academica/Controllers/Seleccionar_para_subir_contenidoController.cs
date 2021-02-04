using Plataforma_academica.Models;
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
            Models.Pais pais = new Models.Pais();
            Models.Niveles nivel = new Models.Niveles();
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                string codig = Request.Form["ir"];

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
                                    Subir_contenidos unid1 = new Subir_contenidos();
                                    TempData.Keep("mensaje12");
                                    String unidad = Convert.ToString(TempData["mensaje12"]);
                                    unid1.codigo_unidad = unidad;
                                    Session["uni"] = unid1;
                                    ViewBag.mensaje = "actividad";
                                    return View();
                                    //return RedirectToAction("Actividades", "Actividades");
                                }
                                else
                                {
                                    String codig6 = Request.Form["ir6"];
                                    if (codig6 != null)
                                    {
                                        principalP act2 = new principalP();
                                        act2.codigo_actividad = codig6;
                                        Session["usuario12"] = act2;
                                        return RedirectToAction("Editar_Actividad", "Editar_Actividad");
                                    }else
                                    {
                                        String codig7 = Request.Form["ir99"];
                                        if (codig7 != null)
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
                                            return RedirectToAction("Contenido_practico", "Contenido_practico");
                                        }
                                        else
                                        {
                                            String codig8 = Request.Form["ir4_"];
                                            if (codig8 != null)
                                            {
                                                //Terminar codigo para visualizar el examen como tutor
                                                principalP act2 = new principalP();
                                                act2.codigo_examen = codig8;
                                                Session["usuarios10"] = act2;
                                                return RedirectToAction("Practica", "Practica");
                                            }else
                                            {
                                                String codig9 = Request.Form["ir6_"];
                                                if (codig9 != null)
                                                {
                                                     //ingresar a la edicion del examen
                                                    principalP act2 = new principalP();
                                                    act2.codigo_examen = codig9;
                                                    Session["editar_examen"] = act2;
                                                    //return RedirectToAction("Editar_Actividad", "Editar_Actividad");
                                                }else
                                                {
                                                    String codig10 = Request.Form["ir7_"];
                                                    if (codig10 != null)
                                                    {
                                                        ViewBag.mensaje = "pais";
                                                    }else
                                                    {
                                                        String codig11 = Request.Form["ir8_"];
                                                        if (codig11 != null)
                                                        {
                                                            TempData["mensaje20"] = codig11;
                                                            return View();
                                                        }else
                                                        {
                                                            String codig12 = Request.Form["ir9_"];
                                                            if (codig12 != null)
                                                            {
                                                                TempData["mensaje21"] = codig12;
                                                                return View();
                                                            }else
                                                            {
                                                                String codig13 = Request.Form["ir10_"];
                                                                if (codig13 != null)
                                                                {
                                                                    TempData["mensaje22"] = codig13;
                                                                    return View();
                                                                }else
                                                                {
                                                                    String codig14 = Request.Form["ir11_"];
                                                                    if (codig14 != null)
                                                                    {
                                                                        TempData["mensaje23"] = codig14;
                                                                        return View();
                                                                    }
                                                                    else
                                                                    {
                                                                        String codig15 = Request.Form["ir12_"];
                                                                        if (codig15 != null)
                                                                        {
                                                                            TempData["mensaje24"] = codig15;
                                                                            return View();
                                                                        }else
                                                                        {
                                                                            String codig16 = Request.Form["ir14_"];
                                                                            if (codig16 != null)
                                                                            {
                                                                                TempData["mensaje25"] = codig16;
                                                                                return View();
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            
                                        }
                                    }                                
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