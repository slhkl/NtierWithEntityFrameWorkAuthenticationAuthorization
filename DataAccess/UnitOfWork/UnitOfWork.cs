using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
        }
        public void Dispose()
        {

        }
        private DbContext _context { get; set; }
        public DbContext Context
        {
            get
            {
                if (_context == null)
                    _context = new MasterContext();
                return _context;
            }
        }
        public Repository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(Context);
        }

            public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
