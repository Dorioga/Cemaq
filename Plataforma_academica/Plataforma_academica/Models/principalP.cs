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
        public string porcentaje_diplomado { set; get; }
        public string codigo_actividad { set; get; }
        public string url { set; get; }
        public string codigo_examen { set; get; }
        public string informacion_actividad { set; get; }
        public DateTime fecha_cierre  { set; get; }
        public string codigo_curso_usaurio { set; get; }
        private Conexion.Conexion conexion;
        public string nombre_unidad { set; get; }
        public string codigo_curso_nivel { set; get; }
        public string codigo_unidad { set; get; }
        public string porcentaje_modulo { set; get; }
        public string presentacion { set; get; }
        public string nx { set; get; }
        public string imagen { set; get; }

        public principalP[] Buscar_diplomados_modulos_general()
        {
            //Login (Se realiza la verificacion del usuario y su contraseña)
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable menu = con.Execute_Query("call Pr_cargar_diplomados_modulos_general()");
            principalP[] arreglo = new principalP[menu.Rows.Count];
            int j = 0;
            foreach (DataRow i in menu.Rows)
            {
                arreglo[j] = new principalP();
                arreglo[j].nombre_curso = i["nombre_curso"].ToString();
                arreglo[j].codigo_curso = i["id_curso"].ToString();
                arreglo[j].url = i["Url_imagen_curso"].ToString();
                arreglo[j].nombre_unidad = i["nombre_unidad"].ToString();
                arreglo[j].codigo_unidad = i["id_unidad"].ToString();
                arreglo[j].codigo_curso_nivel = i["Curso_nivelid_curso_nivel"].ToString();
                j++;
            }
            return arreglo;

        }

        public principalP[] Buscar_diplomados_modulos_docente(string id_usuario)
        {
            //Login (Se realiza la verificacion del usuario y su contraseña)
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable menu = con.Execute_Query("call Pr_cargar_diplomados_modulos_docente('" + id_usuario + "')");
            principalP[] arreglo = new principalP[menu.Rows.Count];
            int j = 0;
            foreach (DataRow i in menu.Rows)
            {
                arreglo[j] = new principalP();
                arreglo[j].nombre_curso = i["nombre_curso"].ToString();
                arreglo[j].codigo_curso = i["id_curso"].ToString();
                arreglo[j].url = i["Url_imagen_curso"].ToString();
                arreglo[j].nombre_unidad = i["nombre_unidad"].ToString();
                arreglo[j].codigo_unidad = i["id_unidad"].ToString();
                arreglo[j].codigo_curso_nivel = i["Curso_nivelid_curso_nivel"].ToString();
                j++;
            }
            return arreglo;

        }

        public principalP[] Buscar_Cursos_Diplomados_Estudiante(string cc)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable diplomado_modulo = con.Execute_Query("call Pr_cargar_diplomados_modulos_estudiante(" + cc + ")");
            principalP[] arreglo = new principalP[diplomado_modulo.Rows.Count];
            int j = 0;
            foreach (DataRow i in diplomado_modulo.Rows)
            {
                arreglo[j] = new principalP();
                arreglo[j].nombre_curso = i["curso"].ToString();
                arreglo[j].codigo_curso = i["codigo curso"].ToString();
                arreglo[j].porcentaje_diplomado = i["porcentaje"].ToString();
                arreglo[j].url = i["Url_imagen_curso"].ToString();
                arreglo[j].fecha_cierre = Convert.ToDateTime(i["fecha_cierre"].ToString());
                arreglo[j].codigo_curso_usaurio = i["Id_curso_usuario"].ToString();
                arreglo[j].nombre_unidad = i["Nombre Unidad"].ToString();
                arreglo[j].codigo_unidad = i["Codigo unidad"].ToString();
                arreglo[j].codigo_curso_nivel = i["Codigo Curso nivel"].ToString();
                arreglo[j].porcentaje_modulo = i["porcentaje unidad"].ToString();
                arreglo[j].presentacion = i["presentacion"].ToString();
                arreglo[j].imagen= i["url imagen"].ToString();

                j++;
            }
            return arreglo;

        }

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
                arreglo[j].porcentaje_diplomado= i["porcentaje"].ToString();
                arreglo[j].url = i["Url_imagen_curso"].ToString();
                arreglo[j].fecha_cierre = Convert.ToDateTime(i["fecha_cierre"].ToString());
                arreglo[j].codigo_curso_usaurio = i["Id_curso_usuario"].ToString();
                j++;
            }
            return arreglo;

        }

        public principalP[] BuscarCursosgeneral()
        {
            //Login (Se realiza la verificacion del usuario y su contraseña)
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable menu = con.Execute_Query("call Pr_cargar_cursos_general()");
            principalP[] arreglo = new principalP[menu.Rows.Count];
            int j = 0;
            foreach (DataRow i in menu.Rows)
            {
                arreglo[j] = new principalP();
                arreglo[j].nombre_curso = i["nombre_curso"].ToString();
                arreglo[j].codigo_curso = i["id_curso"].ToString();
                arreglo[j].url = i["Url_imagen_curso"].ToString();
                j++;
            }
            return arreglo;

        }

        public principalP[] BuscarCursosDocentes(string id_usuario)
        {
            //Login (Se realiza la verificacion del usuario y su contraseña)
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable menu = con.Execute_Query("call Pr_cargar_cursos_docentes('"+id_usuario+"')");
            principalP[] arreglo = new principalP[menu.Rows.Count];
            int j = 0;
            foreach (DataRow i in menu.Rows)
            {
                arreglo[j] = new principalP();
                arreglo[j].nombre_curso = i["nombre_curso"].ToString();
                arreglo[j].codigo_curso = i["id_curso"].ToString();
                arreglo[j].url = i["Url_imagen_curso"].ToString();
                j++;
            }
            return arreglo;

        }

        public bool Actualizar_saludo(string curso, string usuario)
        {
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_actualizar_saludo ('" + curso + "','" + usuario + "')");
            return x > 0 ? true : false;
        }

        public bool Actualizar_curso_usaurio(string curso_usuario)
        {
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_actualizar_estado_curso_usuario ('" + curso_usuario + "')");
            return x > 0 ? true : false;
        }

        public bool subir_archivo(string url_archivo, string codigo_curso_usuario_unidad, string id_x)
        {
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_ingresar_subir_archivo ('" + url_archivo + "','" + codigo_curso_usuario_unidad + "','" + id_x + "')");
            return x > 0 ? true : false;
        }
    }
}