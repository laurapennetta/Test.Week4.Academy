using Acquisti.Core;
using System.Collections.Generic;
using System.ServiceModel;

namespace Acquisti.Wcf
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di interfaccia "IService1" nel codice e nel file di configurazione contemporaneamente.
    [ServiceContract]
    public interface IAcquistiService
    {
        [OperationContract]
        IEnumerable<Cliente> FetchClienti();

        [OperationContract]
        Cliente FetchClienteById(int id);

        [OperationContract]
        bool CreateCliente(Cliente newCliente);

        [OperationContract]
        bool EditCliente(Cliente editedCliente);

        [OperationContract]
        bool DeleteClienteById(int idCliente);
    }
}
