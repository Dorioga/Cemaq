using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Alumnos
    {
        public string id_usuario { set; get; }
        public string nombre_usuario { set; get; }
        public string nombre_rol { set; get; }


        public Alumnos[] BuscarAlumnos(int grupo)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable alumno = con.Execute_Query("call Pr_cargar_alumnos('" + grupo + "')");
            Alumnos[] arreglo = new Alumnos[alumno.Rows.Count];
            int j = 0;
            foreach (DataRow i in alumno.Rows)
            {
                arreglo[j] = new Alumnos();
                arreglo[j].id_usuario = i["id_usuario"].ToString();
                arreglo[j].nombre_usuario = i["nombre"].ToString();
                arreglo[j].nombre_rol = i["nombre_rol"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}