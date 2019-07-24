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
        public string cedula { set; get; }
        public string Tipo_rol { set; get; }

        private Conexion.Conexion conexion;

        public DataTable BuscarPersona(string u, string c)
        {
            //Login (Se realiza la verificacion del usuario y su contraseña)
            conexion = new Conexion.Conexion();
            DataTable x = conexion.Execute_Query("call Pr_Iniciar_sesion ('" + u + "', '" + c + "')");
            return x;

        }
    }
}