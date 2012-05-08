using System.Web.Mvc;
using DataValidation.Common;
using DataValidation.Models;

namespace DataValidation.Controllers
{
    public class DataAnnotationsController : Controller
    {
        private readonly IDataAnnotationsRepository _repository;

        public DataAnnotationsController(IDataAnnotationsRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {

            return View(_repository);
        }

        public ActionResult New()
        {
            var instance = new DataAnnotation();
            return View("Create", instance);
        }

        public ActionResult Create(DataAnnotation model)
        {
            if(!ModelState.IsValid)
            {
                return View("Create", model);
            }

            _repository.Add(model);

            return RedirectToAction("Index");
        }

        public ActionResult Show(int id)
        {
            var item = _repository.Get(id);
            return View(item);
        }
    }
}