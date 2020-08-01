using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Diplomados_matriculados
    {
        public string id_curso { set; get; }
        public string nombre_curso{ set; get; }
        public string estado_pago { set; get; }
        public string porcentaje { set; get; }


        public Diplomados_matriculados[] Buscardiplomadosdescargar(string id)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable areas = con.Execute_Query("call Pr_cargar_diplomados_descargar('"+id+"')");
            Diplomados_matriculados[] arreglo = new Diplomados_matriculados[areas.Rows.Count];
            int j = 0;
            foreach (DataRow i in areas.Rows)
            {
                arreglo[j] = new Diplomados_matriculados();
                arreglo[j].id_curso = i["id_curso"].ToString();
                arreglo[j].nombre_curso = i["nombre_curso"].ToString();
                arreglo[j].estado_pago = i["estado_pago"].ToString();
                arreglo[j].porcentaje = i["porcentaje"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}