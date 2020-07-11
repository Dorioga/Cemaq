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
        public string estudios { set; get; }
        public int tipo_doc { set; get; }
        public int tipo_pobla { set; get; }
        public int tipo_rol { set; get; }
        public int estado_civil { set; get; }
        public int escolaridad { set; get; }
        public int nombre_contrato { set; get; }
        public string experiencia { set; get; }
        public string formacion { set; get; }
        public string publicaciones { set; get; }


        private Conexion.Conexion conexion;

        public bool Registrar_Trabajadores(Registrar_Trabajador obj, string foto)
        {
            conexion = new Conexion.Conexion();
            string fecha = obj.fecha_nacimiento.ToString("yyyy-MM-dd");
            if (obj.tipo_rol==7)
            {
                int x = conexion.Execute_Operation("call Pr_ingresar_trabajador ('" + obj.cedula + "', '" + obj.nombre1 + "', '" + obj.nombre2 + "', '" + obj.apellido1 + "', '" + obj.apellido2 + "', '" + fecha + "', '" + obj.telefono + "', '" + obj.correo + "', '" + obj.genero + "', '" + obj.tipo_doc + "', '" + obj.tipo_pobla + "', '" + obj.nombre_contrato + "','" + obj.tipo_rol + "','" + obj.estado_civil + "','" + obj.escolaridad + "','" + foto + "','" + obj.experiencia + "','" + obj.formacion + "','" + obj.publicaciones + "')");
                return x > 0 ? true : false;
            }
            else
            {
                if (obj.genero == "1")
                {
                    int x = conexion.Execute_Operation("call Pr_ingresar_trabajador ('" + obj.cedula + "', '" + obj.nombre1 + "', '" + obj.nombre2 + "', '" + obj.apellido1 + "', '" + obj.apellido2 + "', '" + fecha + "', '" + obj.telefono + "', '" + obj.correo + "', '" + obj.genero + "', '" + obj.tipo_doc + "', '" + obj.tipo_pobla + "', '" + obj.nombre_contrato + "','" + obj.tipo_rol + "','" + obj.estado_civil + "','" + obj.escolaridad + "','" + "usuario.png" + "','" + "" + "','" + "" + "','" + "" + "')");
                    return x > 0 ? true : false;
                }
                else
                {
                    if (obj.genero == "2")
                    {
                        int x = conexion.Execute_Operation("call Pr_ingresar_trabajador ('" + obj.cedula + "', '" + obj.nombre1 + "', '" + obj.nombre2 + "', '" + obj.apellido1 + "', '" + obj.apellido2 + "', '" + fecha + "', '" + obj.telefono + "', '" + obj.correo + "', '" + obj.genero + "', '" + obj.tipo_doc + "', '" + obj.tipo_pobla + "', '" + obj.nombre_contrato + "','" + obj.tipo_rol + "','" + obj.estado_civil + "','" + obj.escolaridad + "','" + "usuaria.png" + "','" + "" + "','" + "" + "','" + "" + "')");
                        return x > 0 ? true : false;
                    }
                    else
                    {
                        int x = conexion.Execute_Operation("call Pr_ingresar_trabajador ('" + obj.cedula + "', '" + obj.nombre1 + "', '" + obj.nombre2 + "', '" + obj.apellido1 + "', '" + obj.apellido2 + "', '" + fecha + "', '" + obj.telefono + "', '" + obj.correo + "', '" + obj.genero + "', '" + obj.tipo_doc + "', '" + obj.tipo_pobla + "', '" + obj.nombre_contrato + "','" + obj.tipo_rol + "','" + obj.estado_civil + "','" + obj.escolaridad + "','" + "user.png" + "','" + "" + "','" + "" + "','" + "" + "')");
                        return x > 0 ? true : false;
                    }
                }                
            }

        }

    }
}