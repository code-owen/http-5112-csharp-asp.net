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
    }
}