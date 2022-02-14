using MidLabTaskCRUD.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidLabTaskCRUD.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/
        [HttpGet]
        public ActionResult Index()
        {
            aspMidTask1Entities db = new aspMidTask1Entities();
            var data = db.News.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(string cat, string date)
        {
            if (date == null)
            {
                aspMidTask1Entities db = new aspMidTask1Entities();
                var data = (from n in db.News
                            where n.Category.Contains(cat)
                            select n).ToList();
                return View(data);
            }
            else if(cat == null){
                aspMidTask1Entities db = new aspMidTask1Entities();
                var data = (from n in db.News
                            where n.PublishDate.Contains(date)
                            select n).ToList();
                return View(data);
            
            }
            else if (cat !=null && date != null)
            {
                aspMidTask1Entities db = new aspMidTask1Entities();
                var data = (from n in db.News
                            where n.Category.Contains(cat) && n.PublishDate.Contains(date)
                            select n).ToList();
                return View(data);

            }
            else{
                aspMidTask1Entities db = new aspMidTask1Entities();
                var data = db.News.ToList();
                return View(data);
            }
        }


        public ActionResult Create()
        {
            return View(new News());
        }

        [HttpPost]
        public ActionResult Create(News n)
        {
            if (ModelState.IsValid)
            {
                aspMidTask1Entities db = new aspMidTask1Entities();
                db.News.Add(n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(n);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            aspMidTask1Entities db = new aspMidTask1Entities();
            var news = (from n in db.News where n.Id == id select n).FirstOrDefault();
            return View(news);
        }

         [HttpPost]
         public ActionResult Edit(News new_news)
         {
             if (ModelState.IsValid)
            {
               aspMidTask1Entities db = new aspMidTask1Entities();
               var news = (from n in db.News where n.Id == new_news.Id select n).FirstOrDefault();
               db.Entry(news).CurrentValues.SetValues(new_news);
               db.SaveChanges();
                return RedirectToAction("Index");
            }
             return View();
         }

         [HttpGet]
         public ActionResult Delete(int id)
         {
             aspMidTask1Entities db = new aspMidTask1Entities();
             var news = (from n in db.News where n.Id == id select n).FirstOrDefault();
             return View(news);
         }

         [HttpPost]
         public ActionResult Delete(int id, int temp)
         {
                 aspMidTask1Entities db = new aspMidTask1Entities();
                 var news = (from n in db.News where n.Id == id select n).FirstOrDefault();
                 db.News.Remove(news);
                 db.SaveChanges();
                 return RedirectToAction("Index");
         }
	}
}