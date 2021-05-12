using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Formatos
    {
        private Conexion.Conexion conexion;
        public String nombre_formato { set; get; }
        public String url { set; get; }
        public String fecha_subido { set; get; }
        public String estado { set; get; }
        public String id_formato { set; get; }

        public bool Registrar_formato(string url, string n)
        {
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_ingresar_formato ('" + n + "', '" + url + "')");
            return x > 0 ? true : false;
        }

        public Formatos[] consultar_formatos()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable format = con.Execute_Query("call Pr_cargar_formatos()");
            Formatos[] arreglo = new Formatos[format.Rows.Count];
            Formatos cant = new Formatos();
            int j = 0;
            foreach (DataRow i in format.Rows)
            {
                arreglo[j] = new Formatos();
                arreglo[j].id_formato = i["id_formatos"].ToString();
                arreglo[j].nombre_formato = i["Nombre"].ToString();
                arreglo[j].url = i["Url"].ToString();
                arreglo[j].fecha_subido = i["Fecha_subido"].ToString();
                arreglo[j].estado = i["Estado"].ToString();
                j++;
            }
            return arreglo;
        }


    }
}