using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01641589Assignment1.Controllers
{
    public class TestController : ApiController
    {

        //GET api/test -> "My first "Controller!
        public string Get(){
            return "My first Controller!";
     }


    }
}
