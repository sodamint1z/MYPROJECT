﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaknampoScale.src.model.entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PaknampoScaleDBEntities : DbContext
    {
        public PaknampoScaleDBEntities()
            : base("name=PaknampoScaleDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LOGIN_STATUS> LOGIN_STATUS { get; set; }
        public virtual DbSet<MST_AMPHURES> MST_AMPHURES { get; set; }
        public virtual DbSet<MST_BUSINESS> MST_BUSINESS { get; set; }
        public virtual DbSet<MST_CAR_REGISTERTION> MST_CAR_REGISTERTION { get; set; }
        public virtual DbSet<MST_CUSTOMER> MST_CUSTOMER { get; set; }
        public virtual DbSet<MST_CUSTOMER_SERVICE> MST_CUSTOMER_SERVICE { get; set; }
        public virtual DbSet<MST_DATA_BASIC> MST_DATA_BASIC { get; set; }
        public virtual DbSet<MST_DESTINATION> MST_DESTINATION { get; set; }
        public virtual DbSet<MST_DISTRICTS> MST_DISTRICTS { get; set; }
        public virtual DbSet<MST_GEOGRAPHIES> MST_GEOGRAPHIES { get; set; }
        public virtual DbSet<MST_LINE_DOWN> MST_LINE_DOWN { get; set; }
        public virtual DbSet<MST_MENU> MST_MENU { get; set; }
        public virtual DbSet<MST_MOISTURE> MST_MOISTURE { get; set; }
        public virtual DbSet<MST_PRODUCT> MST_PRODUCT { get; set; }
        public virtual DbSet<MST_PRODUCT_UNIT> MST_PRODUCT_UNIT { get; set; }
        public virtual DbSet<MST_PROVINCES> MST_PROVINCES { get; set; }
        public virtual DbSet<MST_SERVICE_CHARGE> MST_SERVICE_CHARGE { get; set; }
        public virtual DbSet<MST_VENDOR> MST_VENDOR { get; set; }
        public virtual DbSet<STS_SERIAL_PORT> STS_SERIAL_PORT { get; set; }
        public virtual DbSet<USER_LOGIN> USER_LOGIN { get; set; }
        public virtual DbSet<VW_MST_CAR_REGISTERTION> VW_MST_CAR_REGISTERTION { get; set; }
        public virtual DbSet<VW_MST_CUSTOMER> VW_MST_CUSTOMER { get; set; }
        public virtual DbSet<VW_MST_DESTINATION> VW_MST_DESTINATION { get; set; }
        public virtual DbSet<VW_MST_PRODUCT> VW_MST_PRODUCT { get; set; }
        public virtual DbSet<VW_MST_VENDOR> VW_MST_VENDOR { get; set; }
        public virtual DbSet<REGISTER> REGISTERs { get; set; }
    }
}
