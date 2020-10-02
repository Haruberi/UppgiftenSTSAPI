using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UppgiftenSTSAPI.Context;
using UppgiftenSTSAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UppgiftenSTSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DormsController : ControllerBase
    {
        private readonly STSApplicationDBContext _context;

        public DormsController(STSApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/<DormsController>
        [HttpGet]
        public IEnumerable<Dorm> Get()
        {
            return _context.dorms.Include(d => d.students).ToArray();
        }

        // GET api/<DormsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DormsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DormsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DormsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
