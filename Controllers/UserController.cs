using alltopicMvc.DataAccess;
using System;
using System.Web.Mvc;

namespace alltopicMvc.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        private readonly UserAccess _userAccess;

        public UserController()
        {
            _userAccess = new UserAccess();
        }

        public ActionResult Index()
        {
            var users = _userAccess.GetUsers();
            return View(users);
        }

        public ActionResult GetUsers()
        {
            var users = _userAccess.GetUsers();
            return Json(users, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult InsertUser(FormCollection formCollection)
        {
            string name = formCollection["name"];
            string email = formCollection["email"];
            string password = formCollection["password"];
            int is_admin =(formCollection["is_admin"] == "on") ? 1 : 0;


            var result = _userAccess.insertuser(name,email, password, is_admin);

            //return RedirectToRoute("index", "Home");
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

    }
}