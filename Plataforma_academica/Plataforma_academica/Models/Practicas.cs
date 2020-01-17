using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Practicas
    {
        public String nombre_examen { set; get; }
        public int intentos { set; get; }
        public String descripcion_examen { set; get; }
        public int id_pregunta{ set; get; }
        public String nombre_pregunta { set; get; }
        public String contenido_pregunta { set; get; }
        public int id_tipo_multimedia { set; get; }
        public String nombre_tipo_multimedia { set; get; }
        public int id_clasificacion { set; get; }
        public String nombre_clasificacion { set; get; }
        public int id_multimedia_examen { set; get; }
        public String multimedia { set; get; }
        public int id_respuesta { set; get; }
        public String contenido_respuesta { set; get; }
        public int nombre_condicion { set; get; }

        public Practicas[] Consultar_contenido_practica(string cn)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable practica = con.Execute_Query("call Pr_cargar_practica(" + cn + ")");
            Practicas[] arreglo = new Practicas[practica.Rows.Count];
            Practicas inicio = new Practicas();
            int j = 0;
            foreach (DataRow i in practica.Rows)
            {
                arreglo[j] = new Practicas();                
                arreglo[j].id_pregunta = Convert.ToInt32(i["id_pregunta"].ToString());
                arreglo[j].nombre_pregunta = i["nombre pregunta"].ToString();
                arreglo[j].contenido_pregunta = i["contenido pregunta"].ToString();
                arreglo[j].id_tipo_multimedia = Convert.ToInt32(i["id_tipo_multimedia"].ToString());
                arreglo[j].nombre_tipo_multimedia = i["nombre_tipo_multimedia"].ToString();
                arreglo[j].id_clasificacion = Convert.ToInt32(i["id_clasificacion"].ToString());
                arreglo[j].nombre_clasificacion = i["nombre_clasificacion"].ToString();
                arreglo[j].id_multimedia_examen = Convert.ToInt32(i["id_multimedia_examen"].ToString());
                arreglo[j].multimedia = i["multimedia"].ToString();
                j++;
            }
            return arreglo;
        }

        public Practicas[] Consultar_reguntas(string cn)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable practica = con.Execute_Query("call Pr_cargar_practica(" + cn + ")");
            Practicas[] arreglo = new Practicas[practica.Rows.Count];
            Practicas inicio = new Practicas();
            int j = 0;
            foreach (DataRow i in practica.Rows)
            {
                arreglo[j] = new Practicas();
                arreglo[j].id_pregunta = Convert.ToInt32(i["id_pregunta"].ToString());
                j++;
            }
            return arreglo;
        }

        public Practicas[] Consultar_respuestas_practica(string cn, int id_pregunta)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable practica = con.Execute_Query("call Pr_cargar_respuestas_practica(" + cn + ","+id_pregunta+")");
            Practicas[] arreglo = new Practicas[practica.Rows.Count];
            Practicas inicio = new Practicas();
            int j = 0;
            foreach (DataRow i in practica.Rows)
            {
                arreglo[j] = new Practicas();               
                arreglo[j].id_respuesta = Convert.ToInt32(i["id_respuesta"].ToString());
                arreglo[j].contenido_respuesta = i["contenido_respuesta"].ToString();
                arreglo[j].nombre_condicion = Convert.ToInt32(i["nombre_condicion"].ToString());

                j++;
            }
            return arreglo;
        }

        public Practicas[] Consultar_examen_practica(string cn)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable practica = con.Execute_Query("call Pr_cargar_nombre_examen(" + cn + ")");
            Practicas[] arreglo = new Practicas[practica.Rows.Count];
            Practicas inicio = new Practicas();
            int j = 0;
            foreach (DataRow i in practica.Rows)
            {
                arreglo[j] = new Practicas();
                arreglo[j].nombre_examen = i["nombre_examen"].ToString();
                arreglo[j].descripcion_examen = i["descripcion_examen"].ToString();

                j++;
            }
            return arreglo;
        }

        public bool registrar_nota(string id, int id_pregunta, int opcion, float nota, int intentos)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            int x = con.Execute_Operation("call Pr_ingresar_nota ('" + id + "','" + id_pregunta + "','" + opcion + "','" + nota + "', '"+intentos+"')");
            return x > 0 ? true : false;
        }

        public DataTable Buscarintentos(string examen, string id_usuario)
        {
            //Login (Se realiza la verificacion del usuario y su contraseña)
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable x = con.Execute_Query("call Pr_cargar_intentos_examen ('" + examen + "', '" + id_usuario + "')");
            return x;

        }

        public bool actualizar_intentos(string id, string examen, int inten, int opcion, float nota, int id_pregunta)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            int x = con.Execute_Operation("call Pr_actualizar_intentos ('" + inten + "','" + id + "','" + examen + "','" + opcion + "','" + nota + "','" +id_pregunta+ "')");
            return x > 0 ? true : false;
        }
    }
}