using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Contrato
    {
        public string id_contrato { set; get; }
        public string nombre_contrato{ set; get; }


        public Contrato[] BuscarContrato()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable pais = con.Execute_Query("call Pr_cargar_contrato()");
            Contrato[] arreglo = new Contrato[pais.Rows.Count];
            int j = 0;
            foreach (DataRow i in pais.Rows)
            {
                arreglo[j] = new Contrato();
                arreglo[j].id_contrato = i["id_contrato"].ToString();
                arreglo[j].nombre_contrato = i["nombre_contrato"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}