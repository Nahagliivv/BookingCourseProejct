//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceBookingCourseProject.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BookingDBEntities : DbContext
    {
        public BookingDBEntities()
            : base("name=BookingDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BookedServices> BookedServices { get; set; }
        public virtual DbSet<BookingRequests> BookingRequests { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<ServicesTypes> ServicesTypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
