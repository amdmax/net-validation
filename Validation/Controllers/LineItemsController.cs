using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataValidation.Common;
using DataValidation.Models;
using DataValidation.ViewModels;

namespace DataValidation.Controllers
{
    public class LineItemsController : Controller
    {
        private readonly ILineItemRepository _repository;
        private readonly IMapper _mapper;

        public LineItemsController(ILineItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //
        // GET: /LineItems/

        public ActionResult Index()
        {
            var items = _repository.ToList();
            var viewModel = _mapper.Map<List<LineItem>, List<LineItemViewModel>>(items);
            return View(viewModel);
        }

        //
        // GET: /LineItems/Details/5

        public ActionResult Show(int id)
        {
            var lineItem = _repository.Get(id);
            var viewModel = _mapper.Map<LineItem, LineItemViewModel>(lineItem);

            return View(viewModel);
        }

        //
        // GET: /LineItems/Create

        public ActionResult New()
        {
            var viewModel = new LineItemViewModel();
            return View("Create", viewModel);
        }

        //
        // POST: /LineItems/Create

        [HttpPost]
        public ActionResult Create(LineItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return View("Create", viewModel);
            }

            // We usually try to get rid of this roundtrip to the database / services using different approaches
            var lineItem = _repository.Get(viewModel.Id) ?? new LineItem();
            _mapper.Map(viewModel, lineItem);

            if(lineItem.Id == 0)
            {
                _repository.Add(lineItem);
            }
            // we override values in actual line item with those obtained from the UI

            return RedirectToAction("Index");
        }

        //
        // GET: /LineItems/Edit/5

        public ActionResult Edit(int id)
        {
            var lineItem = _repository.Get(id);
            var viewModel = _mapper.Map<LineItem, LineItemViewModel>(lineItem);
            return View("Create", viewModel);
        }
    }
}
