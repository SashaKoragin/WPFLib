﻿

// ------------------------------------------------------------------------------------------------
// This code was generated by EntityFramework Reverse POCO Generator (http://www.reversepoco.com/).
// Created by Simon Hughes (https://about.me/simon.hughes).
//
// Do not make changes directly to this file - edit the template instead.
//
// The following connection settings were used to generate this file:
//     Configuration file:     "EfDatabaseAutomation\App.config"
//     Connection String Name: "DatabaseAutomation"
//     Connection String:      "Data Source=i7751-app127;Initial Catalog=Automation;Integrated Security=True;MultipleActiveResultSets=True"
// ------------------------------------------------------------------------------------------------
// Database Edition        : Enterprise Edition (64-bit)
// Database Engine Edition : Enterprise
// Database Version        : 10.50.6560.0

// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.5
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace EfDatabaseAutomation.Automation.Base
{

    #region Unit of work

    public interface IAutomation : System.IDisposable
    {
        System.Data.Entity.DbSet<InfoViewAutomation> InfoViewAutomations { get; set; } // InfoViewAutomation
        System.Data.Entity.DbSet<LogicsSelectAutomation> LogicsSelectAutomations { get; set; } // LogicsSelectAutomation
        System.Data.Entity.DbSet<TaxJournal> TaxJournals { get; set; } // TaxJournal
        System.Data.Entity.DbSet<TaxJournalAutoReport> TaxJournalAutoReports { get; set; } // TaxJournalAutoReport
        System.Data.Entity.DbSet<TaxJournalAutoWebPage> TaxJournalAutoWebPages { get; set; } // TaxJournalAutoWebPage

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
        System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get; }
        System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get; }
        System.Data.Entity.Database Database { get; }
        System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
        System.Collections.Generic.IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors();
        System.Data.Entity.DbSet Set(System.Type entityType);
        System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
    }

    #endregion

    #region Database context

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.1.0")]
    public class Automation : System.Data.Entity.DbContext, IAutomation
    {
        public System.Data.Entity.DbSet<InfoViewAutomation> InfoViewAutomations { get; set; } // InfoViewAutomation
        public System.Data.Entity.DbSet<LogicsSelectAutomation> LogicsSelectAutomations { get; set; } // LogicsSelectAutomation
        public System.Data.Entity.DbSet<TaxJournal> TaxJournals { get; set; } // TaxJournal
        public System.Data.Entity.DbSet<TaxJournalAutoReport> TaxJournalAutoReports { get; set; } // TaxJournalAutoReport
        public System.Data.Entity.DbSet<TaxJournalAutoWebPage> TaxJournalAutoWebPages { get; set; } // TaxJournalAutoWebPage

        static Automation()
        {
            System.Data.Entity.Database.SetInitializer<Automation>(null);
        }

        public Automation()
            : base("Name=DatabaseAutomation")
        {
        }

        public Automation(string connectionString)
            : base(connectionString)
        {
        }

        public Automation(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
        }

        public Automation(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public Automation(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new InfoViewAutomationConfiguration());
            modelBuilder.Configurations.Add(new LogicsSelectAutomationConfiguration());
            modelBuilder.Configurations.Add(new TaxJournalConfiguration());
            modelBuilder.Configurations.Add(new TaxJournalAutoReportConfiguration());
            modelBuilder.Configurations.Add(new TaxJournalAutoWebPageConfiguration());
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new InfoViewAutomationConfiguration(schema));
            modelBuilder.Configurations.Add(new LogicsSelectAutomationConfiguration(schema));
            modelBuilder.Configurations.Add(new TaxJournalConfiguration(schema));
            modelBuilder.Configurations.Add(new TaxJournalAutoReportConfiguration(schema));
            modelBuilder.Configurations.Add(new TaxJournalAutoWebPageConfiguration(schema));
            return modelBuilder;
        }
    }
    #endregion

    #region Database context factory

    public class AutomationFactory : System.Data.Entity.Infrastructure.IDbContextFactory<Automation>
    {
        public Automation Create()
        {
            return new Automation();
        }
    }

    #endregion

    #region POCO classes

    // InfoViewAutomation
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.1.0")]
    public class InfoViewAutomation
    {
        public int Id { get; set; } // Id (Primary key)
        public string NameView { get; set; } // NameView (length: 64)
        public string NameViewColumns { get; set; } // NameViewColumns (length: 64)
        public string InfoColumn { get; set; } // InfoColumn (length: 256)
        public string FormatView { get; set; } // FormatView (length: 16)
        public bool? IsVisible { get; set; } // IsVisible
        public System.DateTime? DataCreate { get; set; } // DataCreate

        public InfoViewAutomation()
        {
            DataCreate = System.DateTime.Now;
        }
    }

    // LogicsSelectAutomation
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.1.0")]
    public class LogicsSelectAutomation
    {
        public int Id { get; set; } // Id (Primary key)
        public string SelectInfo { get; set; } // SelectInfo (length: 512)
        public string SelectedParametr { get; set; } // SelectedParametr
        public string SelectUser { get; set; } // SelectUser
        public System.DateTime? DataCreate { get; set; } // DataCreate

        public LogicsSelectAutomation()
        {
            DataCreate = System.DateTime.Now;
        }
    }

    // TaxJournal
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.1.0")]
    public class TaxJournal
    {
        public int Id { get; set; } // Id (Primary key)
        public string Color { get; set; } // Color (length: 12)
        public int? IdDelo { get; set; } // IdDelo
        public System.DateTime? DateError { get; set; } // DateError
        public string Inn { get; set; } // Inn (length: 12)
        public string Kpp { get; set; } // Kpp (length: 12)
        public string NameFace { get; set; } // NameFace (length: 512)
        public string Fid { get; set; } // Fid (length: 512)
        public System.DateTime? DateIzveshenie { get; set; } // DateIzveshenie
        public bool? IsTks { get; set; } // IsTks
        public bool? IsMail { get; set; } // IsMail
        public bool? IsLk3 { get; set; } // IsLk3
        public string TypeDocument { get; set; } // TypeDocument (length: 128)
        public string MessageInfo { get; set; } // MessageInfo (length: 512)
        public string LoginUser { get; set; } // LoginUser (length: 1024)
        public string FullPath { get; set; } // FullPath (length: 1024)
        public string NameFile { get; set; } // NameFile (length: 128)
        public string Extensions { get; set; } // Extensions (length: 10)
        public string Mime { get; set; } // Mime (length: 128)
        public byte[] Document { get; set; } // Document (length: 2147483647)
        public bool? IsPrint { get; set; } // IsPrint
        public System.DateTime? DataCreate { get; set; } // DataCreate

        public TaxJournal()
        {
            DataCreate = System.DateTime.Now;
        }
    }

    // TaxJournalAutoReport
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.1.0")]
    public class TaxJournalAutoReport
    {
        public int Id { get; set; } // Id (Primary key)
        public int? IdDelo { get; set; } // IdDelo
        public string Inn { get; set; } // Inn (length: 12)
        public string Kpp { get; set; } // Kpp (length: 12)
        public string NameFace { get; set; } // NameFace (length: 512)
        public string Fid { get; set; } // Fid (length: 512)
        public System.DateTime? DateIzveshenie { get; set; } // DateIzveshenie
        public bool? IsTks { get; set; } // isTks
        public bool? IsMail { get; set; } // isMail
        public bool? IsLk3 { get; set; } // isLk3
        public string TypeDocument { get; set; } // TypeDocument (length: 128)
        public string MessageInfo { get; set; } // MessageInfo (length: 512)
        public string Extensions { get; set; } // Extensions (length: 10)
        public byte[] Document { get; set; } // Document (length: 2147483647)
        public bool? IsPrint { get; set; } // IsPrint
        public System.DateTime? DataCreate { get; set; } // DataCreate
    }

    // TaxJournalAutoWebPage
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.1.0")]
    public class TaxJournalAutoWebPage
    {
        public int Id { get; set; } // Id (Primary key)
        public int? IdDelo { get; set; } // IdDelo
        public string Inn { get; set; } // Inn (length: 12)
        public string Kpp { get; set; } // Kpp (length: 12)
        public string NameFace { get; set; } // NameFace (length: 512)
        public string Fid { get; set; } // Fid (length: 512)
        public System.DateTime? DateIzveshenie { get; set; } // DateIzveshenie
        public bool? IsTks { get; set; } // isTks
        public bool? IsMail { get; set; } // isMail
        public bool? IsLk3 { get; set; } // isLk3
        public string TypeDocument { get; set; } // TypeDocument (length: 128)
        public string MessageInfo { get; set; } // MessageInfo (length: 512)
        public string Extensions { get; set; } // Extensions (length: 10)
        public bool? IsPrint { get; set; } // IsPrint
        public System.DateTime? DataCreate { get; set; } // DataCreate
    }

    #endregion

    #region POCO Configuration

    // InfoViewAutomation
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.1.0")]
    public class InfoViewAutomationConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<InfoViewAutomation>
    {
        public InfoViewAutomationConfiguration()
            : this("dbo")
        {
        }

        public InfoViewAutomationConfiguration(string schema)
        {
            ToTable("InfoViewAutomation", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.NameView).HasColumnName(@"NameView").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(64);
            Property(x => x.NameViewColumns).HasColumnName(@"NameViewColumns").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(64);
            Property(x => x.InfoColumn).HasColumnName(@"InfoColumn").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(256);
            Property(x => x.FormatView).HasColumnName(@"FormatView").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(16);
            Property(x => x.IsVisible).HasColumnName(@"IsVisible").HasColumnType("bit").IsOptional();
            Property(x => x.DataCreate).HasColumnName(@"DataCreate").HasColumnType("smalldatetime").IsOptional();
        }
    }

    // LogicsSelectAutomation
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.1.0")]
    public class LogicsSelectAutomationConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<LogicsSelectAutomation>
    {
        public LogicsSelectAutomationConfiguration()
            : this("dbo")
        {
        }

        public LogicsSelectAutomationConfiguration(string schema)
        {
            ToTable("LogicsSelectAutomation", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.SelectInfo).HasColumnName(@"SelectInfo").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(512);
            Property(x => x.SelectedParametr).HasColumnName(@"SelectedParametr").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.SelectUser).HasColumnName(@"SelectUser").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.DataCreate).HasColumnName(@"DataCreate").HasColumnType("smalldatetime").IsOptional();
        }
    }

    // TaxJournal
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.1.0")]
    public class TaxJournalConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TaxJournal>
    {
        public TaxJournalConfiguration()
            : this("dbo")
        {
        }

        public TaxJournalConfiguration(string schema)
        {
            ToTable("TaxJournal", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Color).HasColumnName(@"Color").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(12);
            Property(x => x.IdDelo).HasColumnName(@"IdDelo").HasColumnType("int").IsOptional();
            Property(x => x.DateError).HasColumnName(@"DateError").HasColumnType("smalldatetime").IsOptional();
            Property(x => x.Inn).HasColumnName(@"Inn").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(12);
            Property(x => x.Kpp).HasColumnName(@"Kpp").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(12);
            Property(x => x.NameFace).HasColumnName(@"NameFace").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(512);
            Property(x => x.Fid).HasColumnName(@"Fid").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(512);
            Property(x => x.DateIzveshenie).HasColumnName(@"DateIzveshenie").HasColumnType("smalldatetime").IsOptional();
            Property(x => x.IsTks).HasColumnName(@"IsTks").HasColumnType("bit").IsOptional();
            Property(x => x.IsMail).HasColumnName(@"IsMail").HasColumnType("bit").IsOptional();
            Property(x => x.IsLk3).HasColumnName(@"IsLk3").HasColumnType("bit").IsOptional();
            Property(x => x.TypeDocument).HasColumnName(@"TypeDocument").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(128);
            Property(x => x.MessageInfo).HasColumnName(@"MessageInfo").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(512);
            Property(x => x.LoginUser).HasColumnName(@"LoginUser").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1024);
            Property(x => x.FullPath).HasColumnName(@"FullPath").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1024);
            Property(x => x.NameFile).HasColumnName(@"NameFile").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(128);
            Property(x => x.Extensions).HasColumnName(@"Extensions").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(10);
            Property(x => x.Mime).HasColumnName(@"Mime").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(128);
            Property(x => x.Document).HasColumnName(@"Document").HasColumnType("image").IsOptional().HasMaxLength(2147483647);
            Property(x => x.IsPrint).HasColumnName(@"IsPrint").HasColumnType("bit").IsOptional();
            Property(x => x.DataCreate).HasColumnName(@"DataCreate").HasColumnType("smalldatetime").IsOptional();
        }
    }

    // TaxJournalAutoReport
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.1.0")]
    public class TaxJournalAutoReportConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TaxJournalAutoReport>
    {
        public TaxJournalAutoReportConfiguration()
            : this("dbo")
        {
        }

        public TaxJournalAutoReportConfiguration(string schema)
        {
            ToTable("TaxJournalAutoReport", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdDelo).HasColumnName(@"IdDelo").HasColumnType("int").IsOptional();
            Property(x => x.Inn).HasColumnName(@"Inn").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(12);
            Property(x => x.Kpp).HasColumnName(@"Kpp").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(12);
            Property(x => x.NameFace).HasColumnName(@"NameFace").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(512);
            Property(x => x.Fid).HasColumnName(@"Fid").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(512);
            Property(x => x.DateIzveshenie).HasColumnName(@"DateIzveshenie").HasColumnType("smalldatetime").IsOptional();
            Property(x => x.IsTks).HasColumnName(@"isTks").HasColumnType("bit").IsOptional();
            Property(x => x.IsMail).HasColumnName(@"isMail").HasColumnType("bit").IsOptional();
            Property(x => x.IsLk3).HasColumnName(@"isLk3").HasColumnType("bit").IsOptional();
            Property(x => x.TypeDocument).HasColumnName(@"TypeDocument").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(128);
            Property(x => x.MessageInfo).HasColumnName(@"MessageInfo").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(512);
            Property(x => x.Extensions).HasColumnName(@"Extensions").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(10);
            Property(x => x.Document).HasColumnName(@"Document").HasColumnType("image").IsOptional().HasMaxLength(2147483647);
            Property(x => x.IsPrint).HasColumnName(@"IsPrint").HasColumnType("bit").IsOptional();
            Property(x => x.DataCreate).HasColumnName(@"DataCreate").HasColumnType("smalldatetime").IsOptional();
        }
    }

    // TaxJournalAutoWebPage
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.1.0")]
    public class TaxJournalAutoWebPageConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TaxJournalAutoWebPage>
    {
        public TaxJournalAutoWebPageConfiguration()
            : this("dbo")
        {
        }

        public TaxJournalAutoWebPageConfiguration(string schema)
        {
            ToTable("TaxJournalAutoWebPage", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdDelo).HasColumnName(@"IdDelo").HasColumnType("int").IsOptional();
            Property(x => x.Inn).HasColumnName(@"Inn").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(12);
            Property(x => x.Kpp).HasColumnName(@"Kpp").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(12);
            Property(x => x.NameFace).HasColumnName(@"NameFace").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(512);
            Property(x => x.Fid).HasColumnName(@"Fid").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(512);
            Property(x => x.DateIzveshenie).HasColumnName(@"DateIzveshenie").HasColumnType("smalldatetime").IsOptional();
            Property(x => x.IsTks).HasColumnName(@"isTks").HasColumnType("bit").IsOptional();
            Property(x => x.IsMail).HasColumnName(@"isMail").HasColumnType("bit").IsOptional();
            Property(x => x.IsLk3).HasColumnName(@"isLk3").HasColumnType("bit").IsOptional();
            Property(x => x.TypeDocument).HasColumnName(@"TypeDocument").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(128);
            Property(x => x.MessageInfo).HasColumnName(@"MessageInfo").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(512);
            Property(x => x.Extensions).HasColumnName(@"Extensions").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(10);
            Property(x => x.IsPrint).HasColumnName(@"IsPrint").HasColumnType("bit").IsOptional();
            Property(x => x.DataCreate).HasColumnName(@"DataCreate").HasColumnType("smalldatetime").IsOptional();
        }
    }

    #endregion

}
// </auto-generated>

