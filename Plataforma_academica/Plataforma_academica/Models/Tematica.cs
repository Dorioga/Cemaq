using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Tematica
    {
        public string id_tematica { set; get; }
        public string nombre_tematica { set; get; }


        public Tematica[] BuscarTematicas()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable tema = con.Execute_Query("call Pr_cargar_tematica()");
            Tematica[] arreglo = new Tematica[tema.Rows.Count];
            int j = 0;
            foreach (DataRow i in tema.Rows)
            {
                arreglo[j] = new Tematica();
                arreglo[j].id_tematica = i["id_tematica_curso"].ToString();
                arreglo[j].nombre_tematica = i["nombre_tematica_curso"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}