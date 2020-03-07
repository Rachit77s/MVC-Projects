using FiltersExample.DataAccess.Managers;
using FiltersExample.ViewModels.Home;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersExample.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        sqlConnection.Open();
        //        SqlCommand sqlCmd = new SqlCommand("Select * from Users", sqlConnection);

        //        SqlDataAdapter dadapter = new SqlDataAdapter(" select * from Users ", sqlConnection);
        //        DataSet dset = new DataSet(); //Creating instance of DataSet
        //        dadapter.Fill(dset, "Users"); // Filling the DataSet with the records returned by SQL statemetns written in sqldataadapter

               
        //       //string record = reader["Name"].ToString();
        //        sqlConnection.Close();
        //    }
        //    return View();
        //}

        [HttpGet]
         public ActionResult Index()
        {
            HomeIndexVM model = new HomeIndexVM();
            //Basically fetching all the users from the below class
            model.Users = UserManager.GetAll();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeIndexVM model)
        {
            Session["CurrentUserID"] = model.SelectedUser;
            TempData["FlashMessage"] = "You are now " + UserManager.GetByID(model.SelectedUser).Name + ".";
            return RedirectToAction("Index");
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