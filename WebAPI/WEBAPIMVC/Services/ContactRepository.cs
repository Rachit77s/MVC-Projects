using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPIMVC.Models;

namespace WEBAPIMVC.Services
{
    public class ContactRepository : IContact
    {
        //Dependency Injection
        private readonly RachitTestEntities _context;

        public ContactRepository(RachitTestEntities context)
        {
            _context = context;
        }


        public void Delete(int id)
        {
            Contact contactDelete = getById(id);

            if (contactDelete == null)
            {
                return ;
            }

            _context.Contacts.Remove(contactDelete);
            _context.SaveChanges();

            //throw new NotImplementedException();
        }

        public IEnumerable<Contact> getAll()
        {
            return _context.Contacts.ToList();
            //throw new NotImplementedException();
        }

        public Contact getById(int id)
        {
            return _context.Contacts.Where(a => a.Id == id).SingleOrDefault();
            //throw new NotImplementedException();
        }

        public void Insert(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();

            //throw new NotImplementedException();
        }

        public void Update(Contact contact)
        {
           
            try
            {
                _context.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }

            //throw new NotImplementedException();
        }
    }
}