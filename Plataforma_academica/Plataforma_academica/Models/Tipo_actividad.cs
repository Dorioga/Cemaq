using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Tipo_actividad
    {
        public string id_tipo_actividad{ set; get; }
        public string nombre_tipo_actividad { set; get; }


        public Tipo_actividad[] BuscarTipoActividad()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable tipo_actividad = con.Execute_Query("call Pr_cargar_tipo_actividad()");
            Tipo_actividad[] arreglo = new Tipo_actividad[tipo_actividad.Rows.Count];
            int j = 0;
            foreach (DataRow i in tipo_actividad.Rows)
            {
                arreglo[j] = new Tipo_actividad();
                arreglo[j].id_tipo_actividad= i["id_tipo_actividad"].ToString();
                arreglo[j].nombre_tipo_actividad = i["nombre_tipo_actividad"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}