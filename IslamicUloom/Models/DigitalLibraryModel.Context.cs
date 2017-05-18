﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IslamicUloom.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DigitalLibraryEntities : DbContext
    {
        public DigitalLibraryEntities()
            : base("name=DigitalLibraryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Abwaab> Abwaabs { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<BookMark> BookMarks { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<LogInfo> LogInfoes { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    
        public virtual ObjectResult<sp_GetPageByPageNumber_Result> sp_GetPageByPageNumber(Nullable<int> pageNumber)
        {
            var pageNumberParameter = pageNumber.HasValue ?
                new ObjectParameter("PageNumber", pageNumber) :
                new ObjectParameter("PageNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetPageByPageNumber_Result>("sp_GetPageByPageNumber", pageNumberParameter);
        }
    
        public virtual ObjectResult<sp_GetPagesByBookId_Result> sp_GetPagesByBookId(Nullable<int> bookId)
        {
            var bookIdParameter = bookId.HasValue ?
                new ObjectParameter("BookId", bookId) :
                new ObjectParameter("BookId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetPagesByBookId_Result>("sp_GetPagesByBookId", bookIdParameter);
        }
    
        public virtual int sp_InsertPage(Nullable<int> bookId, Nullable<double> pageNumberOrder, string pageDetails, string pageNumberDisplay, string pageTag)
        {
            var bookIdParameter = bookId.HasValue ?
                new ObjectParameter("bookId", bookId) :
                new ObjectParameter("bookId", typeof(int));
    
            var pageNumberOrderParameter = pageNumberOrder.HasValue ?
                new ObjectParameter("PageNumberOrder", pageNumberOrder) :
                new ObjectParameter("PageNumberOrder", typeof(double));
    
            var pageDetailsParameter = pageDetails != null ?
                new ObjectParameter("PageDetails", pageDetails) :
                new ObjectParameter("PageDetails", typeof(string));
    
            var pageNumberDisplayParameter = pageNumberDisplay != null ?
                new ObjectParameter("PageNumberDisplay", pageNumberDisplay) :
                new ObjectParameter("PageNumberDisplay", typeof(string));
    
            var pageTagParameter = pageTag != null ?
                new ObjectParameter("PageTag", pageTag) :
                new ObjectParameter("PageTag", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertPage", bookIdParameter, pageNumberOrderParameter, pageDetailsParameter, pageNumberDisplayParameter, pageTagParameter);
        }
    }
}
