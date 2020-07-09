using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    
    public class contenido
    {
        public string nombre_contenido { set; get; }
        public string descripcion_contenido { set; get; }
        public string nombre_multimedia { set; get; }
        public String tipo_multimedia { set; get; }
        public String tipo_soporte { set; get; }
        public int id_actividad { set; get; }
        public string url_video { set; get; }
        public string url_apoyo { set; get; }
        public string codigo_usuario_unidad { set; get; }

        private Conexion.Conexion conexion;

        public DataTable Registrar_Contenido(contenido obj, string unidad, string archivo, string o, string archivo1)
        {
            conexion = new Conexion.Conexion();
            if (Convert.ToInt32(obj.tipo_multimedia) == 1)
            {
                if (Convert.ToInt32(obj.tipo_soporte) == 3)
                {
                    DataTable x = conexion.Execute_Query("call Pr_ingresar_titulo_actividad_inicial ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + "1" + "','" + unidad + "','" + o + "','" + obj.url_video + "', '" + 3 + "', '" + obj.tipo_multimedia + "','" + obj.url_apoyo + "','" + obj.tipo_soporte + "')");
                    return x;
                }
                else
                {
                    DataTable x = conexion.Execute_Query("call Pr_ingresar_titulo_actividad_inicial ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + "1" + "','" + unidad + "','" + o + "','" + obj.url_video + "', '" + 3 + "', '" + obj.tipo_multimedia + "','" + archivo1 + "','" + obj.tipo_soporte + "')");
                    return x;
                }
            }else
            {
                if (Convert.ToInt32(obj.tipo_soporte) == 3)
                {
                    DataTable x = conexion.Execute_Query("call Pr_ingresar_titulo_actividad_inicial ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + "1" + "','" + unidad + "','" + o + "','" + archivo + "', '" + 3 + "', '" + obj.tipo_multimedia + "','" + obj.url_apoyo+ "','" + obj.tipo_soporte + "')");
                    return x;
                }else
                {
                    DataTable x = conexion.Execute_Query("call Pr_ingresar_titulo_actividad_inicial ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + "1" + "','" + unidad + "','" + o + "','" + archivo + "', '" + 3 + "', '" + obj.tipo_multimedia + "','" + archivo1 + "','" + obj.tipo_soporte + "')");
                    return x;
                }
            }
            //if (Convert.ToInt32(obj.tipo_multimedia)==1)
            //{
            //    DataTable x = conexion.Execute_Query("call Pr_ingresar_titulo_actividad_inicial ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + "1" + "','" + unidad + "','" + o + "','" + obj.url_video + "', '" + 3 + "', '" + obj.tipo_multimedia + "','" + archivo1 + "','" + obj.tipo_soporte + "')");
            //    return x;
            //}
            //else
            //{
            //    if (Convert.ToInt32(obj.tipo_soporte) == 3)
            //    {
            //        DataTable x = conexion.Execute_Query("call Pr_ingresar_titulo_actividad_inicial ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + "1" + "','" + unidad + "','" + o + "','" + obj.url_video + "', '" + 3 + "', '" + obj.tipo_multimedia + "','" + obj.url_apoyo + "','" + obj.tipo_soporte + "')");
            //        return x;
            //    }
            //    else
            //    {
            //        DataTable x = conexion.Execute_Query("call Pr_ingresar_titulo_actividad_inicial ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + "1" + "','" + unidad + "','" + o + "','" + archivo + "', '" + 3 + "', '" + obj.tipo_multimedia + "','" + archivo1 + "','" + obj.tipo_soporte + "')");
            //        return x;
            //    }
            //}
                
        }

        public contenido[] buscar_usuarios_correo(string u)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable conten = con.Execute_Query("call Pr_cargar_usuario_unidad_para_correo(" + u + ")");
            contenido[] arreglo = new contenido[conten.Rows.Count];
            contenido inicio = new contenido();
            int j = 0;
            foreach (DataRow i in conten.Rows)
            {
                arreglo[j] = new contenido();
                arreglo[j].codigo_usuario_unidad = i["id"].ToString();

                j++;
            }
            return arreglo;
        }

        public bool Registrar_actividad_automatico(string obj, string uni)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            int x = con.Execute_Operation("call Pr_registrar_actividad_automatico ('" + obj + "', '" +uni + "')");
            return x > 0 ? true : false;

        }

        public bool Registrar_seccion(contenido obj, int id_act, string archivo, string o, string archivo1)
        {
            conexion = new Conexion.Conexion();

            if (Convert.ToInt32(obj.tipo_multimedia) == 1)
            {
                if (Convert.ToInt32(obj.tipo_soporte) == 3)
                {
                    int x = conexion.Execute_Operation("call Pr_ingresar_seccion ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + id_act + "','" + o + "','" + obj.url_video + "', '" + 3 + "', '" + obj.tipo_multimedia + "','" + obj.tipo_soporte + "','" + obj.url_apoyo + "')");
                    return x == 0 ? true : false;
                }else
                {
                    int x = conexion.Execute_Operation("call Pr_ingresar_seccion ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + id_act + "','" + o + "','" + obj.url_video + "', '" + 3 + "', '" + obj.tipo_multimedia + "','" + obj.tipo_soporte + "','" + archivo1 + "')");
                    return x == 0 ? true : false;
                }
            }else
            {
                if (Convert.ToInt32(obj.tipo_soporte) == 3)
                {
                    int x = conexion.Execute_Operation("call Pr_ingresar_seccion ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + id_act + "','" + o + "','" + archivo + "', '" + 3 + "', '" + obj.tipo_multimedia + "','" + obj.tipo_soporte + "','" + obj.url_apoyo + "')");
                    return x == 0 ? true : false;
                }else
                {
                    int x = conexion.Execute_Operation("call Pr_ingresar_seccion ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + id_act + "','" + o + "','" + archivo + "', '" + 3 + "', '" + obj.tipo_multimedia + "','" + obj.tipo_soporte + "','" + archivo1 + "')");
                    return x == 0 ? true : false;
                }
            }

            //if (Convert.ToInt32(obj.tipo_multimedia) == 1)
            //{
            //    int x = conexion.Execute_Operation("call Pr_ingresar_seccion ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + id_act + "','" + o + "','" + obj.url_video + "', '" + 3 + "', '" + obj.tipo_multimedia + "','" + obj.tipo_soporte + "','" + archivo1 + "')");
            //    return x == 0 ? true : false;
            //}
            //else
            //{
            //    if (Convert.ToInt32(obj.tipo_soporte)==3)
            //    {
            //        int x = conexion.Execute_Operation("call Pr_ingresar_seccion ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + id_act + "','" + o + "','" + obj.url_apoyo + "', '" + 3 + "', '" + obj.tipo_multimedia + "','" + obj.tipo_soporte + "','" + archivo1 + "')");
            //        return x == 0 ? true : false;
            //    }
            //    else
            //    {
            //        int x = conexion.Execute_Operation("call Pr_ingresar_seccion ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "', '" + id_act + "','" + o + "','" + archivo + "', '" + 3 + "', '" + obj.tipo_multimedia + "','" + obj.tipo_soporte + "','" + archivo1 + "')");
            //        return x == 0 ? true : false;
            //    }
            //}
        }
    }
}