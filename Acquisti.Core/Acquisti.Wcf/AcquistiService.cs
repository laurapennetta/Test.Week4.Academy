using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Acquisti.Wcf
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "Service1" nel codice e nel file di configurazione contemporaneamente.
    public class AcquistiService : IAcquistiService
    {
        IAcquistiBL acquistiBL;

        public bool CreateCliente(Cliente newCliente)
        {
            if (newCliente == null)
                return false;

            return this.acquistiBL.CreateCliente(newCliente);
        }

        public bool DeleteClienteById(int idCliente)
        {
            if (idCliente > 0)
                return this.acquistiBL.DeleteClienteById(idCliente);

            return false;
        }

        public bool EditCliente(Cliente editedCliente)
        {
            if (editedCliente == null)
                return false;

            return this.acquistiBL.EditBook(editedCliente);
        }

        public Cliente FetchClienteById(int id)
        {
            if (id > 0)
                return this.acquistiBL.FetchClienteById(id);

            return false;
        }

        public IEnumerable<Cliente> FetchClienti()
        {
            return this.acquistiBL.FetchClienti();
        }
    }
}
