using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Reporte
    {
        private Conexion.Conexion conexion;
        public string nombre { set; get; }
        public string tipo_documento { set; get; }
        public string Nombre_institucion { set; get; }
        public string curso { set; get; }
        public string cedula { set; get; }
        public string nom_materia { set; get; }
        public string porcentaje { set; get; }
        public string email_empresa { set; get; }
        public string telefono_empresa { set; get; }
        public string email_persona { set; get; }
        public string telefono_persona { set; get; }
        public string descripcion { set; get; }

        public DataTable ReporteUsuario(int cedula)
        {            
            conexion = new Conexion.Conexion();
            DataTable x = conexion.Execute_Query("call datos_usuario_reporte('" + cedula + "')");
            return x;
        }
        
        public Reporte[] ReporteUsuario_materia(int cedula)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable rporte = con.Execute_Query("call datos_materias_usuario('" + cedula + "')");
            Reporte[] arreglo = new Reporte[rporte.Rows.Count];
            int j = 0;
            foreach (DataRow i in rporte.Rows)
            {
                arreglo[j] = new Reporte();
                arreglo[j].nom_materia = i["nombre_curso"].ToString();
                arreglo[j].porcentaje = i["porcentaje_curso"].ToString();
                arreglo[j].descripcion = i["descripcion_curso"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}