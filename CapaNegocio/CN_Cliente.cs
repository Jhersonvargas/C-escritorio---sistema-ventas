using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cliente
    {

        private CD_Cliente objcd_Cliente = new CD_Cliente();


        public List<Cliente> Listar()
        {
            return objcd_Cliente.Listar();
        }

        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del Cliente\n";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del Cliente\n";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del Cliente\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Cliente.Registrar(obj, out Mensaje);
            }


        }


        public bool Editar(Cliente obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del Cliente\n";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del Cliente\n";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del Cliente\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Cliente.Editar(obj, out Mensaje);
            }


        }


        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            return objcd_Cliente.Eliminar(obj, out Mensaje);
        }
        //-------------------------------------------------------------------------------


        public static SqlDataAdapter da;
        public static DataSet ds;

        public static void ConsultarClientes(Cliente cliente)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = conexion;
                da.SelectCommand.CommandText = "VConsultar_Cliente";
                da.SelectCommand.Parameters.AddWithValue("@filtro", cliente.NombreCompleto);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                ds = new DataSet();
                da.Fill(ds, "CargarClientes");
                conexion.Close();
            }
        }


        //-------------------------------------------------------------------------------

        //----------------------------------------------------------------------------------
    }
}
