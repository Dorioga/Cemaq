using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class FormatosController : Controller
    {
        string nombre;
        // GET: Formatos
        public ActionResult Formatos(Formatos obj, HttpPostedFileBase file)
        {
            Plataforma_academica.Models.principalP act2 = Session["usuario12"] as Plataforma_academica.Models.principalP;
            Login user = Session["usuario"] as Login;

            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Convert.ToInt32(user.rol) != 4)
                {
                    String codigo1 = Request.Form["seccion"];
                    if (codigo1 != null)
                    {
                        if (obj.Registrar_formato(Subir(file), nombre, Convert.ToInt32(user.usuario)))
                        {
                            ViewBag.mensaje = "Exito al cargar";
                            return View();
                        }else
                        {
                            ViewBag.mensaje = "Fallo cargue";
                        }
                    }
                    String codigo_ = Request.Form["subir"];
                    if (codigo_ != null)
                    {
                        var ruta = Server.MapPath("~/imagen_multimedia/" + codigo_);
                        return File(ruta, "aplication/pdf,docx", codigo_);
                    }
                    return View();                
                }
                else
                {
                    return RedirectToAction("PrincipalPlataforma", "principalplataforma");
                }
                
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
                file.SaveAs(Server.MapPath("~/imagen_multimedia/" + archivo));
                nombre = file.FileName;
            }
            return archivo;
        }

        [HttpPost]
        public JsonResult Actualizar_formato(int id_formato, HttpPostedFileBase file)
        {       
            var x = 2;
            Formatos formato = new Formatos();
                formato.Actualizar_formatos(id_formato, Subir(file), nombre);
           return Json(x);
        }

        [HttpPost]
        public JsonResult Deshabilitar_formato(int id_formato)
        {
            var x = 2;
            Formatos formato = new Formatos();
            formato.Deshabilitar_formatos(id_formato);
            return Json(x);
        }
    }
}