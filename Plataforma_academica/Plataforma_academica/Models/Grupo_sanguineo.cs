using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Grupo_sanguineo
    {
        public string id_sanguineo { set; get; }
        public string nombre_sanguineo { set; get; }


        public Grupo_sanguineo[] BuscarSanguineo()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable grupo = con.Execute_Query("call Pr_cargar_grupo_sanguineo()");
            Grupo_sanguineo[] arreglo = new Grupo_sanguineo[grupo.Rows.Count];
            int j = 0;
            foreach (DataRow i in grupo.Rows)
            {
                arreglo[j] = new Grupo_sanguineo();
                arreglo[j].id_sanguineo = i["Id_grupo_sanguineo"].ToString();
                arreglo[j].nombre_sanguineo = i["nombre"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}