using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.Models.ViewDataModel;

namespace Vidly2.Controllers
{
    public class CustomerController : Controller
    {
        public ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult CustomerForm()
        {
            var customerdatamodel = new CustomerViewDataModel()
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipType.ToList()
            };
            return View(customerdatamodel);
        }

        public ActionResult Edit(int id)
        {
            var customerdatamodel = new CustomerViewDataModel();
            var custindb = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (custindb == null)
                return new HttpNotFoundResult();
            customerdatamodel.Customer = custindb;
            customerdatamodel.MembershipTypes = _context.MembershipType.ToList();

            return View("CustomerForm", customerdatamodel);
        }
        public ActionResult Save(Customer Customer)
        {
            if (!ModelState.IsValid)
            {
                var customerdatamodel = new CustomerViewDataModel()
                {
                    Customer = Customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };
                return View("CustomerForm", customerdatamodel);
            }
            if (Customer.Id != 0)
            {
                var custindb = _context.Customer.SingleOrDefault(c => c.Id == Customer.Id);
                custindb.Birthdate = Customer.Birthdate;
                custindb.IsSubscribedToNewsletter = Customer.IsSubscribedToNewsletter;
                custindb.MembershipTypeId = Customer.MembershipTypeId;
                custindb.Name = Customer.Name;
                _context.SaveChanges();

            }
            else
            {
                _context.Customer.Add(Customer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}