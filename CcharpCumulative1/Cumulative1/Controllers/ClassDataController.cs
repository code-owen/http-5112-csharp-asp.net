using Cumulative1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cumulative1.Controllers
{
    public class ClassDataController : Controller
    {
        //uses the school context class to access the database
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// returns a list of Classes from the database
        /// </summary>
        /// <returns>
        /// A list of Class objects with Classes containing the search key
        /// </returns>

        [HttpGet]
        // GET: ClassData
        public List<Class> ListClass(string ClassSearch)
        {
            //creates a connection to the database
            MySqlConnection Conn = School.AccessDatabase();

            //opens the connection
            Conn.Open();

            //creates a command
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query
            cmd.CommandText = "select * from classes where lower(classcode) like @key or classid like @key or teacherid like @key or lower(classname) like @key or startdate like @key or finishdate like @key or lower(classname) like @key";

            //sanitize search terms
            cmd.Parameters.AddWithValue("@key", "%" + ClassSearch + "%");

            //collects results into variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //sets up a list of Classs
            List<Class> Class = new List<Class>();

            //loops through the results of the query
            while (ResultSet.Read())
            {
                //gets the class id
                int ClassId = Convert.ToInt32(ResultSet["classid"]);

                //gets the class code
                string ClassCode = ResultSet["classcode"].ToString();

                //gets the teacher id
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);

                //gets the class start date
                string StartDate = ResultSet["startdate"].ToString();

                //gets the class finish date
                string FinishDate = ResultSet["finishdate"].ToString();

                //gets the class name
                string ClassName = ResultSet["classname"].ToString();

                //creates a class object
                Class NewClass = new Class();

                //sets the information for the Class object
                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.TeacherId = TeacherId;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;

                //adds the information to the Class object
                Class.Add(NewClass);
            }

            //closes the connection to the database
            Conn.Close();

            //returns the Classs
            return Class;
        }


        /// <summary>
        /// Finds the Class by the Class id
        /// </summary>
        /// <param name="1">The Class primary key</param>
        /// <returns>
        /// 1 { ClassCode: "http5101", TeacherId: 1, StartDate: 2018-12-14, FinishDate: 2018-12-14, ClassName: "Web Application Development }"
        /// </returns>
        [HttpGet]
        //creates method FindClass and passes the Class id
        public Class FindClass(int id)
        {
            //create NewClass object
            Class NewClass = new Class();

            //create a connection to the database
            MySqlConnection Conn = School.AccessDatabase();

            //opens the connection to the database
            Conn.Open();

            //creates a command 
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query to pull information from the database
            string query = "select * from classes where classid=@classid";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@classid", id);

            //collects results into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //loops through the results of the query
            while (ResultSet.Read())
            {
                //access database column information by the column name
                int ClassId = Convert.ToInt32(ResultSet["classid"]);

                string ClassCode = ResultSet["classcode"].ToString();

                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);

                string StartDate = ResultSet["startdate"].ToString();

                string FinishDate = ResultSet["finishdate"].ToString();

                string ClassName = ResultSet["classname"].ToString();


                //sets the information into a variable
                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.TeacherId = TeacherId;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;
            }

            //closes connection to the database
            Conn.Close();

            //returns variable
            return NewClass;
        }

        /// <summary>
        /// Receives class information and adds the class to the database
        /// </summary>
        /// <example>
        /// POST : api/ClassData/AddClass
        /// 
        /// FORM DATA / POST DATA:
        /// {
        /// Class Code: HTTP5555
        /// Teacher ID: 6
        /// Start Date: 2023-10-28
        /// Finish Date: 2023-11-30
        /// Class Name: Computer Science
        /// }
        /// </example>
        /// <returns>
        /// List of classes with the new class object
        /// </returns>
        /// AFTER ADD, DELETE, we will focus on the API directly
        //New method in the Class data controller
        [HttpPost]
        public void AddClass(Class NewClass)
        {
            //assume that the informaiton is received correctly
            //contact the database and execute a query

            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();
            MySqlCommand CMD = Conn.CreateCommand();
            string query = "insert into Classes (classcode, teacherid, startdate, finishdate, classname) values(@classcode, @teacherid, @startdate, @finishdate, @classname);";
            CMD.CommandText = query;
            CMD.Parameters.AddWithValue("@classcode", NewClass.ClassCode);
            CMD.Parameters.AddWithValue("@teacherid", NewClass.TeacherId);
            CMD.Parameters.AddWithValue("@startdate", NewClass.StartDate);
            CMD.Parameters.AddWithValue("@finishdate", NewClass.FinishDate);
            CMD.Parameters.AddWithValue("@classname", NewClass.ClassName);

            CMD.Prepare();

            CMD.ExecuteNonQuery();

            Conn.Close();

        }
        /// <summary>
        /// Delete a class from the system
        /// </summary>
        /// <returns>
        /// </returns>
        /// <param name="ClassId">The Class ID in the system</param>
        /// <example>
        /// POST api/ClassData/DeleteClass/3
        /// </example>
        //New method for deleting a Class
        [HttpPost]
        public void DeleteClass(int ClassId)
        {
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();
            MySqlCommand CMD = Conn.CreateCommand();


            string query = "delete from classes where classid=@classid";
            CMD.CommandText = query;
            CMD.Parameters.AddWithValue("@classid", ClassId);

            CMD.Prepare();

            CMD.ExecuteNonQuery();
            Conn.Close();



        }
    }
}