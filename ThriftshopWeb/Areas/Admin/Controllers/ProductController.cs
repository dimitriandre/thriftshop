using Microsoft.AspNetCore.Mvc;
using Thriftshop.DataAccess.Repository.IRepository;
using Thriftshop.DataAccess;
using ThriftshopWeb.Models;
using Thriftshop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ThriftshopWeb.Controllers
{
    public class ProductController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            IEnumerable<Thriftshop.Models.Product> objProductList = _unitOfWork.Product.GetAll();
            return View(objProductList);
        }


        //GET
        public IActionResult Upsert(int? id)
        {
            Product product = new();
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
                u=> new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            IEnumerable<SelectListItem> ItemConditionList = _unitOfWork.ItemCondition.GetAll().Select(
                u=> new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            if (id == null || id == 0)
            {
                //create product
                ViewBag.CategoryList = CategoryList;
                ViewData["ItemCondition"] = ItemConditionList;
                return View(product);
            }
            else
            {
                //update product

            }

            return View(product);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }


            var covertypeFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);

            if (covertypeFromDb == null)
            {
                return NotFound();
            }
            TempData["success"] = "Cover Type updated successfully";
            return View(covertypeFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }


            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Cover Type deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
