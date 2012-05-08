using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataValidation.Common;
using DataValidation.Models;
using DataValidation.ViewModels;

namespace DataValidation.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            var items = _repository.ToList();
            var viewModel = _mapper.Map<List<Customer>, List<CustomerViewModel>>(items);
            return View(viewModel);
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Show(int id)
        {
            var lineItem = _repository.Get(id);
            var viewModel = _mapper.Map<Customer, CustomerViewModel>(lineItem);

            return View(viewModel);
        }

        //
        // GET: /Customer/Create
        
        public ActionResult New()
        {
            return View("Create", new CustomerViewModel());
        } 

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(CustomerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return View("Create", viewModel);
            }

            // We usually try to get rid of this roundtrip to the database / services using different approaches
            var lineItem = _repository.Get(viewModel.Id) ?? new Customer();
            _mapper.Map(viewModel, lineItem);

            if (lineItem.Id == 0)
            {
                _repository.Add(lineItem);
            }
            // we override values in actual line item with those obtained from the UI

            return RedirectToAction("Index");

        }
        
        //
        // GET: /Customer/Edit/5
 
        public ActionResult Edit(int id)
        {
            var lineItem = _repository.Get(id);
            var viewModel = _mapper.Map<Customer, CustomerViewModel>(lineItem);

            return View("Create", viewModel);
        }
    }
}
