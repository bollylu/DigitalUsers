using digiuserslib.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace digiuserslib.Data;

public abstract class ADigitalUsersDbContext : DbContext, IDigitalUsersDbContext {

  public DbSet<EFOrganization> Organizations { get; set; }
  public DbSet<EFContact> Contacts { get; set; }
  public DbSet<EFPhoneNumber> PhoneNumbers { get; set; }
  public DbSet<EFMailAddress> MailAddresses { get; set; }
  public DbSet<EFLocation> Locations { get; set; }
  public DbSet<EFPicture> Pictures { get; set; }
  public DbSet<EFDepartment> Departments { get; set; }

  public DbSet<EFContactPhoneNumber> ContactsPhoneNumbers { get; set; }
  public DbSet<EFContactMailAddress> ContactsMailAddresses { get; set; }
  public DbSet<EFContactLocation> ContactsLocations { get; set; }
  public DbSet<EFContactDepartment> ContactsDepartments { get; set; }

  protected ADigitalUsersDbContext() { }
  protected ADigitalUsersDbContext(DbContextOptions options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    base.OnModelCreating(modelBuilder);

    ConfigureContact(modelBuilder);
    ConfigureLocation(modelBuilder);
    ConfigurePicture(modelBuilder);
    ConfigureMailAddress(modelBuilder);
    ConfigurePhoneNumber(modelBuilder);
    ConfigureDepartment(modelBuilder);
    ConfigureOrganization(modelBuilder);
  }

  protected virtual void ConfigureContact(ModelBuilder modelBuilder) {
    modelBuilder.Entity<EFContact>(entity => {

      entity.HasIndex(e => new { e.FirstName, e.LastName });
      entity.HasIndex(e => new { e.LastName, e.FirstName });

      // ✅ 1 Contact => N Pictures (FK ContactId sur EFPicture)
      entity.HasMany(e => e.Pictures)
        .WithOne()
        .HasForeignKey(e => e.ContactId)
        .OnDelete(DeleteBehavior.SetNull);

      // ✅ N Contacts <=> N PhoneNumbers
      entity.HasMany(e => e.PhoneNumbers)
        .WithMany(e => e.Contacts)
        .UsingEntity<EFContactPhoneNumber>(
          r => r.HasOne(x => x.PhoneNumber).WithMany(),
          l => l.HasOne(x => x.Contact).WithMany());

      // ✅ N Contacts <=> N MailAddresses
      entity.HasMany(e => e.MailAddresses)
        .WithMany(e => e.Contacts)
        .UsingEntity<EFContactMailAddress>(
          r => r.HasOne(x => x.MailAddress).WithMany(),
          l => l.HasOne(x => x.Contact).WithMany());

      // ✅ N Contacts <=> N Locations
      entity.HasMany(e => e.Locations)
        .WithMany()
        .UsingEntity<EFContactLocation>(
          r => r.HasOne(x => x.Location).WithMany(),
          l => l.HasOne(x => x.Contact).WithMany());

      // ✅ N Contacts <=> N Departments as Hod
      entity.HasMany(e => e.HodDepartments)
        .WithMany(d => d.HeadsOfDepartment)
        .UsingEntity<EFHodDepartment>(
          r => r.HasOne(x => x.Department).WithMany(),
          l => l.HasOne(x => x.Contact).WithMany());

      // ✅ N Contacts <=> N Departments
      entity.HasMany(e => e.Departments)
        .WithMany(d => d.Contacts)
        .UsingEntity<EFContactDepartment>(
          r => r.HasOne(x => x.Department).WithMany(),
          l => l.HasOne(x => x.Contact).WithMany());


    });
  }

