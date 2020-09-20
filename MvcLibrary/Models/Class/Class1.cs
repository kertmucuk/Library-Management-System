using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.Models.Entity;

namespace MvcLibrary.Models.Class
{
    public class Class1
    {
        public IEnumerable<TBLBOOK> bookprop { get; set; }
        public IEnumerable<TBLABOUT> aboutprop { get; set; }

        public IEnumerable<TBLMEMBERS> memberprop { get; set; }
        public IEnumerable<TBLUNIVERSITIES> uniprop { get; set; }
    }
}