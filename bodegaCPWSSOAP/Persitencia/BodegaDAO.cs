using bodegaCPWSSOAP.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace bodegaCPWSSOAP.Persitencia
{
    public class BodegaDAO
    {
        private string CadenaConexion = "Data Source = upc-dsd-class.database.windows.net;initial catalog=Bodegas;persist security info=True;user id=u20171d221;password=Jose++301090;MultipleActiveResultSets=True;";

        public Bodega ObtenerBodega(string CodigoB)
        {
            Bodega bodegaEncontrado = null;
            string sql = "SELECT * FROM Bodega WHERE idbodega = @idbodega";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idbodega", CodigoB));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            bodegaEncontrado = new Bodega()
                            {

                                IdBodega = (string)resultado["idbodega"],
                                Nombre = (string)resultado["nombre"],
                                Direccion = (string)resultado["direccion"],
                                Contacto = (string)resultado["contacto"],
                                Telefono = (string)resultado["telefono"],
                                Latitud = (double)resultado["latitud"],
                                Longitud = (double)resultado["longitud"],
                                Activo = (bool)resultado["activo"],
                            };
                        }
                    }
                }
                return bodegaEncontrado;
            }

        }
        public List<Bodega> ListarBodega()
        {
            List<Bodega> bodegaEncontrados = new List<Bodega>();
            Bodega bodegaEncontrado;
            string sql = "SELECT * FROM Bodega";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            bodegaEncontrado = new Bodega()
                            {

                                IdBodega = (string)resultado["idbodega"],
                                Nombre = (string)resultado["nombre"],
                                Direccion = (string)resultado["direccion"],
                                Contacto = (string)resultado["contacto"],
                                Telefono = (string)resultado["telefono"],
                            };
                            bodegaEncontrados.Add(bodegaEncontrado);
                        }
                    }
                }
            }
            return bodegaEncontrados;
        }

    }
}