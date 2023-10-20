using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J3Controller : ApiController
    {
        /// <summary>
        /// CCC 2013 J3 Question
        /// Input a year between 0 and 10000, return the next year greater than the input with unique digits
        /// </summary>
        /// <param name="year">Any year between 0 and 10000</param>
        /// <returns>
        /// Next year with unique digits
        /// </returns>
        /// <example>
        /// GET api/J3/UniqueYear/1987 -> 2013
        /// GET api/J3/UniqueYear/999 -> 1023
        /// </example>
        [HttpGet]
        [Route("api/J3/UniqueYear/{year}")]

        //Checks if input is between 0 and 10000. If true calls FindNextYear
        public int UniqueYear(int year)
        {
            if (year>0 && year<10000)
            {
                int nextYear = FindNextYear(year);
                return nextYear;
            }
           else 
                return 0;
        }
        //Increments year by 1 and checks if year has unique digits against HasDistinctDigit method
        private int FindNextYear(int startYear) 
        {
            int year = startYear + 1;
            while (!HasDistinctDigit (year))
            {
                year++;   
            }
            return year;
        }
        //Checks if digits are unique
        //Converts year to a string and compares pairs of digits 
        //If 2 digits are equal, return false, keep incrementing year until true
        //If true year has unique digits
        private bool HasDistinctDigit(int year)
        {
            string yearStr = year.ToString ();
            for (int i = 0; i < yearStr.Length; i++)
            {
                for (int j = i+1; j < yearStr.Length; j++)
                {
                    if (yearStr[i] == yearStr[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
