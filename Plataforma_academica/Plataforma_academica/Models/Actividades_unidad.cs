using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Actividades_unidad
    {
        public String nombre_actividad { set; get; }
        public String codigo_actividad { set; get; }

        public Actividades_unidad[] Consultar_Actividad_unidades(string nc)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable porcentaje = con.Execute_Query("call Pr_cargar_actividad(" + nc + ")");
            Actividades_unidad[] arreglo = new Actividades_unidad[porcentaje.Rows.Count];
            int j = 0;
            foreach (DataRow i in porcentaje.Rows)
            {
                arreglo[j] = new Actividades_unidad();
                arreglo[j].nombre_actividad = i["nombre actividad"].ToString();
                arreglo[j].codigo_actividad = i["codigo actividad"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}