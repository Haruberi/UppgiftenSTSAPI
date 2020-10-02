using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UppgiftenSTSAPI.Context;
using UppgiftenSTSAPI.Entities;
using UppgiftenSTSAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UppgiftenSTSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarsController : ControllerBase
    {
        private readonly STSApplicationDBContext _context;

        public SeminarsController(STSApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/<SeminarsController>
        [HttpGet]
        public IEnumerable<Paymentmethod> Get()
        {
            return _context.paymentmethods.Include(o => o.seminar).ToArray<Paymentmethod>();
        }

        // GET api/<SeminarsController>/5
        [HttpGet("{id}")]
        public Paymentmethod Get(int id)
        {
            var paymentmethod = _context.paymentmethods.Where(o => o.id == id).FirstOrDefault();
            if (paymentmethod != null)
            {
                return paymentmethod;
            }
            else
            {
                return null;
            }
        }

        // POST api/<SeminarsController>
        [HttpPost]
        public void Post([FromBody] SeminarViewModel seminar)
        {
            _context.seminars.Add(new Seminar { seminarname = seminar.name, SeminarOfPaymentmethodId = seminar.paymentmethodId });
            _context.SaveChanges();
        }

        // PUT api/<SeminarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SeminarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var paymentmethod = new Paymentmethod { id = id };
            _context.paymentmethods.Attach(paymentmethod);
            _context.paymentmethods.Remove(paymentmethod);
            _context.SaveChanges();
        }
    }
}
