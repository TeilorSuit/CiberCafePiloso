﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cibernopilosos
{
    internal class sqlConexion
    {
        private SqlConnection ConexionSql;
        private SqlCommand ComandoSql;
        private SqlDataAdapter DataAdapterSql;
        private DataTable DataTableSql;
        private SqlDataReader DataReader;

        public string Server;
        public string Database;
        public string Usuario;
        public string Clave;


        public sqlConexion()
        {
            Server = "(local)";
            Database = "CiberCafeDB";
            Usuario = "teilor";
            Clave = "teilor";
        }

        public string Cadena
        {
            get
            {
                return $"Server={Server};Database={Database};User id={Usuario.Trim()};Password={Clave}";
            }
        }

        public bool abrirConexion()
        {
            try
            {
                if (ConexionSql == null)
                {
                    ConexionSql = new SqlConnection(Cadena);
                }
                else
                {
                    ConexionSql.ConnectionString = Cadena;
                }

                if (ConexionSql.State != ConnectionState.Open)
                {
                    ConexionSql.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CONECTAR: " + ex.Message);
                return false;
            }
            return true;
        }

        public bool cerrarConexion()
        {
            if (ConexionSql != null && ConexionSql.State == ConnectionState.Open)
            {
                ConexionSql.Close();
            }
            return true;
        }

        public bool Login(string username, string password)
        {
            string consulta = $"SELECT Username, Password FROM Users WHERE Username='{username}'";
            DataTable dt = retornaRegistros(consulta);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string user = dt.Rows[i]["Username"].ToString();
                string pass = dt.Rows[i]["Password"].ToString();
                if (username == user && password == pass)
                {
                    return true;
                }
            }
            return false;
        }

       
        public bool EjecutarAccion(string sentencia)
        {
            try
            {
                if (abrirConexion())
                {
                    ComandoSql = new SqlCommand(sentencia, ConexionSql);
                    ComandoSql.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en EjecutarAccion: " + ex.Message);
                cerrarConexion();
                return false;
            }
            finally
            {
                cerrarConexion();
            }
            return true;
        }

        #region Rescatar Valores
        public DataTable retornaRegistros(string sentencia)
        {
            DataTable dtResultado = new DataTable();
            if (sentencia.Length > 0)
            {
                try
                {
                    if (abrirConexion())
                    {
                        ComandoSql = new SqlCommand(sentencia, ConexionSql);
                        DataAdapterSql = new SqlDataAdapter(ComandoSql);
                        DataTableSql = new DataTable();
                        DataAdapterSql.Fill(DataTableSql);

                        dtResultado = DataTableSql;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en retornaRegistros: " + ex.Message);
                }
                finally
                {
                    cerrarConexion();
                }
            }
            return dtResultado;
        }

        public int DevuelveValorEntero(string consulta)
        {
            int aux = 0;
            try
            {
                if (abrirConexion())
                {
                    ComandoSql = new SqlCommand(consulta, ConexionSql);
                    DataReader = ComandoSql.ExecuteReader();
                    if (DataReader.Read())
                    {
                        if (DataReader[0] != DBNull.Value)
                        {
                            aux = Convert.ToInt32(DataReader[0]);
                        }
                    }
                    DataReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo anda mal (DevuelveValorEntero): " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
            return aux;
        }

        public decimal DevuelveValorDecimal(string consulta)
        {
            decimal aux = 0;
            try
            {
                if (abrirConexion())
                {
                    ComandoSql = new SqlCommand(consulta, ConexionSql);
                    DataReader = ComandoSql.ExecuteReader();
                    if (DataReader.Read())
                    {
                        if (DataReader[0] != DBNull.Value)
                        {
                            aux = Convert.ToDecimal(DataReader[0]);
                        }
                    }
                    DataReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo anda mal (DevuelveValorDecimal): " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
            return aux;
        }

        public bool DevuelveValorBooleano(string consulta)
        {
            bool aux = false;
            try
            {
                if (abrirConexion())
                {
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo anda mal (DevuelveValorBooleano): " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
            return aux;
        }

        public string DevuelveString(string consulta)
        {
            string aux = "";
            try
            {
                if (abrirConexion())
                {
                    ComandoSql = new SqlCommand(consulta, ConexionSql);
                    DataReader = ComandoSql.ExecuteReader();
                    if (DataReader.Read())
                    {
                        if (DataReader[0] != DBNull.Value)
                        {
                            aux = DataReader[0].ToString();
                        }
                    }
                    DataReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo anda mal (DevuelveString): " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
            return aux;
        }
        #endregion
    }
}
