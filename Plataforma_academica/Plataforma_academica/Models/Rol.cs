using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Rol
    {
        public string id_rol { set; get; }
        public string nombre_rol { set; get; }


        public Rol[] BuscarRol()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable rol = con.Execute_Query("call Pr_cargar_rol()");
            Rol[] arreglo = new Rol[rol.Rows.Count];
            int j = 0;
            foreach (DataRow i in rol.Rows)
            {
                arreglo[j] = new Rol();
                arreglo[j].id_rol = i["id_rol"].ToString();
                arreglo[j].nombre_rol = i["nombre_rol"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}