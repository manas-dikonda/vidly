using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public  CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customers = new Customers(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var validViewModel = new CustomerFormViewModel
                    {
                        Customers = viewModel.Customers,
                        MembershipTypes = _context.MembershipType.ToList()
                    };

                    return View("CustomerForm", validViewModel);
                }
                if(viewModel.Customers.Id == 0)
                    _context.Customers.Add(viewModel.Customers);
                else
                {
                    var customerInDb = _context.Customers.Single(c => c.Id == viewModel.Customers.Id);

                    customerInDb.Name = viewModel.Customers.Name;
                    customerInDb.birthday = viewModel.Customers.birthday;
                    customerInDb.MembershipTypeId = viewModel.Customers.MembershipTypeId;
                    customerInDb.isSubscribedToNewsLetter = viewModel.Customers.isSubscribedToNewsLetter;

                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Customer");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName, eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName), ve.ErrorMessage);
                    }
                }
                throw;
            }
           
        }

        // GET: Customer
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customers == null)
                return HttpNotFound();
            
            return View(customers);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            else
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customers = customer,
                    MembershipTypes = _context.MembershipType
                };
                return View("CustomerForm", viewModel);
            }
        }
    }
}