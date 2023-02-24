using Thriftshop.DataAccess;
using Thriftshop.DataAccess.Repository.IRepository;
using Thriftshop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Thriftshop.Utility;

namespace ThriftshopWeb.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
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
				var ItemConditionFromDb = _unitOfWork.ItemCondition.GetFirstOrDefault(u => u.Id == id);

				if (ItemConditionFromDb == null)
				{
					return NotFound();
				}
				return View(ItemConditionFromDb);
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


				var ItemConditionFromDb = _unitOfWork.ItemCondition.GetFirstOrDefault(u => u.Id == id);

				if (ItemConditionFromDb == null)
				{
					return NotFound();
				}
				TempData["success"] = "Cover Type updated successfully";
				return View(ItemConditionFromDb);
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
