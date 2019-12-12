using System;
using System.Collections.Generic;
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
                    if (codigo1 > 0)
                    {
                        for (int i = 0; i < codigo1 ; i++)
                        {
                            int respuesta = Convert.ToInt32(Request.Form["elegida_"+i]);                            
                            if (respuesta == 2)
                            {
                                suma++;
                            }

                        }
                        cantidad = (float)codigo1;
                        evaluar = maxi / cantidad;
                        resultado = evaluar * suma;
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