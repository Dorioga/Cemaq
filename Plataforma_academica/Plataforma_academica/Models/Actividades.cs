using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Actividades
    {
        public String id_actividad { set; get; }
        public String id_tipo_multimedia { set; get; }
        public String Nombre_actividad { set; get; }
        public String descripcion { set; get; }
        public String titulo_seccion { set; get; }
        public String edicion { set; get; }
        public String edicion_estado { set; get; }
        public String contenido_seccion { set; get; }
        public String id_multimedia { set; get; }
        public String url_multimedia { set; get; }

        public String nombre_usuario { set; get; }
        public String correo { set; get; }
        public String identificacion { set; get; }
        public String nombre_act { set; get; }
        public String desc { set; get; }
        public String curso { set; get; }
        public String nombre_uni { set; get; }
        public String niv { set; get; }
        public String arch { set; get; }
        public String tipo_seccion { set; get; }

        public int seccion { set; get; }
        public int cont_seccion { set; get; }
        public int id_curso_actividad { set; get; }
        public double porc { set; get; }
        public string link_referencia { set; get; }
        public DataTable actual_seccion { set; get; }

        public Actividades[] Consultar_contenido_actividad(string cn)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable actividad = con.Execute_Query("call Pr_cargar_contenido(" + cn+ ")");
            Actividades[] arreglo = new Actividades[actividad.Rows.Count];
            Actividades inicio = new Actividades();
            int j = 0;
            foreach (DataRow i in actividad.Rows)
            {
                arreglo[j] = new Actividades();
                arreglo[j].id_actividad = i["id_actividad"].ToString();
                arreglo[j].Nombre_actividad = i["Nombre_actividad"].ToString();
                arreglo[j].descripcion = i["descripcion"].ToString();
                arreglo[j].edicion_estado = i["estado_edicion_actividad"].ToString();
                arreglo[j].titulo_seccion = i["titulo_seccion"].ToString();
                arreglo[j].contenido_seccion = i["contenido_seccion"].ToString();
                arreglo[j].id_multimedia = i["id_multimedia"].ToString();
                arreglo[j].url_multimedia = i["url_multimedia"].ToString();
                arreglo[j].id_tipo_multimedia = i["tipo multimedia"].ToString();
                arreglo[j].tipo_seccion = i["Tipo_seccion"].ToString();
                arreglo[j].arch = i["Archivo"].ToString();
                arreglo[j].link_referencia = i["Link_apa"].ToString();
                j++;
            }
            return arreglo;
        }

        public bool Actualizar_actividad_y_usurio_actividad(string id)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            int x = con.Execute_Operation("call Pr_actualizar_actividad_estado ('" + id + "')");
            return x >= 0 ? true : false;
        }

        public Actividades[] usuarios_correo_actividad(string u)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable acti_usu = con.Execute_Query("call Pr_correos_respecto_actividad(" + u + ")");
            Actividades[] arreglo = new Actividades[acti_usu.Rows.Count];
            Actividades inicio = new Actividades();
            int j = 0;
            foreach (DataRow i in acti_usu.Rows)
            {
                arreglo[j] = new Actividades();
                arreglo[j].nombre_usuario = i["nombre"].ToString();
                arreglo[j].correo = i["email_persona"].ToString();
                arreglo[j].identificacion = i["id_persona"].ToString();
                arreglo[j].curso = i["nombre_curso"].ToString();
                arreglo[j].nombre_uni = i["nombre_unidad"].ToString();
                arreglo[j].niv = i["nombre_nivel"].ToString();
                j++;
            }
            return arreglo;
        }

        public DataTable i_actividad(string u)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable x = con.Execute_Query("call Pr_id_actividad (" + u + ")");
            return x;
        }

        public DataTable Buscar_cantidad_secciones(string u)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable x = con.Execute_Query("call Pr_cargar_cantidad_secciones (" + u + ")");
            return x;
        }

        public bool Actualizar_estado(string codigo_actividad, string edicion)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            int x = con.Execute_Operation("call Pr_actualizar_act ('" + codigo_actividad + "','" + edicion + "')");
            return x > 0 ? true : false;
        }

        public bool Actualizar_porcentaje(double porcentaje, int codigo_actividad, int seccion, int id_curso_actividd)
        {
           Conexion.Conexion con = new Conexion.Conexion();
           int x = con.Execute_Operation("call Pr_actualizar_porcentaje_actividad ('" +porcentaje+ "', '" +codigo_actividad+ "', '" +seccion+"', '" +id_curso_actividd+"')");
           return x > 0 ? true : false;
        }

        public bool Actualizar_porcentaje_estado(int codigo_actividad, int id_curso_actividd)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            int x = con.Execute_Operation("call Pr_actualizar_esatado_eactividad ('" + codigo_actividad + "', '" + id_curso_actividd + "')");
            return x > 0 ? true : false;
        }

        public DataTable Buscar_porcentaje_seccion(string u, string usuario)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable x = con.Execute_Query("call Pr_cargar_porcentaje (" + u + "," + usuario + ")");
            return x;
        }

        public DataTable Buscar_seccion_actual(string u, string id_usuario)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable x = con.Execute_Query("call Pr_cargar_seccion_actual (" + u + ", "+id_usuario+")");
            return x;
        }
    }
}