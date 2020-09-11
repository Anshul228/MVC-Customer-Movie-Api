using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MovieCustomerMVCwithAuth.Models;
using MovieCustomerMVCwithAuth.ViewModel;

namespace MovieCustomerMVCwithAuth.Controllers
{
  // [Authorize]
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Customer
        
       // [Authorize(Roles = "CanManageMovies")]//or else create diff view for guest and admin
        public ActionResult Index()
        {
            //var cust = _context.Customers.Include(m=>m.MemberShipType).ToList();
            //return View(cust);
            
            IEnumerable<Customer> customers;
            HttpResponseMessage rp = GlobalVariables.webApiClient.GetAsync("Customer").Result;
            customers = rp.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            return View(customers);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Details(int id)
        {
            //var singlecust = _context.Customers.Include(q=>q.MemberShipType).SingleOrDefault(c => c.Id == id);
            //if (singlecust == null) 
            //{
            //    return HttpNotFound();
            //}

            //return View(singlecust);
            HttpResponseMessage httpResponse = GlobalVariables.webApiClient.GetAsync($"Customer/{id}").Result;
            Customer singlecust;
            singlecust = httpResponse.Content.ReadAsAsync<Customer>().Result;
            return View(singlecust);
        }
        //public ActionResult Create()
        //{
        //    var membershipTypes = _context.MemberShipTypes.ToList();
        //    var viewModel = new NewCustViewModel
        //    {
        //        MemberShipTypes = membershipTypes
        //    };
        //    return View(viewModel);
        //}
        //[HttpPost]
        // public ActionResult Create(Customer customer)
        //  {
        //  _context.Customers.Add(customer);
        //    _context.SaveChanges();
        //    return RedirectToAction("index", "Customer");
        //}
       
        public ActionResult Delete(int id)
        {
            Customer c = _context.Customers.Find(id);
            //_context.Customers.Find(id);
            _context.Customers.Remove(c);
            _context.SaveChanges();
            return RedirectToAction("index","Customer");
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            HttpResponseMessage mresponse = GlobalVariables.webApiClient.GetAsync("MemberShipApi").Result;
            var membershipTypes = mresponse.Content.ReadAsAsync<IEnumerable<MemberShipType>>().Result;
            HttpResponseMessage cresponse = GlobalVariables.webApiClient.GetAsync("Customers").Result;
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustViewModel
                {

                    MemberShipTypes = membershipTypes


                };

                return View("New", viewModel);
            }

            if (customer.Id == 0)
                cresponse = GlobalVariables.webApiClient.PostAsJsonAsync("Customers", customer).Result;
            else
            {
                cresponse = GlobalVariables.webApiClient.PutAsJsonAsync($"Customers/{customer.Id}", customer).Result;
            }

            return RedirectToAction("Index");
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new NewCustViewModel
            //    {
            //        Customer = customer,
            //        MemberShipTypes = _context.MemberShipTypes.ToList()

            //    };
            //    return View("New",viewModel);
            //}
            //if (customer.Id == 0)
            //    _context.Customers.Add(customer);
            //else
            //{
            //var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            // customerInDb.BirthDate = customer.BirthDate;
            //    customerInDb.MembershipTypeId = customer.MembershipTypeId;
            //    customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            //}
            //_context.SaveChanges();
            //return RedirectToAction("Index", "Customer");
        }
        public ActionResult Edit(int id)
        {
            HttpResponseMessage mr = GlobalVariables.webApiClient.GetAsync("MemberShipApi").Result;
            HttpResponseMessage cr = (GlobalVariables.webApiClient.GetAsync($"Customer/{id}")).Result;
            var vm = new NewCustViewModel
            {
                Customer = cr.Content.ReadAsAsync<Customer>().Result,
                MemberShipTypes=mr.Content.ReadAsAsync<IEnumerable<MemberShipType>>().Result
            };
            return View("new", vm);
            //var updateCast = _context.Customers.SingleOrDefault(c => c.Id == id);
            //if (updateCast == null)
            //{
            //    return HttpNotFound();
            //}
            //var vm = new NewCustViewModel
            //{
            //    Customer = updateCast,
            //    MemberShipTypes = _context.MemberShipTypes.ToList()
            //};
            //return View("New", vm);
        }
        public ActionResult New()
        {
            //var membershipTypes = _context.MemberShipTypes.ToList();
            //var ViewModel = new NewCustViewModel
            //{
            //    MemberShipTypes = membershipTypes
            //};
            //        return View(ViewModel);
            HttpResponseMessage mresponse = GlobalVariables.webApiClient.GetAsync("MemberShipApi").Result;

            var membershipTypes = mresponse.Content.ReadAsAsync<IEnumerable<MemberShipType>>().Result;

            var viewModel = new NewCustViewModel

            {
                Customer = new Customer(),
                MemberShipTypes = membershipTypes
            };

            return View("New",viewModel);
        }

    }
}