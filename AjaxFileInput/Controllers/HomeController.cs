using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxFileInput.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase[] files,int? id)//parametre adı files view ID si ile aynı olmak zorunda
        {
            for (int i = 0; i < files.Length; i++)
            {
                var folder = Server.MapPath("~/Upload");
                var randomFileName = Path.GetRandomFileName();
                var FileName = Path.ChangeExtension(randomFileName, ".jpg");
                var path = Path.Combine(folder, FileName);

                files[i].SaveAs(path);
            }
            return Json("");
        }
    }
}