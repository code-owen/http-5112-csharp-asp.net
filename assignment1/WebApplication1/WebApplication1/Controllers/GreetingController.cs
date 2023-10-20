using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01641589Assignment1.Controllers
{
    public class GreetingController : ApiController
    {
        // POST api/Greeting
        // returns error message "The requested resource does not support http method 'GET'".
        // the default request when going to api/Greeting is a GET request which is why we get an error message
        // Using command prompt curl -d "" "http://localhost:44354/api/Greeting" returns the string "Hello World!"
        public string Post()
        {
            return "Hello World!";
        }
        
        

    }
}
