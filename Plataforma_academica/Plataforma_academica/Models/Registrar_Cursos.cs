using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Registrar_Cursos
    {
        public string Nombre_curso { set; get; }
        public string descripcion_curso { set; get; }
        public int codigo_tematica { set; get; }
        public int codigo_horas { set; get; }
        public string[] avanzado { set; get; }
        public int cantidadBasico { set; get; }
        public int cantidadIntermedio { set; get; }
        public int cantidadAvanzado { set; get; }
        public string docente { set; get; }
        public string[] basico { set; get; }
        public string[] intermedio { set; get; }
        public string[] descripcionbasico { set; get; }
        public string[] descripcionintermedio { set; get; }
        public string[] descripcionavanzado { set; get; }
        private Conexion.Conexion conexion;

        public bool Registrar_curso_unidad(Registrar_Cursos obj, int codigo_nivel,string nombre_unidad,string descripcion_unidad)
        {
            
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_registrar_curso_unidad ('" + obj.Nombre_curso + "','"+codigo_nivel+"','" + nombre_unidad + "','" + descripcion_unidad + "')");
            return x == 0 ? true : false;

        }

        public bool Registrar_curso_nivel(Registrar_Cursos obj, int codigo_nivel)
        {

            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_ingresar_cursonivel ('" + obj.Nombre_curso + "','" + codigo_nivel + "','" + obj.docente + "')");
            return x == 0 ? true : false;

        }

        public bool Registrar_curso_(Registrar_Cursos obj, string archivo)
        {

            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_ingresar_curso ('" + obj.Nombre_curso + "','" + obj.descripcion_curso + "','" + obj.codigo_tematica + "','"+archivo+"')");
            return x >= 0 ? true : false;

        }


    }
}