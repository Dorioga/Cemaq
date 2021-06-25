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
        string nombre;
        // GET: Registrar_Cursos
        public ActionResult Registrar_Cursos(Registrar_Cursos obj, Tematica t, Horas_diplomado horas, HttpPostedFileBase file, Docentes d)
        {
            Models.Login user = Session["usuario"] as Models.Login;

            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }else
            {
                if (Convert.ToInt32(user.rol) > 3)
                {
                    return RedirectToAction("principalplataforma", "PrincipalPlataforma");
                }else
                {
                    if (Request.Form["listar"] != null)
                    {
                        t.id_tematica = Request.Form["listar"].ToString();
                    }
                    if (Request.Form["listar1"] != null)
                    {
                        horas.id_horas = Request.Form["listar1"].ToString();
                    }
                    if (Request.Form["listar2"] != null)
                    {
                        d.id_docente = Request.Form["listar2"].ToString();
                    }
                    List<SelectListItem> prueba = ViewData["lista"] as List<SelectListItem>;
                    if (prueba == null)
                    {
                        Plataforma_academica.Models.Tematica te = new Plataforma_academica.Models.Tematica();
                        Plataforma_academica.Models.Tematica[] temati;
                        Plataforma_academica.Models.Horas_diplomado ho = new Plataforma_academica.Models.Horas_diplomado();
                        Plataforma_academica.Models.Horas_diplomado[] hor;
                        Plataforma_academica.Models.Docentes doc = new Plataforma_academica.Models.Docentes();
                        Plataforma_academica.Models.Docentes[] doce;

                        temati = te.BuscarTematicas();
                        hor = ho.BuscarHoras();
                        doce = doc.BuscarDocentes();

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
                        for (int i= 1; i<6; i++)
                        {
                            lista1.Add(new SelectListItem
                            {
                                Text = Convert.ToString(i),
                                Value = Convert.ToString(i),
                                Selected = false
                            });
                        }
                        ViewData["lista2"] = lista1;

                        List<SelectListItem> lista5 = new List<SelectListItem>();
                        foreach (Horas_diplomado i in hor)
                        {
                            lista5.Add(new SelectListItem
                            {
                                Text = i.cantidad_horas,
                                Value = i.id_horas,
                                Selected = false
                            });
                        }
                        ViewData["lista5"] = lista5;

                        List<SelectListItem> lista6 = new List<SelectListItem>();
                        foreach (Docentes i in doce)
                        {
                            lista6.Add(new SelectListItem
                            {
                                Text = i.nombre,
                                Value = i.id_docente,
                                Selected = false
                            });
                        }
                        ViewData["lista6"] = lista6;

                        //List<SelectListItem> lista2 = new List<SelectListItem>();
                        //for (int j = 0; j < 11; j++)
                        //{
                        //    lista2.Add(new SelectListItem
                        //    {
                        //        Text = Convert.ToString(j),
                        //        Value = Convert.ToString(j),
                        //        Selected = false
                        //    });
                        //}
                        //ViewData["lista3"] = lista2;

                        //List<SelectListItem> lista3 = new List<SelectListItem>();
                        //for (int h = 0; h < 11; h++)
                        //{
                        //    lista3.Add(new SelectListItem
                        //    {
                        //        Text = Convert.ToString(h),
                        //        Value = Convert.ToString(h),
                        //        Selected = false
                        //    });
                        //}
                        //ViewData["lista4"] = lista3;
                    }
                }
                String codig100 = Request.Form["ir100"];
                if (codig100 != null)
                {
                    //ViewBag.mensajeavanzado = obj.cantidadAvanzado;
                    ViewBag.mensajebasico = obj.cantidadBasico;
                    //ViewBag.mensajeintermedio = obj.cantidadIntermedio;
                    ViewBag.mensaje1 = "Registro exitoso";
                }else
                {
                    String codig101 = Request.Form["ir101"];
                    if (codig101 != null)
                    {
                        if (obj.Registrar_curso_(obj, Subir(file)))
                        {
                            if (obj.cantidadBasico > 0)
                            {
                                if (obj.Registrar_curso_nivel(obj, 1))
                                {
                                    for (int i = 0; i < obj.cantidadBasico; i++)
                                    {
                                        obj.Registrar_curso_unidad(obj, 1, obj.basico[i], obj.descripcionbasico[i]);

                                    }
                                    ViewBag.mensaje2 = "Registro exito";
                                }

                            }
                            //if (obj.cantidadIntermedio > 0)
                            //{
                            //    if (obj.Registrar_curso_nivel(obj, 2))
                            //    {
                            //        for (int j = 0; j < obj.cantidadIntermedio; j++)
                            //        {
                            //            obj.Registrar_curso_unidad(obj, 2, obj.intermedio[j], obj.descripcionintermedio[j]);
                            //        }
                            //    }

                            //}
                            //if (obj.cantidadAvanzado > 0)
                            //{
                            //    if (obj.Registrar_curso_nivel(obj, 3))
                            //    {
                            //        for (int m = 0; m < obj.cantidadAvanzado; m++)
                            //        {
                            //            obj.Registrar_curso_unidad(obj, 3, obj.avanzado[m], obj.descripcionavanzado[m]);
                            //        }
                            //    }

                            //}
                        }else
                        {
                            ViewBag.mensaje2 = "Registro no";
                        }
                        
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public string Subir(HttpPostedFileBase file)
        {
            string archivo;

            if (file == null)
            {
                nombre = null;
                return null;
            }
            else
            {
                archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName).ToLower();
                file.SaveAs(Server.MapPath("~/Imagenes/" + archivo));
                nombre = file.FileName;
            }
            return archivo;
        }       
    }
}