using Antlr.Runtime;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MuslimBlog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager(new EFBlogDal());
		CommentManager cm = new CommentManager(new EFCommentDal());

		[AllowAnonymous]
		public ActionResult Index()
        {
            return View();
        }
		[AllowAnonymous]
		public PartialViewResult BlogList(int page=1)
        {
            var blogList = bm.GetList().ToPagedList(page,6);
            return PartialView(blogList);
        }
		[AllowAnonymous]
		public PartialViewResult FeaturedPosts()
        {
            //1.post
          
            var posttitle1 = bm.GetList().OrderByDescending(z=>z.BlogID).Where(x => x.BlogID == 1011).Select(y => y.BlogTitle).FirstOrDefault();
			var postimage1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1011).Select(y => y.BlogImage).FirstOrDefault();
			var blogpostid1= bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1011).Select(y => y.BlogID).FirstOrDefault();
			var blogdate1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1011).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.posttitle1 = posttitle1;
			ViewBag.postimage1 = postimage1;
			ViewBag.blogdate1 = blogdate1;
			ViewBag.blogpostid1 = blogpostid1;

			//2.post

			var posttitle2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1012).Select(y => y.BlogTitle).FirstOrDefault();
			var postimage2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1012).Select(y => y.BlogImage).FirstOrDefault();
			var blogpostid2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1012).Select(y => y.BlogID).FirstOrDefault();
			var blogdate2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1012).Select(y => y.BlogDate).FirstOrDefault();
			ViewBag.posttitle2 = posttitle2;
			ViewBag.postimage2= postimage2;
			ViewBag.blogdate2 = blogdate2;
			ViewBag.blogpostid2 = blogpostid2;


			//3.post

			var posttitle3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1014).Select(y => y.BlogTitle).FirstOrDefault();
			var postimage3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1014).Select(y => y.BlogImage).FirstOrDefault();
			var blogdate3= bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1014).Select(y => y.BlogDate).FirstOrDefault();
			var blogpostid3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1014).Select(y => y.BlogID).FirstOrDefault();
			ViewBag.blogpostid3 = blogpostid3;
			ViewBag.posttitle3 = posttitle3;
			ViewBag.postimage3 = postimage3;
			ViewBag.blogdate3= blogdate3;

			//4.post

			var posttitle4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1010).Select(y => y.BlogTitle).FirstOrDefault();
			var postimage4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1010).Select(y => y.BlogImage).FirstOrDefault();
			var blogdate4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1010).Select(y => y.BlogDate).FirstOrDefault();
			var blogpostid4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1010).Select(y => y.BlogID).FirstOrDefault();
			ViewBag.blogpostid4 = blogpostid4;
			ViewBag.posttitle4 = posttitle4;
			ViewBag.postimage4 = postimage4;
			ViewBag.blogdate4= blogdate4;

			//5.post

			var posttitle5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1006).Select(y => y.BlogTitle).FirstOrDefault();
			var postimage5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1006).Select(y => y.BlogImage).FirstOrDefault();
			var blogdate5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1006).Select(y => y.BlogDate).FirstOrDefault();
			var blogpostid5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.BlogID == 1006).Select(y => y.BlogID).FirstOrDefault();
			ViewBag.blogpostid5 = blogpostid5;
			ViewBag.posttitle5 = posttitle5;
			ViewBag.postimage5 = postimage5;
			ViewBag.blogdate5 = blogdate5;


			return PartialView();
        }
		[AllowAnonymous]
		public PartialViewResult OtherFeaturedPosts()
		{
			return PartialView();
		}

		[AllowAnonymous]
		public ActionResult BlogDetails()
		{

			return View();
		}
		[AllowAnonymous]
		public PartialViewResult BlogCover(int id)
        {
			var BlogDetailsList = bm.GetBlogByID(id);
			return PartialView(BlogDetailsList);
        }
		[AllowAnonymous]
		public PartialViewResult BlogReadAll(int id)
        {
			var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }
		[AllowAnonymous]
		public ActionResult BlogByCategory(int id)
		{
			var BlogListByCategory = bm.GetBlogByCategory(id);
			var CategoryName = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
			ViewBag.CategoryName = CategoryName;
			var CategoryDesc = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
			ViewBag.CategoryDesc = CategoryDesc;
			return View(BlogListByCategory);
		}

		[Authorize]
		public ActionResult AdminBlogList()
		{
			var bloglist = bm.GetList();
			return View(bloglist);
		}
		
		public ActionResult AdminBlogList2()
		{
			var bloglist = bm.GetList();
			return View(bloglist);
		}
		[Authorize(Roles ="A")]
		[HttpGet]
		public ActionResult AddNewBlog()
		{
			Context c = new Context();
			List<SelectListItem>values=(from x in c.Categorys.ToList()
										select new SelectListItem
										{
				                        Text=x.CategoryName,
					                    Value=x.CategoryId.ToString()
                                        }).ToList();
			ViewBag.values = values;

			List<SelectListItem> values2 = (from x in c.Authors.ToList()
										   select new SelectListItem
										   {
											   Text = x.AuthorName,
											   Value = x.AuthorID.ToString()
										   }).ToList();
			ViewBag.values2 = values2;

			return View();
		}
		[HttpPost]
		public ActionResult AddNewBlog(Blog b)
		{
			bm.TAdd(b);
			return RedirectToAction("AdminBlogList");
		}
		public ActionResult DeleteBlog(int id)
		{
			Blog blog = bm.GetByID(id);
			bm.TDelete(blog);
			
			return RedirectToAction("AdminBlogList");
		}
		[AllowAnonymous]
		[HttpGet]
		public ActionResult UpdateBlog(int id)
		{

			Blog blog = bm.GetByID(id);
			Context c = new Context();
			List<SelectListItem> values = (from x in c.Categorys.ToList()
										   select new SelectListItem
										   {
											   Text = x.CategoryName,
											   Value = x.CategoryId.ToString()
										   }).ToList();
			ViewBag.values = values;

			List<SelectListItem> values2 = (from x in c.Authors.ToList()
											select new SelectListItem
											{
												Text = x.AuthorName,
												Value = x.AuthorID.ToString()
											}).ToList();
			ViewBag.values2 = values2;
			return View(blog);
		}
		[HttpPost]
		public ActionResult UpdateBlog(Blog p)
		{
			bm.TUpdate(p);
			return RedirectToAction("AdminBlogList");
		}
		[AllowAnonymous]
		public ActionResult GetCommentByBlog(int id)
		{
			var commentlist = cm.CommentByBlog(id);
			return View(commentlist);
		}
		public ActionResult AuthorBlogList(int id)
		{
			var blogs = bm.GetBlogByAuthor(id);
			return View(blogs);
		}

	}
}