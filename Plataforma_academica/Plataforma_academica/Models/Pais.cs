using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Pais
    {

        public string id_pais { set; get; }
        public string nombre_pais { set; get; }
        

        public Pais[] BuscarPais()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable pais = con.Execute_Query("call Pr_cargar_pais()");
            Pais[] arreglo = new Pais[pais.Rows.Count];
            int j = 0;
            foreach (DataRow i in pais.Rows)
            {
                arreglo[j] = new Pais();
                arreglo[j].id_pais = i["id_pais"].ToString();
                arreglo[j].nombre_pais = i["nombre_pais"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}