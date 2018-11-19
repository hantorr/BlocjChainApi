using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockChainFront.Models
{
    public class RegistroModel
    {
        public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cuenta { get; set; }
        public string Direccion { get; set; }
        public long IdTransaccion { get; set; }
    }
}