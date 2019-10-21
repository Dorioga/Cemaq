using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Editar_Actividad
    {
        public String id_actividad { set; get; }
        public String id_tipo_multimedia { set; get; }
        public String Nombre_actividad { set; get; }
        public String descripcion { set; get; }
        public String titulo_seccion { set; get; }
        public String contenido_seccion { set; get; }
        public String id_multimedia { set; get; }
        public String url_multimedia { set; get; }
        public String descripcion_editar { set; get; }
        public String id_seccion { set; get; }
        public String mul { set; get; }
        public String editar_elegir { set; get; }

        private Conexion.Conexion con = new Conexion.Conexion();


        public Editar_Actividad[] Editar_contenido_actividad(string cn)
        {
            
            DataTable actividad = con.Execute_Query("call Pr_cargar_contenido(" + cn + ")");
            Editar_Actividad[] arreglo = new Editar_Actividad[actividad.Rows.Count];
            int j = 0;
            foreach (DataRow i in actividad.Rows)
            {
                arreglo[j] = new Editar_Actividad();
                arreglo[j].id_actividad = i["id_actividad"].ToString();
                arreglo[j].titulo_seccion = i["titulo_seccion"].ToString();
                arreglo[j].contenido_seccion = i["contenido_seccion"].ToString();
                arreglo[j].id_multimedia = i["id_multimedia"].ToString();
                arreglo[j].url_multimedia = i["url_multimedia"].ToString();
                arreglo[j].id_tipo_multimedia = i["tipo multimedia"].ToString();
                j++;
            }
            return arreglo;
        }

        public Editar_Actividad[] lista_editar(string cn)
        {

            DataTable actividad = con.Execute_Query("call Pr_cargar_contenido(" + cn + ")");
            Editar_Actividad[] arreglo = new Editar_Actividad[actividad.Rows.Count];
            Editar_Actividad inicio = new Editar_Actividad();
            int j = 0;
            foreach (DataRow i in actividad.Rows)
            {
                arreglo[j] = new Editar_Actividad();
                arreglo[j].titulo_seccion = i["titulo_seccion"].ToString();
                arreglo[j].id_seccion = i["id_seccion"].ToString();
                j++;
            }
            return arreglo;
        }

        public Editar_Actividad[] Buscar_comentario_editar(string c)
        {
            
            DataTable x = con.Execute_Query("call Pr_Comentario_Editar ('" + c + "')");
            Editar_Actividad[] arreglo = new Editar_Actividad[x.Rows.Count];
            int j = 0;
            foreach (DataRow i in x.Rows)
            {
                arreglo[j] = new Editar_Actividad();
                arreglo[j].descripcion_editar = i["Descripcion_editar"].ToString();
                j++;
            }
            return arreglo;

        }

        public DataTable contenido_actividad_editar(Editar_Actividad obj, string cn)
        {            
            DataTable x = con.Execute_Query("call Pr_cargar_para_editar(" + cn + "," + obj.editar_elegir + ")");
            return x;
        }

        public bool Actualizar_nombre_actividad(string cn, Editar_Actividad obj)
        {
            con = new Conexion.Conexion();
            int x = con.Execute_Operation("call Pr_Actualizar_Nombre_Actividad ('" + obj.Nombre_actividad + "', '" + cn+ "', '" + obj.editar_elegir + "')");
            return x > 0 ? true : false;
        }

        public bool Actualizar_nombre_seccion(string cn, Editar_Actividad obj)
        {
            con = new Conexion.Conexion();
            int x = con.Execute_Operation("call Pr_Actualizar_nombre_seccion ('" + obj.titulo_seccion + "', '" + obj.editar_elegir + "')");
            return x > 0 ? true : false;
        }

        public bool Actualizar_descripcion_actividad(string cn1, Editar_Actividad obj)
        {
            con = new Conexion.Conexion();
            int y = con.Execute_Operation("call Pr_actualizar_descripcion_actividad ('" + obj.descripcion + "', '" + cn1 + "', '"+obj.editar_elegir+"')");
            return y > 0 ? true : false;
        }

        public bool Actualizar_descripcion_seccion(Editar_Actividad obj)
        {
            con = new Conexion.Conexion();
            int y = con.Execute_Operation("call Pr_Actualizar_seccion ('" + obj.descripcion + "', '" + obj.editar_elegir + "')");
            return y > 0 ? true : false;
        }

        public bool Actualizar_multimedia(string cn2, Editar_Actividad obj, string nombre, lista_tipo_multimedia tipo_multimedia, HttpPostedFileBase o)
        {
            con = new Conexion.Conexion();
            int z = con.Execute_Operation("call Pr_actualizar_multimedia ('" + nombre + "', '"+ o.FileName + "','" + cn2 + "', '"+ obj.mul+"')");
            return z > 0 ? true : false;
        }

        public bool Eliminar_multimedia(string cn3)
        {
            con = new Conexion.Conexion();
            int zx = con.Execute_Operation("call Pr_actualizar_estado_mutimedia ('" + cn3 +"')");
            return zx > 0 ? true : false;
        }

        //public bool Actualizar_nombre_seccion(string cn, Editar_Actividad obj)
        //{
        //    int x=0;
        //    con = new Conexion.Conexion();
        //    //mUESTREME DNDE SE CARGA LO DE BASE DEDATOS 
        //    for (int i = 0; i < obj.titulo_seccion2.Length; i++)
        //    {
        //        if (obj.titulo_seccion2[i] != "")
        //        {
        //            x = con.Execute_Operation("call Pr_Actualizar_nombre_seccion ('" + obj.titulo_seccion2[i] + "', '" + cn + "')");
        //        }                
        //    }
            
        //    return x > 0 ? true : false;
        //}

    }
}