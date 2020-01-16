using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    
    public class contenido
    {
        public string nombre_contenido { set; get; }
        public string descripcion_contenido { set; get; }
        public string nombre_multimedia { set; get; }

        private Conexion.Conexion conexion;

        public bool Registrar_Contenido(contenido obj)
        {
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_ingresar_titulo_actividad ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + "unidad id" + "')");
            return x > 0 ? true : false;

        }
    }
}