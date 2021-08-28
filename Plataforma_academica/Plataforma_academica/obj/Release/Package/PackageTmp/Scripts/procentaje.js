




     actividad.datos1 = us.Buscar_porcentaje_seccion(actividad1.codigo_actividad);
     if (Convert.ToInt32(actividad.datos1.Rows[0]["porcentaje"].ToString()) < 100)
     {
         actividad.datos = us.Buscar_cantidad_secciones(actividad1.codigo_actividad);
         for (var j = 1; j <= Convert.ToInt32(actividad.datos.Rows[0]["numero secciones"].ToString()); j++)
         {

         }
     }
