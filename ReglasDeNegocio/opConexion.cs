using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReglasDeNegocio;

namespace ReglasDeNegocio
{
    public class opConexion
    {



        //public String sLastError = "";
        static string sError = "";


        //public Boolean AbrirConexion(string sUser, string sPassword)
        //{
        //    string CadenaConexion = $"server=localhost ; database=Gimnasio ; User Id = {sUser}; Password = {sPassword}; integrated security = true";

        //    SqlConnection conexion = new SqlConnection(CadenaConexion);
        //    Boolean bAllOk = true;

        //    try
        //    {
        //        conexion.Open();
        //    }
        //    catch (Exception ex)
        //    {
        //        sLastError = ex.Message;
        //        bAllOk = false;
        //    }
        //    finally
        //    {
        //        conexion.Close();
        //    }

        //    return bAllOk;
        //}


        public static string CadenaConexion()
        {
            string CadenaConexion = $"Server=localhost ; Database= Gimnasio ; Integrated Security=True;";
            SqlConnection conexion = new SqlConnection(CadenaConexion);

            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            finally
            {
                conexion.Close();
            }

            return CadenaConexion;
        }

    }
}
