using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Grupo
    {
        public string id_grupo { set; get; }
        public string nombre_grupo { set; get; }


        public Grupo[] BuscarGrupo(int empresa)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable grupo = con.Execute_Query("call Pr_cargar_grupo('" + empresa + "')");
            Grupo[] arreglo = new Grupo[grupo.Rows.Count];
            int j = 0;
            foreach (DataRow i in grupo.Rows)
            {
                arreglo[j] = new Grupo();
                arreglo[j].id_grupo = i["id_grupo"].ToString();
                arreglo[j].nombre_grupo = i["nombre_grupo"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}