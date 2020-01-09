using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Dto;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class CustomersController : ApiController
    {
        public ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IHttpActionResult GetCustomers()
        {
            var customerdto = _context.Customer.Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerdto);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var custindb = _context.Customer.SingleOrDefault(c => c.Id == id);
            if(custindb==null)
                return NotFound();

            var customerdto = Mapper.Map<Customer, CustomerDto>(custindb);
            return Ok(customerdto);
        }

        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customer.Add(customer);
            _context.SaveChanges();
            //customerDto.
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }
    }
}
