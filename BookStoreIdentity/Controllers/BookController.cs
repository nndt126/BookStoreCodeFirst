using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Class;
using Model.Interface;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookDAO _iBookDAO;

        public BookController(IBookDAO iBookDAO)
        {
            _iBookDAO = iBookDAO;
        }

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllBooks()
        {
            var model = _iBookDAO.GetBookViewModel();
            return View(model);
        }

        // [Authorize]
        // public ActionResult AdminGetAllBooks()
        // {
        //     var model = new BookDAO().GetAllBookAuthors();
        //     return View(model);
        // }

        [Authorize]
        public ActionResult AdminGetAllBooks()
        {
            return View();
        }

        [Authorize]
        public JsonResult AdminGetAllBooksJson()
        {
            var result = _iBookDAO.GetAllBookAuthors().ToList();
            
            var jsonResult = result.Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                Prices = x.Prices,
                Description = x.Description,
                Image = x.Image,
                AuthorName = x.Author.AuthorName,
                IsDeleted = x.IsDeleted,
            });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public JsonResult AddBook(Book book)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                if(book.ID == 0)
                {
                    int id = _iBookDAO.Insert(book);
                    if (id > 0)
                        status = true;
                    else
                        status = false;
                }
                else
                {
                    status = _iBookDAO.Update(book);
                }
            }
            return Json(new { success = status });
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetBookByID(int ID)
        {
            var result = _iBookDAO.GetBookByID(ID);

            var jsonResult = result.Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                Prices = x.Prices,
                Description = x.Description,
                Image = x.Image,
                AuthorID = x.Author.ID,
                IsDeleted = x.IsDeleted,
            }).FirstOrDefault();

            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public JsonResult DeleteBook(Book book)
        {
            bool status = false;
            var result = _iBookDAO.GetBookByID(book.ID).SingleOrDefault();
            if (result != null)
                status = _iBookDAO.Delete(result);
            return Json(new { success = status });
        }
    }
}