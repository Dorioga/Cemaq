using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class Registrar_TrabajadorController : Controller
    {
        // GET: Registrar_Trabajador
        public ActionResult Registrar_Trabajador(Registrar_Trabajador obj, Rol rol, Tipo_documento tipo_doc, Tipo_poblacion tipo_pobla)
        {
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
                }else
                {
                    if (Request.Form["listar"] != null)
                    {
                        rol.id_rol = Request.Form["listar"].ToString();
                    }
                    if (Request.Form["listar1"] != null)
                    {
                        tipo_doc.id_tipo_documento = Request.Form["listar1"].ToString();
                    }
                    if (Request.Form["listar2"] != null)
                    {
                        tipo_pobla.id_tipo_poblacion = Request.Form["listar2"].ToString();
                    }
                    List<SelectListItem> prueba = ViewData["lista"] as List<SelectListItem>;
                    if (prueba == null)
                    {
                        Plataforma_academica.Models.Rol r = new Plataforma_academica.Models.Rol();
                        Plataforma_academica.Models.Rol[] rol_;
                        Plataforma_academica.Models.Tipo_documento ti = new Plataforma_academica.Models.Tipo_documento();
                        Plataforma_academica.Models.Tipo_documento[] tid;
                        Plataforma_academica.Models.Tipo_poblacion tip = new Plataforma_academica.Models.Tipo_poblacion();
                        Plataforma_academica.Models.Tipo_poblacion[] tipob;

                        rol_ = r.BuscarRol();
                        tid = ti.Buscartipodocumento();
                        tipob = tip.Buscarpoblacion();

                        List<SelectListItem> lista = new List<SelectListItem>();
                        foreach (Rol i in rol_)
                        {
                            lista.Add(new SelectListItem
                            {
                                Text = i.nombre_rol,
                                Value = i.id_rol,
                                Selected = false
                            });
                        }
                        ViewData["lista2"] = lista;

                        List<SelectListItem> lista1 = new List<SelectListItem>();
                        foreach (Tipo_documento i in tid)
                        {
                            lista1.Add(new SelectListItem
                            {
                                Text = i.nombre_tipo_documento,
                                Value = i.id_tipo_documento,
                                Selected = false
                            });
                        }
                        ViewData["lista1"] = lista1;

                        List<SelectListItem> lista2 = new List<SelectListItem>();
                        foreach (Tipo_poblacion i in tipob)
                        {
                            lista2.Add(new SelectListItem
                            {
                                Text = i.nombre_tipo_poblacion,
                                Value = i.id_tipo_poblacion,
                                Selected = false
                            });
                        }
                        ViewData["lista3"] = lista2;
                    }
                }

            }
            if (ValidarDatos(obj))
            {
                String codigo1 = Request.Form["subir1"];
                if (codigo1 != null)
                {
                    Contenido_practico id_examen = new Contenido_practico();
                    if (obj.Registrar_Trabajadores(obj))
                    {
                        ViewBag.mensaje = "Exito";
                    }                    
                    else
                    {
                        ViewBag.mensaje = "No se registro el examen";
                    }
                }
            }

            return View();
        }

        public bool ValidarDatos(Registrar_Trabajador obj)
        {
            if (obj.cedula != null || obj.apellido1 != null || obj.fecha_nacimiento != null || obj.nombre1 != null || obj.telefono != null || obj.nombre_contrato != null)
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