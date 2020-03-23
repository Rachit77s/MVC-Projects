using InfrrdTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfrrdTest.Controllers
{
    public class SaveformController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // GET: Saveform
        public ActionResult Index()
        {
            FormModel formModel = new FormModel();
            List<CategoryModel> listCategoryModel = new List<CategoryModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    con.Open();
                    SqlCommand sqlCmd = new SqlCommand("Select CategoryID, CategoryName from Category", con);
                    SqlDataReader rdr = sqlCmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CategoryModel categoryModel = new CategoryModel();
                        categoryModel.CategoryID = Convert.ToInt32(rdr["CategoryID"]);
                        categoryModel.CategoryName = rdr["CategoryName"].ToString();
                        listCategoryModel.Add(categoryModel);
                    }
                    con.Close();
                }

                formModel.CategoryCollection = listCategoryModel.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(formModel);
        }

        [HttpPost]
        public ActionResult Index(FormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string query = $"INSERT INTO Detail(CategoryID,Year,Amount) " +
                                        $"VALUES( {model.CategoryID}, '{model.Year}', {model.Amount})";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            // opening connection  
                            con.Open();
                            // Executing insert query  
                            cmd.ExecuteNonQuery();

                            TempData["msg"] = " The data has been successfully saved !";
                        }
                    }
                }               
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public ActionResult Result()
        {
            try
            {
                IEnumerable<FormModel> listFormData = GetAllFormModel();

                var result = listFormData
                             .GroupBy(l => l.CategoryNameField)
                             .Select(cl => new SummaryModel
                             {
                                 Category = cl.Key.ToString(),
                                 Before2018 = cl.Where(y => Convert.ToDateTime(y.Year).Year < 2018).ToList().Sum(x => x.Amount),
                                 Year2018 = cl.Where(y => Convert.ToDateTime(y.Year).Year == 2018).ToList().Sum(x => x.Amount),
                                 Year2019 = cl.Where(y => Convert.ToDateTime(y.Year).Year == 2019).ToList().Sum(x => x.Amount),
                                 Year2020 = cl.Where(y => Convert.ToDateTime(y.Year).Year == 2020).ToList().Sum(x => x.Amount),
                                 After2020 = cl.Where(y => Convert.ToDateTime(y.Year).Year > 2020).ToList().Sum(x => x.Amount),
                                 Total = cl.Sum(c => c.Amount),
                             }).ToList();

                return View("Result", result);
            }
            catch (Exception ex)
            {
                throw ex;
            }                    
        }

        public IEnumerable<FormModel> GetAllFormModel()
        {
            try
            {
                List<FormModel> lstFormData = new List<FormModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    con.Open();
                    SqlCommand sqlCmd = new SqlCommand("SELECT D.DetailID, D.CategoryID, D.Year, D.Amount, C.CategoryName FROM Detail D INNER JOIN Category C ON C.CategoryID = D.CategoryID", con);

                    SqlDataReader rdr = sqlCmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FormModel form = new FormModel();
                        form.DetailID = Convert.ToInt32(rdr["DetailID"]);
                        form.CategoryID = Convert.ToInt32(rdr["CategoryID"]);
                        form.Year = rdr["Year"].ToString();
                        form.Amount = Convert.ToInt32(rdr["Amount"]);
                        form.CategoryNameField = rdr["CategoryName"].ToString();
                        lstFormData.Add(form);
                    }
                    con.Close();
                }
                return lstFormData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}



//private void MyFunc()
//{



//    MyFunc();

//    void MyFunc()
//    {
//        try
//        {

//            Convert.ToDateTime("04-03-2020");
//            Convert.ToDateTime("03-03-2016");
//            Convert.ToDateTime("08-01-2020");
//            Convert.ToDateTime("02-03-2020");
//            Convert.ToDateTime("04-03-2016");
//            Convert.ToDateTime("01-01-2015");
//            Convert.ToDateTime("04-03-2020");
//            Convert.ToDateTime("01-07-2016");
//            Convert.ToDateTime("21-08-2020");


//            DateTime.ParseExact("04-03-2020", "dd/MM/yyyy", CultureInfo.InvariantCulture);
//            DateTime.ParseExact("03-03-2016", "dd/MM/yyyy", CultureInfo.InvariantCulture);
//            DateTime.ParseExact("08-01-2020", "dd/MM/yyyy", CultureInfo.InvariantCulture);
//            DateTime.ParseExact("02-03-2020", "dd/MM/yyyy", CultureInfo.InvariantCulture);
//            DateTime.ParseExact("04-03-2016", "dd/MM/yyyy", CultureInfo.InvariantCulture);
//            DateTime.ParseExact("01-01-2015", "dd/MM/yyyy", CultureInfo.InvariantCulture);
//            DateTime.ParseExact("04-03-2020", "dd/MM/yyyy", CultureInfo.InvariantCulture);
//            DateTime.ParseExact("01-07-2016", "dd/MM/yyyy", CultureInfo.InvariantCulture);
//            DateTime.ParseExact("21-08-2020", "dd/MM/yyyy", CultureInfo.InvariantCulture);
//        }
//        catch (Exception ex)
//        {
//            MyFunc();
//            throw ex;
//        }
//    }

//}