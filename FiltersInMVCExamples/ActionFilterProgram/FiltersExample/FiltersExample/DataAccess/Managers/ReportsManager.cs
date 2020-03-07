using FiltersExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FiltersExample.DataAccess.Managers
{
    public class ReportsManager
    {
        public static List<Report> GetAll()
        {
            using (TestEntities context = new TestEntities())
            {
                return context.Reports.Include(x => x.User).OrderBy(x => x.Title).ToList();
            }
        }

        public static Report GetByID(int id)
        {
            using (TestEntities context = new TestEntities())
            {
                return context.Reports.Include(x => x.User).First(x => x.ReportID == id);
            }
        }
    }
}