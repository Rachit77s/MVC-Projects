using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index()
        {
            IEnumerable<ContactModel> contactList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Contacts").Result;
            contactList = response.Content.ReadAsAsync<IEnumerable<ContactModel>>().Result;

            return View(contactList);
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
                try
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Contacts", contactModel).Result;
                    TempData["SuccessMessage"] = "Saved Successfully";
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Contacts/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<ContactModel>().Result);
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
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            else
            {

            }
               

            return RedirectToAction("Index");

        }



        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Contacts/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}