using Acquisti.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acquisti.CoreEF
{
    public class RepositoryOrdine : IRepositoryOrdine
    {
        private readonly AcquistiContext ctx;

        public RepositoryOrdine() : this(new AcquistiContext()) { }

        public RepositoryOrdine(AcquistiContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Ordine item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Ordini.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Ordine item)
        {
            if (item == null)
                return false;

            try
            {
                var book = ctx.Ordini.Find(item.ID);

                if (book != null)
                    ctx.Ordini.Remove(book);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Ordine> Fetch()
        {
            try
            {
                return ctx.Ordini.ToList();
            }
            catch (Exception)
            {
                return new List<Ordine>();
            }
        }

        public Ordine GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Ordini.Find(id);
        }

        public bool Update(Ordine item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Ordini.Update(item);
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
