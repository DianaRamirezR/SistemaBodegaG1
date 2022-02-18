using bodegaCPWSSOAP.Dominio;
using bodegaCPWSSOAP.Errores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace bodegaCPWSSOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBodegaBCService" in both code and config file together.
    [ServiceContract]
    public interface IBodegaBCService
    {
        [FaultContract(typeof(ErroresException))]

        [OperationContract]
        Cliente CrearCliente(Cliente clienteACrear);

        [OperationContract]
        Cliente ObtenerCliente(string codCliente);

        [OperationContract]
        Cliente Modificarcliente(Cliente clienteAModificar);

        [OperationContract]
        Bodega ObtenerBodega(string idBodega);

        [OperationContract]
        List<Bodega> ListarBodegas();
    }
}
