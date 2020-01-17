using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Empresa
    {
        public string id_empresa { set; get; }
        public string nombre_empresa { set; get; }


        public Empresa[] BuscarEmpresa(int municipio)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable empresa = con.Execute_Query("call Pr_cargar_empresa('" + municipio + "')");
            Empresa[] arreglo = new Empresa[empresa.Rows.Count];
            int j = 0;
            foreach (DataRow i in empresa.Rows)
            {
                arreglo[j] = new Empresa();
                arreglo[j].id_empresa = i["id_empresa"].ToString();
                arreglo[j].nombre_empresa = i["nombre_empresa"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}