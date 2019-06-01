using Dapper;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.ContainsKey("CategoryID"))
                    ModelState["CategoryID"].Errors.Clear();

                if (ModelState.IsValid)
                {
                    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString))
                    {
                        //Products product = db.QueryFirstOrDefault<Products>("EmployeeGet ", new { ProductName = products.ProductName }, commandType: CommandType.StoredProcedure);
                        const string sp = "SP_INSERT_CATEGORY";
                        var dynamicParameters = new DynamicParameters();
                        dynamicParameters.Add("CategoryName", category.CategoryName);
                        dynamicParameters.Add("Description", category.Description);
                        Category Category = db.QueryFirstOrDefault<Category>
                                            (sp, dynamicParameters, commandType: CommandType.StoredProcedure);
                    }

                    ModelState.Clear();

                    ViewBag.result = "Record Inserted Successfully!";

                }
              
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
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

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
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
