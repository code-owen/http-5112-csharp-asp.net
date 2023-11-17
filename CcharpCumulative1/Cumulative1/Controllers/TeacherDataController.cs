using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using Cumulative1.Models;
using MySql.Data.MySqlClient;

namespace Cumulative1.Controllers
{
    public class TeacherDataController : Controller
    {
        //uses the school context class to access the database
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// returns a list of teachers from the database
        /// </summary>
        /// <returns>
        /// A list of teacher objects with teachers containing the search key
        /// </returns>
        [HttpGet]
        // GET: TeacherData
        public List<Teacher> ListTeacher(string TeacherSearch)
        {
            //creates a connection to the database
            MySqlConnection Conn = School.AccessDatabase();

            //opens the connection
            Conn.Open();

            //creates a command
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query
            cmd.CommandText ="select * from teachers where teacherfname like @key or teacherlname like @key";

            //sanitize search terms
            cmd.Parameters.AddWithValue("@key", "%" + TeacherSearch + "%");

            //collects results into variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //sets up a list of teachers
            List<Teacher> Teachers = new List<Teacher>();

            //loops through the results of the query
            while (ResultSet.Read())
            {
                //gets the teacher id
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);

                //gets the teachers first name
                string TeacherFName = ResultSet["teacherfname"].ToString();

                //gets the teachers last name
                string TeacherLName = ResultSet["teacherlname"].ToString();

                //gets the employee id
                string EmployeeId = ResultSet["employeenumber"].ToString();

                //gets the hire date
                string HireDate = ResultSet["hiredate"].ToString();

                //gets the salary
                string Salary = ResultSet["salary"].ToString();

                //creates a teacher object
                Teacher NewTeacher = new Teacher();

                //sets the information for the teacher object
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFName = TeacherFName;
                NewTeacher.TeacherLName = TeacherLName;
                NewTeacher.EmployeeId = EmployeeId;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;

                //adds the information to the teacher object
                Teachers.Add(NewTeacher);
            }

            //closes the connection to the database
            Conn.Close();

            //returns the teachers
            return Teachers;
        }

        /// <summary>
        /// Finds the teacher by the teacher id
        /// </summary>
        /// <param name="id">The teacher primary key</param>
        /// <returns>
        /// A teacher object
        /// </returns>
        [HttpGet]
        //creates method FindTeacher and passes the teacher id
        public Teacher FindTeacher(int id)
        {
            //create NewTeacher object
            Teacher NewTeacher = new Teacher();

            //create a connection to the database
            MySqlConnection Conn = School.AccessDatabase();

            //opens the connection to the database
            Conn.Open();

            //creates a command 
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query to pull information from the database
            cmd.CommandText = "select * from teachers where teacherid = " + id;

            //collects results into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();
            
            //loops through the results of the query
            while (ResultSet.Read())
            {
                //access database column information by the column name
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);

                string TeacherFName = ResultSet["teacherfname"].ToString();

                string TeacherLName = ResultSet["teacherlname"].ToString();

                string EmployeeId = ResultSet["employeenumber"].ToString();

                string HireDate = ResultSet["hiredate"].ToString();

                string Salary = ResultSet["salary"].ToString();

                //sets the information into a variable
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFName = TeacherFName;
                NewTeacher.TeacherLName = TeacherLName;
                NewTeacher.EmployeeId = EmployeeId;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
            }

            //closes connection to the database
            Conn.Close();

            //returns variable
            return NewTeacher;
        }
    }
}