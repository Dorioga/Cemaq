using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Municipio
    {
        public string id_municipio { set; get; }
        public string nombre_municipio{ set; get; }


        public Municipio[] BuscarMunicipio(string depart)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable municipio = con.Execute_Query("call Pr_cargar_municipio('" + depart+ "')");
            Municipio[] arreglo = new Municipio[municipio.Rows.Count];
            int j = 0;
            foreach (DataRow i in municipio.Rows)
            {
                arreglo[j] = new Municipio();
                arreglo[j].id_municipio = i["id_municipio"].ToString();
                arreglo[j].nombre_municipio = i["nombre_municipio"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}