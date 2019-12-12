using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class principalP
    {
        public string nombre_curso { set; get; }
        public string codigo_curso { set; get; }
        public string codigo_actividad { set; get; }
        public string codigo_examen { set; get; }

        private Conexion.Conexion conexion;

        public principalP[] BuscarCursos(string cc)
        {
            //Login (Se realiza la verificacion del usuario y su contraseña)
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable menu = con.Execute_Query("call Pr_cargar_curso(" + cc + ")");
            principalP[] arreglo = new principalP[menu.Rows.Count];
            int j = 0;
            foreach (DataRow i in menu.Rows)
            {
                arreglo[j] = new principalP();
                arreglo[j].nombre_curso = i["curso"].ToString();
                arreglo[j].codigo_curso = i["codigo curso"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}