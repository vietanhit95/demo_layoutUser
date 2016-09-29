using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai2.Models;

namespace Bai2.Controllers
{
    public class HomeController : Controller
    {
        
        //
        // GET: /Home/
        public ActionResult Index()
        {
            using (DemoEntities db = new DemoEntities())
            {
                List<object> lstCategory = new List<object>();
                lstCategory.Add(db.Categories.Where(n=>n.Parent == 1).ToList());
                lstCategory.Add(db.Articles.Take(4).ToList());
                return View(lstCategory);
            }
        }
        

	}
}