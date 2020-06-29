using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Departamento
    {
        public string id_departamento { set; get; }
        public string nombre_departamento { set; get; }


        public Departamento[] BuscarDepartamento()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable departamento = con.Execute_Query("call Pr_cargar_departamento()");
            Departamento[] arreglo = new Departamento[departamento.Rows.Count];
            int j = 0;
            foreach (DataRow i in departamento.Rows)
            {
                arreglo[j] = new Departamento();
                arreglo[j].id_departamento = i["id_departamento"].ToString();
                arreglo[j].nombre_departamento = i["nombre_departamento"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}