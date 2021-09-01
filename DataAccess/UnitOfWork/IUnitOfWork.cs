using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}
