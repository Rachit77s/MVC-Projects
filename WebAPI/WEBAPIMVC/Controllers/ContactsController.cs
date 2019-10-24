﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WEBAPIMVC.Models;
using WEBAPIMVC.Services;

namespace WEBAPIMVC.Controllers
{
    public class ContactsController : ApiController
    {
        //private RachitTestEntities db = new RachitTestEntities();

            //For injecting dependency
        private readonly IContact _Icontact;

        //public ContactsController()
        //{
            
        //}

        public ContactsController(IContact Icontact)
        {
            _Icontact = Icontact;
        }

        // GET: api/Contacts
        public IEnumerable<Contact> GetContacts()
        {
            //return db.Contacts;
            return _Icontact.getAll();
           //return View(a);
        }

        // GET: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact(int id)
        {
            Contact cont = _Icontact.getById(id);
            if (cont == null)
            {
                return NotFound();
            }

            return Ok(cont);
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.Id)
            {
                return BadRequest();
            }

            //db.Entry(contact).State = EntityState.Modified;          

            try
            {
                _Icontact.Update(contact);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contacts
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Contacts.Add(contact);
            //db.SaveChanges();


            _Icontact.Insert(contact);

            return CreatedAtRoute("DefaultApi", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = _Icontact.getById(id);
            if (contact == null)
            {
                return NotFound();
            }

            //db.Contacts.Remove(contact);
            //db.SaveChanges();

            _Icontact.Delete(id);

            return Ok(contact);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _Icontact.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool ContactExists(int id)
        {
            bool returnVariable = true;
            var conExist = _Icontact.getById(id);

            if (conExist == null)
            {
                returnVariable = false;
            }
            return returnVariable;
            //return _Icontact.Contacts.Count(e => e.Id == id) > 0;
        }
    }
}