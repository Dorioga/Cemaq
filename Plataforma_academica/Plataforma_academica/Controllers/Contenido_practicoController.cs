using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class Contenido_practicoController : Controller
    {
        string nombre;
        // GET: Contenido_practico
        public ActionResult Contenido_practico(Contenido_practico obj, lista_tipo_multimedia tipo, HttpPostedFileBase file, Clasificacion_multimedia tipoact, Tipo_de_pregunta tipo_pregunta, Tipo_examen tipo_examen, Condiciones condicion)
        {
            Plataforma_academica.Models.principalP act2 = Session["usuario12"] as Plataforma_academica.Models.principalP;
            Login user = Session["usuario"] as Login;

            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Convert.ToInt32(user.rol) > 3)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (Request.Form["listar"] != null)
                    {
                        tipo.codigo = Request.Form["listar"].ToString();
                    }
                    if (Request.Form["listar1"] != null)
                    {
                        tipoact.codigo = Request.Form["listar1"].ToString();
                    }
                    if (Request.Form["listar2"] != null)
                    {
                        tipo_pregunta.codigo = Request.Form["listar2"].ToString();
                    }
                    if (Request.Form["listar3"] != null)
                    {
                        tipo_examen.codigo = Request.Form["listar3"].ToString();
                    }
                    if (Request.Form["listar4"] != null)
                    {
                        condicion.codigo = Request.Form["listar4"].ToString();
                    }
                    List<SelectListItem> prueba = ViewData["lista"] as List<SelectListItem>;
                    if (prueba == null)
                    {
                        Plataforma_academica.Models.lista_tipo_multimedia ti = new Plataforma_academica.Models.lista_tipo_multimedia();
                        Plataforma_academica.Models.lista_tipo_multimedia[] tid;
                        Plataforma_academica.Models.Clasificacion_multimedia tiacti = new Plataforma_academica.Models.Clasificacion_multimedia();
                        Plataforma_academica.Models.Clasificacion_multimedia[] tia;
                        Plataforma_academica.Models.Tipo_de_pregunta tipregunta = new Plataforma_academica.Models.Tipo_de_pregunta();
                        Plataforma_academica.Models.Tipo_de_pregunta[] tipopre;
                        Plataforma_academica.Models.Tipo_examen tiexam = new Plataforma_academica.Models.Tipo_examen();
                        Plataforma_academica.Models.Tipo_examen[] tipoexam;
                        Plataforma_academica.Models.Condiciones condici = new Plataforma_academica.Models.Condiciones();
                        Plataforma_academica.Models.Condiciones[] condi;

                        tid = ti.Consultar_tipo_multimedia();
                        tia = tiacti.Consultar_tipo_clasificacion();
                        tipopre = tipregunta.Consultar_tipo_pregunta();
                        tipoexam = tiexam.Consultar_tipo_examen();
                        condi = condici.Consultar_tipo_condicion();

                        List<SelectListItem> lista = new List<SelectListItem>();
                        foreach (lista_tipo_multimedia i in tid)
                        {
                            lista.Add(new SelectListItem
                            {
                                Text = i.nombre,
                                Value = i.codigo,
                                Selected = false
                            });
                        }
                        ViewData["lista2"] = lista;

                        List<SelectListItem> lista1 = new List<SelectListItem>();
                        foreach (Clasificacion_multimedia i in tia)
                        {
                            lista1.Add(new SelectListItem
                            {
                                Text = i.nombre,
                                Value = i.codigo,
                                Selected = false
                            });
                        }
                        ViewData["lista1"] = lista1;

                        List<SelectListItem> lista2 = new List<SelectListItem>();
                        foreach (Tipo_de_pregunta i in tipopre)
                        {
                            lista2.Add(new SelectListItem
                            {
                                Text = i.nombre,
                                Value = i.codigo,
                                Selected = false
                            });
                        }
                        ViewData["lista3"] = lista2;

                        List<SelectListItem> lista3 = new List<SelectListItem>();
                        foreach (Tipo_examen i in tipoexam)
                        {
                            lista3.Add(new SelectListItem
                            {
                                Text = i.nombre,
                                Value = i.codigo,
                                Selected = false
                            });
                        }
                        ViewData["lista4"] = lista3;

                        List<SelectListItem> lista4 = new List<SelectListItem>();
                        foreach (Condiciones i in condi)
                        {
                            lista4.Add(new SelectListItem
                            {
                                Text = i.nombre,
                                Value = i.codigo,
                                Selected = false
                            });
                        }
                        ViewData["lista5"] = lista4;
                    }
                }
            }
            if (ValidarDatos(obj))
            {
                String codigo1 = Request.Form["subir1"];
                if (codigo1 != null)
                {
                    Contenido_practico id_examen = new Contenido_practico();
                    DataTable datos = null;
                    Plataforma_academica.Models.Subir_contenidos usu = Session["usuario11"] as Plataforma_academica.Models.Subir_contenidos;
                    datos = obj.Registrar_Titulo_practica(obj, usu.codigo_unidad);
                    if (datos != null)
                    {
                        id_examen.id_exam = Convert.ToInt32(datos.Rows[0]["id_examen"].ToString());
                        Session["usuario_id_actividad_examen"] = id_examen;
                        ViewBag.mensaje = "Registro exitoso";
                        codigo1 = null;
                    }
                    else
                    {
                        ViewBag.mensaje = "No se registro el examen";
                    }
                }else
                {
                    String codigo3 = Request.Form["seccion"];
                    if (codigo3 != null)
                    {
                        ViewBag.mensaje = "Elegir pregunta";
                    }
                    else
                    {
                        String codigo2 = Request.Form["elegir"];
                        if (codigo2 != null)
                        {
                            Contenido_practico pregunta = new Contenido_practico();
                            Plataforma_academica.Models.Contenido_practico cont = Session["usuario_id_actividad_examen"] as Plataforma_academica.Models.Contenido_practico;
                            DataTable datos = null;
                            datos = obj.Registrar_pregunta(obj,cont.id_exam, Subir(file), nombre);
                            if (datos != null)
                            {
                                pregunta.tipo_pregunta = obj.tipo_pregunta;
                                pregunta.id_pregunta = datos.Rows[0]["id_pregunta"].ToString();
                                Session["usuario_pregunta"] = pregunta;
                                ViewBag.mensaje = "Registro pregunta";
                            }else
                            {
                                ViewBag.mensaje = "No se registro la pregunta";
                            }
                        }else
                        {
                            String codigo4 = Request.Form["seccion_2"];
                            if (codigo4 != null)
                            {
                                Contenido_practico pregunta = new Contenido_practico();
                                Plataforma_academica.Models.Contenido_practico res = Session["usuario_pregunta"] as Plataforma_academica.Models.Contenido_practico;
                                if (obj.Registrar_Respuesta(obj,res.id_pregunta))
                                {
                                    ViewBag.mensaje = "Registro otra respuesta";
                                }else
                                {
                                    ViewBag.mensaje = "No se registraron sus respuestas";
                                }
                                
                            }
                            else
                            {
                                String codigo5 = Request.Form["elegir1"];
                                if (codigo5 != null)
                                {
                                    ViewBag.mensaje = "Registro pregunta";
                                }
                                else
                                {
                                    String codigo6 = Request.Form["agregar"];
                                    if (codigo6 != null)
                                    {
                                        ViewBag.mensaje = "Registro exitoso";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return View();
        }

        public bool ValidarDatos(Contenido_practico obj)
        {
            if (obj.nombre_contenido != null || obj.nombre_pregunta != null)
            {
                return true;
            }
            else
            {
                return false;
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
    }
}