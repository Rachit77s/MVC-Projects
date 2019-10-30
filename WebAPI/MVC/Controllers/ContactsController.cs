using MVC.ErrorLog;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [LogCustomExceptionFilter]
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index()
        {
            IEnumerable<ContactModel> contactList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Contacts").Result;

            if (response.IsSuccessStatusCode)
            {
                contactList = response.Content.ReadAsAsync<IEnumerable<ContactModel>>().Result;
                return View(contactList);
            }

            else
            {
                TempData["SuccessMessage"] = "No data found";
                return View();
            }

            
        }

     
        // GET: ContactModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Contacts", contactModel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["SuccessMessage"] = "Saved Successfully";
                    }
                    
                    return RedirectToAction("Index");
               
            }
            else
            {
                TempData["SuccessMessage"] = "Please fill up the details correctly";
                return View();
            }
            
        }


        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Contacts/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                return View(response.Content.ReadAsAsync<ContactModel>().Result);
            }
            else
            {
                return View();
            }
        }

        // POST: ContactModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Contacts/" + id.ToString(), contactModel).Result;
     
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Updated Successfully";
                }
            }
            else
            {
                TempData["SuccessMessage"] = "Please fill up the details correctly";
                return View();
            }
               
            return RedirectToAction("Index");

        }

       
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Contacts/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                HttpResponseMessage errorMessage = new HttpResponseMessage(HttpStatusCode.NotModified);
                TempData["SuccessMessage"] = errorMessage.ToString();
                return View();
            }
            
        }
    }
}