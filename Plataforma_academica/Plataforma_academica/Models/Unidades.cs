using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Unidades
    {
        public String nombre_unidad;
        public String codigo_curso_nivel;
        public String codigo_unidad;

        public Unidades[] Consultar_unidades_grupo(string nc)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable porcentaje = con.Execute_Query("call Pr_cargar_unidad(" + nc + ")");
            Unidades[] arreglo = new Unidades[porcentaje.Rows.Count];
            int j = 0;
            foreach (DataRow i in porcentaje.Rows)
            {
                arreglo[j] = new Unidades();
                arreglo[j].nombre_unidad = i["Nombre Unidad"].ToString();
                arreglo[j].codigo_curso_nivel = i["Codigo Curso nivel"].ToString();
                arreglo[j].codigo_unidad = i["Codigo Unidad"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}