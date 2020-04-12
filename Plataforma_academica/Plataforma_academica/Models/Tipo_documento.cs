using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Tipo_documento
    {
        public string id_tipo_documento { set; get; }
        public string nombre_tipo_documento{ set; get; }


        public Tipo_documento[] Buscartipodocumento()
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable documento = con.Execute_Query("call Pr_cargar_tipo_documento()");
            Tipo_documento[] arreglo = new Tipo_documento[documento.Rows.Count];
            int j = 0;
            foreach (DataRow i in documento.Rows)
            {
                arreglo[j] = new Tipo_documento();
                arreglo[j].id_tipo_documento = i["id_tipo_documento"].ToString();
                arreglo[j].nombre_tipo_documento = i["nombre_tipo_documento"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}