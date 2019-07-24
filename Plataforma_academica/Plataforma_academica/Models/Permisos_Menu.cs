using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Permisos_Menu
    {
        public String nombre, controlador, accion;

        public Permisos_Menu[] ConsultarMenu(String cargo)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable menu = con.Execute_Query("call Pr_cargar_permisos(" + cargo + ")");
            Permisos_Menu[] arreglo = new Permisos_Menu[menu.Rows.Count];
            int j = 0;
            foreach (DataRow i in menu.Rows)
            {
                arreglo[j] = new Permisos_Menu();
                arreglo[j].nombre = i["nombre_permiso"].ToString();
                arreglo[j].controlador = i["controlador_permiso"].ToString();
                arreglo[j].accion = i["accion_permiso"].ToString();
                j++;
            }
            return arreglo;

        }
    }
}