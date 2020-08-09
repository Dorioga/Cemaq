using System;
using System.Collections.Generic;
using System.Linq;
using Plataforma_academica.Models;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Web.UI;
using System.Net.Mail;
using System.Net;

namespace Plataforma_academica.Controllers
{
    public class LoginController : Controller
    {
        Login user = new Login();
        Pais consul = new Pais();
        Login b = new Login();

        // GET: Login

        public ActionResult Login(Login usr, Tipo_documento tipo_doc, Tipo_poblacion tipo_pobla, Municipio mun, Pais pa, Departamento d, Genero g, Estado_civil e, Escolaridad cola, Grupo_sanguineo grup)
        {
            DataTable datos = null;
            HtmlHelper.ClientValidationEnabled = false;

            String codigo2 = Request.Form["iniciar"];
            if (codigo2 != null)
            {
                if (usr.usuario == null || usr.contraseña == null)
                {
                    ViewBag.mensaje = "vacios";
                    ViewBag.mensaje2 = "Los campos de Usuario y Contraseña no deben estar vacios";
                } else
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
                        user.genero = datos.Rows[0]["nombre_genero"].ToString();
                        user.foto = datos.Rows[0]["foto"].ToString();
                        user.correo = datos.Rows[0]["email_persona"].ToString();
                        user.nombre_usu = datos.Rows[0]["nombre2"].ToString();
                        user.tipo_sangui = datos.Rows[0]["n"].ToString();
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
            if (Request.Form["listar7"] != null)
            {
                e.id_estado = Request.Form["listar7"].ToString();
            }
            if (Request.Form["listar6"] != null)
            {
                g.id_genero = Request.Form["listar6"].ToString();
            }
            if (Request.Form["listar8"] != null)
            {
                cola.id_escolaridad = Request.Form["listar8"].ToString();
            }
            if (Request.Form["listar9"] != null)
            {
                grup.id_sanguineo = Request.Form["listar9"].ToString();
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
                Plataforma_academica.Models.Genero ge = new Plataforma_academica.Models.Genero();
                Plataforma_academica.Models.Genero[] gen;
                Plataforma_academica.Models.Estado_civil es = new Plataforma_academica.Models.Estado_civil();
                Plataforma_academica.Models.Estado_civil[] est;
                Plataforma_academica.Models.Escolaridad esco = new Plataforma_academica.Models.Escolaridad();
                Plataforma_academica.Models.Escolaridad[] escola;
                Plataforma_academica.Models.Grupo_sanguineo sang = new Plataforma_academica.Models.Grupo_sanguineo();
                Plataforma_academica.Models.Grupo_sanguineo[] grup_sangui;

                tid = ti.Buscartipodocumento();
                tipob = tip.Buscarpoblacion();
                pai = p.BuscarPais();
                depa = dp.BuscarDepartamento();
                mu = m.BuscarMunicipio();
                gen = ge.BuscarGenero();
                est = es.BuscarEstadoCivil();
                escola = esco.BuscarEscolaridad();
                grup_sangui = sang.BuscarSanguineo();

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

                List<SelectListItem> lista8 = new List<SelectListItem>();
                foreach (Estado_civil i in est)
                {
                    lista8.Add(new SelectListItem
                    {
                        Text = i.nombre_estado,
                        Value = i.id_estado,
                        Selected = false
                    });
                }
                ViewData["lista8"] = lista8;

                List<SelectListItem> lista9 = new List<SelectListItem>();
                foreach (Escolaridad i in escola)
                {
                    lista9.Add(new SelectListItem
                    {
                        Text = i.nombre,
                        Value = i.id_escolaridad,
                        Selected = false
                    });
                }
                ViewData["lista9"] = lista9;

                List<SelectListItem> lista10 = new List<SelectListItem>();
                foreach (Grupo_sanguineo i in grup_sangui)
                {
                    lista10.Add(new SelectListItem
                    {
                        Text = i.nombre_sanguineo,
                        Value = i.id_sanguineo,
                        Selected = false
                    });
                }
                ViewData["lista10"] = lista10;
            }
            if (ValidarDatos(usr))
            {
                String codigo1 = Request.Form["subir1"];
                if (codigo1 != null)
                {
                    if (usr.Registrar_estudiante(usr))
                    {
                        if (SendEmail(usr.correo,usr.apellido1, usr.cedula))
                        {
                            ViewBag.mensaje = "Exito";
                            ViewBag.mensaje2 = "El Nuevo Usuario fue registrado con exito, se envió los datos de inicio de sesión, al correo " + usr.correo;
                        }
                        
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

        public bool SendEmail(string c,string apellido, string contrase)
        {
            bool a = false;
            if (c == null)
            {
                a = false;
            }
            else
            {
                DataTable r;
                r = b.Buscaruser(contrase);
                if (r != null && r.Rows.Count > 0)
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(c);
                    mail.From = new MailAddress("cemaqacademica@gmail.com");
                    mail.Subject = "Notificación";
                    mail.Body = "Usted ha sido registrado como un usuario de forma exitosa en DIPLOMADOS - CEMAQ, sus credenciales son:\n\r" +
                        "Usuario: " + r.Rows[0]["nombre_usuario"].ToString() +
                        "\n\rContraseña: " + contrase + " " + "http://diplomados-cemaq.azurewebsites.net/Login/Login";


                    mail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Host = "smtp.gmail.com";
                    smtp.Credentials = new NetworkCredential("cemaqacademica@gmail.com", "academica2020!");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    a = true;
                    return a;
                }
                  
            }

            return a;
        }

        public bool ValidarDatos(Login obj)
        {
            if (obj.cedula != null || obj.apellido1 != null || obj.fecha_nacimiento != null || obj.nombre1 != null || obj.telefono != null || obj.municipio != null)
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
            TempData.Remove("mensaje9");
            TempData.Remove("mensaje10");
            Session.Clear();
            Response.AppendHeader("Cache-Control", "no-store");
            return RedirectToAction("Login", "Login");
        }

        
        //public JsonResult GetStateList(int CountryId)
        //{
        //    List<SelectListItem> states = new List<SelectListItem>();

        //        Plataforma_academica.Models.Departamento dp = new Plataforma_academica.Models.Departamento();
        //        Plataforma_academica.Models.Departamento[] depa;

        //        depa = dp.BuscarDepartamento(CountryId);
            
        //        foreach (Departamento i in depa)
        //        {
        //            states.Add(new SelectListItem
        //            {
        //                Text = i.nombre_departamento,
        //                Value = i.id_departamento,
        //                Selected = false
        //            });
        //        }
        //    ViewData["states"] = states;
        //    return Json(ViewData["states"],JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult GetCity(string x)
        //{
        //    List<SelectListItem> City = new List<SelectListItem>();

        //    Plataforma_academica.Models.Municipio m = new Plataforma_academica.Models.Municipio();
        //    Plataforma_academica.Models.Municipio[] mu;

        //    mu = m.BuscarMunicipio(x);

        //    foreach (Municipio i in mu)
        //    {
        //        City.Add(new SelectListItem
        //        {
        //            Text = i.nombre_municipio,
        //            Value = i.id_municipio,
        //            Selected = false
        //        });
        //    }
        //    ViewData["City"] = City;
        //    return Json(ViewData["City"]);
        //}

    }
}