using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Cumulative1.Models
{
    public class Teacher
    {
        //Define a teacher

        //Teacher id
        public int TeacherId { get; set; }
        
        //Teacher first name
        public string TeacherFName { get; set; }

        //Teacher last name
        public string TeacherLName { get; set; }

        //Teacher employee number
        public string EmployeeId { get; set; }

        //Teacher hire date
        public string HireDate { get; set; }

        //Teacher salary
        public string Salary { get; set; }
    
    }
}