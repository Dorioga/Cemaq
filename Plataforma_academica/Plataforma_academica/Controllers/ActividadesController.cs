using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Plataforma_academica.Models;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Plataforma_academica.Controllers
{
    public class ActividadesController : Controller
    {
        
        Actividades act = new Actividades();

        // GET: Actividades
        
        public async Task<ActionResult> Actividades(Actividades obj)
        {
            Models.Login user = Session["usuario"] as Models.Login;
            Models.principalP actividad = Session["usuario3"] as Models.principalP;
            DataTable datos2 = null;
            Models.principalP acti = Session["usuario10"] as Models.principalP;
            DataTable datos3 = null;
            Actividades ver = new Actividades();

            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Convert.ToInt32(user.rol) > 10)
                {
                    return RedirectToAction("principalplataforma", "PrincipalPlataforma");
                }
                else
                {
                    String codigo_ = Request.Form["subir"];
                    if (codigo_ != null)
                    {
                        var ruta = Server.MapPath("~/imagen_multimedia/"+codigo_);
                        return File(ruta, "aplication/pdf,docx", codigo_);
                    }
                        //cargar y aumentar en uno la seccion de la tabla y el porcentaje aumentarlo como si ya se hubiera realizado uno
                        if (actividad != null)
                    {
                        datos2 = act.Buscar_porcentaje_seccion(actividad.codigo_actividad);
                        if (Convert.ToInt32(datos2.Rows[0]["seccion"].ToString()) == 0)
                        {
                            datos3 = act.Buscar_cantidad_secciones(actividad.codigo_actividad);
                            double porce = (1 * 100) / Convert.ToInt32(datos3.Rows[0]["numero secciones"].ToString());
                            act.id_curso_actividad = Convert.ToInt32(datos2.Rows[0]["id tabla"].ToString());
                            act.Actualizar_porcentaje(porce, Convert.ToInt32(actividad.codigo_actividad), 1, act.id_curso_actividad);
                        }
                    }else
                    {
                        if (acti != null)
                        {
                            String codigo = Request.Form["iraprobado"];
                            if (codigo != null)
                            {

                                Plataforma_academica.Models.Subir_contenidos usu = Session["uni"] as Plataforma_academica.Models.Subir_contenidos;
                                if (ver.Actualizar_actividad_y_usurio_actividad(codigo))
                                {
                                    var registro = registro_curso_usuario_actividad(codigo, usu.codigo_unidad);
                                    var correo = SendEmail(codigo, usu.codigo_unidad);
                                    await Task.WhenAll(registro, correo);
                                    if (registro.Result && correo.Result)
                                    {
                                        return RedirectToAction("seleccionar_unidad_para_contenido", "Seleccionar_para_subir_contenido");
                                    }
                                    else
                                    {
                                        ViewBag.mensaje1 = "actualizacion_no_registro";
                                        ViewBag.mensaje = "La actividad no fue habilitada con exito para los beneficiarios";
                                    }
                                }
                            }else
                            {
                                String codigo1 = Request.Form["irdesaprobado"];
                                if (codigo1 != null)
                                {
                                    if (ver.Actualizar_estado(codigo1, obj.edicion))
                                    {
                                        ViewBag.mensaje1 = "actualizacion_";
                                        ViewBag.mensaje = "Se a realizado las recomendaciones para edición";
                                    }
                                }
                            }
                        }
                    }
                    return View();//Pagina de actividad
                }
            }
            
        }

        public async Task<bool> SendEmail(string codigo, string uni)
        {
            return await Task.Run(() => {
                Actividades[] arreglos;
                Actividades ver = new Actividades();
                Actividades ac = new Actividades();
                bool a = false;
                DataTable dato;
                dato = ac.i_actividad(codigo); 
                arreglos = ver.usuarios_correo_actividad(uni);
                for (int i = 0; i < arreglos.Length; i++)
                {
                    if (arreglos[i].correo == null)
                    {
                        a = false;
                    }
                    else
                    {
                        MailMessage mail = new MailMessage();
                        mail.To.Add(arreglos[i].correo);
                        mail.From = new MailAddress("amazonianacademia@gmail.com");
                        mail.Subject = "Notificación";
                        mail.Body = "Se habilito la actividad: \n\r" + dato.Rows[0]["actividad"].ToString() + " las cual esta en el Curso: " + dato.Rows[0]["curso"].ToString() + " Nivel: " + dato.Rows[0]["nivel"].ToString() + " Unidad: " + dato.Rows[0]["unidad"].ToString() + " y su objetivo es: " + dato.Rows[0]["descripcion"].ToString() +
                            "\n\rpara el estudiante: " + arreglos[i].nombre_usuario + " identificado con el N°: " + arreglos[i].identificacion + " "+"https://amazoniaacademia.azurewebsites.net/Login/Login";


                        mail.IsBodyHtml = true;

                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.Host = "smtp.gmail.com";
                        smtp.Credentials = new NetworkCredential("amazonianacademia@gmail.com", "amazonian2020");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        a = true;
                    }
                }
                return a;
            });
           
        }

        public async Task<bool> registro_curso_usuario_actividad(string obj, string codigo_unidad)
        {
            contenido ar = new contenido();
            contenido[] arre;
            bool b = false;
            Plataforma_academica.Models.principalP act3 = Session["usuario10"] as Plataforma_academica.Models.principalP;
            return await Task.Run(() => {                
                arre = ar.buscar_usuarios_correo(codigo_unidad);
                if (arre != null)
                {
                    for (int i = 0; i < arre.Length; i++)
                    {
                        ar.Registrar_actividad_automatico(obj, arre[i].codigo_usuario_unidad);
                    }
                   b = true;
                    return b;
                }
                else
                {
                   b = false;
                   return b;
                }
            });     
        }

        [HttpPost]
        public JsonResult porcentaje()
        {
            Models.principalP actividad = Session["usuario3"] as Models.principalP;
            Models.Actividades sec1 = Session["seccion1"] as Models.Actividades;
            Actividades usu = new Actividades();
            DataTable datos = null;            
            DataTable datos1 = null;
            var x = 2;

            datos1 = usu.Buscar_porcentaje_seccion(actividad.codigo_actividad);
            usu.id_curso_actividad = Convert.ToInt32(datos1.Rows[0]["id tabla"].ToString());
            Session["seccion1"] = usu;

            if (Convert.ToDouble(datos1.Rows[0]["porcentaje"].ToString()) < 100)
                {
                    datos = usu.Buscar_cantidad_secciones(actividad.codigo_actividad);
                    usu.seccion = Convert.ToInt32(datos.Rows[0]["numero secciones"].ToString());
                    usu.cont_seccion++;
                    Session["seccion1"] = usu;
                    int countseccion = Convert.ToInt32(datos1.Rows[0]["seccion"].ToString());
                    countseccion++;

                if (countseccion <= Convert.ToInt32(datos.Rows[0]["numero secciones"].ToString()))
                {
                    double porce = (countseccion*100) / Convert.ToInt32(datos.Rows[0]["numero secciones"].ToString());
                    if (countseccion == Convert.ToInt32(datos.Rows[0]["numero secciones"].ToString()))
                    {
                        usu.Actualizar_porcentaje_estado(Convert.ToInt32(actividad.codigo_actividad), usu.id_curso_actividad);
                    }
                    usu.Actualizar_porcentaje(porce, Convert.ToInt32(actividad.codigo_actividad),countseccion, usu.id_curso_actividad);
                }


            }
            return Json(x);
        }
    }
}