using System.Collections.Generic;
using System.Web.Mvc;
using DataValidation.Common;
using DataValidation.Models;

namespace DataValidation.Controllers
{
    public class CustomerEntitiesController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerEntitiesController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //
        // GET: /CustomerEntities/

        public ActionResult Index()
        {
            ICollection<Customer> collection = _customerRepository;
            return View(collection);
        }

        //
        // GET: /CustomerEntities/Details/5

        public ActionResult Show(int id)
        {
            var customer = _customerRepository.Get(id);
            return View("Show", customer);
        }

        //
        // GET: /CustomerEntities/Create

        public ActionResult New()
        {
            var customer = new Customer();
            return View("Create", customer);
        } 

        //
        // POST: /CustomerEntities/Create

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", customer);
            }

            _customerRepository.Add(customer);

            return RedirectToAction("Index");

        }
        
        //
        // GET: /CustomerEntities/Edit/5
 
        public ActionResult Edit(int id)
        {
            var customer = _customerRepository.Get(id);
            return View("Create", customer);
        }
    }
}
