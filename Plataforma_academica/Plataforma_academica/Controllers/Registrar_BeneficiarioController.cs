using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Net.Mail;
using System.Net;

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
            string usuario;
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
                                R.genero = ((Excel.Range)range.Cells[row, 9]).Text;
                                R.tipo_doc = ((Excel.Range)range.Cells[row, 10]).Text;
                                R.tipo_pobla = ((Excel.Range)range.Cells[row, 11]).Text;
                                R.municipio = ((Excel.Range)range.Cells[row, 12]).Text;
                                R.estado_civil = ((Excel.Range)range.Cells[row, 13]).Text;
                                R.escolaridad = ((Excel.Range)range.Cells[row, 14]).Text;
                                R.tipo_sanguineo = ((Excel.Range)range.Cells[row, 15]).Text;

                                DataTable datos1;

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
                                            usuario = R.nombre1.Substring(0,3);
                                            if (SendEmail(R.correo, usuario, R.apellido1, R.cedula))
                                            {
                                                ViewBag.Mensaje = "Correcto!";
                                            }
                                        }
                                        else
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

        public bool SendEmail(string c, string nombre, string apellido, string contrase)
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
               mail.Body = "Usted ha sido registrado como un usuario de forma exitosa en DIPLOMADOS - CEMAQ, sus credenciales son:\n\r" +
                        "Usuario: " + nombre +"."+apellido+
                        "\n\rContraseña: " + contrase + " " + "http://diplomados-cemaq.azurewebsites.net/Login/Login";


               mail.IsBodyHtml = true;

               SmtpClient smtp = new SmtpClient("smtp.gmail.com");
               smtp.Host = "smtp.gmail.com";
               smtp.Port = 587;
               smtp.Credentials = new NetworkCredential("cemaqacademica@gmail.com", "academica2020!");
               smtp.EnableSsl = true;
               smtp.Send(mail);
                smtp.Dispose();
               a = true;
               return a;
                

            }

            return a;
        }

    }
}