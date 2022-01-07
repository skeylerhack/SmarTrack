﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OEE.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class OEEDataContext : DbContext
    {
        public OEEDataContext()
            : base("name=OEEDataContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<USER> USERS { get; set; }
        public DbSet<NHA_XUONG> NHA_XUONG { get; set; }
    
        public virtual ObjectResult<spGetData_Result> spGetData(Nullable<int> nNgu, string uSERNAME, string nXuong)
        {
            var nNguParameter = nNgu.HasValue ?
                new ObjectParameter("NNgu", nNgu) :
                new ObjectParameter("NNgu", typeof(int));
    
            var uSERNAMEParameter = uSERNAME != null ?
                new ObjectParameter("USERNAME", uSERNAME) :
                new ObjectParameter("USERNAME", typeof(string));
    
            var nXuongParameter = nXuong != null ?
                new ObjectParameter("NXuong", nXuong) :
                new ObjectParameter("NXuong", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetData_Result>("spGetData", nNguParameter, uSERNAMEParameter, nXuongParameter);
        }
    
        public virtual ObjectResult<spLCDFull_Result> spLCDFull()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spLCDFull_Result>("spLCDFull");
        }
    
        public virtual ObjectResult<spLCD_Result> spLCD()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spLCD_Result>("spLCD");
        }
    }
}