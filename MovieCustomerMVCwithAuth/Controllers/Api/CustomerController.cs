using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieCustomerMVCwithAuth.Models;
using System.Data.Entity;

namespace MovieCustomerMVCwithAuth.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers()
        {

            var cust = _context.Customers.Include(q => q.MemberShipType).ToList();
            //return _context.Customers.ToList();
            if (cust==null)
                return BadRequest("cust not found!!!");
            return Ok(cust);
        }
        public IHttpActionResult GetCustomer(int id)
        {
            if (id <=0)
                return BadRequest("cust not in the db ~~");
            var customer = _context.Customers.Include(c=>c.MemberShipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                // throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            return Ok(customer); 
        }
        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest("model data invalid");
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }
                                                                                                                                                                                                                   
        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest("invalid data ~~");
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();
                // throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.Name = customer.Name;
            //customerInDb.BirthDate = customer.BirthDate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            _context.SaveChanges();
            return Ok();
        }
        //DELETE /api/customers/1
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (id <= 0)
                return BadRequest("Customer not found");
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
