using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Actividades
    {
        public String id_actividad { set; get; }
        public String Nombre_actividad { set; get; }
        public String descripcion { set; get; }
        public String titulo_seccion { set; get; }
        public String contenido_seccion { set; get; }
        public String id_multimedia { set; get; }
        public String url_multimedia { set; get; }

        private Conexion.Conexion conexion;

        public DataTable Consultar_contenido_actividad(string cn)
        {
            conexion = new Conexion.Conexion();
            DataTable x = conexion.Execute_Query("call Pr_cargar_contenido ('" + cn + "')");
            return x;
        }
    }
}