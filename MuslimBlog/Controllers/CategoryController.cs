using BusinessLayer.Concrete;
using BusinessLayer.Concreterepo;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuslimBlog.Controllers
{
    public class CategoryController : Controller
    {
		// GET: Category
		CategoryManager cm = new CategoryManager(new EFCategoryDal());
       
		[AllowAnonymous]
		public PartialViewResult BlogDetailsCategoryList()
        {
            return PartialView();
        }
        public ActionResult AdminCategoryList()
        {
            var categorylist = cm.GetList();
            return View(categorylist);
        }
		[HttpGet]
		public ActionResult AdminCategoryAdd()
		{

			return View();
		}
		[HttpPost]
		public ActionResult AdminCategoryAdd(Category p)
		{
			CategoryValidator categoryValidator = new CategoryValidator();
			ValidationResult results = categoryValidator.Validate(p);
			if (results.IsValid)
			{
              cm.TAdd(p);
			return RedirectToAction("AdminCategoryList");
			}
			else
			{
				foreach(var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
				}
			}
			return View();

			
		}
		[AllowAnonymous]
		[HttpGet]
		public ActionResult CategoryEdit(int id)
		{
			Category category = cm.GetByID(id);
			return View(category);
		}
		[AllowAnonymous]
		[HttpPost]
		public ActionResult CategoryEdit(Category p)
		{
			CategoryValidator categoryValidator = new CategoryValidator();
			ValidationResult results = categoryValidator.Validate(p);
			if (results.IsValid)
			{
				cm.TUpdate(p);
				return RedirectToAction("AdminCategoryList");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
		public ActionResult CategoryDelete(int id)
		{
			cm.DeleteCategoryBL(id);
			return RedirectToAction("AdminCategoryList");
		}
		public ActionResult CategoryStatusTrue(int id)
		{
			cm.CategoryStatusTrueBL(id);
			return RedirectToAction("AdminCategoryList");
		}

	}
}