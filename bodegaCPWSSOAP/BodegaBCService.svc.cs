using bodegaCPWSSOAP.Dominio;
using bodegaCPWSSOAP.Errores;
using bodegaCPWSSOAP.Persitencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bodegaCPWSSOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BodegaBCService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BodegaBCService.svc or BodegaBCService.svc.cs at the Solution Explorer and start debugging.
    public class BodegaBCService : IBodegaBCService
    {
        private ClienteDAO clienteDAO = new ClienteDAO();

        private BodegaDAO bodegaDAO = new BodegaDAO();

                public Cliente CrearCliente(Cliente clienteACrear)
        {
            if (clienteDAO.ObtenerCliente(clienteACrear.CodCliente) != null)  //Ya existe
            {
                throw new FaultException<ErroresException>(
                    new ErroresException()
                    {
                        Codigo = "101",
                        Descripcion = "El codigo de Cliente YA EXISTE!"
                    },
                    new FaultReason("Error al intentar crear cliente"));
            }
            return clienteDAO.CrearCliente(clienteACrear);
        }

        public List<Bodega> ListarBodegas()
        {
            return bodegaDAO.ListarBodega();
        }

        public Cliente Modificarcliente(Cliente clienteAModificar)
        {
            return clienteDAO.Modificarcliente(clienteAModificar);
        }

        public Bodega ObtenerBodega(string idBodega)
        {
            return bodegaDAO.ObtenerBodega(idBodega);
        }

        public Cliente ObtenerCliente(string codCliente)
        {
            return clienteDAO.ObtenerCliente(codCliente);
        }
    }

}
