using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuslimBlog.Controllers
{
	[AllowAnonymous]
	public class MailSubscribeController : Controller
    {       
        SubscribeMailManager sm = new SubscribeMailManager(new EFMailDal());

		[AllowAnonymous]
		[HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
		[AllowAnonymous]
		[HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {
            sm.TAdd(p);
            return PartialView();
        }
    }
}