using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class lista_tipo_multimedia
    {
        public string codigo;
        public string nombre;

        public lista_tipo_multimedia[] Consultar_tipo_multimedia()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable estado = con.Execute_Query("CALL Pr_Cargar_Tipo_Multimedia()");
            lista_tipo_multimedia[] arreglo = new lista_tipo_multimedia[estado.Rows.Count];
            int j = 0;
            foreach (DataRow i in estado.Rows)
            {
                arreglo[j] = new lista_tipo_multimedia();
                arreglo[j].codigo = i["id_tipo_multimedia"].ToString();
                arreglo[j].nombre = i["nombre_tipo_multimedia"].ToString();
                j++;
            }
            return arreglo;

        }
    }


}