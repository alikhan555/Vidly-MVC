using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new Models.ApplicationDbContext();
        }
		
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            var Customers = _context.Customers.Include(C => C.MembershipType).SingleOrDefault(C => C.Id == id);
            if (Customers == null) return HttpNotFound();
            else return View(Customers);
        }

        
        public ActionResult New()
        {
            var newCustomerViewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipType = _context.MembershipType.ToList()
            };
            return View("CustomerForm", newCustomerViewModel);
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(C => C.Id==Id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList()
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipType.ToList()
                };

                return View("CustomerForm", ViewModel);
            }

            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerDB = _context.Customers.Single(c => c.Id == customer.Id);

                customerDB.Name = customer.Name;
                customerDB.BirthDate = customer.BirthDate;
                customerDB.MembershipTypeId = customer.MembershipTypeId;
                customerDB.IsSubcribedToNwesLatter = customer.IsSubcribedToNwesLatter;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

    }
}