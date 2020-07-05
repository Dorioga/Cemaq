using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Plataforma_academica.Controllers
{
    public class Registrar_BeneficiarioController : Controller
    {

        public ActionResult Registrar_Beneficiario(HttpPostedFileBase excelfile)
        {
            Registrar_Beneficiario R = new Registrar_Beneficiario();
            Registrar_Beneficiario D = new Registrar_Beneficiario();
            Registrar_Beneficiario unidad = new Registrar_Beneficiario();
            Registrar_Beneficiario unidad1 = new Registrar_Beneficiario();
            Registrar_Beneficiario actividad = new Registrar_Beneficiario();
            Plataforma_academica.Models.principalP act2 = Session["usuario12"] as Plataforma_academica.Models.principalP;
            Models.Login user = Session["usuario"] as Models.Login;
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Convert.ToInt32(user.rol) != 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (excelfile == null || excelfile.ContentLength == 0)
                    {
                        ViewBag.Mensaje = "Selecione un archivo de Excel!";

                    }
                    else
                    {
                        if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                        {
                            string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + excelfile.FileName).ToLower();
                            excelfile.SaveAs(Server.MapPath("~/Excel_R_Beneficiarios/" + archivo));
                            Excel.Application application = new Excel.Application();
                            Excel.Workbook workbook = application.Workbooks.Open(Server.MapPath("~/Excel_R_Beneficiarios/" + archivo));
                            Excel.Worksheet worksheet = workbook.ActiveSheet;
                            Excel.Range range = worksheet.UsedRange;
                            List<Registrar_Beneficiario> listAlumnos = new List<Registrar_Beneficiario>();
                            for (int row = 1; row <= range.Rows.Count; row++)
                            {
                               
                                R.cedula = ((Excel.Range)range.Cells[row, 1]).Text;
                                R.nombre1 = ((Excel.Range)range.Cells[row, 2]).Text;
                                R.nombre2 = ((Excel.Range)range.Cells[row, 3]).Text;
                                R.apellido1 = ((Excel.Range)range.Cells[row, 4]).Text;
                                R.apellido2 = ((Excel.Range)range.Cells[row, 5]).Text;
                                R.fecha_nacimiento = ((Excel.Range)range.Cells[row, 6]).Text;
                                R.telefono = ((Excel.Range)range.Cells[row, 7]).Text;
                                R.correo = ((Excel.Range)range.Cells[row, 8]).Text;
                                R.documento = ((Excel.Range)range.Cells[row, 9]).Text;
                                R.poblacion = ((Excel.Range)range.Cells[row, 10]).Text;
                                R.genero = ((Excel.Range)range.Cells[row, 11]).Text;
                                R.cod_rol = ((Excel.Range)range.Cells[row, 12]).Text;
                                R.nombre_empresa = ((Excel.Range)range.Cells[row, 13]).Text;
                                R.nombre_grupo= ((Excel.Range)range.Cells[row, 14]).Text;
                                R.nombre_curso = ((Excel.Range)range.Cells[row, 15]).Text;
                                R.cantidad_nivel = ((Excel.Range)range.Cells[row, 16]).Text;
                                R.nivel1 = ((Excel.Range)range.Cells[row, 17]).Text;
                                R.nivel2 = ((Excel.Range)range.Cells[row, 18]).Text;
                                R.nivel3 = ((Excel.Range)range.Cells[row, 19]).Text;


                                DataTable datos1;
                                DataTable datos2;

                                Registrar_Beneficiario v = new Registrar_Beneficiario();
                                if (row > 1 && R.cedula != "")
                                {
                                    datos1 = v.Buscarbeneficiario(R.cedula);
                                    if (datos1 != null && datos1.Rows.Count > 0)
                                    {
                                        ViewBag.mensaje = "El alumno ya existe";
                                        ViewBag.mensaje2 = "El alumno con numero de cedula: " + R.cedula + " y nombre: " + R.nombre1 + " " + R.apellido1 + " ya existe";
                                        listAlumnos.Add(R);
                                        ViewBag.ListAlumnos = listAlumnos;
                                        return View();
                                    }
                                    else
                                    {
                                        if (D.Registrar_Beneficiarios(R))
                                        {
                                            //if (D.Registrar_Nivel_Beneficiarios(R))
                                            //{
                                            //    if (Convert.ToUInt32(R.cantidad_nivel) == 1)
                                            //    {
                                            //        datos2 = D.Buscarunidades_para_registrar1(R);
                                            //        for (int i = 0; i < datos2.Rows.Count; i++)
                                            //        {
                                            //            unidad.codigo_unidad = datos2.Rows[i]["id_unidad"].ToString();
                                            //            if (unidad1.Registrar_Unidad_Beneficiarios1(unidad, R))
                                            //            {
                                            //                datos1 = D.Buscaractividades_para_registrar(unidad);
                                            //                for (int j = 0; j < datos1.Rows.Count; j++)
                                            //                {
                                            //                    actividad.codigo_actividad = datos1.Rows[j]["id_actividad"].ToString();
                                            //                    actividad.Registrar_actividad_Beneficiarios(actividad,R, unidad);

                                            //                }
                                            //                datos1 = D.Buscarexamen_para_registrar(unidad);
                                            //                for (int j = 0; j < datos1.Rows.Count; j++)
                                            //                {
                                            //                    actividad.codigo_examen = datos1.Rows[j]["id_examen"].ToString();
                                            //                    actividad.Registrar_examen_Beneficiarios(actividad, R, unidad);

                                            //                }
                                            //            }

                                            //        }
                                            //    }else
                                            //    {
                                            //        if (Convert.ToUInt32(R.cantidad_nivel) == 2)
                                            //        {
                                            //            datos1 = D.Buscarunidades_para_registrar1(R);
                                            //            for (int i = 0; i < datos1.Rows.Count; i++)
                                            //            {
                                            //                unidad.codigo_unidad = datos1.Rows[i]["id_unidad"].ToString();
                                            //                if (unidad1.Registrar_Unidad_Beneficiarios1(unidad, R))
                                            //                {
                                            //                    datos1 = D.Buscaractividades_para_registrar(unidad);
                                            //                    for (int j = 0; j < datos1.Rows.Count; j++)
                                            //                    {
                                            //                        actividad.codigo_actividad = datos1.Rows[j]["id_actividad"].ToString();
                                            //                        actividad.Registrar_actividad_Beneficiarios(actividad, R, unidad);

                                            //                    }
                                            //                    datos1 = D.Buscarexamen_para_registrar(unidad);
                                            //                    for (int j = 0; j < datos1.Rows.Count; j++)
                                            //                    {
                                            //                        actividad.codigo_examen = datos1.Rows[j]["id_examen"].ToString();
                                            //                        actividad.Registrar_examen_Beneficiarios(actividad, R, unidad);

                                            //                    }
                                            //                }
                                            //            }
                                            //            datos1 = R.Buscarunidades_para_registrar2(R);
                                            //            for (int i = 0; i < datos1.Rows.Count; i++)
                                            //            {
                                            //                unidad.codigo_unidad = datos1.Rows[i]["id_unidad"].ToString();
                                            //                if (unidad1.Registrar_Unidad_Beneficiarios2(unidad, R))
                                            //                {
                                            //                    datos1 = D.Buscaractividades_para_registrar(unidad);
                                            //                    for (int j = 0; j < datos1.Rows.Count; j++)
                                            //                    {
                                            //                        actividad.codigo_actividad = datos1.Rows[j]["id_actividad"].ToString();
                                            //                        actividad.Registrar_actividad_Beneficiarios(actividad, R, unidad);

                                            //                    }
                                            //                    datos1 = D.Buscarexamen_para_registrar(unidad);
                                            //                    for (int j = 0; j < datos1.Rows.Count; j++)
                                            //                    {
                                            //                        actividad.codigo_examen = datos1.Rows[j]["id_examen"].ToString();
                                            //                        actividad.Registrar_examen_Beneficiarios(actividad, R, unidad);

                                            //                    }
                                            //                }
                                            //            }
                                            //        }
                                            //        else
                                            //        {
                                            //            if (Convert.ToUInt32(R.cantidad_nivel) == 3)
                                            //            {
                                            //                datos1 = D.Buscarunidades_para_registrar1(R);
                                            //                for (int i = 0; i < datos1.Rows.Count; i++)
                                            //                {
                                            //                    unidad.codigo_unidad = datos1.Rows[i]["id_unidad"].ToString();
                                            //                    if (unidad1.Registrar_Unidad_Beneficiarios1(unidad, R))
                                            //                    {
                                            //                        datos1 = D.Buscaractividades_para_registrar(unidad);
                                            //                        for (int j = 0; j < datos1.Rows.Count; j++)
                                            //                        {
                                            //                            actividad.codigo_actividad = datos1.Rows[j]["id_actividad"].ToString();
                                            //                            actividad.Registrar_actividad_Beneficiarios(actividad, R, unidad);

                                            //                        }
                                            //                        datos1 = D.Buscarexamen_para_registrar(unidad);
                                            //                        for (int j = 0; j < datos1.Rows.Count; j++)
                                            //                        {
                                            //                            actividad.codigo_examen = datos1.Rows[j]["id_examen"].ToString();
                                            //                            actividad.Registrar_examen_Beneficiarios(actividad, R, unidad);

                                            //                        }
                                            //                    }
                                            //                }
                                            //                datos1 = D.Buscarunidades_para_registrar2(R);
                                            //                for (int i = 0; i < datos1.Rows.Count; i++)
                                            //                {
                                            //                    unidad.codigo_unidad = datos1.Rows[i]["id_unidad"].ToString();
                                            //                    if (unidad1.Registrar_Unidad_Beneficiarios2(unidad, R))
                                            //                    {
                                            //                        datos1 = D.Buscaractividades_para_registrar(unidad);
                                            //                        for (int j = 0; j < datos1.Rows.Count; j++)
                                            //                        {
                                            //                            actividad.codigo_actividad = datos1.Rows[j]["id_actividad"].ToString();
                                            //                            actividad.Registrar_actividad_Beneficiarios(actividad, R, unidad);

                                            //                        }
                                            //                        datos1 = D.Buscarexamen_para_registrar(unidad);
                                            //                        for (int j = 0; j < datos1.Rows.Count; j++)
                                            //                        {
                                            //                            actividad.codigo_examen = datos1.Rows[j]["id_examen"].ToString();
                                            //                            actividad.Registrar_examen_Beneficiarios(actividad, R, unidad);

                                            //                        }
                                            //                    }
                                            //                }
                                            //                datos1 = D.Buscarunidades_para_registrar3(R);
                                            //                for (int i = 0; i < datos1.Rows.Count; i++)
                                            //                {
                                            //                    unidad.codigo_unidad = datos1.Rows[i]["id_unidad"].ToString();
                                            //                    if (unidad1.Registrar_Unidad_Beneficiarios3(unidad, R))
                                            //                    {
                                            //                        datos1 = D.Buscaractividades_para_registrar(unidad);
                                            //                        for (int j = 0; j < datos1.Rows.Count; j++)
                                            //                        {
                                            //                            actividad.codigo_actividad = datos1.Rows[j]["id_actividad"].ToString();
                                            //                            actividad.Registrar_actividad_Beneficiarios(actividad, R, unidad);

                                            //                        }
                                            //                        datos1 = D.Buscarexamen_para_registrar(unidad);
                                            //                        for (int j = 0; j < datos1.Rows.Count; j++)
                                            //                        {
                                            //                            actividad.codigo_examen = datos1.Rows[j]["id_examen"].ToString();
                                            //                            actividad.Registrar_examen_Beneficiarios(actividad, R, unidad);

                                            //                        }
                                            //                    }
                                            //                }
                                            //            }
                                            //        }
                                            //    }                                             
                                            //}
                                        }else
                                        {
                                            ViewBag.Mensaje = "Incorrecto!";
                                        }
                                        listAlumnos.Add(R);
                                        ViewBag.Mensaje = "Correcto!";
                                    }
                                }                                
                            }
                            ViewBag.ListAlumnos = listAlumnos;
                            return View();
                        }
                        else
                        {
                            ViewBag.Mensaje = "Selecione un archivo de Excel correcto!";
                        }
                    }
                }
                return View();
            }
        }

        //[HttpPost]
        //public List<SelectListItem> Lista_municipios(string id)
        //{
        //    Plataforma_academica.Models.Municipio mun = new Plataforma_academica.Models.Municipio();
        //    List<SelectListItem> lista1 = new List<SelectListItem>();
        //    if (Request.Form["listar1"] != null)
        //    {
        //        mun.id_municipio = Request.Form["listar1"].ToString();
        //    }

        //    List<SelectListItem> prueba = ViewData["lista"] as List<SelectListItem>;
        //    if (prueba == null)
        //    {
        //        Plataforma_academica.Models.Municipio municipio = new Plataforma_academica.Models.Municipio();
        //        Plataforma_academica.Models.Municipio[] Muni;
        //        String codigo1 = Request.Form["departa"];

        //        Muni = municipio.BuscarMunicipio(id);
                
        //        foreach (Municipio i in Muni)
        //        {
        //            lista1.Add(new SelectListItem
        //            {
        //                Text = i.nombre_municipio,
        //                Value = i.id_municipio,
        //                Selected = false
        //            });
        //        }
        //        ViewData["lista1"] = lista1;
        //    }
        //    return lista1;
        //}
    }
}