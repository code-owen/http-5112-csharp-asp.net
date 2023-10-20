using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IfPractice.Controllers
{
    public class IfController : ApiController
    {



        /// <summary>
        /// Receive a time of day, output an appropriate welcome for that time
        /// </summary>
        /// <param name="time">The input time (24 hour format)</param>
        /// <returns>
        //GET api/IfPractice/Welcome/6 -> "Good Morning"
        //GET api/IfPractice/Welcome/13 -> "Good Afternoon"
        //GET api/IfPractice/Welcome/20 -> "Good Evening"
        //GET api/IfPractice/Welcome/20 -> "Good Evening"
        //GET api/IfPractice/Welcome/22 -> "Good Night"
        /// </returns>
        [HttpGet]
        [Route("api/If/Welcome/{time}")]

        public string Welcome(int time)
        {
            //When is good morning? When time is between 6 - 10
            //When is good afternoon? When time is between 11 - 15
            //When is good evening? When time is between 16 - 24
            //Everything else is goodnight

            string greeting = "";

            if (time>=6 && time <=10)
            {
                greeting = "Morning";
            }else if (time>=11 && time <=15)
            {
                greeting = "Afternoon";
            }else if (time>=16 && time <= 20)
            {
                greeting = "Evening";
            }
            else
            {
                greeting = "Night";
            }

            return "Good " + greeting;
        }

    }
}
