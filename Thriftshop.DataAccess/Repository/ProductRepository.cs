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
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Thriftshop.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Id = obj.Id;
                objFromDb.Description = obj.Description;
                objFromDb.Gender = obj.Gender;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price = obj.Price;
                objFromDb.Price10 = obj.Price10;
                objFromDb.Price30 = obj.Price30;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.ItemConditionId = obj.ItemConditionId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
