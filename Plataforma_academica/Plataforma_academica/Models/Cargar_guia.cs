using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Cargar_guia
    {
        public bool Actualizar_guia(string url_guia, string id_unidad)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            int x = con.Execute_Operation("call Pr_actualizar_guia ('" + url_guia + "', '" + id_unidad + "')");
            return x > 0 ? true : false;
        }

    }
}