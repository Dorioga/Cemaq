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
        public String edicion { set; get; }
        public String edicion_examen { set; get; }
        public String examen { set; get; }
        public String id_examen { set; get; }

        public Actividades_unidad[] Consultar_Actividad_unidades(string nc)
        {
            //@ -27,5 + 28,23 @@ namespace Plataforma_academica.Models
            
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
        public Actividades_unidad[] Consultar_examen_unidades(string nc)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable porcentaje1 = con.Execute_Query("call Pr_cargar_examen_visualizar(" + nc + ")");
            Actividades_unidad[] arreglo = new Actividades_unidad[porcentaje1.Rows.Count];
            int j = 0;
            foreach (DataRow i in porcentaje1.Rows)
            {
                arreglo[j] = new Actividades_unidad();
                arreglo[j].examen = i["nombre examen"].ToString();
                arreglo[j].id_examen = i["id examen"].ToString();
                j++;
            }
            return arreglo;

        }
        public Actividades_unidad[] Consultar_examen_unidades_edic(string nc)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable porcentaje2 = con.Execute_Query("call Pr_cargar_examen_editar(" + nc + ")");
            Actividades_unidad[] arreglo = new Actividades_unidad[porcentaje2.Rows.Count];
            int j = 0;
            foreach (DataRow i in porcentaje2.Rows)
            {
                arreglo[j] = new Actividades_unidad();
                arreglo[j].examen = i["nombre examen"].ToString();
                arreglo[j].id_examen = i["id examen"].ToString();
                arreglo[j].edicion_examen = i["editar"].ToString();
                j++;
            }
            return arreglo;

        }

        public Actividades_unidad[] Consultar_Actividad_unidades_edic(string nc)
    {
        Conexion.Conexion con = new Conexion.Conexion();
        DataTable porcentaje = con.Execute_Query("call Pr_cargar_actividad_edic(" + nc + ")");
        Actividades_unidad[] arreglo = new Actividades_unidad[porcentaje.Rows.Count];
        int j = 0;
        foreach (DataRow i in porcentaje.Rows)
        {
            arreglo[j] = new Actividades_unidad();
            arreglo[j].nombre_actividad = i["nombre actividad"].ToString();
            arreglo[j].codigo_actividad = i["codigo actividad"].ToString();
            arreglo[j].edicion = i["Editado"].ToString();
            j++;
        }
        return arreglo;

    }
}
}