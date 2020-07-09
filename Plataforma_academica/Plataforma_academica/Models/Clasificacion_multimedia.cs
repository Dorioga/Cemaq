using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Clasificacion_multimedia
    {
        public string codigo;
        public string nombre;

        public Clasificacion_multimedia[] Consultar_tipo_clasificacion()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable estado = con.Execute_Query("CALL Pr_Cargar_tipo_soporte()");
            Clasificacion_multimedia[] arreglo = new Clasificacion_multimedia[estado.Rows.Count];
            int j = 0;
            foreach (DataRow i in estado.Rows)
            {
                arreglo[j] = new Clasificacion_multimedia();
                arreglo[j].codigo = i["Id_tipo_soporte"].ToString();
                arreglo[j].nombre = i["Nombre_soporte"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}