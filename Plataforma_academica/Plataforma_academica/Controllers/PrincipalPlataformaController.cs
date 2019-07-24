using Plataforma_academica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_academica.Controllers
{
    public class PrincipalPlataformaController : Controller
    {
        // GET: PrincipalPlataforma
        public ActionResult principalplataforma()
        {        
            return View();
        }
    }
}