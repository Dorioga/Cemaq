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
    public class Principal_todosController : Controller
    {
       Principal_todos todo = new Principal_todos();
        // GET: Principal_todos
        public ActionResult Principal_todos()
        {
            Models.Login user = Session["usuario"] as Models.Login;
            Models.Niveles nivel = new Models.Niveles();
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                String codig = Request.Form["ir"];

                if (codig != null)
                {
                    TempData["mensaje1"] = codig;
                    return View();
                }
                else
                {
                    String codig2 = Request.Form["irr"];
                    DataTable datos = null;
                    DataTable datos3 = null;
                    if (codig2 != null)
                    {
                        TempData["mensaje2"] = codig2;
                        ViewBag.mensaje = "cargar";
                        datos = todo.Buscarcurso(codig2);
                        datos3 = todo.Buscarcurso_inscrito(codig2, user.usuario);
                        if (datos3.Rows.Count >0)
                        {
                            ViewBag.mensaje1 = "ya";
                        }
                        if (datos != null && datos.Rows.Count > 0)
                        {
                            todo.id_R = datos.Rows[0]["id_curso"].ToString();
                            todo.nombre_R = datos.Rows[0]["nombre_curso"].ToString();
                            todo.descripcion_R = datos.Rows[0]["descripcion_curso"].ToString();
                            Session["registrar_curso_usuario"] = todo;
                        }
                        return View();
                    }else
                    {
                        String codig3 = Request.Form["ir_R"];
                        if (codig3 != null)
                        {
                            Plataforma_academica.Models.Login usu = Session["usuario"] as Plataforma_academica.Models.Login;
                            Plataforma_academica.Models.Registrar_Beneficiario R = new Plataforma_academica.Models.Registrar_Beneficiario();
                            DataTable datos2;
                            DataTable datos1;
                            Principal_todos unidad = new Principal_todos();
                            Principal_todos actividad = new Principal_todos();
                            Registrar_Beneficiario unidad1 = new Registrar_Beneficiario();
                            Registrar_Beneficiario actividad1 = new Registrar_Beneficiario();
                            if (R.Registrar_curso_usuario(usu.usuario, codig3))
                            {
                                if (R.Registrar_Nivel_Beneficiarios(codig3, "1", usu.usuario))
                                {
                                    datos2 = R.Buscarunidades_para_registrar1("1", codig3);
                                    for (int i = 0; i < datos2.Rows.Count; i++)
                                    {
                                        unidad.id_unidad = datos2.Rows[i]["id_unidad"].ToString();
                                        if (unidad1.Registrar_Unidad_Beneficiarios1(unidad, codig3, "1",usu.usuario))
                                        {
                                            datos1 = R.Buscaractividades_para_registrar(unidad);
                                            for (int j = 0; j < datos1.Rows.Count; j++)
                                            {
                                                actividad.id_actividad = datos1.Rows[j]["id_actividad"].ToString();
                                                actividad1.Registrar_actividad_Beneficiarios(unidad, usu.usuario, actividad);

                                            }
                                            datos1 = R.Buscarexamen_para_registrar(unidad);
                                            for (int j = 0; j < datos1.Rows.Count; j++)
                                            {
                                                actividad.id_examen = datos1.Rows[j]["id_examen"].ToString();
                                                actividad1.Registrar_examen_Beneficiarios(actividad, usu.usuario);

                                            }
                                        }

                                    }
                                    SendEmail(user.correo, user.Nombre);
                                }
                            }
                        }
                    }
                }
            }
            return View();
        }

        public bool SendEmail(string c, string nom)
        {
            bool a = false;
            if (c == null)
            {
                a = false;
            }
            else
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(c);
                mail.From = new MailAddress("cemaqacademica@gmail.com");
                mail.Subject = "Notificación";
                mail.Body = nom + ", Usted ha sido registrado de forma exitosa en un DIPLOMADO en: " + "https://cemaq.com.co/" + 
                " para iniciar el proceso de formación ingrese a: "+"http://diplomados-cemaq.azurewebsites.net/Login/Login";


                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
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