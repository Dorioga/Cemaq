using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class Registrar_CursosController : Controller
    {
        // GET: Registrar_Cursos
        public ActionResult Registrar_Cursos(Registrar_Cursos obj, Tematica t)
        {
            Models.Login user = Session["usuario"] as Models.Login;

            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }else
            {
                if (Convert.ToInt32(user.rol) > 3)
                {
                    return RedirectToAction("Index", "Home");
                }else
                {
                    if (Request.Form["listar"] != null)
                    {
                        t.id_tematica = Request.Form["listar"].ToString();
                    }
                    List<SelectListItem> prueba = ViewData["lista"] as List<SelectListItem>;
                    if (prueba == null)
                    {
                        Plataforma_academica.Models.Tematica te = new Plataforma_academica.Models.Tematica();
                        Plataforma_academica.Models.Tematica[] temati;

                        temati = te.BuscarTematicas();

                        List<SelectListItem> lista = new List<SelectListItem>();
                        foreach (Tematica i in temati)
                        {
                            lista.Add(new SelectListItem
                            {
                                Text = i.nombre_tematica,
                                Value = i.id_tematica,
                                Selected = false
                            });
                        }
                        ViewData["lista1"] = lista;

                        List<SelectListItem> lista1 = new List<SelectListItem>();
                        for (int i= 0; i<11; i++)
                        {
                            lista1.Add(new SelectListItem
                            {
                                Text = Convert.ToString(i),
                                Value = Convert.ToString(i),
                                Selected = false
                            });
                        }
                        ViewData["lista2"] = lista1;

                        List<SelectListItem> lista2 = new List<SelectListItem>();
                        for (int j = 0; j < 11; j++)
                        {
                            lista2.Add(new SelectListItem
                            {
                                Text = Convert.ToString(j),
                                Value = Convert.ToString(j),
                                Selected = false
                            });
                        }
                        ViewData["lista3"] = lista2;

                        List<SelectListItem> lista3 = new List<SelectListItem>();
                        for (int h = 0; h < 11; h++)
                        {
                            lista3.Add(new SelectListItem
                            {
                                Text = Convert.ToString(h),
                                Value = Convert.ToString(h),
                                Selected = false
                            });
                        }
                        ViewData["lista4"] = lista3;
                    }
                }
                String codig100 = Request.Form["ir100"];
                if (codig100 != null)
                {
                    ViewBag.mensajeavanzado = obj.cantidadAvanzado;
                    ViewBag.mensajebasico = obj.cantidadBasico;
                    ViewBag.mensajeintermedio = obj.cantidadIntermedio;
                    ViewBag.mensaje1 = "Registro exitoso";
                }else
                {
                    String codig101 = Request.Form["ir101"];
                    if (codig101 != null)
                    {
                        if (obj.Registrar_curso_(obj))
                        {
                            if (obj.cantidadBasico > 0)
                            {
                                if (obj.Registrar_curso_nivel(obj, 1))
                                {
                                    for (int i = 0; i < obj.cantidadBasico; i++)
                                    {
                                        obj.Registrar_curso_unidad(obj, 1, obj.basico[i], obj.descripcionbasico[i]);
                                    }
                                }

                            }
                            if (obj.cantidadIntermedio > 0)
                            {
                                if (obj.Registrar_curso_nivel(obj, 2))
                                {
                                    for (int j = 0; j < obj.cantidadIntermedio; j++)
                                    {
                                        obj.Registrar_curso_unidad(obj, 2, obj.intermedio[j], obj.descripcionintermedio[j]);
                                    }
                                }

                            }
                            if (obj.cantidadAvanzado > 0)
                            {
                                if (obj.Registrar_curso_nivel(obj, 3))
                                {
                                    for (int m = 0; m < obj.cantidadAvanzado; m++)
                                    {
                                        obj.Registrar_curso_unidad(obj, 3, obj.avanzado[m], obj.descripcionavanzado[m]);
                                    }
                                }

                            }
                        }else
                        {
                            ViewBag.mensaje2 = "Registro no";
                        }
                        ViewBag.mensaje2 = "Registro exito";
                    }
                }
            }
            return View();
        }
    }
}