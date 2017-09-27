using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            string _imgname = string.Empty;
            var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
            var sPath = System.Web.HttpContext.Current.Request.Form["sPath"];
            var sPathResize = System.Web.HttpContext.Current.Request.Form["sPathResize"];
            if (pic.ContentLength > 0)
            {
                var fileName = Path.GetFileName(pic.FileName);
                var _ext = Path.GetExtension(pic.FileName);

                _imgname = Guid.NewGuid().ToString();
                var _comPath = Server.MapPath(sPath) + _imgname + _ext;
                _imgname = _imgname + _ext;

                ViewBag.Msg = _comPath;
                var path = _comPath;

                // Saving Image in Original Mode
                pic.SaveAs(path);

                if (sPathResize != null)
                {
                    path = Server.MapPath(sPathResize) + "m-" + _imgname + _ext;
                    pic.SaveAs(path);
                }

                // end resize
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }
    }
}