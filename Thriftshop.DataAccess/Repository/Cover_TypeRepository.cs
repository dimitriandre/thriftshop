using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Thriftshop.DataAccess.Repository.IRepository;
using Thriftshop.Models;
using ThriftshopWeb.DataAccess;
using ThriftshopWeb.Models;

namespace Thriftshop.DataAccess.Repository
{
    public class Cover_TypeRepository : Repository<Cover_Type>, ICover_TypeRepository
    {
        private ApplicationDbContext _db;

        public Cover_TypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Cover_Type obj)
        {
            _db.Cover_Types.Update(obj);
        }
    }
}
