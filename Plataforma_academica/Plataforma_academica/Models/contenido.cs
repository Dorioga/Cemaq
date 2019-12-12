using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    
    public class contenido
    {
        public string nombre_contenido { set; get; }
        public string descripcion_contenido { set; get; }
        public string nombre_multimedia { set; get; }
        public String tipo_multimedia { set; get; }
        public String tipo_clasificacion { set; get; }
        public int id_actividad { set; get; }

        private Conexion.Conexion conexion;

        public DataTable Registrar_Contenido(contenido obj, string unidad, string archivo, string o)
        {
            conexion = new Conexion.Conexion();
            DataTable x = conexion.Execute_Query("call Pr_ingresar_titulo_actividad_inicial ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + "1" + "','" + unidad + "','" + o + "','" + archivo + "', '" + obj.tipo_clasificacion + "', '" + obj.tipo_multimedia + "')");
            return x;
        }

        public bool Registrar_seccion(contenido obj, int id_act, string archivo, string o)
        {
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_ingresar_seccion ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + id_act + "','" + o + "','" + archivo + "', '" + obj.tipo_clasificacion + "', '" + obj.tipo_multimedia + "')");
            return x == 0 ? true : false;
        }
    }
}