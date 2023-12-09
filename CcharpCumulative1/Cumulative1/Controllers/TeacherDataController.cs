using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            cmd.CommandText = "select * from teachers where lower(teacherfname) like @key or lower(teacherlname) like @key or hiredate like @key or lower(employeenumber) like @key or salary like @key";

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
                NewTeacher.EmployeeNumber = EmployeeId;
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
        /// <param teacherid="1">The teacher primary key</param>
        /// <returns>
        /// 1 { TeacherFName: "Alexander", TeacherLName: "Bennett", EmployeeNumber: "T378", HireDate: 2016-08-05, Salary: 55.30 }
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
            string query = "select * from teachers where teacherid=@teacherid";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@Teacherid",id);

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
                NewTeacher.EmployeeNumber = EmployeeId;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
            }

            //closes connection to the database
            Conn.Close();

            //returns variable
            return NewTeacher;
        }

        /// <summary>
        /// Receives Teacher information and adds the Teacher to the database
        /// </summary>
        /// <example>
        /// POST : api/TeacherData/AddTeacher
        /// 
        /// FORM DATA / POST DATA:
        /// {
        /// First Name: Owen
        /// Last Name: Laing
        /// Employee Number: T555
        /// Salary: 99.00
        /// }
        /// </example>
        /// <returns>
        /// Teacher list with new teacher object
        /// </returns>
        /// AFTER ADD, DELETE, we will focus on the API directly
        //New method in the teacher data controller
        [HttpPost]
        public void AddTeacher(Teacher NewTeacher)
        {
            //assume that the informaiton is received correctly
            //contact the database and execute a query

            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();
            MySqlCommand CMD = Conn.CreateCommand();
            string query = "insert into teachers (teacherfname, teacherlname, employeenumber, salary, hiredate) values(@teacherfname, @teacherlname, @employeenumber, @salary, @hiredate);";
            CMD.CommandText = query;
            CMD.Parameters.AddWithValue("@teacherfname", NewTeacher.TeacherFName);
            CMD.Parameters.AddWithValue("@teacherlname", NewTeacher.TeacherLName);
            CMD.Parameters.AddWithValue("@employeenumber", NewTeacher.EmployeeNumber);
            CMD.Parameters.AddWithValue("@salary", NewTeacher.Salary);
            CMD.Parameters.AddWithValue("@hiredate", NewTeacher.HireDate);

            CMD.Prepare();

            CMD.ExecuteNonQuery();

            Conn.Close();

        }
        /// <summary>
        /// Delete a Teacher from the system
        /// </summary>
        /// <returns>
        /// </returns>
        /// <param name="TeacherId">The Teacher ID in the system</param>
        /// <example>
        /// POST api/TeacherData/DeleteTeacher/3
        /// </example>
        //New method for deleting a teacher
        [HttpPost]
        public void DeleteTeacher(int TeacherId)
        {
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();
            MySqlCommand CMD = Conn.CreateCommand();


            string query = "delete from teachers where teacherid=@teacherid";
            CMD.CommandText = query;
            CMD.Parameters.AddWithValue("@teacherid", TeacherId);

            CMD.Prepare();

            CMD.ExecuteNonQuery();  
            Conn.Close();



        }
        /// <summary>
        /// Updates the teacher in the databae given the teacher id and teacher information
        /// </summary>
        /// <param name="TeacherId">The teacher Id to update</param>
        /// <param name="UpdatedTeacher">An object containing the new information</param>
        /// <example>
        /// POST: /TeacherData/UpdateTecaher/1
        /// 
        /// POST DATA / FORM DATA ? REQUEST BODY
        /// {
        ///     "TeacherFName" : "Alexander"
        ///     "TeacherLName" : "Bennett"
        /// }
        /// </example>
        /// <param name="TeacherId"
        /// <return>
        /// </return>
        [HttpPost]
        public void UpdateTeacher(int TeacherId, [Microsoft.AspNetCore.Mvc.FromBody] Teacher UpdatedTeacher)
        {
            //update logic
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();


            //query
            string query = "update teachers set teacherfname=@fname, teacherlname=@lname, employeenumber=@enumber, hiredate=@hdate, salary=@salary where teacherid=@id;";


                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@fname", UpdatedTeacher.TeacherFName);
                cmd.Parameters.AddWithValue("@lname", UpdatedTeacher.TeacherLName);
                cmd.Parameters.AddWithValue("@enumber", UpdatedTeacher.EmployeeNumber);
                cmd.Parameters.AddWithValue("@hdate", UpdatedTeacher.HireDate);
                cmd.Parameters.AddWithValue("@salary", UpdatedTeacher.Salary);
                cmd.Parameters.AddWithValue("@id", TeacherId);
                
                cmd.Prepare();

                cmd.ExecuteNonQuery();

                Conn.Close();
        }
    }
}