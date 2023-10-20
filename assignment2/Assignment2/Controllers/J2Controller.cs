using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;

namespace Assignment2.Controllers
{
    
    public class J2Controller : ApiController
    {
        /// <summary>
        /// CCC 2015 J2 Question
        /// Input a string with happy (:-)) and sad (:-() emoticons. Counts number of happy and sad emoticons
        /// and returns result
        /// </summary>
        /// <param name="input">Sentence or random characters containing emoticons</param>
        /// <returns>
        /// A string based on if happy emoticons is greater, equal to, or less than sad emoticons
        /// Happy > Sad = "happy"
        /// Happy = Sad = "unsure"
        /// Happy < Sad = "sad"
        /// No emoticons = "none"
        /// </returns>
        /// <example>
        /// api/J2?input=How are you :-) doing :-( today :-)?  --> happy
        /// api/J2?input=:)  --> none
        /// api/J2?input=This:-(is str:-(:-(ange te:-)xt.  --> sad
        /// api/J2?input=:-) Happy :-( Sad :-) Happy :-( Sad  --> unsure
        /// </example>
        //api/j2?input=How are you :-) doing :-( today :-)?
        //GET: J2
        [HttpGet]
        //[Route("api/J2/HappyorSad/{string}")]
        //public string HappyOrSad(string input)
        
        //[FromUri] attribute that specifies an action is coming from the URL
        public string HappyOrSad([FromUri] string input)
        {
            int happyCount = 0;
            int sadCount = 0;
            //checks string for emoticons and adds to count
            for (int i = 0; i<input.Length-2; i++)
            {
                if (input[i] ==':' && input[i+1] =='-' && input[i+2] ==')')
                {
                    happyCount++;
                }
                else if (input[i] ==':' && input[i+1] =='-' && input[i+2] =='(')
                {
                    sadCount++;
                }
            }
            //compares counts and returns result
            if (happyCount == 0 && sadCount == 0)
            {
                return "none";
            }
            else if (happyCount == sadCount)
            {
                return "unsure";
            }
            else if (happyCount > sadCount)
            {
                return "happy";
            }
            else
            {
                return "sad";
            }
        }
    }
}
