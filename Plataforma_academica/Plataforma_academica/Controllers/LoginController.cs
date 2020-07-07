using System;
using System.Collections.Generic;
using System.Linq;
using Plataforma_academica.Models;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Web.UI;

namespace Plataforma_academica.Controllers
{
    public class LoginController : Controller
    {
        Login user = new Login();
        Pais consul = new Pais();

        // GET: Login

        public ActionResult Login(Login usr, Tipo_documento tipo_doc, Tipo_poblacion tipo_pobla, Municipio mun, Pais pa, Departamento d, Genero g)
        {
            DataTable datos = null; 
                
                    String codigo2 = Request.Form["iniciar"];
                    if (codigo2 != null)
                    {
                        if (usr.usuario == null || usr.contraseña == null)
                        {
                            ViewBag.mensaje = "vacios";
                            ViewBag.mensaje2 = "Los campos de Usuario y Contraseña no deben estar vacios";
                        }else
                        {
                            datos = user.BuscarPersona(usr.usuario, usr.contraseña);

                            if (datos != null && datos.Rows.Count > 0)
                            {
                                user.Nombre = datos.Rows[0]["nombre"].ToString();
                                user.rol = datos.Rows[0]["id_rol"].ToString();
                                user.cedula = datos.Rows[0]["id_persona"].ToString();
                                user.Tipo_rol = datos.Rows[0]["nombre_rol"].ToString();
                                user.cedula = datos.Rows[0]["id_persona"].ToString();
                                user.usuario = datos.Rows[0]["id_usuario"].ToString();
                                user.conexion_usuario = datos.Rows[0]["estado_conexion_usuario"].ToString();
                                Session["usuario"] = user;
                                if (Convert.ToInt32(datos.Rows[0]["id_rol"].ToString()) < 7 && Convert.ToInt32(datos.Rows[0]["id_rol"].ToString()) > 3)
                                {
                                    return RedirectToAction("principalplataforma", "PrincipalPlataforma");//Pagina secundaria luego del login
                                }
                                else
                                {
                                    return RedirectToAction("seleccionar_unidad_para_contenido", "Seleccionar_para_subir_contenido");
                                }

                            }
                            else
                            {
                                ViewBag.mensaje = "datos incorrectos";
                                ViewBag.mensaje2 = "El Usuario o Contraseña son incorrectos, ingrese los datos e intentelo nuevamente";
                            }
                        }               
                
                    }       
                    
                if (Request.Form["listar1"] != null)
                {
                    tipo_doc.id_tipo_documento = Request.Form["listar1"].ToString();
                }
                if (Request.Form["listar2"] != null)
                {
                    tipo_pobla.id_tipo_poblacion = Request.Form["listar2"].ToString();
                }               
                if (Request.Form["listar4"] != null)
                {
                    pa.id_pais = Request.Form["listar4"].ToString();
                }
                if (Request.Form["listar5"] != null)
                {
                    d.id_departamento = Request.Form["listar5"].ToString();
                }
                if (Request.Form["listar3"] != null)
                {
                    mun.id_municipio = Request.Form["listar3"].ToString();
                }
            if (Request.Form["listar6"] != null)
            {
                g.id_genero = Request.Form["listar6"].ToString();
            }

            List<SelectListItem> prueba = ViewData["lista"] as List<SelectListItem>;
                if (prueba == null)
                {
                    Plataforma_academica.Models.Tipo_documento ti = new Plataforma_academica.Models.Tipo_documento();
                    Plataforma_academica.Models.Tipo_documento[] tid;
                    Plataforma_academica.Models.Tipo_poblacion tip = new Plataforma_academica.Models.Tipo_poblacion();
                    Plataforma_academica.Models.Tipo_poblacion[] tipob;
                    Plataforma_academica.Models.Pais p = new Plataforma_academica.Models.Pais();
                    Plataforma_academica.Models.Pais[] pai;
                    Plataforma_academica.Models.Municipio m = new Plataforma_academica.Models.Municipio();
                    Plataforma_academica.Models.Municipio[] mu;
                    Plataforma_academica.Models.Departamento dp = new Plataforma_academica.Models.Departamento();
                    Plataforma_academica.Models.Departamento[] depa;
                Plataforma_academica.Models.Genero ge= new Plataforma_academica.Models.Genero();
                Plataforma_academica.Models.Genero[] gen;

                    tid = ti.Buscartipodocumento();
                    tipob = tip.Buscarpoblacion();
                    pai = p.BuscarPais();
                    depa = dp.BuscarDepartamento();
                    mu = m.BuscarMunicipio();
                    gen = ge.BuscarGenero();

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

                    List<SelectListItem> lista4 = new List<SelectListItem>();
                    foreach (Pais i in pai)
                    {
                        lista4.Add(new SelectListItem
                        {
                            Text = i.nombre_pais,
                            Value = i.id_pais,
                            Selected = false
                        });
                    }
                    ViewData["lista4"] = lista4;

                    List<SelectListItem> lista5 = new List<SelectListItem>();
                    foreach (Departamento i in depa)
                    {
                        lista5.Add(new SelectListItem
                        {
                            Text = i.nombre_departamento,
                            Value = i.id_departamento,
                            Selected = false
                        });
                    }
                    ViewData["lista5"] = lista5;

                    List<SelectListItem> lista6 = new List<SelectListItem>();
                    foreach (Municipio i in mu)
                    {
                        lista6.Add(new SelectListItem
                        {
                            Text = i.nombre_municipio,
                            Value = i.id_municipio,
                            Selected = false
                        });
                    }
                    ViewData["lista6"] = lista6;

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
            }
            if (ValidarDatos(usr))
            {
                String codigo1 = Request.Form["subir1"];
                if (codigo1 != null)
                {
                    if (usr.Registrar_estudiante(usr))
                    {
                        ViewBag.mensaje = "Exito";
                        ViewBag.mensaje2 = "El Nuevo Usuario fue registrado con exito, se envió los datos de inicio de sesión, al correo "+usr.correo;
                    }
                    else
                    {
                        ViewBag.mensaje = "No se registro el usuario";
                        ViewBag.mensaje2 = "El Usuario no fue registrado, intentelo nuevamente.";
                    }
                }
            }
            return View();
        }

        public bool ValidarDatos(Login obj)
        {
            if (obj.cedula != null || obj.apellido1 != null || obj.fecha_nacimiento != null || obj.nombre1 != null || obj.telefono != null || obj.municipio!= null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public ActionResult cerrarsesion()
        {
            Plataforma_academica.Models.Login usu = Session["usuario"] as Plataforma_academica.Models.Login;
            user.Actualizar_conexion(usu);
            Session.Clear();
            Response.AppendHeader("Cache-Control", "no-store");
            return RedirectToAction("Login", "Login");
        }

        //public ActionResult Pais()
        //{
        //   ViewBag.mensaje = "datos correctos";
        //   return RedirectToAction("seleccionar_unidad_para_contenido", "Seleccionar_para_subir_contenido");
        //}

    }
}