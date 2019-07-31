using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Actividades
    {
        public String id_actividad { set; get; }
        public String id_tipo_multimedia { set; get; }
        public String Nombre_actividad { set; get; }
        public String descripcion { set; get; }
        public String titulo_seccion { set; get; }
        public String contenido_seccion { set; get; }
        public String id_multimedia { set; get; }
        public String url_multimedia { set; get; }

        public Actividades[] Consultar_contenido_actividad(string cn)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable actividad = con.Execute_Query("call Pr_cargar_contenido(" + cn+ ")");
            Actividades[] arreglo = new Actividades[actividad.Rows.Count];
            Actividades inicio = new Actividades();
            int j = 0;
            foreach (DataRow i in actividad.Rows)
            {
                arreglo[j] = new Actividades();
                arreglo[j].id_actividad = i["id_actividad"].ToString();
                arreglo[j].Nombre_actividad = i["Nombre_actividad"].ToString();
                arreglo[j].descripcion = i["descripcion"].ToString();
                arreglo[j].titulo_seccion = i["titulo_seccion"].ToString();
                arreglo[j].contenido_seccion = i["contenido_seccion"].ToString();
                arreglo[j].id_multimedia = i["id_multimedia"].ToString();
                arreglo[j].url_multimedia = i["url_multimedia"].ToString();
                arreglo[j].id_tipo_multimedia = i["tipo multimedia"].ToString();

                j++;
            }
            return arreglo;
        }
    }
}