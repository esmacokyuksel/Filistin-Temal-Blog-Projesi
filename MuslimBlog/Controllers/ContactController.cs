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
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EFContactDal());
		[AllowAnonymous]
		public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
		[AllowAnonymous]
		public ActionResult SendMassage()
        {
			return View();
		}
		[HttpPost]
		public ActionResult SendMassage(Contact p)
		{
			ContactValidator contactValidator = new ContactValidator();
			ValidationResult results = contactValidator.Validate(p);
			if (results.IsValid)
			{
				p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
				cm.TAdd(p);
				return RedirectToAction("Index","Blog");
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
        public ActionResult SendBox()
        {
            var messagelist = cm.GetList();
            return View(messagelist);
        }
		public ActionResult MassageDetails(int id)
		{
            Contact contact = cm.GetByID(id);
			return View(contact);
		}
	}
}