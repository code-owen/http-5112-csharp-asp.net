using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01641589Assignment1.Controllers
{
    /// <summary>
    /// input a number, adds 10 to that number and returns the sum
    /// </summary>
    // GET api/AddTen/{id}
    // RETURN sum
    public class AddTenController : ApiController
    {
        public int Get(int id)
        {
            int sum = id + 10;
            return sum;
        
        }
        


    }
}
