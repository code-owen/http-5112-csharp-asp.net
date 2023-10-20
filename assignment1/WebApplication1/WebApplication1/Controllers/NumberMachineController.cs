using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01641589Assignment1.Controllers
{
    public class NumberMachineController : ApiController
    {
        /// <summary>
        /// input number, number goes through equation with 4 different operators, returns result
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //GET api/NumberMachine/{id}
        //RETURN result
        public int Get(int id)
        {
            int result = (((id + 5) * 5) - 20) / 2;
        
            return result;
        }

        }
}
