using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class ContenidoController : Controller
    {
        string nombre;
        // GET: Contenido
        public ActionResult Cargar_contenido(contenido obj, lista_tipo_multimedia tipo, HttpPostedFileBase file, Clasificacion_multimedia tipoact)
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
                    List<SelectListItem> prueba = ViewData["lista"] as List<SelectListItem>;
                    if (prueba == null)
                    {
                        Plataforma_academica.Models.lista_tipo_multimedia ti = new Plataforma_academica.Models.lista_tipo_multimedia();
                        Plataforma_academica.Models.lista_tipo_multimedia[] tid;
                        Plataforma_academica.Models.Clasificacion_multimedia tiacti = new Plataforma_academica.Models.Clasificacion_multimedia();
                        Plataforma_academica.Models.Clasificacion_multimedia[] tia;

                        tid = ti.Consultar_tipo_multimedia();
                        tia = tiacti.Consultar_tipo_clasificacion();

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
                    }
                }
            }
            if (ValidarDatos(obj))
            {
                String codigo1 = Request.Form["Subir"];
                if (codigo1 != null)
                {
                    contenido id = new contenido();
                    DataTable datos = null;                
                    
                    //Plataforma_academica.Models.principalP act3 = Session["usuario10"] as Plataforma_academica.Models.principalP;
                    Plataforma_academica.Models.Subir_contenidos usu = Session["usuario11"] as Plataforma_academica.Models.Subir_contenidos;
                    datos = obj.Registrar_Contenido(obj, usu.codigo_unidad, Subir(file), nombre);
                    if (datos != null)
                    {
                        id.id_actividad = Convert.ToInt32(datos.Rows[0]["id_actividad"].ToString());
                        Session["usuario_id_actividad_seccion"] = id;                       
                        ViewBag.mensaje = "Registro exitoso";
                    }
                    else
                    {
                        ViewBag.mensaje = "No se registro el trabajador";
                    }
                }else
                {
                    int codigo2 = Convert.ToInt32(Request.Form["agregar"]);
                    String codigo3 = Request.Form["seccion"];
                    if (codigo2 > 0 || codigo3 != null)
                    {
                        ViewBag.mensaje = "Habilitar Sección";                        
                        if (codigo3 != null)
                        {
                            Plataforma_academica.Models.contenido id_actividad = Session["usuario_id_actividad_seccion"] as Plataforma_academica.Models.contenido;
                            if (obj.Registrar_seccion(obj, id_actividad.id_actividad, Subir(file), nombre))
                            {
                                ViewBag.mensaje = "Registro exitoso";
                            }
                            else
                            {
                                ViewBag.mensaje = "No se registro el trabajador";
                            }
                        }
                        
                    }
                }                
            }
            return View();
        }

        //[HttpPost]
        //public JsonResult automatico(string text)
        //{
        //    contenido[] arre;
        //    Plataforma_academica.Models.Subir_contenidos usu = Session["usuario11"] as Plataforma_academica.Models.Subir_contenidos;
        //    contenido ar = new contenido();
        //    arre = ar.buscar_usuarios_correo(usu.codigo_unidad);
        //    var x = 2;
        //    for (int i = 0; i < arre.Length; i++)
        //    {
        //        ar.Registrar_actividad_automatico(text, arre[i].codigo_usuario_unidad);
        //    }
        //    return Json(x);
        //}

        public bool ValidarDatos(contenido obj)
        {
            if (obj.nombre_contenido != null)
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
            else {
                archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName).ToLower();
                file.SaveAs(Server.MapPath("~/imagen_multimedia/" + archivo));
                nombre = file.FileName;                
            }
            return archivo;
        }
    }
}