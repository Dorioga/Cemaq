using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_academica.Models
{
    public class Chat
    {
        public string id_chat { set; get; }
        public string mensaje { set; get; }
        public string emisor { set; get; }
        public string receptor { set; get; }
        public string estado_chat { set; get; }
        public string fecha { set; get; }
        public DataTable datos { set; get; }
        public string nombre { set; get; }
        public string respuesta { set; get; }

        public Chat[] BuscarChat(string usuario)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable chat = con.Execute_Query("call Pr_cargar_chats('" + usuario + "')");
            Chat[] arreglo = new Chat[chat.Rows.Count];
            int j = 0;
            foreach (DataRow i in chat.Rows)
            {
                arreglo[j] = new Chat();
                arreglo[j].id_chat = i["id_chat"].ToString();
                arreglo[j].mensaje = i["mensaje"].ToString();
                arreglo[j].emisor = i["emisor"].ToString();
                arreglo[j].receptor = i["receptor"].ToString();
                arreglo[j].fecha = i["fecha"].ToString();
                arreglo[j].estado_chat = i["estado_chat"].ToString();
                arreglo[j].respuesta = i["respuesta"].ToString();
                j++;
            }
            return arreglo;

        }

        public DataTable BuscarPersona(string c)
        {
            //Login (Se realiza la verificacion del usuario y su contraseña)
            Conexion.Conexion con = new Conexion.Conexion();
            DataTable x = con.Execute_Query("call Pr_cargar_receptor ('" + c + "')");
            return x;

        }
    }
}