using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Acquisti.Core
{
    public class Ordine
    {
        public int ID { get; set; }
        public DateTime DataOrdine { get; set; }
        public string CodiceOrdine { get; set; }
        public string CodiceProdotto { get; set; }
        public double Importo { get; set; }
        public Cliente Cliente { get; set; }
    }
}
