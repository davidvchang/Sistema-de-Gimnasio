using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class OpAccionesSQL
    {
        public string sLastError = "";


        public Boolean ExisteUsuario(string user, string password)
        {
            Boolean UsuarioExiste = false;

            using (SqlConnection conexion = new SqlConnection(opConexion.CadenaConexion()))
            {
                try
                {
                    conexion.Open();
                    string query = $"SELECT COUNT(*) FROM InicioSesion WHERE Usuario = '{user}' AND Contraseña = '{password}'";
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    int resultado = Convert.ToInt32(cmd.ExecuteScalar());

                    UsuarioExiste = (resultado > 0);
                }
                catch(Exception ex)
                {
                    sLastError = ex.Message;
                }
                finally
                {
                    conexion.Close();
                }
            }


            return UsuarioExiste;
        }

        public Boolean RegistrarClientes(Int32 sId, String sNombre, String sApellidos, Int32 sEdad, String sTelefono, String sDireccion, DateTime sFechaInicio, 
                                        DateTime sFechaFinal, Int32 sMesesPagados)
        {
            Boolean bAllOk = true;

            using(SqlConnection conexion = new SqlConnection(opConexion.CadenaConexion()))
            {
                try
                {
                    conexion.Open();
                    string query = $"INSERT INTO Clientes (Id, Nombre, Apellidos, Edad, Telefono, Direccion, FechaInicio, FechaFinal, MesesPagados) " +
                                    $"VALUES ({sId}, '{sNombre}', '{sApellidos}', {sEdad}, '{sTelefono}', '{sDireccion}', '{sFechaInicio.ToString("dd-MM-yyyy")}', '{sFechaFinal.ToString("dd-MM-yyyy")}', {sMesesPagados});";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                    bAllOk = false;
                }
                finally
                {
                    conexion.Close();
                }
            }

            return bAllOk;
        }

        public Boolean RegistrarLogins(String sUser, String sPassword)
        {
            Boolean bAllOk = true;

            using (SqlConnection conexion = new SqlConnection(opConexion.CadenaConexion()))
            {
                try
                {
                    conexion.Open();
                    string query = $"INSERT INTO InicioSesion (Usuario, Contraseña) VALUES ('{sUser}', '{sPassword}');";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                    bAllOk = false;
                }
                finally
                {
                    conexion.Close();
                }
            }

            return bAllOk;
        }

        public Boolean ActualizarClientes(Int32 sId, String sNombre, String sApellidos, Int32 sEdad, String sTelefono, String sDireccion, DateTime sFechaInicio,
                                        DateTime sFechaFinal, Int32 sMesesPagados)
        {
            Boolean bAllOk = true;

            using (SqlConnection conexion = new SqlConnection(opConexion.CadenaConexion()))
            {
                try
                {
                    conexion.Open();
                    string query = $"UPDATE Clientes SET Nombre = '{sNombre}', Apellidos = '{sApellidos}', Edad = {sEdad}, " +
                                    $"Telefono = '{sTelefono}', Direccion = '{sDireccion}', " +
                                    $"FechaInicio = '{sFechaInicio.ToString("dd-MM-yyyy")}', " +
                                    $"FechaFinal = '{sFechaFinal.ToString("dd-MM-yyyy")}', MesesPagados = {sMesesPagados} " +
                                    $"WHERE Id = {sId}";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                    bAllOk = false;
                }
                finally
                {
                    conexion.Close();
                }
            }

            return bAllOk;
        }

        public Boolean EliminarClientes(Int32 sId)
        {
            Boolean bAllOk = true;

            using (SqlConnection conexion = new SqlConnection(opConexion.CadenaConexion()))
            {
                try
                {
                    conexion.Open();
                    string query = $"DELETE FROM Clientes WHERE Id = {sId}";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                    bAllOk = false;
                }
                finally
                {
                    conexion.Close();
                }
            }

            return bAllOk;
        }

        public Boolean EliminarLogins(String sUser, String sPassword)
        {
            Boolean bAllOk = true;

            using (SqlConnection conexion = new SqlConnection(opConexion.CadenaConexion()))
            {
                try
                {
                    conexion.Open();
                    string query = $"DELETE FROM InicioSesion WHERE Usuario = '{sUser}' AND Contraseña = '{sPassword}'";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                    bAllOk = false;
                }
                finally
                {
                    conexion.Close();
                }
            }

            return bAllOk;
        }

        public DataTable MostrarRegistradosEnDGV()
        {
            DataTable dt = new DataTable();

            using(SqlConnection conexion = new SqlConnection(opConexion.CadenaConexion()))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT Id, Nombre, Apellidos, Edad, Telefono, Direccion, FechaInicio, FechaFinal, MesesPagados FROM Clientes ";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                }
                finally
                {
                    conexion.Close();
                }
            }
            return dt;
        }

        public DataTable MostrarRegistradosEstatusEnDGV()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conexion = new SqlConnection(opConexion.CadenaConexion()))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT * FROM Clientes ";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                }
                finally
                {
                    conexion.Close();
                }
            }
            return dt;
        }

        public DataTable MostrarLoginsEnDGV()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conexion = new SqlConnection(opConexion.CadenaConexion()))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT * FROM InicioSesion WHERE Usuario != 'admin' AND Contraseña != 'admin'";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                }
                finally
                {
                    conexion.Close();
                }
            }
            return dt;
        }

        public DataTable BuscarPorEstutus (string sStatus)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conexion = new SqlConnection(opConexion.CadenaConexion()))
            {
                try
                {
                    conexion.Open();
                    string query = $"SELECT * FROM Clientes Where Estatus = '{sStatus}'";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                }
                finally
                {
                    conexion.Close();
                }
            }
            return dt;
        }

        public DataTable BuscarPorNombre(string sNombre)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conexion = new SqlConnection(opConexion.CadenaConexion()))
            {
                try
                {
                    conexion.Open();
                    string query = $"SELECT * FROM Clientes Where Nombre LIKE '%{sNombre}%'";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                }
                finally
                {
                    conexion.Close();
                }
            }
            return dt;
        }

        public int ObtenerUltimoID()
        {
            int ultimoID = -1;

            using (SqlConnection conexion = new SqlConnection(opConexion.CadenaConexion()))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT COALESCE(MAX(id), 0) + 1 AS ultimo_id FROM Clientes;";
                    SqlCommand comando = new SqlCommand(query, conexion);

                    // Ejecutar la consulta y obtener el resultado
                    object resultado = comando.ExecuteScalar();

                    // Verificar si el resultado es válido y convertirlo a entero
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        ultimoID = Convert.ToInt32(resultado);
                    }
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                }
                finally
                {
                    conexion.Close();
                }
            }

            return ultimoID;
        }

    }
}
