using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetDrinks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesAPiController : ControllerBase
    {
        // GET: api/<CategoriesAPiController>
        [HttpGet]
        public System.Collections.Generic.IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CategoriesAPiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesAPiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriesAPiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesAPiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
