using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Tipo_de_pregunta
    {
        public string codigo;
        public string nombre;

        public Tipo_de_pregunta[] Consultar_tipo_pregunta()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable estado = con.Execute_Query("CALL Pr_cargar_tipo_de_pregunta()");
            Tipo_de_pregunta[] arreglo = new Tipo_de_pregunta[estado.Rows.Count];
            int j = 0;
            foreach (DataRow i in estado.Rows)
            {
                arreglo[j] = new Tipo_de_pregunta();
                arreglo[j].codigo = i["id tipo"].ToString();
                arreglo[j].nombre = i["tipo"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}