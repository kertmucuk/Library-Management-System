﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBLibraryEntities : DbContext
    {
        public DBLibraryEntities()
            : base("name=DBLibraryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLAUTHOR> TBLAUTHOR { get; set; }
        public virtual DbSet<TBLBOOK> TBLBOOK { get; set; }
        public virtual DbSet<TBLCASE> TBLCASE { get; set; }
        public virtual DbSet<TBLCATEGORY> TBLCATEGORY { get; set; }
        public virtual DbSet<TBLEMPLOYEE> TBLEMPLOYEE { get; set; }
        public virtual DbSet<TBLMEMBERS> TBLMEMBERS { get; set; }
        public virtual DbSet<TBLPENALTIES> TBLPENALTIES { get; set; }
        public virtual DbSet<TBLPROCESS> TBLPROCESS { get; set; }
        public virtual DbSet<TBLABOUT> TBLABOUT { get; set; }
        public virtual DbSet<TBLContact> TBLContact { get; set; }
        public virtual DbSet<TBLUNIVERSITIES> TBLUNIVERSITIES { get; set; }
        public virtual DbSet<TBLMESSAGES> TBLMESSAGES { get; set; }
        public virtual DbSet<TBLAnnouncements> TBLAnnouncements { get; set; }
    }
}
