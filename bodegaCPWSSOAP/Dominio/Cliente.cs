using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace bodegaCPWSSOAP.Dominio
{
   [DataContract]
    public class Cliente
    {
        [DataMember]
        public string CodCliente { get; set; }
        [DataMember]
        public string NombreCliente { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Referencia { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public bool Activo { get; set; }
        [DataMember]
        public string IdUser { get; set; }
    }
}