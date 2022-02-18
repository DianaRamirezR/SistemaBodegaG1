using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace bodegaCPWSSOAP.Dominio
{
   [DataContract]
    public class Bodega
    {
        [DataMember]
        public string IdBodega { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public bool Activo { get; set; }
        [DataMember]
        public string Contacto { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public double Latitud { get; set; }
        [DataMember]
        public double Longitud { get; set; }
        [DataMember]
        public string IdUserB { get; set; }
    }
}