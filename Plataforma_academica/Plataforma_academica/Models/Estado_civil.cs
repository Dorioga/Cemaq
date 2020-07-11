using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Estado_civil
    {
        public string id_estado { set; get; }
        public string nombre_estado { set; get; }


        public Estado_civil[] BuscarEstadoCivil()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable pais = con.Execute_Query("call Pr_cargar_estado_civil()");
            Estado_civil[] arreglo = new Estado_civil[pais.Rows.Count];
            int j = 0;
            foreach (DataRow i in pais.Rows)
            {
                arreglo[j] = new Estado_civil();
                arreglo[j].id_estado = i["Id_estado_civil"].ToString();
                arreglo[j].nombre_estado = i["nombre"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}