  protected virtual void ConfigureLocation(ModelBuilder modelBuilder) {
    modelBuilder.Entity<EFLocation>(entity => {
      //entity.HasKey(e => e.Id);
      //entity.Property(e => e.Id).HasMaxLength(50);
      //entity.Property(e => e.Name).HasMaxLength(200).IsRequired();
      //entity.Property(e => e.Address1).HasMaxLength(200).IsRequired();
      //entity.Property(e => e.Number).HasMaxLength(20);
      //entity.Property(e => e.Address2).HasMaxLength(200);
      //entity.Property(e => e.AddressDetails).HasMaxLength(500);
      //entity.Property(e => e.City).HasMaxLength(100).IsRequired();
      //entity.Property(e => e.ZipCode).HasMaxLength(20).IsRequired();
      //entity.Property(e => e.Country).HasMaxLength(100).IsRequired();
      entity.HasIndex(e => new { e.City, e.ZipCode });

      // ✅ 1 Location => N Pictures (FK LocationId sur EFPicture)
      entity.HasMany(e => e.Pictures)
        .WithOne()
        .HasForeignKey(e => e.LocationId)
        .OnDelete(DeleteBehavior.SetNull);

      // ✅ N Locations <=> N Contacts
      entity.HasMany(e => e.Contacts)
        .WithMany(e => e.Locations)
        .UsingEntity<EFContactLocation>(
          r => r.HasOne(x => x.Contact).WithMany(),
          l => l.HasOne(x => x.Location).WithMany());
    });
  }

  protected virtual void ConfigurePicture(ModelBuilder modelBuilder) {
    modelBuilder.Entity<EFPicture>(entity => {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Id).HasMaxLength(50);
      entity.Property(e => e.Name).HasMaxLength(200);
      entity.Property(e => e.Description).HasMaxLength(1000);
      entity.Property(e => e.PictureBase64);
      entity.Property(e => e.PictureUrl).HasMaxLength(1000);
      // ✅ FK nullables vers Contact et Location
      entity.Property(e => e.ContactId).HasMaxLength(50);
      entity.Property(e => e.LocationId).HasMaxLength(50);
    });
  }

  protected virtual void ConfigurePhoneNumber(ModelBuilder modelBuilder) {
    modelBuilder.Entity<EFPhoneNumber>(entity => {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Id).HasMaxLength(50);
      entity.Property(e => e.Number).HasMaxLength(20).IsRequired();
      entity.Property(e => e.CountryCode)
        .HasConversion(new EnumToStringConverter<EPhoneCountry>());
      entity.Property(e => e.Prefix).HasMaxLength(10);
      entity.Property(e => e.Extension).HasMaxLength(10);
      entity.Property(e => e.Type)
        .HasConversion(new EnumToStringConverter<EPhoneNumberType>());
    });
  }

  protected virtual void ConfigureMailAddress(ModelBuilder modelBuilder) {
    modelBuilder.Entity<EFMailAddress>(entity => {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Id).HasMaxLength(50);
      entity.Property(e => e.Address).HasMaxLength(255).IsRequired();
      entity.Property(e => e.DisplayName).HasMaxLength(200);
      entity.HasIndex(e => e.Address).IsUnique();
    });
  }

  protected virtual void ConfigureDepartment(ModelBuilder modelBuilder) {
    modelBuilder.Entity<EFDepartment>(entity => {

    });
  }

  protected virtual void ConfigureOrganization(ModelBuilder modelBuilder) {
    modelBuilder.Entity<EFOrganization>(entity => {
      entity.HasMany(e => e.Departments)
          .WithOne(d => d.Organization)
          .HasForeignKey(d => d.OrganizationId)
          .IsRequired()                           // FK non nullable = département DOIT avoir une org
          .OnDelete(DeleteBehavior.Restrict);     // empêche de supprimer une org qui a des départements

      entity.HasMany(e => e.Contacts)
          .WithOne(c => c.Organization)
          .HasForeignKey(c => c.OrganizationId)
          .IsRequired(false)                      // nullable : un contact PEUT ne pas avoir d'org
          .OnDelete(DeleteBehavior.SetNull);      // si l'org est supprimée, le contact reste (OrganizationId => null)
    });
  }
}
