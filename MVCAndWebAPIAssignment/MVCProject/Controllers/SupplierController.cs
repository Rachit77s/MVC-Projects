using DamcoEvaluation.Models;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    [LogCustomExceptionFilter]
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            IEnumerable<SupplierRateModel> supplierRateModel;
            //This is as good as URL: http://localhost:58000/api/Supplier
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Supplier").Result;

            if (response.IsSuccessStatusCode)
            {
                supplierRateModel = response.Content.ReadAsAsync<IEnumerable<SupplierRateModel>>().Result;
                return View(supplierRateModel);
            }
            else
            {
                TempData["SuccessMessage"] = "No data found";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ShowSuppliers()
        {                           
           return View();           
        }

        [HttpGet]
        public JsonResult GetSuppliersData()
        {
            IEnumerable<SupplierRateModel> supplierRateModel;
            //This is as good as URL: http://localhost:58000/api/Supplier/ShowSuppliers
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Supplier").Result;

            if (response.IsSuccessStatusCode)
            {
                supplierRateModel = response.Content.ReadAsAsync<IEnumerable<SupplierRateModel>>().Result;
                return Json( supplierRateModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                TempData["SuccessMessage"] = "No data found";
                return Json( new { error = TempData["SuccessMessage"] });
            }
        }

        [HttpGet]
        public JsonResult GetSuppliersDataAsync(int id = 0)
        {
            IEnumerable<SupplierRateModel> supplierRateModel;
            //This is as good as URL: http://localhost:58000/api/Supplier/ShowSuppliers
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Supplier/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                supplierRateModel = response.Content.ReadAsAsync<IEnumerable<SupplierRateModel>>().Result;
                return Json(supplierRateModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                TempData["SuccessMessage"] = "No data found";
                return Json(new { error = TempData["SuccessMessage"] });
            }
        }
    }
}