using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Cumulative1.Models;
using System.Diagnostics;

namespace Cumulative1.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        //Go to /Views/Teacher/List?TeacherSearch={value}
        //Browser opens a list of teachers page
        public ActionResult List(string TeacherSearch)
        {
            //passes teacher information to the view
            
            //create an instance of the teacher data controller
            TeacherDataController Controller = new TeacherDataController();

            List<Teacher> Teachers = Controller.ListTeacher(TeacherSearch);

            //passes the teachers information to the /Views/Teacher/List.cshtml
            return View(Teachers);
        }

        //GET: /Teacher/Show/{id}
        //Route to /Teacher/Show.cshtml
        public ActionResult Show(int id)
        {
            //creates instance of the teacher data controller
            TeacherDataController Controller = new TeacherDataController();

            //takes the id from the FindTeacher method
            Teacher SelectedTeacher = Controller.FindTeacher(id);

            //passes the id to /Teacher/Show.cshtml
            return View(SelectedTeacher);
        }

        //GET:
        public ActionResult New()
        {
            return View();
        }

        //POST: /Teacher/Create
        [HttpPost]
        public ActionResult Create(Teacher NewTeacher)
        {
            //Capture the Teacher information posted to us

            //Add the Teacher information to the database
            TeacherDataController Controller = new TeacherDataController();
            //Go back to the original list of teachers
            Controller.AddTeacher(NewTeacher);
            //Redirects to the list Teachers method
            return RedirectToAction("List");
        }

        //GET : Teacher Delete
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController Controller = new TeacherDataController();

            Teacher SelectedTeacher = Controller.FindTeacher(id);

            
            
            return View(SelectedTeacher);
        }

        //POST : /Teacher/Delete/{TeacherId}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController Controller = new TeacherDataController();
            Controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET: /Teacher/Update/{teacherid}
        //routes to Views/Teacher/Update.cshtml
        public ActionResult Update(int id) 
        {
            TeacherDataController Controller = new TeacherDataController();

            //want to disaplay the Teacher information
            Teacher SelectedTeacher = Controller.FindTeacher(id);

            return View(SelectedTeacher);
        }

        //POST: /Teacher/Update/{teacherid}
        //updates the teacher
        //redirects to the show teacher page
        [HttpPost]
        public ActionResult UpdateTeacher(int id, Teacher UpdatedTeacher)
        {

            //update the teacher
            TeacherDataController controller = new TeacherDataController();

            controller.UpdateTeacher(id, UpdatedTeacher);

            //return to the show page
            return RedirectToAction("Show/" + id);
        }
    }
}