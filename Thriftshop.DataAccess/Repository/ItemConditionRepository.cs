using Thriftshop.DataAccess.Repository.IRepository;
using Thriftshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thriftshop.DataAccess.Repository
{
    public class ItemConditionRepository : Repository<ItemCondition>, IItemConditionRepository
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
