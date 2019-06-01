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
    public class HomeController : Controller
    {
        // GET: Products  
        public ActionResult Index()
        {
            List<Products> ProductsList = new List<Products>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString))
            {
                ProductsList = db.Query<Products>("Select * From PRODUCTS").ToList();
            }
           
            return View(ProductsList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Insert New Movie";
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString))
            //{
            //    Products product = db.QueryFirstOrDefault<Products>("EmployeeGet ", new { ProductName = products.ProductName }, commandType: CommandType.StoredProcedure);
            //}
            return View();
        }


        [HttpPost]
        // Create New: Products  
        public  ActionResult Create(Products products)
        {
            List<Products> Products = new List<Products>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString))
            {
                //Products product = db.QueryFirstOrDefault<Products>("EmployeeGet ", new { ProductName = products.ProductName }, commandType: CommandType.StoredProcedure);
                const string sp = "GET_OPTICAL_ORDER_XML_TO_SUBMIT_LAB";
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("ORDER_ID", products.ProductName);
                Products product =  db.QueryFirstOrDefault<Products>
                                    (sp, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
           
            return View(Products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}