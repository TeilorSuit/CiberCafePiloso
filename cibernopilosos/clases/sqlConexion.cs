using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;
using System.Drawing;

namespace cibernopilosos
{
    internal class sqlConexion
    {
        public SqlConnection ConexionSql;
        public SqlCommand ComandoSql;
        public SqlDataAdapter DataAdapterSql;
        public DataTable DataTableSql;
        public SqlDataReader DataReader;

        string Server;
        string Database;
        string Usuario;
        string Clave;
        string Cadena;

        public sqlConexion()
        {
            Server = "TEILOR\\SQLEXPRESS";
            Database = "CiberCafeDB";
            Usuario = "teilor";
            Clave = "teilor";
        }
        public bool abrirConexion()
        {
            ConexionSql = new SqlConnection();
            try
            {
                Cadena = "Server=" + Server + "; Database=" + Database + "; User id=" + Usuario.Trim() + "; Password=" + Clave;
                ConexionSql.ConnectionString = Cadena;
                ConexionSql.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CONECTAR: "+ex.Message);
                return false;
            }
            return true;
        }
        public bool cerrarConexion()
        {
            ConexionSql.Close();
            return true;
        }

        public bool Login(string username, string password)
        {
            string consulta = $"Select Username,PassWord from Users Where Username='{username}'";
            DataTable dt = retornaRegistros(consulta);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (username == dt.Rows[i][0].ToString()&&password == dt.Rows[i][1].ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public DataTable retornaRegistros(string Sentencia)
        {
            if (Sentencia.Length > 0)
            {
                try
                {
                    abrirConexion();
                    ComandoSql = new SqlCommand(Sentencia, ConexionSql);
                    DataAdapterSql = new SqlDataAdapter(ComandoSql);
                    DataTableSql = new DataTable();
                    DataAdapterSql.Fill(DataTableSql);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cerrarConexion();
            }
            return DataTableSql;
        }

        public bool EjecutarAccion(string Sentencia)
        {
            try
            {
                abrirConexion();
                ComandoSql = new SqlCommand(Sentencia, ConexionSql);
                ComandoSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cerrarConexion();
                return false;
            }
            cerrarConexion();
            return true;
        }

        public int DevuelveValorEntero(string consulta)//sin usar
        {
            int aux = 0;
            try
            {
                abrirConexion();
                ComandoSql = new SqlCommand(consulta, ConexionSql);
                DataReader = ComandoSql.ExecuteReader();
                if (DataReader.Read())
                {
                    if (DataReader[0] != DBNull.Value)
                    {
                        aux = (int)DataReader[0];
                    }
                }
                DataReader.Close();
                cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo anda mal. " + ex.Message);
                cerrarConexion();
            }
            return aux;
        }

        //completar mas funciones

        public bool DevuelveValorBooleano(string consulta)
        {
            bool aux = false;
            try
            {
                abrirConexion();
                ComandoSql = new SqlCommand(consulta, ConexionSql);
                DataReader = ComandoSql.ExecuteReader();
                if (DataReader.Read())
                {
                    if (DataReader[0] != DBNull.Value)
                    {
                        aux = (bool)DataReader[0];
                    }
                }
                DataReader.Close();
                cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo anda mal. " + ex.Message);
                cerrarConexion();
            }
            return aux;
        }

        public string DevuelveString(string consulta)//pal admin
        {
            string aux = "";
            try
            {
                abrirConexion();
                ComandoSql = new SqlCommand(consulta, ConexionSql);
                DataReader = ComandoSql.ExecuteReader();
                if (DataReader.Read())
                {
                    if (DataReader[0] != DBNull.Value)
                    {
                        aux = (string)DataReader[0];
                    }
                }
                DataReader.Close();
                cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo anda mal. " + ex.Message);
                cerrarConexion();
            }
            return aux;
        }
    }
}
