using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Registrar_Trabajador
    {
        public string cedula { set; get; }
        public string nombre1 { set; get; }
        public string nombre2 { set; get; }
        public string apellido1 { set; get; }
        public string apellido2 { set; get; }
        public DateTime fecha_nacimiento { set; get; }
        public string telefono { set; get; }
        public string correo { set; get; }
        public string genero { set; get; }
        public int tipo_doc { set; get; }
        public int tipo_pobla { set; get; }
        public int tipo_rol { set; get; }
        public string nombre_contrato { set; get; }

        private Conexion.Conexion conexion;

        public bool Registrar_Trabajadores(Registrar_Trabajador obj)
        {
            conexion = new Conexion.Conexion();
            string fecha = obj.fecha_nacimiento.ToString("yyyy-MM-dd");            
            int x = conexion.Execute_Operation("call Pr_ingresar_trabajador ('" + obj.cedula + "', '" + obj.nombre1 + "', '" + obj.nombre2 + "', '" + obj.apellido1 + "', '" + obj.apellido2 + "', '" + fecha + "', '" + obj.telefono + "', '" + obj.correo + "', '" + obj.genero + "', '" + obj.tipo_doc + "', '" + obj.tipo_pobla + "', '" + obj.nombre_contrato + "','" + obj.tipo_rol + "')");
            return x > 0 ? true : false;

        }

    }
}