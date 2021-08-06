using Acquisti.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acquisti.CoreEF
{
    public class RepositoryCliente : IRepositoryCliente
    {
        private readonly AcquistiContext ctx;

        public RepositoryCliente() : this(new AcquistiContext()) { }

        public RepositoryCliente(AcquistiContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Cliente item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Clienti.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Cliente item)
        {
            if (item == null)
                return false;

            try
            {
                var c = ctx.Clienti.Find(item.ID);

                if (c != null)
                    ctx.Clienti.Remove(c);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cliente> Fetch()
        {
            try
            {
                return ctx.Clienti.Include(b => b.Ordini).ToList();
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
        }

        public Cliente GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Clienti.Find(id);
        }

        public bool Update(Cliente item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Clienti.Update(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
