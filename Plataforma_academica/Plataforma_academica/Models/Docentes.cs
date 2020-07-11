using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Docentes
    {
        public string id_docente { set; get; }
        public string nombre{ set; get; }


        public Docentes[] BuscarDocentes()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable pais = con.Execute_Query("call Pr_cargar_docentes()");
            Docentes[] arreglo = new Docentes[pais.Rows.Count];
            int j = 0;
            foreach (DataRow i in pais.Rows)
            {
                arreglo[j] = new Docentes();
                arreglo[j].id_docente = i["id_persona"].ToString();
                arreglo[j].nombre = i["nombre"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}