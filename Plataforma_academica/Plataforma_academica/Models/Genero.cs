using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Genero
    {
        public string id_genero{ set; get; }
        public string nombre_genero{ set; get; }


        public Genero[] BuscarGenero()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable pais = con.Execute_Query("call Pr_cargar_genero()");
            Genero[] arreglo = new Genero[pais.Rows.Count];
            int j = 0;
            foreach (DataRow i in pais.Rows)
            {
                arreglo[j] = new Genero();
                arreglo[j].id_genero = i["id_genero"].ToString();
                arreglo[j].nombre_genero= i["nombre_genero"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}