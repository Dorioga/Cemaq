using System;
using System.Collections.Generic;
using System.Linq;
using Plataforma_academica.Models;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Plataforma_academica.Controllers
{
    public class LoginController : Controller
    {
        Login user = new Login();
        // GET: Login
        public ActionResult Login(Login usr)
        {
            DataTable datos = null;
            if (usr.usuario != null)
            {
                if (usr.usuario == null || usr.contraseña == null)
                {
                    ViewBag.mensaje = "vacios";
                }
                else
                {
                    datos = user.BuscarPersona(usr.usuario, usr.contraseña);

                    if (datos != null && datos.Rows.Count > 0)
                    {
                        user.Nombre = datos.Rows[0]["nombre"].ToString();
                        user.rol = datos.Rows[0]["id_rol"].ToString();
                        user.cedula = datos.Rows[0]["id_persona"].ToString();
                        user.Tipo_rol = datos.Rows[0]["nombre_rol"].ToString();
                        user.cedula = datos.Rows[0]["id_persona"].ToString();
                        Session["usuario"] = user;
                        ViewBag.mensaje = "datos correctos";
                        return RedirectToAction("principalplataforma", "PrincipalPlataforma");//Pagina secundaria luego del login

                    }
                    else
                    {
                        ViewBag.mensaje = "datos incorrectos";
                    }
                }


            }
            return View();
        }

        public ActionResult cerrarsesion()
        {
            Session.Clear();
            Response.AppendHeader("Cache-Control", "no-store");
            return RedirectToAction("Login", "Login");
        }
    }
}