using Thriftshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thriftshop.DataAccess.Repository.IRepository
{
	public interface IItemConditionRepository : IRepository<ItemCondition>
	{
		public void Update(ItemCondition obj);
	}
}
