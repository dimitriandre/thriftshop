using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Thriftshop.DataAccess.Repository.IRepository;
using Thriftshop.Models;
using Thriftshop.DataAccess;
using ThriftshopWeb.Models;

namespace Thriftshop.DataAccess.Repository
{
    public class ItemConditionRepository : Repository<Models.ItemCondition>, IItemConditionRepository
    {
        private ApplicationDbContext _db;

        public ItemConditionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Models.ItemCondition obj)
        {
            _db.ItemConditions.Update(obj);
        }
    }
}
