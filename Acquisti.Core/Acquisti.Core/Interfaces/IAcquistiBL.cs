﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Acquisti.Core
{
    public interface IAcquistiBL
    {
        #region Cliente
        IEnumerable<Cliente> FetchClienti(Func<Cliente, bool> filter = null);
        Cliente FetchClienteById(int id);
        bool CreateCliente(Cliente newCliente);
        bool EditCliente(Cliente editedCliente);
        bool DeleteClienteById(int idCliente);
        #endregion

        #region Ordine
        IEnumerable<Ordine> FetchOrdini(Func<Ordine, bool> filter = null);
        Ordine FetchOrdineById(int id);
        bool CreateOrdine(Ordine newOrdine);
        bool EditOrdine(Ordine editedOrdine);
        bool DeleteOrdineById(int idOrdine);
        #endregion
    }
}
