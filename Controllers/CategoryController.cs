using alltopicMvc.DataAccess;
using alltopicMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace alltopicMvc.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly  CategooryDataAccess _categooryDataAccess;

        public CategoryController()
        {
            _categooryDataAccess = new CategooryDataAccess();
        }


        public ActionResult Index()
        {
            //var categories = _categooryDataAccess.GetCategories();
            //return View(categories);
            return View();
        }

        public ActionResult GetCategories()
        {

            var categories = _categooryDataAccess.GetCategories();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InsertCategory(Category category)
        {
            string name = category.Name;
            string title = category.Title;
            string description = category.Description;
            string image = category.Image;

            var result = _categooryDataAccess.insertCategory(name, title, description, image);

            //return RedirectToRoute("index", "Home");
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }



    }
}