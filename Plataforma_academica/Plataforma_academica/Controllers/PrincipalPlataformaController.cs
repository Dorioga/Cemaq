using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class PrincipalPlataformaController : Controller
    {
        // GET: PrincipalPlataforma
        string nombre;
        public ActionResult principalplataforma(HttpPostedFileBase file)
        {
            Models.Login user = Session["usuario"] as Models.Login;
            //Plataforma_academica.Models.principalP principal = new Plataforma_academica.Models.principalP();
            //Plataforma_academica.Models.principalP[] arreglo;
            Models.Niveles nivel = new Models.Niveles();
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                //arreglo = principal.BuscarCursos(user.cedula);
                //if (arreglo.Length == 0)
                //{
                //    return RedirectToAction("Principal_todos", "Principal_todos");
                //}
                String codig = Request.Form["ir"];

                if (codig != null)
                {
                    TempData["mensaje9"] = codig;
                    return View();
                }
                else
                {
                        String codig3 = Request.Form["irrr"];

                        if (codig3 != null)
                        {
                            TempData["mensaje10"] = codig3;
                            return View();
                        }else
                        {
                            String codig4 = Request.Form["irrrr"];

                            if (codig4 != null)
                            {
                                principalP act1 = new principalP();
                                act1.codigo_actividad = codig4;
                                Session["usuario3"] = act1;
                                ViewBag.mensaje = "actividad";
                                return View();
                            //return RedirectToAction("Actividades", "Actividades"); 
                        }
                        else
                            {
                                String codig5 = Request.Form["irrrr5"];
                                if (codig5 != null)
                                {
                                    //Arreglar el codio para visualizar los examenes por parte de los alumnos
                                    principalP act2 = new principalP();
                                    act2.codigo_examen = codig5;
                                Session["usuarios2"] = act2;
                                return RedirectToAction("Practica", "Practica");
                            }else
                            {
                                String codigmo = Request.Form["irmodal"];
                                if (codigmo != null)
                                {
                                    principalP actuali = new principalP();
                                    actuali.Actualizar_saludo(codigmo,user.usuario);
                                }
                                else
                                {
                                    String codigarchivo = Request.Form["irarchivo"];
                                    if (codigarchivo != null)
                                    {
                                        principalP subir = new principalP();
                                        if (subir.Actualizar_subir_archivo(Subir(file), codigarchivo))
                                        {
                                            if (SendEmail(user.correo, user.Nombre))
                                            {
                                                ViewBag.mensaje = "exito";
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
            

            return View();
        }

        [HttpPost]
        public JsonResult finalizado_por_fecha(string codigo)
        {
            var x = 2;
            principalP act = new principalP();
            if (act.Actualizar_curso_usaurio(codigo))
            {
                return Json(x);
            }
            return Json(0);
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

        public bool SendEmail(string c, string nom)
        { bool a = false;
            if (c == null)
            {
                a = false;
            }else
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(c);
                mail.From = new MailAddress("cemaqacademica@gmail.com");
                mail.Subject = "Notificación";
                mail.Body = nom+", Usted ha enviado de forma exitosa la actividad: \n\r" +
                    "http://diplomados-cemaq.azurewebsites.net/Login/Login";


                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new NetworkCredential("cemaqacademica@gmail.com", "academica2020!");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                a = true;
                return a;
            }

            return a;
        }              

    }
}