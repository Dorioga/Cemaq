using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Niveles
    {
        public String nombre_nivel { set; get; }
        public String codigo_nivel { set; get; }
        
        public Niveles[] Consultar_niveles_grupo(Niveles cn)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable porcentaje = con.Execute_Query("call Pr_cargar_nivel(" + cn.codigo_nivel + ")");
            Niveles[] arreglo = new Niveles[porcentaje.Rows.Count];
            int j = 0;
            foreach (DataRow i in porcentaje.Rows)
            {
                arreglo[j] = new Niveles();
                arreglo[j].nombre_nivel = i["nombre nivel"].ToString();
                arreglo[j].codigo_nivel = i["Curso nivel"].ToString();
                j++;
            }
            return arreglo;

        }

        public Niveles[] Consultar_niveles_usuario(Niveles cn, string id_usuario)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable porcentaje = con.Execute_Query("call Pr_cargar_nivel_usuario(" + cn.codigo_nivel + ","+id_usuario+")");
            Niveles[] arreglo = new Niveles[porcentaje.Rows.Count];
            int j = 0;
            foreach (DataRow i in porcentaje.Rows)
            {
                arreglo[j] = new Niveles();
                arreglo[j].nombre_nivel = i["nombre nivel"].ToString();
                arreglo[j].codigo_nivel = i["Curso nivel"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}