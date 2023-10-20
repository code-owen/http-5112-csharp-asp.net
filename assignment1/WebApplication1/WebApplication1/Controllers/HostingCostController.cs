using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01641589Assignment1.Controllers
{
    public class HostingCostController : ApiController
    {

        /// <summary>
        /// input number of hosting days, calculates price/FN, hst and total price, returns price 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        // RETURN # of fortnights at $5.50/FN = hosting cost
        // RETURN total hst of hosting cost
        // RETURN total price 
        // </returns>

        // GET api/HostingCost/{id}
        public IEnumerable<string> Get(int id)
        {
        // takes {id} / 14 rounds down to nearest whole number + 1
            double fortnights = Math.Floor((double)id / 14) + 1;
            double hostingCost = fortnights * 5.50;
            double hst = hostingCost * 0.13;
            double total = hostingCost + hst;
            string result1 = $"{fortnights} fortnights at $5.50/FN = ${hostingCost:0.00} CAD";
            string result2 = $"HST 13% = ${hst:0.00} CAD";
            string result3 = $"Total = ${total:0.00} CAD";

            return new string[] { result1, result2, result3 };

        }

    }
}
