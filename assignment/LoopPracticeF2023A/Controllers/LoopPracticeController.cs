using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease;

namespace LoopPracticeF2023A.Controllers
{
    public class LoopPracticeController : Controller
    {
        //GET api/LoopPractice/WhileLoop/5 -> 1,2,3,4,5
        //GET api/LoopPractice/WhileLoop/10 -> 1,2,3,4,5,6,7,8,9,10

        /// <summary>
        /// This program receives an inpit limit and counts up to it
        /// </summary>
        /// <param name="limit">The number to count up to</param>
        /// <returns>
        /// a list of comma separated values starting from 1 to the limit
        /// </returns>
        [HttpGet]
        [Route("api/LoopPractice/WhileLoop/{limit}")]
        public string WhileLoop(int limit)
        {
            int start = 1;
            string message = "";
            int incrementor = start;
            string delimiter = ",";

            //the code will execut as long as incementor <= limit
            while(incrementor <= limit)
            {
                //execute this code over and over until the condition is false
                //how can we make it so there is no extra comma at the end?
                if (incrementor <= limit) 
                {
                    //if we are at the end of the loop, get rid of the ,
                    delimiter = "";
                }
                message = message + incrementor + delimiter;
                incrementor = incrementor + 1;
            }

            return message;
            
        }

        //For Loop Practice
        //Get api/LoopPractice/ForLoop/-8 -> "0,-1,-2,-3,-4,-5,-6,-7,-8"
        /// <summary>
        /// Receives an input limit and counts down to it
        /// </summary>
        /// <param name="Limit">the input limit value</param>
        /// <returns>a series of comma separate numners counting down from 0 to the limit</returns>
        [HttpGet]
        [Route("api/LoopPractice/ForLoop")]
        public string ForLoop(int limit)
        {
            string message = "";
            int start = 0;
            //starting value
            //exit condition
            //incrementing step

            for (int i=start; i>=limit; i-=1) 
            {
                message = message + i;
            }


            return message;
        }


        //For Loop Practice
        //Get api/LoopPractice/ForEachLoop
        /// <summary>
        /// Prints out a list of our favourtie movies
        /// </summary>
        /// <returns>
        /// Se7en, Frozen, Matrix, Sherlock Holmes, LOTR
        /// </returns>
        [HttpGet]
        [Route("api/LoopPractice/ForEachLoop")]
        public string ForEachLoop()
        {
            List<string> Movies = new List<string>();
            Movies.Add("Lego Movie"); 
            Movies.Add("Se7en");
            Movies.Add("Frozen");
            Movies.Add("Matrix");
            Movies.Add("Sherlock Holmes");
            Movies.Add("LOTR");

            string message = "";
            foreach (string item in Movies) 
            {
                message = message + Movies + ", ";
            }


            return "Foreach Loop";
        }
    }
}