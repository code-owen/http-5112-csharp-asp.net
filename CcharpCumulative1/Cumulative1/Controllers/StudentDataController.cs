using Cumulative1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cumulative1.Controllers
{
    public class StudentDataController : Controller
    {
        //uses the school context class to access the database
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// returns a list of Students from the database with a search function
        /// </summary>
        /// <example>
        /// Search: "Sarah"
        /// Returns: Sarah Valdez
        /// </example>
        /// <returns>
        /// A list of Student objects with Students containing the search key
        /// 1 { StudentFName: "Sarah", StudentLName: "Valdez", StudentNumber: "N1678", EnrollDate: 2018-06-18 }
        /// </returns>

        [HttpGet]
        // GET: StudentData
        public List<Student> ListStudent(string StudentSearch)
        {
            //creates a connection to the database
            MySqlConnection Conn = School.AccessDatabase();

            //opens the connection
            Conn.Open();

            //creates a command
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query
            cmd.CommandText = "select * from students where lower(studentfname) like @key or lower(studentlname) like @key or lower(studentnumber) like @key or enroldate like @key";

            //sanitize search terms
            cmd.Parameters.AddWithValue("@key", "%" + StudentSearch + "%");

            //collects results into variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //sets up a list of Students
            List<Student> Students = new List<Student>();

            //loops through the results of the query
            while (ResultSet.Read())
            {
                //gets the Student id
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);

                //gets the Students first name
                string StudentFName = ResultSet["studentfname"].ToString();

                //gets the Students last name
                string StudentLName = ResultSet["studentlname"].ToString();

                //gets the employee id
                string StudentNumber = ResultSet["studentnumber"].ToString();

                //gets the hire date
                string EnrollDate = ResultSet["enroldate"].ToString();

                //creates a Student object
                Student NewStudent = new Student();

                //sets the information for the Student object
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFName = StudentFName;
                NewStudent.StudentLName = StudentLName;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrollDate = EnrollDate;

                //adds the information to the Student object
                Students.Add(NewStudent);
            }

            //closes the connection to the database
            Conn.Close();

            //returns the Students
            return Students;
        }


        /// <summary>
        /// Finds the Student by the Student id
        /// </summary>
        /// <param id="2">The Student primary key</param>
        /// <returns>
        /// 2 { StudentFName: "Jennifer", StudentLName: "Faulkner", StudentNumber: "N1679", EnrollDate: 2018-08-02 }
        /// </returns>
        [HttpGet]
        //creates method FindStudent and passes the Student id
        public Student FindStudent(int id)
        {
            //create NewStudent object
            Student NewStudent = new Student();

            //create a connection to the database
            MySqlConnection Conn = School.AccessDatabase();

            //opens the connection to the database
            Conn.Open();

            //creates a command 
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query to pull information from the database
            string query = "select * from students where studentid=@studentid";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@studentid", id);

            //collects results into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //loops through the results of the query
            while (ResultSet.Read())
            {
                //access database column information by the column name
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);

                string StudentFName = ResultSet["studentfname"].ToString();

                string StudentLName = ResultSet["studentlname"].ToString();

                string StudentNumber = ResultSet["studentnumber"].ToString();

                string EnrollDate = ResultSet["enroldate"].ToString();


                //sets the information into a variable
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFName = StudentFName;
                NewStudent.StudentLName = StudentLName;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrollDate = EnrollDate;
            }

            //closes connection to the database
            Conn.Close();

            //returns variable
            return NewStudent;
        }

        /// <summary>
        /// Receives Student information and adds the Student to the database
        /// </summary>
        /// <example>
        /// POST : api/StudentData/AddStudent
        /// 
        /// FORM DATA / POST DATA:
        /// {
        /// First Name: Owen
        /// Last Name: Laing
        /// Student Number: N555
        /// Enroll Date: 2023-11-30
        /// }
        /// </example>
        /// <returns>
        /// A list entry with a new student object
        /// </returns>

        //New method in the Student data controller
        [HttpPost]
        public void AddStudent(Student NewStudent)
        {
            //assumes that the informaiton is received correctly
            //contact the database and execute a query
            //inserts data into the sql table and closes the connection
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();
            MySqlCommand CMD = Conn.CreateCommand();
            string query = "insert into students (studentfname, studentlname, studentnumber, enroldate) values(@studentfname, @studentlname, @studentnumber, @enroldate);";
            CMD.CommandText = query;
            CMD.Parameters.AddWithValue("@studentfname", NewStudent.StudentFName);
            CMD.Parameters.AddWithValue("@studentlname", NewStudent.StudentLName);
            CMD.Parameters.AddWithValue("@studentnumber", NewStudent.StudentNumber);
            CMD.Parameters.AddWithValue("@enroldate", NewStudent.EnrollDate);

            CMD.Prepare();

            CMD.ExecuteNonQuery();

            Conn.Close();

        }
        /// <summary>
        /// Delete a Student from the system
        /// </summary>
        /// <returns>
        /// </returns>
        /// <param name="StudentId">The Student ID in the system</param>
        /// <example>
        /// POST api/StudentData/DeleteStudent/3
        /// </example>
        //New method for deleting a Student
        [HttpPost]
        public void DeleteStudent(int StudentId)
        {
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();
            MySqlCommand CMD = Conn.CreateCommand();


            string query = "delete from students where studentid=@studentid";
            CMD.CommandText = query;
            CMD.Parameters.AddWithValue("@studentid", StudentId);

            CMD.Prepare();

            CMD.ExecuteNonQuery();
            Conn.Close();



        }
        /// <summary>
        /// Updates the student in the databae given the student id and Student information
        /// </summary>
        /// <param name="StudentId">The Student Id to update</param>
        /// <param name="UpdatedStudent">An object containing the new information</param>
        /// <example>
        /// POST: /StudentData/UpdateTecaher/1
        /// 
        /// POST DATA / FORM DATA ? REQUEST BODY
        /// {
        ///     "StudentFName" : "Alexander"
        ///     "StudentLName" : "Bennett"
        /// }
        /// </example>
        /// <param name="StudentId"
        /// <return>
        /// </return>
        [HttpPost]
        public void UpdateStudent(int StudentId, [Microsoft.AspNetCore.Mvc.FromBody] Student UpdatedStudent)
        {
            //update logic
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();


            //query
            string query = "update students set studentfname=@fname, studentlname=@lname, studentnumber=@snumber, enroldate=@edate where studentid=@id;";


            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@fname", UpdatedStudent.StudentFName);
            cmd.Parameters.AddWithValue("@lname", UpdatedStudent.StudentLName);
            cmd.Parameters.AddWithValue("@snumber", UpdatedStudent.StudentNumber);
            cmd.Parameters.AddWithValue("@edate", UpdatedStudent.EnrollDate);
            cmd.Parameters.AddWithValue("@id", StudentId);

            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }
    }
}
