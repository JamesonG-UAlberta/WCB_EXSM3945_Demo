using API_Demo.Data;
using API_Demo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public CustomerController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _context.Customers.ToArray();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(string id)
        {
            int providedID;
            try
            {
                providedID = int.Parse(id);
            }
            catch
            {
                return BadRequest();
            }
            try
            {
                Customer found = _context.Customers.Where(x => x.Id == providedID).Single();
                return found;
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post(string fname, string lname)
        {

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, string fname, string lname)
        {

        }

        [HttpPatch("{id}")]
        public void Patch(int id, string prop, string value)
        {

        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
