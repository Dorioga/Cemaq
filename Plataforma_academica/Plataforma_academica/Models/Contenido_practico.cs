﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Contenido_practico
    {
        public int tipo_pregunta { set; get; }
        public int tipo_multimedia { set; get; }
        public int tipo_clasificacion { set; get; }
        public string nombre_contenido { set; get; }
        public string descripcion_contenido { set; get; }
        public int id_exam { set; get; }
        public int tipo_e { set; get; }
        public string nombre_pregunta { set; get; }
        public string descripcion_pregunta { set; get; }
        public String[] respuestas { set; get; }
        public string nombre_multimedia { set; get; }
        public string url_multimedia { set; get; }
        public string id_pregunta { set; get; }
        public int[] tipo_condicion { set; get; }
        
        private Conexion.Conexion conexion;

        public DataTable Registrar_Titulo_practica(Contenido_practico obj, string unidad)
        {
            conexion = new Conexion.Conexion();
            DataTable x = conexion.Execute_Query("call Pr_ingresar_examen ('" + obj.nombre_contenido + "', '" + obj.descripcion_contenido + "','" + obj.tipo_e + "','" + unidad+ "')");
            return x;
        }

        public DataTable Registrar_pregunta(Contenido_practico obj, int fk_examen, string url, string nombre)
        {
            conexion = new Conexion.Conexion();
            DataTable x = conexion.Execute_Query("call Pr_ingresar_pregunta ('" + obj.nombre_pregunta + "', '" + obj.descripcion_pregunta + "','" + fk_examen + "','" + obj.tipo_pregunta + "','" + nombre + "','" + url + "','" + obj.tipo_clasificacion + "','" + obj.tipo_multimedia+ "')");
            return x;
        }

        public bool Registrar_Respuesta(Contenido_practico obj, string pregunta)
        {
            conexion = new Conexion.Conexion();
            int x = 0;
            for (int i = 0; i < 4; i++)
            {
                if (obj.respuestas[i] != "")
                {
                    x = conexion.Execute_Operation("call Pr_ingresar_respuesta ('" + obj.respuestas[i] + "', '" + obj.tipo_condicion[i] + "', '" + pregunta + "')");
                }
            }
            return x > 0 ? true : false;
        }
    }
}