using bodegaCPWSSOAP.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace bodegaCPWSSOAP.Persitencia
{
    public class ClienteDAO
    {
        private string CadenaConexion = "Data Source = upc-dsd-class.database.windows.net;initial catalog=Bodegas;persist security info=True;user id=u20171d221;password=Jose++301090;MultipleActiveResultSets=True;";

        public Cliente CrearCliente(Cliente clienteACrear)
        {
            Cliente clienteCreado;
            string sql = "INSERT INTO cliente VALUES (@codCliente, @nombreCliente, @direccion, @referencia, @telefono, @email, @activo,@id)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codCliente", clienteACrear.CodCliente));
                    comando.Parameters.Add(new SqlParameter("@nombreCliente", clienteACrear.NombreCliente));
                    comando.Parameters.Add(new SqlParameter("@direccion", clienteACrear.Direccion));
                    comando.Parameters.Add(new SqlParameter("@referencia", clienteACrear.Referencia));
                    comando.Parameters.Add(new SqlParameter("@telefono", clienteACrear.Telefono));
                    comando.Parameters.Add(new SqlParameter("@email", clienteACrear.Email));
                    comando.Parameters.Add(new SqlParameter("@activo", clienteACrear.Activo));
                    comando.Parameters.Add(new SqlParameter("@id", clienteACrear.IdUser));
                    comando.ExecuteNonQuery();
                }
                clienteCreado = ObtenerCliente(clienteACrear.CodCliente);
                return clienteCreado;
            }
        }


        public Cliente ObtenerCliente(string codigoCliente)
        {
            Cliente clienteEncontrado = null;
            string sql = "SELECT * FROM cliente WHERE codCliente = @codCliente";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codCliente", codigoCliente));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            clienteEncontrado = new Cliente()
                            {
                                CodCliente = (string)resultado["codCliente"],
                                NombreCliente = (string)resultado["nombreCliente"],
                                Direccion = (string)resultado["direccion"],
                                Referencia = (string)resultado["referencia"],
                                Telefono = (string)resultado["telefono"],
                                Email = (string)resultado["email"],
                                Activo = (bool)resultado["activo"],
                                IdUser = (string)resultado["id"],
                            };
                        }
                    }
                }
                return clienteEncontrado;
            }

        }

        public Cliente Modificarcliente(Cliente clienteAModificar)
        {
            Cliente clienteModificado;
            string sql = " UPDATE cliente SET direccion=@direccion, referencia=@referencia," +
                         "  telefono = @telefono WHERE codCliente = @codCliente";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codCliente", clienteAModificar.CodCliente));
                    comando.Parameters.Add(new SqlParameter("@direccion", clienteAModificar.Direccion));
                    comando.Parameters.Add(new SqlParameter("@referencia", clienteAModificar.Referencia));
                    comando.Parameters.Add(new SqlParameter("@telefono", clienteAModificar.Telefono));
                    comando.ExecuteNonQuery();
                }
                clienteModificado = ObtenerCliente(clienteAModificar.CodCliente);
                return clienteModificado;
            }
        }

    }
}