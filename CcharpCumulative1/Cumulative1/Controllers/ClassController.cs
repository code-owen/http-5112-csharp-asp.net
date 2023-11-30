using Cumulative1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cumulative1.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        //Go to /Views/Class/List?ClassSearch={value}
        //Browser opens a list of Classes page
        public ActionResult List(string ClassSearch)
        {
            //passes Class information to the view

            //create an instance of the Class data controller
            ClassDataController Controller = new ClassDataController();

            List<Class> Class = Controller.ListClass(ClassSearch);

            //passes the Classes information to the /Views/Class/List.cshtml
            return View(Class);
        }

        //GET: /Class/Show/{id}
        //Route to /Class/Show.cshtml
        public ActionResult Show(int id)
        {
            //creates instance of the Class data controller
            ClassDataController Controller = new ClassDataController();

            //takes the id from the FindClass method
            Class SelectedClass = Controller.FindClass(id);

            //passes the id to /Class/Show.cshtml
            return View(SelectedClass);
        }

        //GET:
        public ActionResult New()
        {
            return View();
        }

        //POST: /Class/Create
        [HttpPost]
        public ActionResult Create(Class NewClass)
        {
            //Capture the Class information posted to us

            //Add the Class information to the database
            ClassDataController Controller = new ClassDataController();
            //Go back to the original list of Classes
            Controller.AddClass(NewClass);
            //Redirects to the list Classes method
            return RedirectToAction("List");
        }

        //GET : Class Delete
        public ActionResult DeleteConfirm(int id)
        {
            ClassDataController Controller = new ClassDataController();

            Class SelectedClass = Controller.FindClass(id);



            return View(SelectedClass);
        }

        //POST : /Class/Delete/{ClassId}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ClassDataController Controller = new ClassDataController();
            Controller.DeleteClass(id);
            return RedirectToAction("List");
        }
    }
}