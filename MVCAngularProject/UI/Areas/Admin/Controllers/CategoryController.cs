using DomainModels.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        //Call BaseController Constructor to inject dependency
        public CategoryController(IUnitOfWork _uow) : base(_uow)
        {

        }

        public ActionResult Index()
        {
            //Get all the categories
            //Protected Global var for all the Controllers: uow in BaseController
            IEnumerable<Category> data = uow.CategoryRepository.GetAll();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["CategoryException"] = $"Mandatory field missing";
                    return View();
                }

                uow.CategoryRepository.Add(model);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["CategoryException"] = $"Exception occured while saving the details: {ex.ToString()}";
                return View();
            }

        }
    }
}