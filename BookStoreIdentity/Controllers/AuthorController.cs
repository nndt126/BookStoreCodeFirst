using Model.Class;
using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using PagedList;
using Model.Interface;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {

        private readonly IAuthorDAO _iAuthorDAO;

        public AuthorController(IAuthorDAO iAuthorDAO)
        {
            _iAuthorDAO = iAuthorDAO;
        }

        // GET: Author
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllAuthors()
        {
            var model = _iAuthorDAO.GetAuthors();
            return View(model);
        }

        [Authorize]
        public ActionResult AdminGetAllAuthorsPaging(string sortOrder, string currentFilter, string searchString ,int id = 1)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.sortOrder = sortOrder;

            if (searchString != null)
                id = 1;

            else
                searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            int numberItemOfPage = 3;

            var authors = _iAuthorDAO.GetAuthorPaging(sortOrder, searchString, numberItemOfPage, id);
            ViewBag.numberPage = id;
            ViewBag.numberOfPage = Math.Ceiling(_iAuthorDAO.GetAllAuthorsAdmin().Count / (numberItemOfPage * 1.0f));
            return View(authors);
        }

        //[Authorize]
        //public ActionResult AdminGetAllAuthors(string sortOrder, string currentFilter, string searchString, int? page)
        //{
        //    ViewBag.CurrentSort = sortOrder;
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

        //    if (searchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //        searchString = currentFilter;

        //    int pageSize = 2;
        //    int pageNumber = (page ?? 1);


        //    var authors = _iAuthorDAO.GetAllAuthors();

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        authors = authors.Where(s => s.AuthorName.Contains(searchString));
        //    }

        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            authors = authors.OrderByDescending(s => s.AuthorName);
        //            break;
        //        case "Date":
        //            authors = authors.OrderBy(s => s.Birthday);
        //            break;
        //        case "date_desc":
        //            authors = authors.OrderByDescending(s => s.Birthday);
        //            break;
        //        default:
        //            authors = authors.OrderBy(s => s.AuthorName);
        //            break;
        //    }

        //    return View(authors.ToPagedList(pageNumber, pageSize));
        //    //return View(authors.ToList());
        //}

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        public ActionResult EditAuthor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var auDAO = _iAuthorDAO.GetAuthorByID(id);
                if (auDAO == null)
                {
                    return HttpNotFound();
                }
                return View(auDAO);
            }
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorName,Birthday,AuthorImage,IsDeleted")] Author author)
        {
            if (ModelState.IsValid)
            {
                int id = _iAuthorDAO.Insert(author);
                if (id > 0)
                {
                    return RedirectToAction("AdminGetAllAuthorsPaging", "Author");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View(author);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAuthor([Bind(Include = "ID,AuthorName,Birthday,AuthorImage,IsDeleted")]Author author)
        {
            if (ModelState.IsValid)
            {
                //var auDAO = new AuthorDAO();
                var result = _iAuthorDAO.Update(author);
                if (result)
                {
                    return RedirectToAction("AdminGetAllAuthorsPaging", "Author");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            return View(author);
        }

        //[Authorize]
        //[HttpDelete]
        //public ActionResult DeleteAjax(int id)
        //{
        //    var auDAO = new AuthorDAO();
        //    var result = auDAO.Delete(id);
        //    if (!result)
        //    {
        //        ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
        //    }
        //    return JavaScript("location.reload()");
        //    //return RedirectToAction("AdminGetAllAuthors", "Author");
        //}

        [Authorize]
        //[HttpPost, ActionName("Delete")]
        public JsonResult DeleteAjax(int AuthorID)
        {
            //var auDAO = new AuthorDAO();
            var result = _iAuthorDAO.DeleteAjax(AuthorID);
            return Json(result, JsonRequestBehavior.AllowGet);
            //return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        [Authorize]
        public JsonResult AdminGetAllAuthorsJson()
        {
            //var authorDAO = new AuthorDAO();
            var authorList = _iAuthorDAO.GetAllAuthors().ToList();

            var jsonResult = authorList.Select(x => new
            {
                ID = x.ID,
                AuthorName = x.AuthorName,
            });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
    }
}