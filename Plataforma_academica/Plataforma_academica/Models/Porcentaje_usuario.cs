using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Porcentaje_usuario
    {
        public string nombre_curso { set; get; }
        public double porcentaje_curso { set; get; }
        public int id_curso { set; get; }
        public string nombre_nivel { set; get; }
        public double porcentaje_desarrollo { set; get; }
        public int id_curso_usuario_nivel { set; get; }
        public string nombre_unidad { set; get; }
        public double porcentaje_usuario_unidad { set; get; }
        public int id_curso_usuario_unidad { set; get; }
        public string nombre_actividad { set; get; }
        public double porcentaje_usuario_actividad { set; get; }
        public string nombre_examen { set; get; }
        public double porcentaje_examen { set; get; }

        private Conexion.Conexion conexion;

        public Porcentaje_usuario[] Porcentaje_Cursos(string codigo_usuario)
        {
            //Login (Se realiza la verificacion del usuario y su contraseña)
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable menu = con.Execute_Query("call Pr_cargar_porcentajes_grupo("+codigo_usuario+")");
            Porcentaje_usuario[] arreglo = new Porcentaje_usuario[menu.Rows.Count];
            int j = 0;
            foreach (DataRow i in menu.Rows)
            {
                arreglo[j] = new Porcentaje_usuario();
                arreglo[j].id_curso = Convert.ToInt32(i["id_curso"].ToString());
                arreglo[j].nombre_curso = i["nombre_curso"].ToString();
                arreglo[j].porcentaje_curso =Convert.ToDouble(i["porcentaje_curso"].ToString());
                j++;
            }
            return arreglo;

        }

        public Porcentaje_usuario[] Porcentaje_nivel(int codigo_curso, string codigo_usuario)
        {
            //Login (Se realiza la verificacion del usuario y su contraseña)
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable menu = con.Execute_Query("call Pr_cargar_porcentaje_nivel(" + codigo_usuario + "," + codigo_curso + ")");
            Porcentaje_usuario[] arreglo = new Porcentaje_usuario[menu.Rows.Count];
            int j = 0;
            foreach (DataRow i in menu.Rows)
            {
                arreglo[j] = new Porcentaje_usuario();
                arreglo[j].nombre_nivel = i["nombre_nivel"].ToString();
                arreglo[j].porcentaje_desarrollo = Convert.ToDouble(i["porcentaje_desarrollo"].ToString());
                arreglo[j].id_curso_usuario_nivel = Convert.ToInt32(i["id_curso_usuario_nivel"].ToString());
                j++;
            }
            return arreglo;

        }

        public Porcentaje_usuario[] Porcentaje_unidad(int curso_usuario_nivel)
        {
            //Login (Se realiza la verificacion del usuario y su contraseña)
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable menu = con.Execute_Query("call Pr_cargar_porcentaje_unidad(" + curso_usuario_nivel + ")");
            Porcentaje_usuario[] arreglo = new Porcentaje_usuario[menu.Rows.Count];
            int j = 0;
            foreach (DataRow i in menu.Rows)
            {
                arreglo[j] = new Porcentaje_usuario();
                arreglo[j].nombre_unidad = i["nombre_unidad"].ToString();
                arreglo[j].porcentaje_usuario_unidad = Convert.ToDouble(i["procentaje_usuario_unidad"].ToString());
                arreglo[j].id_curso_usuario_unidad = Convert.ToInt32(i["id_curso_usuario_unidad"].ToString());
                j++;
            }
            return arreglo;
        }

        public Porcentaje_usuario[] Porcentaje_actividad(int curso_usuario_unidad)
        {
            //Login (Se realiza la verificacion del usuario y su contraseña)
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable menu = con.Execute_Query("call Pr_cargar_porcentaje_actividad(" + curso_usuario_unidad + ")");
            Porcentaje_usuario[] arreglo = new Porcentaje_usuario[menu.Rows.Count];
            int j = 0;
            foreach (DataRow i in menu.Rows)
            {
                arreglo[j] = new Porcentaje_usuario();
                arreglo[j].nombre_actividad= i["nombre_actividad"].ToString();
                arreglo[j].porcentaje_usuario_actividad = Convert.ToDouble(i["porcentaje_usuario_actividad"].ToString());
                j++;
            }
            return arreglo;
        }

        public Porcentaje_usuario[] Porcentaje_examen(int curso_usuario_unidad)
        {
            //Login (Se realiza la verificacion del usuario y su contraseña)
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable menu = con.Execute_Query("call Pr_cargar_porcentaje_examen(" + curso_usuario_unidad + ")");
            Porcentaje_usuario[] arreglo = new Porcentaje_usuario[menu.Rows.Count];
            int j = 0;
            foreach (DataRow i in menu.Rows)
            {
                arreglo[j] = new Porcentaje_usuario();
                arreglo[j].nombre_examen = i["nombre_examen"].ToString();
                arreglo[j].porcentaje_examen = Convert.ToDouble(i["porcentaje_examen"].ToString());
                j++;
            }
            return arreglo;
        }
    }
}