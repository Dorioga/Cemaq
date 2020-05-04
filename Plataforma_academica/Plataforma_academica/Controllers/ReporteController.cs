using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plataforma_academica.Models;
using System.Data;

namespace Plataforma_academica.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        Reporte report = new Reporte();
        Reporte report1 = new Reporte();
        public ActionResult Reporte()
        {
            Login user = Session["usuario"] as Login;
            DataTable datos = null;
            DataTable datos1 = null;
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                datos = report.ReporteUsuario(Convert.ToInt32(user.cedula));
                if (datos != null && datos.Rows.Count > 0)
                {
                    report.cedula = datos.Rows[0]["id_persona"].ToString();
                    report.curso = datos.Rows[0]["nombre_grupo"].ToString();
                    report.nombre = datos.Rows[0]["nombre"].ToString();
                    report.Nombre_institucion = datos.Rows[0]["nombre_empresa"].ToString();
                    report.tipo_documento = datos.Rows[0]["nombre_tipo_documento"].ToString();
                    report.telefono_empresa = datos.Rows[0]["telefono_empresa"].ToString();
                    report.telefono_persona = datos.Rows[0]["num_tel_persona"].ToString();
                    report.email_empresa = datos.Rows[0]["email_empresa"].ToString();
                    report.email_persona = datos.Rows[0]["email_persona"].ToString();
                    Session["report_datos"] = report;
                }

                return View();
            }
            
        }
    }
}