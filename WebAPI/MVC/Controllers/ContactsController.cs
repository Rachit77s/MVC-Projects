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
        public ActionResult AddOrEdit(int id = 0)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrEdit()
        {
            return View();
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
                    // _Icontact.Insert(contactModel);
                    //_Icontact.Save();
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Contacts", contactModel).Result;
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

            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Contacts/" + id.ToString(), contactModel).Result;

            return RedirectToAction("Index");

        }


    }
}