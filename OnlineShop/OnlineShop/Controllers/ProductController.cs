using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using OnlineShop.Models;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Insert New Product";

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString))
            {
                var CategoryType = db.Query<Category>("select * from CATEGORIES", null).ToList();

                var viewModel = new ProductCategoryViewModel
                {
                    Category = CategoryType
                };
                return View("Create", viewModel);
            }
        }

        // POST: Product/Create
        [HttpPost] 
        public ActionResult Create(Products products )
        {
            try
            {
                if(ModelState.ContainsKey("products.ProductID"))
                    ModelState["products.ProductID"].Errors.Clear();
                ModelState.Remove("products.ProductID");

                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);

                if (ModelState.IsValid)
                {
                    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString))
                    {
                        //Products product = db.QueryFirstOrDefault<Products>("EmployeeGet ", new { ProductName = products.ProductName }, commandType: CommandType.StoredProcedure);
                        const string sp = "SP_INSERT_PRODUCTS";
                        var dynamicParameters = new DynamicParameters();
                        dynamicParameters.Add("@ProductName"      , products.ProductName);
                        dynamicParameters.Add("@CategoryID"       , products.CategoryID);
                        dynamicParameters.Add("@QuantityPerUnit"  , products.QuantityPerUnit);
                        dynamicParameters.Add("@UnitPrice"        , products.UnitPrice);
                        dynamicParameters.Add("@UnitsInStock"     , products.UnitsInStock);
                        dynamicParameters.Add("@UnitsOnOrder"     , products.UnitsOnOrder);

                        Products prod = db.QueryFirstOrDefault<Products>
                                            (sp, dynamicParameters, commandType: CommandType.StoredProcedure);
                    }

                    ModelState.Clear();

                    ViewBag.result = "Product Inserted Successfully!";
                }

                //return RedirectToAction("Index");
                return View();
            }
            catch
            {
                
                //var viewModel = new ProductCategoryViewModel
                //{
                //    Category = 
                //};
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
