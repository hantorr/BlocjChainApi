using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockChainFront.Models
{
    public class RegistroModel
    {
        public long Id { get; set; }
        public string NumeroDoc { get; set; }
        public string Nombre { get; set; }
        public string Cuenta { get; set; }
        public string CuentaBC { get; set; }
    }
}