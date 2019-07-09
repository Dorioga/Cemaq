using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class AcademicaProfesionalController : Controller
    {
        // GET: AcademicaProfesional
        public ActionResult Academicaprofesional()
        {
            String codig = Request.Form["ir"];

            if (codig == "profesional")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Academicainfantil", "AcademicaProfesional");
            }
        }

        public ActionResult Academicainfantil()
        {
            
            return View();
        }

        public ActionResult login()
        {

            return RedirectToAction("principalplataforma", "PrincipalPlataforma");
        }
    }
}