using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class Editar_ActividadController : Controller
    {
        DataTable dato = null;
        Editar_Actividad se = new Editar_Actividad();
        Editar_Actividad act = new Editar_Actividad();
        // GET: Editar_Actividad
        public ActionResult Editar_Actividad(lista_tipo_multimedia tipo, Editar_Actividad obj, HttpPostedFileBase file)
        {
            Plataforma_academica.Models.principalP act2 = Session["usuario12"] as Plataforma_academica.Models.principalP;
            Models.Login user = Session["usuario"] as Models.Login;
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
                        obj.id_seccion = Request.Form["listar1"].ToString();
                    }
                    List<SelectListItem> prueba = ViewData["lista"] as List<SelectListItem>;
                    if (prueba == null)
                    {
                        Plataforma_academica.Models.lista_tipo_multimedia ti = new Plataforma_academica.Models.lista_tipo_multimedia();
                        Plataforma_academica.Models.lista_tipo_multimedia[] tid;
                        Plataforma_academica.Models.Editar_Actividad edi = new Plataforma_academica.Models.Editar_Actividad();
                        Plataforma_academica.Models.Editar_Actividad[] editar;

                        tid = ti.Consultar_tipo_multimedia();
                        editar = edi.lista_editar(act2.codigo_actividad);

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
                        foreach (Editar_Actividad i in editar)
                        {
                            lista1.Add(new SelectListItem
                            {
                                Text = i.titulo_seccion,
                                Value = i.id_seccion,
                                Selected = false
                            });
                        }
                        ViewData["lista1"] = lista1;
                    }
                    String codig100 = Request.Form["ir100"];
                        if (codig100 != null)
                        {
//9,16,17
                            dato = obj.contenido_actividad_editar(obj, act2.codigo_actividad);

                            if (dato != null && dato.Rows.Count > 0)
                            {
                                se.id_seccion = dato.Rows[0]["id_seccion"].ToString();
                                se.id_tipo_multimedia = dato.Rows[0]["tipo multimedia"].ToString();
                                se.id_multimedia = dato.Rows[0]["id_multimedia"].ToString();
                                se.contenido_seccion = dato.Rows[0]["contenido_seccion"].ToString();
                                se.titulo_seccion = dato.Rows[0]["titulo_seccion"].ToString();
                                se.url_multimedia = dato.Rows[0]["url_multimedia"].ToString();
                                se.Nombre_actividad = dato.Rows[0]["nombre_actividad"].ToString();
                                Session["usuario19"] = se;

                            }
                        }

                        String editar1 = Request.Form["ir1"];
                        String editar2 = Request.Form["ir4"];
                        String editar3 = Request.Form["ir8"];
                        String editar4 = Request.Form["ir12"];
                        String editar18 = Request.Form["ir16"];
                        String editar19 = Request.Form["ir19"];
                        String editar20 = Request.Form["ir20"];
                        String editar21 = Request.Form["ir21"];
                    if (editar1 != null)
                        {
                            if (obj.Actualizar_nombre_actividad(editar1, obj))
                            {
                                ViewBag.mensaje = "Registro exitoso";

                            }
                            else
                            {
                                ViewBag.mensaje = "no se realizo la actualización";
                            }
                        }
                        else
                        {
                            if (editar2 != null)
                            {
                                if (obj.Actualizar_nombre_actividad(editar2, obj))
                                {
                                    ViewBag.mensaje = "Registro exitoso";

                                }
                                else
                                {
                                    ViewBag.mensaje = "no se realizo la actualización";
                                }
                            }
                            else
                            {
                                if (editar3 != null)
                                {
                                    if (obj.Actualizar_nombre_actividad(editar3, obj))
                                    {
                                        ViewBag.mensaje = "Registro exitoso";

                                    }
                                    else
                                    {
                                        ViewBag.mensaje = "no se realizo la actualización";
                                    }
                                }
                                else
                                {
                                    if (editar4 != null)
                                    {
                                        if (obj.Actualizar_nombre_actividad(editar4, obj))
                                        {
                                            ViewBag.mensaje = "Registro exitoso";

                                        }
                                        else
                                        {
                                            ViewBag.mensaje = "no se realizo la actualización";
                                        }
                                    }
                                    else
                                    {
                                       if (editar18 != null)
                                       {
                                         if (obj.Actualizar_nombre_seccion(editar18, obj))
                                         {
                                            ViewBag.mensaje = "Registro exitoso";

                                         }
                                         else
                                         {
                                            ViewBag.mensaje = "no se realizo la actualización";
                                         }
                                        }
                                       else
                                        {
                                        if (editar19 != null)
                                        {
                                            if (obj.Actualizar_nombre_seccion(editar19, obj))
                                            {
                                                ViewBag.mensaje = "Registro exitoso";

                                            }
                                            else
                                            {
                                                ViewBag.mensaje = "no se realizo la actualización";
                                            }
                                        }else
                                        {
                                            if (editar20 != null)
                                            {
                                                if (obj.Actualizar_nombre_seccion(editar20, obj))
                                                {
                                                    ViewBag.mensaje = "Registro exitoso";

                                                }
                                                else
                                                {
                                                    ViewBag.mensaje = "no se realizo la actualización";
                                                }
                                            }else
                                            {
                                                if (editar21 != null)
                                                {
                                                    if (obj.Actualizar_nombre_seccion(editar21, obj))
                                                    {
                                                        ViewBag.mensaje = "Registro exitoso";

                                                    }
                                                    else
                                                    {
                                                        ViewBag.mensaje = "no se realizo la actualización";
                                                    }
                                                }
                                                else
                                                {
                                                    String editar5 = Request.Form["ir2"];
                                                    String editar6 = Request.Form["ir5"];
                                                    String editar7 = Request.Form["ir9"];
                                                    String editar8 = Request.Form["ir13"];
                                                    String editar17 = Request.Form["ir17"];
                                                    String editar22 = Request.Form["ir22"];
                                                    String editar23 = Request.Form["ir23"];
                                                    String editar24 = Request.Form["ir24"];

                                                    if (editar5 != null)
                                                    {
                                                        if (obj.Actualizar_descripcion_actividad(editar5, obj))
                                                        {
                                                            ViewBag.mensaje = "Registro exitoso";

                                                        }
                                                        else
                                                        {
                                                            ViewBag.mensaje = "no se realizo la actualización";
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (editar6 != null)
                                                        {
                                                            if (obj.Actualizar_descripcion_actividad(editar6, obj))
                                                            {
                                                                ViewBag.mensaje = "Registro exitoso";

                                                            }
                                                            else
                                                            {
                                                                ViewBag.mensaje = "no se realizo la actualización";
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (editar7 != null)
                                                            {
                                                                if (obj.Actualizar_descripcion_actividad(editar7, obj))
                                                                {
                                                                    ViewBag.mensaje = "Registro exitoso";

                                                                }
                                                                else
                                                                {
                                                                    ViewBag.mensaje = "no se realizo la actualización";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (editar8 != null)
                                                                {
                                                                    if (obj.Actualizar_descripcion_actividad(editar8, obj))
                                                                    {
                                                                        ViewBag.mensaje = "Registro exitoso";

                                                                    }
                                                                    else
                                                                    {
                                                                        ViewBag.mensaje = "no se realizo la actualización";
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (editar17 != null)
                                                                    {
                                                                        if (obj.Actualizar_descripcion_seccion(obj))
                                                                        {
                                                                            ViewBag.mensaje = "Registro exitoso";

                                                                        }
                                                                        else
                                                                        {
                                                                            ViewBag.mensaje = "no se realizo la actualización";
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (editar22 != null)
                                                                        {
                                                                            if (obj.Actualizar_descripcion_seccion(obj))
                                                                            {
                                                                                ViewBag.mensaje = "Registro exitoso";

                                                                            }
                                                                            else
                                                                            {
                                                                                ViewBag.mensaje = "no se realizo la actualización";
                                                                            }
                                                                        }else
                                                                        {
                                                                            if (editar23 != null)
                                                                            {
                                                                                if (obj.Actualizar_descripcion_seccion(obj))
                                                                                {
                                                                                    ViewBag.mensaje = "Registro exitoso";

                                                                                }
                                                                                else
                                                                                {
                                                                                    ViewBag.mensaje = "no se realizo la actualización";
                                                                                }
                                                                            }else
                                                                            {
                                                                                if (editar24 != null)
                                                                                {
                                                                                    if (obj.Actualizar_descripcion_seccion(obj))
                                                                                    {
                                                                                        ViewBag.mensaje = "Registro exitoso";

                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        ViewBag.mensaje = "no se realizo la actualización";
                                                                                    }
                                                                                }else
                                                                                {
                                                                                    String editar9 = Request.Form["ir7"];
                                                                                    String editar10 = Request.Form["ir11"];
                                                                                    String editar11 = Request.Form["ir15"];
                                                                                    if (editar9 != null)
                                                                                    {
                                                                                        if (obj.Eliminar_multimedia(editar9))
                                                                                        {
                                                                                            ViewBag.mensaje = "Registro exitoso";
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (editar10 != null)
                                                                                        {
                                                                                            if (obj.Eliminar_multimedia(editar10))
                                                                                            {
                                                                                                ViewBag.mensaje = "Registro exitoso";
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (editar11 != null)
                                                                                            {
                                                                                                if (obj.Eliminar_multimedia(editar11))
                                                                                                {
                                                                                                    ViewBag.mensaje = "Registro exitoso";
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                String editar12 = Request.Form["ir3"];
                                                                                                String editar13 = Request.Form["ir18"];
                                                                                                if (editar12 != null)
                                                                                                {
                                                                                                    if (Convert.ToInt32(obj.mul) > 0)
                                                                                                    {
                                                                                                        if (file != null)
                                                                                                        {
                                                                                                            if (obj.Actualizar_multimedia(editar12, obj, Subir(file), tipo, file))
                                                                                                            {
                                                                                                                file = null;
                                                                                                                ViewBag.mensaje = "Registro exitoso";
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                ViewBag.mensaje = "no se realizo la actualización";
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (editar13 != null)
                                                                                                    {
                                                                                                        if (file != null)
                                                                                                        {
                                                                                                            if (obj.Actualizar_multimedia(editar13, obj, Subir(file), tipo, file))
                                                                                                            {
                                                                                                                file = null;
                                                                                                                ViewBag.mensaje = "Registro exitoso";
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                ViewBag.mensaje = "no se realizo la actuzalización";
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        String editar14 = Request.Form["ir6"];
                                                                                                        String editar15 = Request.Form["ir10"];
                                                                                                        String editar16 = Request.Form["ir14"];
                                                                                                        if (editar14 != null)
                                                                                                        {
                                                                                                            if (Convert.ToInt32(obj.mul) > 0)
                                                                                                            {
                                                                                                                if (file != null)
                                                                                                                {
                                                                                                                    if (obj.Actualizar_multimedia(editar14, obj, Subir(file), tipo, file))
                                                                                                                    {
                                                                                                                        file = null;
                                                                                                                        ViewBag.mensaje = "Registro exitoso";
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        ViewBag.mensaje = "no se realizo la actualización";
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (editar15 != null)
                                                                                                            {
                                                                                                                if (Convert.ToInt32(obj.mul) > 0)
                                                                                                                {
                                                                                                                    if (file != null)
                                                                                                                    {
                                                                                                                        if (obj.Actualizar_multimedia(editar15, obj, Subir(file), tipo, file))
                                                                                                                        {
                                                                                                                            file = null;
                                                                                                                            ViewBag.mensaje = "Registro exitoso";
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            ViewBag.mensaje = "no se realizo la actualización";
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (editar16 != null)
                                                                                                                {
                                                                                                                    if (Convert.ToInt32(obj.mul) > 0)
                                                                                                                    {
                                                                                                                        if (file != null)
                                                                                                                        {
                                                                                                                            if (obj.Actualizar_multimedia(editar16, obj, Subir(file), tipo, file))
                                                                                                                            {
                                                                                                                                file = null;
                                                                                                                                ViewBag.mensaje = "Registro exitoso";
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                ViewBag.mensaje = "no se realizo la actualización";
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }                                                                        
                                                                    }

                                                                }
                                                            }
                                                        }

                                                    }
                                                }
                                            }
                                        }                                        
                                    }   
                                    }
                                }
                            }
                        }
                    }
                    return View(obj);
                }
           
        }

        [HttpPost]
        public string Subir(HttpPostedFileBase file)
        {
            if (file == null) return null;
            string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName).ToLower();
            file.SaveAs(Server.MapPath("~/imagen_multimedia/" + archivo));
            return archivo;
        }
    }
}