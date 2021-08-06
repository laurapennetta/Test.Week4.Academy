using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acquisti.Core
{
    public class AcquistiBL : IAcquistiBL
    {
        private readonly IRepositoryCliente clienteRepo;
        private readonly IRepositoryOrdine ordineRepo;

        //public AcquistiBL()
        //{
        //    this.clienteRepo = DependencyContainer.Resolve<IRepositoryCliente>();
        //    this.ordineRepo = DependencyContainer.Resolve<IRepositoryOrdine>();
        //}

        public AcquistiBL(IRepositoryCliente clienteR, IRepositoryOrdine ordineR)
        {
            this.clienteRepo = clienteR;
            this.ordineRepo = ordineR;
        }

        #region Cliente
        public bool CreateCliente(Cliente newCliente)
        {
            if (newCliente == null)
                return false;

            return clienteRepo.Add(newCliente);
        }
        public bool EditCliente(Cliente editedCliente)
        {
            if (editedCliente == null)
                return false;

            return clienteRepo.Update(editedCliente);
        }

        public IEnumerable<Cliente> FetchClienti(Func<Cliente, bool> filter = null)
        {
            if (filter != null)
                return clienteRepo.Fetch().Where(filter);

            return clienteRepo.Fetch();
        }

        public Cliente FetchClienteById(int id)
        {
            if (id <= 0)
                return null;

            return clienteRepo.GetById(id);
        }

        public bool DeleteClienteById(int idCliente)
        {
            if (idCliente <= 0)
                return false;

            Cliente clienteToBeDeleted = this.clienteRepo.GetById(idCliente);

            if (clienteToBeDeleted != null)
                return clienteRepo.Delete(clienteToBeDeleted);

            return false;
        }
        #endregion

        #region Ordine
        public IEnumerable<Ordine> FetchOrdini(Func<Ordine, bool> filter = null)
        {
            if (filter != null)
                return ordineRepo.Fetch().Where(filter);

            return ordineRepo.Fetch();
        }

        public Ordine FetchOrdineById(int id)
        {
            if (id <= 0)
                return null;

            return ordineRepo.GetById(id);
        }

        public bool CreateOrdine(Ordine newOrdine)
        {
            if (newOrdine == null)
                return false;

            return ordineRepo.Add(newOrdine);
        }

        public bool EditOrdine(Ordine editedOrdine)
        {
            if (editedOrdine == null)
                return false;

            return ordineRepo.Update(editedOrdine);
        }

        public bool DeleteOrdineById(int idOrdine)
        {
            if (idOrdine <= 0)
                return false;

            Ordine loanBeDeleted = this.ordineRepo.GetById(idOrdine);

            if (loanBeDeleted != null)
                return ordineRepo.Delete(loanBeDeleted);

            return false;
        }
        #endregion
    }
}
