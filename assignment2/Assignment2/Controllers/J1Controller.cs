using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J1Controller : ApiController
    {
        /// <summary>
        /// CCC 2015 J1 Question
        /// Input a month and day and returns if date (Feb 18) is special 
        /// </summary>
        /// <param name="month">Month</param>
        /// <param name="day">Day</param>
        /// <returns>String "Before", "Special" or "After"</returns>
        /// <example>
        /// GET api/J1/GetSpecialDay/1/15 -> Before
        /// GET api/J1/GetSpecialDay/2/18 -> Special
        /// GET api/J1/GetSpecialDay/12/25 -> After
        /// </example>
        // GET: J1
        [HttpGet]
        [Route("api/J1/GetSpecialDay/{month}/{day}")]

        public string GetSpecialDay(int month, int day)
        {
            //checks month and day and compares it to the special day, returns result
            if (month < 2 || (month == 2 && day < 18))
            {
                return "Before";
            }
            else if (month == 2 && day == 18)
            {
                return "Special";
            }
            else
            {
                return "After";
            }

        }
    }
}
