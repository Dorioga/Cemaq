using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Editar_Actividad
    {
        public String id_actividad { set; get; }
        public String id_tipo_multimedia { set; get; }
        public String Nombre_actividad { set; get; }
        public String descripcion { set; get; }
        public String titulo_seccion { set; get; }
        public String contenido_seccion { set; get; }
        public String id_multimedia { set; get; }
        public String url_multimedia { set; get; }
        public String descripcion_editar { set; get; }
        public String id_seccion { set; get; }
       private Conexion.Conexion con = new Conexion.Conexion();

        public Editar_Actividad[] Editar_contenido_actividad(string cn)
        {
            
            DataTable actividad = con.Execute_Query("call Pr_cargar_contenido(" + cn + ")");
            Editar_Actividad[] arreglo = new Editar_Actividad[actividad.Rows.Count];
            Editar_Actividad inicio = new Editar_Actividad();
            int j = 0;
            foreach (DataRow i in actividad.Rows)
            {
                arreglo[j] = new Editar_Actividad();
                arreglo[j].id_actividad = i["id_actividad"].ToString();
                arreglo[j].Nombre_actividad = i["Nombre_actividad"].ToString();
                arreglo[j].descripcion = i["descripcion"].ToString();
                arreglo[j].titulo_seccion = i["titulo_seccion"].ToString();
                arreglo[j].contenido_seccion = i["contenido_seccion"].ToString();
                arreglo[j].id_multimedia = i["id_multimedia"].ToString();
                arreglo[j].url_multimedia = i["url_multimedia"].ToString();
                arreglo[j].id_tipo_multimedia = i["tipo multimedia"].ToString();
                arreglo[j].descripcion_editar = i["descripcion editar"].ToString();
                arreglo[j].id_seccion = i["id_seccion"].ToString();

                j++;
            }
            return arreglo;
        }

        public bool Actualizar_nombre_actividad(string cn, Editar_Actividad obj)
        {
            con = new Conexion.Conexion();
            int x = con.Execute_Operation("call Pr_Actualizar_Nombre_Actividad ('" + obj.Nombre_actividad + "', '" + cn+ "')");
            return x > 0 ? true : false;
        }
    }
}