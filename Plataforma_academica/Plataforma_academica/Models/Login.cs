using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Login
    {
        public string usuario { set; get; }
        public string contraseña { set; get; }
        public string Nombre { set; get; }
        public string rol { set; get; }
        public string escolaridad { set; get; }
        public string estado_civil { set; get; }
        public string cedula { set; get; }
        public string Tipo_rol { set; get; }
        public string tipo_doc { set; get; }
        public string tipo_pobla { set; get; }
        public string nombre1 { set; get; }
        public string nombre2 { set; get; }
        public string apellido1 { set; get; }
        public string apellido2 { set; get; }
        public DateTime fecha_nacimiento { set; get; }
        public string telefono { set; get; }
        public string correo { set; get; }
        public string genero { set; get; }
        public string municipio { set; get; }
        public string departamento { set; get; }
        public string pais { set; get; }
        public string foto { set; get; }
        public string conexion_usuario { set; get; }

        private Conexion.Conexion conexion;

        public DataTable BuscarPersona(string u, string c)
        {
            //Login (Se realiza la verificacion del usuario y su contraseña)
            conexion = new Conexion.Conexion();
            DataTable x = conexion.Execute_Query("call Pr_Iniciar_sesion ('" + u + "', '" + c + "')");
            return x;

        }

        public bool Registrar_estudiante(Login obj)
        {
            conexion = new Conexion.Conexion();
            string fecha = obj.fecha_nacimiento.ToString("yyyy-MM-dd");
            if (obj.genero=="1")
            {
                int x = conexion.Execute_Operation("call Pr_ingresar_estudiante ('" + obj.cedula + "', '" + obj.nombre1 + "', '" + obj.nombre2 + "', '" + obj.apellido1 + "', '" + obj.apellido2 + "', '" + fecha + "', '" + obj.telefono + "', '" + obj.correo + "', '" + obj.genero + "', '" + obj.tipo_doc + "', '" + obj.tipo_pobla + "', '" + obj.municipio + "', '" + obj.estado_civil + "','" + obj.escolaridad + "','" + "usuario.png" + "')");
                return x == 0 ? true : false;
            }
            else
            {
                if (obj.genero == "2")
                {
                    int x = conexion.Execute_Operation("call Pr_ingresar_estudiante ('" + obj.cedula + "', '" + obj.nombre1 + "', '" + obj.nombre2 + "', '" + obj.apellido1 + "', '" + obj.apellido2 + "', '" + fecha + "', '" + obj.telefono + "', '" + obj.correo + "', '" + obj.genero + "', '" + obj.tipo_doc + "', '" + obj.tipo_pobla + "', '" + obj.municipio + "', '" + obj.estado_civil + "','" + obj.escolaridad + "','" + "usuaria.png" + "')");
                    return x == 0 ? true : false;
                }
                else
                {
                    int x = conexion.Execute_Operation("call Pr_ingresar_estudiante ('" + obj.cedula + "', '" + obj.nombre1 + "', '" + obj.nombre2 + "', '" + obj.apellido1 + "', '" + obj.apellido2 + "', '" + fecha + "', '" + obj.telefono + "', '" + obj.correo + "', '" + obj.genero + "', '" + obj.tipo_doc + "', '" + obj.tipo_pobla + "', '" + obj.municipio + "', '" + obj.estado_civil + "','" + obj.escolaridad + "','" + "user.png" + "')");
                    return x == 0 ? true : false;
                }
            }

        }

        public bool Actualizar_conexion(Login obj)
        {
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_cerrar_sesion ('" + obj.cedula + "')");
            return x > 0 ? true : false;
        }

        
    }
}