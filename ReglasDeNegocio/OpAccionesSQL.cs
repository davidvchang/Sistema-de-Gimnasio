using System;
using System.Collections.Generic;
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

        public Boolean RegistrarClientes(String sNombre, String sApellidos, Int32 sEdad, String sTelefono, String sDireccion, DateTime sFechaInicio, 
                                        DateTime sFechaFinal, Int32 sMesesPagados)
        {
            Boolean bAllOk = true;

            using(SqlConnection conexion = new SqlConnection(opConexion.CadenaConexion()))
            {
                try
                {
                    conexion.Open();
                    string query = $"INSERT INTO Clientes (Nombre, Apellidos, Edad, Telefono, Direccion, FechaInicio, FechaFinal, MesesPagados) " +
                                    $"VALUES ('{sNombre}', '{sApellidos}', {sEdad}, '{sTelefono}', '{sDireccion}', '{sFechaInicio.ToString("dd-MM-yyyy")}', '{sFechaFinal.ToString("dd-MM-yyyy")}', {sMesesPagados})";
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
    }
}
