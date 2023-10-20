using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01641589Assignment1.Controllers
{
    public class GreetingsController : ApiController
    {
        /// <summary>
        /// input number, returns greetings message to number of people
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //GET api/Greetings/{id}
        //RETURN "Greetings to {id} people!"
        public string Get(int id)
        {
            return "Greetings to " + id + " people!";
        }



    }
}
