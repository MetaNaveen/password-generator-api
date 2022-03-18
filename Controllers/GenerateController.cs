using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace password_generator_api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class GenerateController : ControllerBase
   {

      #region Static members --------------------------------------------------

      private static readonly Random getRandom = new Random();
      private static readonly String UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      private static readonly String LOWER_CASE = "abcdefghijklmnopqrstuvwxyz";
      private static readonly String SPECIAL_CHARS = "!@#$%^&*()";

      #endregion

      // GET: api/<GenerateController>
      [HttpGet]
      public ActionResult Get([FromQuery] int length, [FromQuery] bool isUpperCase, [FromQuery] bool isLowerCase, [FromQuery] bool isNumeric, [FromQuery] bool isSpecial)
      {
         try
         {
            object ob = new
            {
               Message = "Success",
               Password = generatePassword(length, isUpperCase, isLowerCase, isNumeric, isSpecial)
            };
            return Ok(ob);
         } catch(Exception ex)
         {
            return StatusCode(500, ex.Message);
         }
      }

      // GET api/<GenerateController>/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
         return "value";
      }

      // POST api/<GenerateController>
      [HttpPost]
      public void Post([FromBody] string value)
      {
      }

      #region Methods ----------------------------------------------------------

      public static int getRandomInt(int start = 0, int end = 10) => getRandom.Next(start, end);
      public static char getRandomUpperCase() => UPPER_CASE[getRandomInt(0, 26)];
      public static char getRandomLowerCase() => LOWER_CASE[getRandomInt(0, 26)];
      public static char getRandomSpecialCase() => SPECIAL_CHARS[getRandomInt(0, 10)];

      public static string generatePassword(int length, bool isUpperCase = false, bool isLowerCase = true, bool isNumeric = false, bool isSpecialChars = false)
      {
         if (length == 0) length = 20;
         List<string> conditions = new();
         if (isUpperCase) conditions.Add("UPPER_CASE");
         if (isLowerCase) conditions.Add("LOWER_CASE");
         if (isNumeric) conditions.Add("NUMERICS");
         if (isSpecialChars) conditions.Add("SPECIAL_CHARS");

         StringBuilder sb = new();
         for (int i = 0; i < length; i++)
         {
            string randomChoice = conditions[getRandom.Next(0, conditions.Count())];
            switch (randomChoice)
            {
               case "NUMERICS": 
                  sb.Append(getRandomInt()); break;
               case "UPPER_CASE":
                  sb.Append(getRandomUpperCase()); break;
               case "LOWER_CASE":
                  sb.Append(getRandomLowerCase()); break;
               case "SPECIAL_CHARS":
                  sb.Append(getRandomSpecialCase()); break;
               default:
                  sb.Append(getRandomInt()); break;
            }
         }

         return sb.ToString();
      }


      #endregion Methods
   }
}
