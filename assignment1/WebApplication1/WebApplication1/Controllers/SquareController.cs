using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01641589Assignment1.Controllers
{
    public class SquareController : ApiController
    {
        /// <summary>
        /// input number, multiplies number by itself to get the square, returns result 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/Square/{id}
        // RETURN square
        public int Get(int id)
        {
            int square = id * id;
            return square;
        }

    }
}
