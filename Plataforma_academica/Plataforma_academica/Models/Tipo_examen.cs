using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Tipo_examen
    {
        public string codigo;
        public string nombre;

        public Tipo_examen[] Consultar_tipo_examen()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable estado = con.Execute_Query("CALL Pr_cargar_tipo_examen()");
            Tipo_examen[] arreglo = new Tipo_examen[estado.Rows.Count];
            int j = 0;
            foreach (DataRow i in estado.Rows)
            {
                arreglo[j] = new Tipo_examen();
                arreglo[j].codigo = i["id_tipo_examen"].ToString();
                arreglo[j].nombre = i["nombre_tipo_examen"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}