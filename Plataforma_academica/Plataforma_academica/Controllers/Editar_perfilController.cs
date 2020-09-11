using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class Editar_perfilController : Controller
    {
        string nombre;
        Editar_perfil invocar = new Editar_perfil();
        // GET: Editar_perfil
        public ActionResult Editar_perfil(HttpPostedFileBase file, Editar_perfil obj)
        {
            Models.Login user = Session["usuario"] as Models.Login;
            DataTable datos = null;
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }else
            {
                String codig100 = Request.Form["ir101"];
                if (codig100 != null)
                {
                    int f = ValidarDatos(obj, file);
                    if (f > 0)
                    {
                        if (invocar.Actualizar_perfil(obj,f,user.cedula,Subir(file)))
                        {
                            datos = user.BuscarPersona(user.nombre_usu, user.cedula);

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
                                user.telefono = datos.Rows[0]["num_tel_persona"].ToString();
                                user.estado_civil = datos.Rows[0]["civi"].ToString();
                                Session["usuario"] = user;
                            }
                        }                        
                    }                    
                }
            }
            return View();
        }
        public int ValidarDatos(Editar_perfil obj, HttpPostedFileBase file)
        {
            if (obj.correo != null && obj.telefono != null && file != null)
            {
                return 1;
            }
            else
            {
                if (obj.correo != null && obj.telefono != null)
                {
                    return 2;
                }else
                {
                    if (obj.correo != null)
                    {
                        return 3;
                    }
                    else
                    {
                        if (obj.telefono != null)
                        {
                            return 4;
                        }
                        else
                        {
                            if (file != null)
                            {
                                return 5;
                            }
                            else
                            {
                                if (file != null && obj.correo != null)
                                {
                                    return 6;
                                }else
                                {
                                    if (file != null && obj.telefono != null)
                                    {
                                        return 7;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return 0;
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