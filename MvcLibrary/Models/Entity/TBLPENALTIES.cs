//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcLibrary.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLPENALTIES
    {
        public int ID { get; set; }
        public Nullable<int> Member { get; set; }
        public Nullable<int> Process { get; set; }
        public Nullable<System.DateTime> Starttime { get; set; }
        public Nullable<System.DateTime> Endtime { get; set; }
        public Nullable<decimal> Charge { get; set; }
    
        public virtual TBLMEMBERS TBLMEMBERS { get; set; }
        public virtual TBLPROCESS TBLPROCESS { get; set; }
    }
}
