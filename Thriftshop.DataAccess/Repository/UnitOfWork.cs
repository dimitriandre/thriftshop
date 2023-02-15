using Thriftshop.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriftshopWeb.DataAccess;

namespace Thriftshop.DataAccess.Repository.IRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Cover_Type = new Cover_TypeRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }

        public ICover_TypeRepository Cover_Type { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
