using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web.Http;

namespace IfPractice.Controllers
{
    public class RouteController : ApiController
    {

        //GET api/Route/Greeting/owen/7 => "Good morning to Owen at 7am"
        [HttpGet]
        [Route("api/Route/Greeting/{name}/{time}")]
        public string Greeting(string name, int time)
        {
            return "Good morning to "+name+" "+time+"am";
        }

        //GET api/Route/Goodbye => "Have a nice day"
        [HttpGet]
        [Route("api/Route/Goodbye/{time}")]
        public string Goodbye(int time) 
        {
            return "Have a nice day";
        }

    }
}
