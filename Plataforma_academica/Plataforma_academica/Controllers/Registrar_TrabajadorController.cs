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
        string nombre;
        // GET: Registrar_Trabajador
        public ActionResult Registrar_Trabajador(Registrar_Trabajador obj, HttpPostedFileBase file1, Rol rol, Tipo_documento tipo_doc, Tipo_poblacion tipo_pobla, Genero g, Contrato c, Escolaridad e, Estado_civil es, Grupo_sanguineo san)
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
                    return RedirectToAction("Login", "Login");
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
                    if (Request.Form["listar6"] != null)
                    {
                        g.id_genero = Request.Form["listar6"].ToString();
                    }
                    if (Request.Form["listar7"] != null)
                    {
                        c.id_contrato = Request.Form["listar7"].ToString();
                    }
                    if (Request.Form["listar8"] != null)
                    {
                        e.id_escolaridad = Request.Form["listar8"].ToString();
                    }
                    if (Request.Form["listar9"] != null)
                    {
                        es.id_estado = Request.Form["listar9"].ToString();
                    }
                    if (Request.Form["listar10"] != null)
                    {
                        san.id_sanguineo = Request.Form["listar10"].ToString();
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
                        Plataforma_academica.Models.Genero ge = new Plataforma_academica.Models.Genero();
                        Plataforma_academica.Models.Genero[] gen;
                        Plataforma_academica.Models.Contrato co = new Plataforma_academica.Models.Contrato();
                        Plataforma_academica.Models.Contrato[] con;
                        Plataforma_academica.Models.Estado_civil esta = new Plataforma_academica.Models.Estado_civil();
                        Plataforma_academica.Models.Estado_civil[] civi;
                        Plataforma_academica.Models.Escolaridad esco = new Plataforma_academica.Models.Escolaridad();
                        Plataforma_academica.Models.Escolaridad[] cola;
                        Plataforma_academica.Models.Grupo_sanguineo sangui = new Plataforma_academica.Models.Grupo_sanguineo();
                        Plataforma_academica.Models.Grupo_sanguineo[] sa;

                        rol_ = r.BuscarRol();
                        tid = ti.Buscartipodocumento();
                        tipob = tip.Buscarpoblacion();
                        gen = ge.BuscarGenero();
                        con = co.BuscarContrato();
                        civi = esta.BuscarEstadoCivil();
                        cola = esco.BuscarEscolaridad();
                        sa = sangui.BuscarSanguineo();

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

                        List<SelectListItem> lista7 = new List<SelectListItem>();
                        foreach (Genero i in gen)
                        {
                            lista7.Add(new SelectListItem
                            {
                                Text = i.nombre_genero,
                                Value = i.id_genero,
                                Selected = false
                            });
                        }
                        ViewData["lista7"] = lista7;

                        List<SelectListItem> lista8 = new List<SelectListItem>();
                        foreach (Contrato i in con)
                        {
                            lista8.Add(new SelectListItem
                            {
                                Text = i.nombre_contrato,
                                Value = i.id_contrato,
                                Selected = false
                            });
                        }
                        ViewData["lista8"] = lista8;

                        List<SelectListItem> lista9 = new List<SelectListItem>();
                        foreach (Estado_civil i in civi)
                        {
                            lista9.Add(new SelectListItem
                            {
                                Text = i.nombre_estado,
                                Value = i.id_estado,
                                Selected = false
                            });
                        }
                        ViewData["lista9"] = lista9;

                        List<SelectListItem> lista10 = new List<SelectListItem>();
                        foreach (Escolaridad i in cola)
                        {
                            lista10.Add(new SelectListItem
                            {
                                Text = i.nombre,
                                Value = i.id_escolaridad,
                                Selected = false
                            });
                        }
                        ViewData["lista10"] = lista10;

                        List<SelectListItem> lista11 = new List<SelectListItem>();
                        foreach (Grupo_sanguineo i in sa)
                        {
                            lista11.Add(new SelectListItem
                            {
                                Text = i.nombre_sanguineo,
                                Value = i.id_sanguineo,
                                Selected = false
                            });
                        }
                        ViewData["lista11"] = lista11;
                    }
                }

            }
            if (ValidarDatos(obj))
            {
                String codigo1 = Request.Form["subir1"];
                if (codigo1 != null)
                {
                    Contenido_practico id_examen = new Contenido_practico();
                    if (obj.Registrar_Trabajadores(obj,Subir(file1)))
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