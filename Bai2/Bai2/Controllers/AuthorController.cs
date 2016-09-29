using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai2.Models;


namespace Bai2.Controllers
{
    public class AuthorController : Controller
    {
        //
        // GET: /Author/
        [HttpGet]
        public ActionResult Index()
        {
            using (DemoEntities demo = new DemoEntities())
            {
                List<Author> lstauthor = demo.Authors.ToList();
                return View(lstauthor);
            }

        }

        //
        // GET: /Author/
        [HttpGet]
        public ActionResult Add()
        {
            Author author = new Author();
            return View(author);
        }

        //
        // POST: /Author/
        [HttpPost]
        public ActionResult Add(Author author)
        {
            using (DemoEntities db = new DemoEntities())
            {
                db.Authors.Add(author);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        //
        // GET: /Author/Edit/1
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (DemoEntities db = new DemoEntities())
            {
                Author author = db.Authors.SingleOrDefault(x => x.Id == id);
                return View(author);
            }
        }

        //
        // POST: /Author/Edit/1
        [HttpPost]
        public ActionResult Edit(Author authorObj,int id)
        {
            using (DemoEntities db = new DemoEntities())
            {
                Author author = db.Authors.SingleOrDefault(x => x.Id == id);
                if (author != null)
                {
                    author.Name = authorObj.Name;
                    author.Address = authorObj.Address;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            using (DemoEntities demo = new DemoEntities())
            {
                Author author = demo.Authors.SingleOrDefault(k => k.Id == id);
                if(author != null)
                {
                    demo.Authors.Remove(author);
                    demo.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View();
            }
        }
    }
}