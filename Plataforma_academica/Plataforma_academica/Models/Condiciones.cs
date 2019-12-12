using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Condiciones
    {
        public string codigo;
        public string nombre;

        public Condiciones[] Consultar_tipo_condicion()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable estado = con.Execute_Query("CALL Pr_cargar_condiciones()");
            Condiciones[] arreglo = new Condiciones[estado.Rows.Count];
            int j = 0;
            foreach (DataRow i in estado.Rows)
            {
                arreglo[j] = new Condiciones();
                arreglo[j].codigo = i["Id_condicion"].ToString();
                arreglo[j].nombre = i["nombre_condicion"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}