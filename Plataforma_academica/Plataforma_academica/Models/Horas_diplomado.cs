using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Horas_diplomado
    {

        public string id_horas{ set; get; }
        public string cantidad_horas { set; get; }


        public Horas_diplomado[] BuscarHoras()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable horas = con.Execute_Query("call Pr_cargar_horas()");
            Horas_diplomado[] arreglo = new Horas_diplomado[horas.Rows.Count];
            int j = 0;
            foreach (DataRow i in horas.Rows)
            {
                arreglo[j] = new Horas_diplomado();
                arreglo[j].id_horas = i["Id_horas"].ToString();
                arreglo[j].cantidad_horas = i["Cantidad_horas"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}