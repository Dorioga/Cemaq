using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Escolaridad
    {
        public string id_escolaridad { set; get; }
        public string nombre { set; get; }


        public Escolaridad[] BuscarEscolaridad()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable pais = con.Execute_Query("call Pr_cargar_escolaridad()");
            Escolaridad[] arreglo = new Escolaridad[pais.Rows.Count];
            int j = 0;
            foreach (DataRow i in pais.Rows)
            {
                arreglo[j] = new Escolaridad();
                arreglo[j].id_escolaridad = i["Id_escolaridad"].ToString();
                arreglo[j].nombre = i["nombre_escolaridad"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}