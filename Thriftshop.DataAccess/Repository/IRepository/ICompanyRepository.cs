using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Thriftshop.Models;

namespace Thriftshop.DataAccess.Repository.IRepository
{
    public class ICompanyRepository : IRepository<Company>
    {
        public void Add(Company entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAll(string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Company GetFirstOrDefault(Expression<Func<Company, bool>> filter, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Company entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Company> entity)
        {
            throw new NotImplementedException();
        }
    }
}
