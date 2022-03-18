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

      public static int getRandomInt() => getRandom.Next(0, 10);

      public static string generatePassword(int length, bool isUpperCase = false, bool isLowerCase = true, bool isNumeric = false, bool specialChars = false)
      {
         if (length == 0) length = 20;
         StringBuilder sb = new();
         for (int i = 0; i < length; i++)
         {
            sb.Append(getRandomInt());
         }

         return sb.ToString();
      }


      #endregion Methods
   }
}
