using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InfrrdTest.Models
{
    public class SummaryModel
    {
        [DisplayName("Category / Year")]
        public string Category { get; set; }

        [DisplayName("Before 2018")]
        public int Before2018 { get; set; }

        [DisplayName("2018")]
        public int Year2018 { get; set; }

        [DisplayName("2019")]
        public int Year2019 { get; set; }

        [DisplayName("2020")]
        public int Year2020 { get; set; }

        [DisplayName("After 2020")]
        public int After2020 { get; set; }

        public int Total { get; set; }
    }
}