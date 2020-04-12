using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Tipo_poblacion
    {
        public string id_tipo_poblacion{ set; get; }
        public string nombre_tipo_poblacion { set; get; }


        public Tipo_poblacion[] Buscarpoblacion()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable poblacion = con.Execute_Query("call Pr_cargar_tipo_poblacion()");
            Tipo_poblacion[] arreglo = new Tipo_poblacion[poblacion.Rows.Count];
            int j = 0;
            foreach (DataRow i in poblacion.Rows)
            {
                arreglo[j] = new Tipo_poblacion();
                arreglo[j].id_tipo_poblacion = i["id_tipo_poblacion"].ToString();
                arreglo[j].nombre_tipo_poblacion = i["nombre_tipo_poblacion"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}