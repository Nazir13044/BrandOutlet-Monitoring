﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrandOutlet.Models.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BrandOutletMonitoringEntities : DbContext
    {
        public BrandOutletMonitoringEntities()
            : base("name=BrandOutletMonitoringEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<BrandShop> BrandShops { get; set; }
        public virtual DbSet<tblBrandingMonitoringTeam> tblBrandingMonitoringTeams { get; set; }
        public virtual DbSet<tblBrandingTeam> tblBrandingTeams { get; set; }
        public virtual DbSet<tblCreateAccount> tblCreateAccounts { get; set; }
        public virtual DbSet<tblImageUploader> tblImageUploaders { get; set; }
        public virtual DbSet<BrandingIssue> BrandingIssues { get; set; }
        public virtual DbSet<BrandingIssuesSolved> BrandingIssuesSolveds { get; set; }
        public virtual DbSet<BrandIssueMaster> BrandIssueMasters { get; set; }
        public virtual DbSet<BrandMonitorCategory> BrandMonitorCategories { get; set; }
        public virtual DbSet<BrandOutletDetail> BrandOutletDetails { get; set; }
        public virtual DbSet<BrandOutletMaster> BrandOutletMasters { get; set; }
        public virtual DbSet<BrandOutletLog> BrandOutletLogs { get; set; }
        public virtual DbSet<BrandMainMenu> BrandMainMenus { get; set; }
        public virtual DbSet<BrandRole> BrandRoles { get; set; }
        public virtual DbSet<BrandSubMenu> BrandSubMenus { get; set; }
        public virtual DbSet<BrandLogin> BrandLogins { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<BrandMonitorSubCategory> BrandMonitorSubCategories { get; set; }
    }
}