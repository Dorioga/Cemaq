using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Plataforma_academica.Conexion
{
    public class Conexion
    {
        public static string stringConnection = ConfigurationManager.ConnectionStrings["plataforma_academica"].ConnectionString;
        private MySqlConnection MyConnection = new MySqlConnection(stringConnection);

        //Connect Data Base
        private bool Connect()
        {
            try
            {
                MyConnection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //Disconnect Data Base
        private void Disconnect()
        {
            MyConnection.Close();
        }
        //Query To Multiple Table 
        public DataTableCollection Execute_Query_Collection(string sentencia)
        {
            MySqlDataAdapter AdapterMySql = new MySqlDataAdapter();
            AdapterMySql.SelectCommand = new MySqlCommand(sentencia, MyConnection);
            DataSet Result = new DataSet();
            AdapterMySql.Fill(Result);
            try
            {

                return Result.Tables;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        //Query to one Table
        public DataTable Execute_Query(string sentencia)
        {
            MySqlDataAdapter AdapterMySql = new MySqlDataAdapter();
            AdapterMySql.SelectCommand = new MySqlCommand(sentencia, MyConnection);
            DataSet Result = new DataSet();
            AdapterMySql.Fill(Result);
            try
            {
                return Result.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        //Execute Operation
        public int Execute_Operation(string sentencia)
        {
            try
            {
                if (Connect())
                {

                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = sentencia;
                    comando.Connection = MyConnection;
                    int x = comando.ExecuteNonQuery();
                    Disconnect();
                    return x;
                }
                else
                {
                    return -1;
                }
            }
            catch
            {

                return -1;
            }


        }
        //Open Connection
        public MySqlConnection Open_Connection()
        {
            string CadenaConexion;
            CadenaConexion = ConfigurationManager.ConnectionStrings["control_academico"].ConnectionString;
            MySqlConnection Conexion = new MySqlConnection(CadenaConexion);
            try
            {
                Conexion.Open();
            }
            catch (Exception error)
            {

            }
            return Conexion;
        }

        //Execute Transaction
        public bool Execute_Transaction(string[] cadena)
        {
            MySqlConnection con = Open_Connection();
            MySqlTransaction transa = con.BeginTransaction();
            MySqlCommand cmd;

            try
            {
                for (int i = 0; i < cadena.Length; i++)
                {
                    if (cadena[i].Length > 0)
                    {
                        cmd = new MySqlCommand(cadena[i], con);
                        cmd.Transaction = transa;
                        cmd.ExecuteNonQuery();
                    }

                }
                transa.Commit();
                return true;
            }
            catch
            {
                transa.Rollback();
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public int Execute_Operation_Param(String Query, List<MySqlParameter> param)
        {
            if (Connect())
            {
                using (MyConnection)
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {

                        cmd.Connection = MyConnection;
                        cmd.CommandText = Query;
                        foreach (MySqlParameter x in param)
                        {
                            cmd.Parameters.Add(x);

                        }
                        int y = cmd.ExecuteNonQuery();
                        Disconnect();
                        return y;
                    }
                }

            }
            else
            {
                return -1;
            }

        }


        //Recorrer Esquemas
        public void GetSchemaInfo()
        {
            using (MyConnection)
            {
                MySqlCommand command = new MySqlCommand(
                  "select *from user ;",
                  MyConnection);
                MyConnection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                DataTable schemaTable = reader.GetSchemaTable();

                foreach (DataRow row in schemaTable.Rows)
                {

                    foreach (DataColumn column in schemaTable.Columns)
                    {

                        String datos = column.ColumnName.ToString() + "  " + row[column];
                        Console.WriteLine(String.Format("{0} = {1}",
                           column.ColumnName, row[column]));
                    }
                }
            }
        }
        //Recorrer Multiples tablas

        public void RetrieveMultipleResults(String sql)
        {
            using (MyConnection)
            {
                MySqlCommand command = new MySqlCommand(sql, MyConnection);
                if (Connect())
                {
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.HasRows)
                    {
                        String ver = reader.GetName(0) + "" + reader.GetName(1);


                        while (reader.Read())
                        {

                            byte[] dato = (byte[])reader.GetValue(1);

                            String columna = reader.GetInt32(0) + "" + reader.GetString(1);

                        }
                        reader.NextResult();


                        {

                        }


                    }
                }
                else
                {

                }
            }
        }
    }
}