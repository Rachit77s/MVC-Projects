using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBAPIMVC.Models;

namespace WEBAPIMVC.Services
{
    public interface IContact
    {
        IEnumerable<Contact> getAll();

       // void Save();
        void Insert(Contact contact);
        void Delete(int id);
        void Update(Contact contact);
        Contact getById(int id);

    }
}
