using DomainModels.Entities;
using DomainModels.ViewModels;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork _uow) : base(_uow)
        {

        }

        public ActionResult Index()
        {
            //Get all the Products
            //Protected Global var for all the Controllers: uow in BaseController
            IEnumerable<Product> data = uow.ProductRepository.GetAll();
            return View(data);
        }

        public ActionResult Create()
        {
            //Make sure you are passing Viewbag
            ViewBag.Categories = uow.CategoryRepository.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["CategoryException"] = $"Mandatory field missing";
                    ViewBag.Categories = uow.ProductRepository.GetAll();
                    return View();
                }

                string folderPath = "~/uploads/";
                bool exists = Directory.Exists(Server.MapPath(folderPath));
                if (!exists)
                {
                    Directory.CreateDirectory(Server.MapPath(folderPath));
                }

                string fileName = Path.GetFileName(model.file.FileName);
                string path = Path.Combine(Server.MapPath(folderPath), fileName);
                model.file.SaveAs(path);

                model.ImageName = fileName;
                model.ImagePath = "/uploads/" + fileName;

                Product product = new Product();
                product.ProductId = model.ProductId;
                product.Name = model.Name;
                product.UnitPrice = model.UnitPrice;
                product.CategoryId = model.CategoryId;
                product.Description = model.Description;
                product.ImagePath = model.ImagePath;
                product.ImageName = model.ImageName;

                uow.ProductRepository.Add(product);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["CategoryException"] = $"Exception occured while saving the details: {ex.ToString()}";
                //Make sure you are passing Viewbag
                ViewBag.Categories = uow.ProductRepository.GetAll();
                return View();
            }

        }
    }
}