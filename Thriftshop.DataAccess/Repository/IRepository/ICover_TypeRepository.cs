using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thriftshop.Models;

namespace Thriftshop.DataAccess.Repository.IRepository
{
    public interface ICover_TypeRepository : IRepository<Cover_Type>
    {
        public void Update(Cover_Type obj);
    }
}
