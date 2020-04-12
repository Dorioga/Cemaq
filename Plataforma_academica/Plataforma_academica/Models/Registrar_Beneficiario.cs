using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Registrar_Beneficiario
    {
        public string nombre1 { set; get; }
        public string nombre2 { set; get; }
        public string apellido1 { set; get; }
        public string apellido2 { set; get; }
        public string cedula { set; get; }
        public string telefono { set; get; }
        public string rol { set; get; }
        public string institucion { set; get; }
        public string documento { set; get; }
        public string genero { set; get; }
        public string poblacion { set; get; }
        public string fecha_nacimiento { set; get; }
        public string correo { set; get; }
        public string nombre_empresa { set; get; }
        public string nombre_grupo { set; get; }
        public string cod_rol { set; get; }
        public string nombre_curso { set; get; }
        public string cantidad_nivel { set; get; }
        public string nivel1 { set; get; }
        public string nivel2 { set; get; }
        public string nivel3 { set; get; }
        public string codigo_unidad { set; get; }
        public string codigo_actividad { set; get; }
        public string codigo_examen { set; get; }

        private Conexion.Conexion conexion;

        public bool Registrar_Beneficiarios(Registrar_Beneficiario obj)
        {
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_ingresar_beneficiario ('" + obj.cedula + "', '" + obj.nombre1 + "', '" + obj.nombre2 + "', '" + obj.apellido1 + "', '" + obj.apellido2 + "', '" + obj.fecha_nacimiento + "', '" + obj.telefono + "', '" + obj.correo + "', '" + obj.genero + "', '" + obj.nombre_empresa + "', '" + obj.nombre_grupo + "', '"+obj.poblacion+"','"+obj.documento+"','"+obj.cod_rol+ "','" + obj.nombre_curso + "')");
            return x > 0 ? true : false;

        }


        public bool Registrar_Nivel_Beneficiarios(Registrar_Beneficiario obj)
        {
            int y = Convert.ToInt32(obj.cantidad_nivel);
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_ingresar_nivel_usuario ('" + obj.cedula + "','" + obj.nombre_curso + "','" + obj.nivel1 + "','" + obj.nivel2 + "','" + obj.nivel3 + "','" + y + "')");
            return x == 0 ? true : false;

        }

        public bool Registrar_Unidad_Beneficiarios1(Registrar_Beneficiario obj,  Registrar_Beneficiario obj1)
        {
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_ingresar_unidades_beneficiario ('" + obj.codigo_unidad + "', '" + obj1.nombre_curso + "', '" + obj1.nivel1 + "', '" + obj1.cedula + "')");
            return x > 0 ? true : false;

        }

        public bool Registrar_Unidad_Beneficiarios2(Registrar_Beneficiario obj, Registrar_Beneficiario obj1)
        {
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_ingresar_unidades_beneficiario ('" + obj.codigo_unidad + "', '" + obj1.nombre_curso + "', '" + obj1.nivel2 + "', '" + obj1.cedula + "')");
            return x > 0 ? true : false;

        }

        public bool Registrar_Unidad_Beneficiarios3(Registrar_Beneficiario obj, Registrar_Beneficiario obj1)
        {
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_ingresar_unidades_beneficiario ('" + obj.codigo_unidad + "', '" + obj1.nombre_curso + "', '" + obj1.nivel3 + "', '" + obj1.cedula + "')");
            return x > 0 ? true : false;

        }

        public bool Registrar_actividad_Beneficiarios(Registrar_Beneficiario obj, Registrar_Beneficiario obj1, Registrar_Beneficiario obj2)
        {
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_ingresar_actividad_beneficiario ('" + obj2.codigo_unidad + "', '" + obj1.cedula + "', '" + obj.codigo_actividad + "')");
            return x > 0 ? true : false;

        }

        public bool Registrar_examen_Beneficiarios(Registrar_Beneficiario obj, Registrar_Beneficiario obj1, Registrar_Beneficiario obj2)
        {
            conexion = new Conexion.Conexion();
            int x = conexion.Execute_Operation("call Pr_ingresar_examen_beneficiario ('" + obj2.codigo_unidad + "', '" + obj1.cedula + "', '"+obj.codigo_examen+"')");
            return x > 0 ? true : false;

        }

        public DataTable Buscarunidades_para_registrar1(Registrar_Beneficiario obj)
        {
            conexion = new Conexion.Conexion();
            DataTable x = conexion.Execute_Query("call Pr_cargar_unidades_registrar_beneficiario('" + obj.nivel1 + "', '" + obj.nombre_curso + "')");
            return x;
        }

        public DataTable Buscarunidades_para_registrar2(Registrar_Beneficiario obj)
        {
            conexion = new Conexion.Conexion();
            DataTable x = conexion.Execute_Query("call Pr_cargar_unidades_registrar_beneficiario('" + obj.nivel2 + "', '" + obj.nombre_curso + "')");
            return x;
        }

        public DataTable Buscarunidades_para_registrar3(Registrar_Beneficiario obj)
        {
            conexion = new Conexion.Conexion();
            DataTable x = conexion.Execute_Query("call Pr_cargar_unidades_registrar_beneficiario('" + obj.nivel3 + "', '" + obj.nombre_curso + "')");
            return x;
        }

        public DataTable Buscarexamen_para_registrar(Registrar_Beneficiario obj)
        {
            conexion = new Conexion.Conexion();
            DataTable x = conexion.Execute_Query("call Pr_cargar_examen_beneficiario('" + obj.codigo_unidad + "')");
            return x;
        }

        public DataTable Buscaractividades_para_registrar(Registrar_Beneficiario obj)
        {
            conexion = new Conexion.Conexion();
            DataTable x = conexion.Execute_Query("call Pr_cargar_actividad_beneficiario('" + obj.codigo_unidad + "')");
            return x;
        }

        public DataTable Buscarbeneficiario(string cedula)
        {
            conexion = new Conexion.Conexion();
            DataTable x = conexion.Execute_Query("call Pr_cargar_existencia_beneficiario('" + cedula + "')");
            return x;
        }
    }
}