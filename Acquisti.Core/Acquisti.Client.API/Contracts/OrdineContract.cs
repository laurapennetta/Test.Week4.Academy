using System;
using System.Collections.Generic;
using System.Text;

namespace Acquisti.Client.API
{
    public class OrdineContract
    {
        public int ID { get; set; }
        public DateTime DataOrdine { get; set; }
        public string CodiceOrdine { get; set; }
        public string CodiceProdotto { get; set; }
        public double Importo { get; set; }
    }
}
