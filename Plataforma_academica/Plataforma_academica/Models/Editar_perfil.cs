using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Editar_perfil
    {
        public string foto { set; get; }
        public string telefono { set; get; }
        public string correo { set; get; }
        private Conexion.Conexion conexion=new Conexion.Conexion();

        public bool Actualizar_perfil(Editar_perfil obj, int numero, string cedula, string foto)
        {
            int x = conexion.Execute_Operation("call Pr_actualizar_perfil ('" + numero + "','" + obj.correo + "','" + obj.telefono + "','" + foto + "', '" + cedula + "')");
            return x > 0 ? true : false;
        }

    }
}