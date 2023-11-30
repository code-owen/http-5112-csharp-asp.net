using Cumulative1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cumulative1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        //Go to /Views/Student/List?StudentSearch={value}
        //Browser opens a list of Students page
        public ActionResult List(string StudentSearch)
        {
            //passes Student information to the view

            //create an instance of the Student data controller
            StudentDataController Controller = new StudentDataController();

            List<Student> Students = Controller.ListStudent(StudentSearch);

            //passes the Students information to the /Views/Student/List.cshtml
            return View(Students);
        }

        //GET: /Student/Show/{id}
        //Route to /Student/Show.cshtml
        public ActionResult Show(int id)
        {
            //creates instance of the Student data controller
            StudentDataController Controller = new StudentDataController();

            //takes the id from the FindStudent method
            Student SelectedStudent = Controller.FindStudent(id);

            //passes the id to /Student/Show.cshtml
            return View(SelectedStudent);
        }

        //GET:
        public ActionResult New()
        {
            return View();
        }

        //POST: /Student/Create
        [HttpPost]
        public ActionResult Create(Student NewStudent)
        {
            //Capture the Student information posted to us

            //Add the Student information to the database
            StudentDataController Controller = new StudentDataController();
            //Go back to the original list of Students
            Controller.AddStudent(NewStudent);
            //Redirects to the list Students method
            return RedirectToAction("List");
        }

        //GET : Student Delete
        public ActionResult DeleteConfirm(int id)
        {
            StudentDataController Controller = new StudentDataController();

            Student SelectedStudent = Controller.FindStudent(id);



            return View(SelectedStudent);
        }

        //POST : /Student/Delete/{StudentId}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            StudentDataController Controller = new StudentDataController();
            Controller.DeleteStudent(id);
            return RedirectToAction("List");
        }
    }
}