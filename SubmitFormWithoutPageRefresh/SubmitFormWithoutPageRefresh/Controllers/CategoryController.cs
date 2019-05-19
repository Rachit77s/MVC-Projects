using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using SubmitFormWithoutPageRefresh.Models;

namespace SubmitFormWithoutPageRefresh.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString))
            {
                string SelectQuery = @"SELECT * FROM  [dbo].[CATEGORIES]";

                var result = db.Query(SelectQuery);
           
            return View(result);
            }
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
                        string insertQuery = @"INSERT INTO [dbo].[CATEGORIES]
                                               ([CategoryName]
                                               ,[Description])
                                                VALUES
                                               (	
			                                     @CategoryName
			                                    ,@Description
		                                       )";

                        var result = db.Execute(insertQuery, category);
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
