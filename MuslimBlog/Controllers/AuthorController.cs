using BusinessLayer.Concrete;
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

    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogmanager = new BlogManager(new EFBlogDal());
        AuthorManager authormanager = new AuthorManager(new EFAuthorDal());

		[AllowAnonymous]
		public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = blogmanager.GetBlogByID(id);
            return PartialView(authordetail);
        }
		[AllowAnonymous]
		public PartialViewResult  AuthorPopularPost(int id)
        {
            var blogauthorid = blogmanager.GetList().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
            
            var authorblogs = blogmanager.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblogs);
        }
		[AllowAnonymous]
		public ActionResult AuthorList()
        {
             var authorlist=authormanager.GetList();
            return View(authorlist);
        }
		[AllowAnonymous]
		[HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
		[AllowAnonymous]
		[HttpPost]
		public ActionResult AddAuthor(Author p)
		{
			AuthorValidator authorValidator = new AuthorValidator();
			ValidationResult results = authorValidator.Validate(p);
			if (results.IsValid)
			{
				authormanager.TAdd(p);
				return RedirectToAction("AuthorList");
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
		[AllowAnonymous]
		[HttpGet]
		public ActionResult AuthorEdit(int id)
        {
            Author author = authormanager.GetByID(id);
            return View(author);
        }
		[AllowAnonymous]
		[HttpPost]
		public ActionResult AuthorEdit(Author p)
		{
			AuthorValidator authorValidator = new AuthorValidator();
			ValidationResult results = authorValidator.Validate(p);
			if (results.IsValid)
			{
				authormanager.TUpdate(p);
				return RedirectToAction("AuthorList");
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

	}
}