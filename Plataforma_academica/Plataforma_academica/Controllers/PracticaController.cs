using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class PracticaController : Controller
    {
        // GET: Practica
        public ActionResult Practica()
        {
            Models.Login user = Session["usuario"] as Models.Login;
            Models.Practicas practica = new Models.Practicas();
            Plataforma_academica.Models.principalP act2 = Session["usuarios10"] as Plataforma_academica.Models.principalP;
            Plataforma_academica.Models.principalP act3 = Session["usuarios2"] as Plataforma_academica.Models.principalP;
            Plataforma_academica.Models.Practicas intent = Session["intentos"] as Plataforma_academica.Models.Practicas;
            Plataforma_academica.Models.Practicas[] arreglo;
            int rol = Convert.ToInt32(user.rol);
            int intentos2;
            DataTable datos = null;
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Convert.ToInt32(user.rol) > 10)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    int codigo1 = Convert.ToInt32(Request.Form["calcular"]);
                    int suma = 0;
                    float resultado;
                    float maxi = 5;
                    float evaluar;
                    float cantidad;
                    cantidad = (float)codigo1;
                    evaluar = maxi / cantidad;
                    if (codigo1 > 0)
                    {
                        if (rol < 4 || rol >= 7)
                        {
                            arreglo = practica.Consultar_reguntas(act2.codigo_examen);
                            datos = practica.Buscarintentos(act2.codigo_examen, user.usuario);
                            if (datos != null && datos.Rows.Count > 0)
                            {
                                practica.intentos = Convert.ToInt32(datos.Rows[0]["intentos"].ToString());
                                Session["intentos"] = practica;
                            }else
                            {
                                practica.intentos = 0;
                                Session["intentos"] = practica;
                                intentos2 = practica.intentos;
                                intentos2++;
                                for (int i = 0; i < codigo1; i++)
                                {
                                    int respuesta = Convert.ToInt32(Request.Form["elegida_" + i]);
                                    if (respuesta == 2)
                                    {
                                        practica.registrar_nota(user.usuario, arreglo[i].id_pregunta, respuesta, evaluar, intentos2);
                                        suma++;
                                    }
                                    else
                                    {              
                                        practica.registrar_nota(user.usuario, arreglo[i].id_pregunta, respuesta, 0, intentos2);
                                    }

                                }
                                ViewBag.mensaje3 = "Este es su intento N°: " + intentos2 + " intentos permitidos";
                            }
                            //error?
                            if (practica.intentos == 1)
                            {                                
                                intentos2=practica.intentos;
                                intentos2++;
                                for (int i = 0; i < codigo1; i++)
                                {
                                    int respuesta = Convert.ToInt32(Request.Form["elegida_" + i]);
                                    if (respuesta == 2)
                                    {
                                        
                                        practica.actualizar_intentos(user.usuario, act2.codigo_examen, intentos2, respuesta, evaluar, arreglo[i].id_pregunta);
                                        suma++;
                                    }
                                    else
                                    {
                                        
                                        practica.actualizar_intentos(user.usuario, act2.codigo_examen, intentos2, respuesta, 0, arreglo[i].id_pregunta);
                                    }

                                }                                
                                ViewBag.mensaje3 = "Este es su intento N°: " + intentos2 + " intentos permitidos";
                            }
                            else
                            {
                                if (practica.intentos >= 2)
                                {
                                    ViewBag.mensaje3 = "Usted ya realizo los 2 intentos permitidos";
                                }
                            }
                        }
                        else
                        {
                            if (rol > 3 && rol < 7)
                            {
                                arreglo = practica.Consultar_reguntas(act3.codigo_examen);
                                datos = practica.Buscarintentos(act3.codigo_examen, user.usuario);
                                if (datos != null && datos.Rows.Count > 0)
                                {
                                    practica.intentos = Convert.ToInt32(datos.Rows[0]["intetos"].ToString());
                                    Session["intentos"] = practica;
                                }
                                else
                                {
                                    practica.intentos = 0;
                                    Session["intentos"] = practica;
                                    intentos2 = practica.intentos;
                                    intentos2++;
                                    for (int i = 0; i < codigo1; i++)
                                    {
                                        int respuesta = Convert.ToInt32(Request.Form["elegida_" + i]);
                                        if (respuesta == 2)
                                        {
                                            
                                            practica.registrar_nota(user.usuario, arreglo[i].id_pregunta, respuesta, evaluar,intentos2);
                                            suma++;
                                        }
                                        else
                                        {
                                            
                                            practica.registrar_nota(user.usuario, arreglo[i].id_pregunta, respuesta, 0, intentos2);
                                        }

                                    }
                                    ViewBag.mensaje3 = "Este es su intento N°: " + intentos2 + " intentos permitidos";
                                }
                                if (practica.intentos == 1)
                                {
                                    intentos2 = practica.intentos;
                                    intentos2++;
                                    for (int i = 0; i < codigo1; i++)
                                    {
                                        int respuesta = Convert.ToInt32(Request.Form["elegida_" + i]);
                                        if (respuesta == 2)
                                        {

                                            practica.actualizar_intentos(user.usuario, act3.codigo_examen, intentos2, respuesta, evaluar, arreglo[i].id_pregunta);
                                            suma++;
                                        }
                                        else
                                        {
                                            practica.actualizar_intentos(user.usuario, act3.codigo_examen, intentos2, respuesta, 0, arreglo[i].id_pregunta);
                                        }

                                    }
                                    ViewBag.mensaje3 = "Este es su intento N°: " + intentos2 + " intentos permitidos";
                                }
                                else
                                {
                                    if (practica.intentos>=2)
                                    {
                                        ViewBag.mensaje3 = "Usted ya realizo los 2 intentos permitidos";
                                    }
                                }
                            }
                        }                       
                        resultado = evaluar * suma;
                        //aqui va la nota del examen/practica/quiz
                        if (resultado < 3)
                        {
                            ViewBag.mensaje1 = "Perdio";
                            ViewBag.mensaje2 = "su nota es: "+resultado+" por lo cual se le recomienda instruirse nuevamente sobre las actividades relacionadas al examen";
                        }else
                        {
                            if (resultado < 3.5)
                            {
                                ViewBag.mensaje1 = "aprobo";
                                ViewBag.mensaje2 = "su nota es: " + resultado + " con la cual aprobo, pero se recomienda seguir mejorando mediante el uso de las actividades teóricas";
                            }else
                            {
                                if (resultado < 3.9)
                                {
                                    ViewBag.mensaje1 = "aprobo";
                                    ViewBag.mensaje2 = "su nota es: " + resultado + " con la cual aprobo, pero se recomienda seguir mejorando mediante el uso de las actividades teóricas";
                                }
                                else
                                {
                                    if (resultado > 3.9)
                                    {
                                        ViewBag.mensaje1 = "aprobo";
                                        ViewBag.mensaje2 = "su nota es: " + resultado + " con la cual aprobo el examen";
                                    }
                                }
                            }
                        }
                    }
                    return View();//Pagina de actividad               

                }
            }
        }
    }
}