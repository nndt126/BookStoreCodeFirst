using Model.DAL;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreIdentity.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        #region Index method.  
        /// <summary>  
        /// Index method.   
        /// </summary>  
        /// <returns>Returns - Index view</returns>  
        /// 
        private readonly IBookDAO _iBookDAO;

        public HomeController(IBookDAO iBookDAO)
        {
            _iBookDAO = iBookDAO;
        }

        public ActionResult Index()
        {
            var model = _iBookDAO.GetBookViewModel();
            return View(model);
        }

        [Authorize]
        public ActionResult Get()
        {
            return this.View();
        }
        #endregion
    }
}