using Microsoft.AspNetCore.Mvc;
using Thriftshop.DataAccess.Repository.IRepository;
using Thriftshop.DataAccess;
using ThriftshopWeb.Models;
using Thriftshop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Thriftshop.Models.ViewModels;

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
            ProductVM productVM = new()
            {
                Product = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                ItemConditionList = _unitOfWork.ItemCondition.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };



            if (id == null || id == 0)
            {
                //create product
                //ViewBag.CategoryList = CategoryList;
                //ViewData["ItemCondition"] = ItemConditionList;
                return View(productVM);
            }
            else
            {
                //update product

            }

            return View(productVM);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM obj, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                //_unitOfWork.Product.Update(obj);
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
