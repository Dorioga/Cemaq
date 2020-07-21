using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Unidades
    {
        public String nombre_unidad;
        public String codigo_curso_nivel;
        public String codigo_unidad;
        public String porcentaje_modulo;
        public String presentacion;
        public String nombre;
        public String escolaridad;
        public String academica;
        public String foto;
        public String nombre_curso;
        public String email_persona;

        public Unidades[] Consultar_unidades_grupo(string nc)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable porcentaje = con.Execute_Query("call Pr_cargar_unidades_general(" + nc + ")");
            Unidades[] arreglo = new Unidades[porcentaje.Rows.Count];
            int j = 0;
            foreach (DataRow i in porcentaje.Rows)
            {
                arreglo[j] = new Unidades();
                arreglo[j].nombre_unidad = i["nombre_unidad"].ToString();
                arreglo[j].codigo_unidad = i["id_Unidad"].ToString();
                j++;
            }
            return arreglo;

        }

        public Unidades[] Consultar_unidades_usuario(string nc, string id_usuario)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable porcentaje = con.Execute_Query("call Pr_cargar_unidad_usuario(" + nc + ", "+id_usuario+")");
            Unidades[] arreglo = new Unidades[porcentaje.Rows.Count];
            int j = 0;
            foreach (DataRow i in porcentaje.Rows)
            {
                arreglo[j] = new Unidades();
                arreglo[j].nombre_unidad = i["Nombre Unidad"].ToString();
                arreglo[j].codigo_unidad = i["Codigo Curso nivel"].ToString();
                arreglo[j].codigo_curso_nivel = i["Codigo Unidad"].ToString();
                arreglo[j].porcentaje_modulo = i["porcentaje"].ToString();
                arreglo[j].presentacion = i["presentacion"].ToString();
                j++;
            }
            return arreglo;

        }

        public Unidades[] Consultar_docente_curso(string nc)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable porcentaje = con.Execute_Query("call Pr_cargar_docente_curso(" + nc + ")");
            Unidades[] arreglo = new Unidades[porcentaje.Rows.Count];
            int j = 0;
            foreach (DataRow i in porcentaje.Rows)
            {
                arreglo[j] = new Unidades();
                arreglo[j].nombre = i["nombre"].ToString();
                arreglo[j].escolaridad = i["escolaridad"].ToString();
                arreglo[j].academica = i["academica"].ToString();
                arreglo[j].foto = i["foto"].ToString();
                arreglo[j].nombre_curso= i["nombre_curso"].ToString();
                arreglo[j].email_persona = i["email_persona"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}