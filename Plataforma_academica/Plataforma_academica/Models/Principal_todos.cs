using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Principal_todos
    {
        public string id_tematica { set; get; }
        public string nombre_tematica { set; get; }
        public string id_curso { set; get; }
        public string id_c { set; get; }
        public string nombre_curso { set; get; }
        public string descripcion { set; get; }
        public string id_R { set; get; }
        public string nombre_R { set; get; }
        public string descripcion_R { set; get; }
        public string id_unidad { set; get; }
        public string id_actividad { set; get; }
        public string id_examen { set; get; }
        public string estado_tematica { set; get; }
        public string estado_diplomado { set; get; }
        public string imagen { set; get; }
        public string url_imagen { set; get; }

        Conexion.Conexion con = new Conexion.Conexion();

        public DataTable Buscarcurso(string u)
        {
            
            DataTable x = con.Execute_Query("call Pr_cargar_diploamo_para_registrar ('" + u +"')");
            return x;

        }

        public DataTable Buscarcurso_inscrito(string u, string usuario)
        {

            DataTable x = con.Execute_Query("call Pr_cargar_si_esta_el_curso ('" + u + "', '" + usuario + "')");
            return x;

        }

        public Principal_todos[] Buscarareas()
        {
            
            DataTable areas = con.Execute_Query("call Pr_cargar_tematicas()");
            Principal_todos[] arreglo = new Principal_todos[areas.Rows.Count];
            int j = 0;
            foreach (DataRow i in areas.Rows)
            {
                arreglo[j] = new Principal_todos();
                arreglo[j].id_tematica = i["id_tematica_curso"].ToString();
                arreglo[j].nombre_tematica = i["nombre_tematica_curso"].ToString();
                arreglo[j].estado_tematica = i["estado"].ToString();
                arreglo[j].imagen = i["url_imagen"].ToString();
                j++;
            }
            return arreglo;

        }

        public Principal_todos[] Buscar_cursos_areas(Principal_todos id)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable areas_cursos = con.Execute_Query("call Pr_cargar_cursos_tematica('"+id.id_c+"')");
            Principal_todos[] arreglo = new Principal_todos[areas_cursos.Rows.Count];
            int j = 0;
            foreach (DataRow i in areas_cursos.Rows)
            {
                arreglo[j] = new Principal_todos();
                arreglo[j].id_curso = i["id_curso"].ToString();
                arreglo[j].nombre_curso = i["nombre_curso"].ToString();
                arreglo[j].estado_diplomado = i["estado_curso"].ToString();
                arreglo[j].url_imagen = i["Url_imagen_curso"].ToString();
                j++;
            }
            return arreglo;

        }

        public Principal_todos[] Buscar_descripcion_areas(Principal_todos id)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable areas_cursos = con.Execute_Query("call Pr_cargar_descripcion_area('" + id.id_c + "')");
            Principal_todos[] arreglo = new Principal_todos[areas_cursos.Rows.Count];
            int j = 0;
            foreach (DataRow i in areas_cursos.Rows)
            {
                arreglo[j] = new Principal_todos();
                arreglo[j].descripcion = i["descripcion_tematica_curso"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}