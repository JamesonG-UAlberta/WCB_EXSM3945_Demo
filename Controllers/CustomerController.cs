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
        public ActionResult Post(string fname, string lname)
        {
            if (string.IsNullOrWhiteSpace(fname) || string.IsNullOrWhiteSpace(lname))
            {
                return BadRequest();
            }
            try
            {
                _context.Customers.Add(new Customer() { FirstName = fname, LastName = lname });
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, string fname, string lname)
        {
            int providedID;
            Customer found;
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
                found = _context.Customers.Where(x => x.Id == providedID).Single();
            }
            catch
            {
                return NotFound();
            }
            try
            {
                found.FirstName = fname??found.FirstName;
                found.LastName = lname??found.LastName;
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch("{id}")]
        public ActionResult Patch(string id, string prop, string value)
        {
            int providedID;
            Customer found;
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
                found = _context.Customers.Where(x => x.Id == providedID).Single();
            }
            catch
            {
                return NotFound();
            }
            try
            {
                switch (prop)
                {
                    case "fname":
                        found.FirstName = value;
                        break;
                    case "lname":
                        found.LastName = value;
                        break;
                    default:
                        return BadRequest();
                }
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            int providedID;
            Customer found;
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
                found = _context.Customers.Where(x => x.Id == providedID).Single();
            }
            catch
            {
                return NotFound();
            }
            try
            {
                _context.Customers.Remove(found);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
