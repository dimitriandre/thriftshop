using Microsoft.AspNetCore.Mvc;
using Thriftshop.DataAccess.Repository.IRepository;
using Thriftshop.DataAccess;
using ThriftshopWeb.Models;
using Thriftshop.Models;

namespace ThriftshopWeb.Controllers
{
    public class ItemConditionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemConditionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            IEnumerable<Thriftshop.Models.ItemCondition> objItemConditionList = _unitOfWork.ItemCondition.GetAll();
            return View(objItemConditionList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Thriftshop.Models.ItemCondition obj)
        {
                
            if (ModelState.IsValid)
            {
                _unitOfWork.ItemCondition.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var coverTypeFromDb = _unitOfWork.ItemCondition.GetFirstOrDefault(u=>u.Id==id);

            if (coverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Thriftshop.Models.ItemCondition obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.ItemCondition.Update(obj);
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


            var covertypeFromDb = _unitOfWork.ItemCondition.GetFirstOrDefault(u => u.Id == id);

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
            var obj = _unitOfWork.ItemCondition.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }


            _unitOfWork.ItemCondition.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Cover Type deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
