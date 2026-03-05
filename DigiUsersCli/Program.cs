using digiuserslib;
using digiuserslib.Data;
using digiuserslib.Data.Entities;

using Microsoft.EntityFrameworkCore;

const string DATA_FOLDER = "data";
const string DB_FILE = "digiusers.db";

#region --- Create and clean Data structure --------------------------------------------
try {
  if (!Directory.Exists(DATA_FOLDER)) {
    Directory.CreateDirectory(DATA_FOLDER);
  }
  if (File.Exists($"{DATA_FOLDER}/{DB_FILE}")) {
    File.Delete($"{DATA_FOLDER}/{DB_FILE}");
  }
} catch (Exception ex) {
  Console.WriteLine($"Error preparing database file: {ex.Message}");
  return;
}
#endregion --- Create and clean Data structure -----------------------------------------

using  (IDigitalUsersDbContext context = DigitalUsersSqliteDbContext.Create(DATA_FOLDER, DB_FILE)) {

  await context.Database.EnsureCreatedAsync();

  #region Add data to the database

  #region --- Contacts --------------------------------------------
  EFContact JohnDoe = new EFContact {
    Id = Guid.NewGuid().ToString(),
    FirstName = "John",
    LastName = "Doe",
    Company = "Acme Corp",
    Title = "Software Engineer",
    Notes = "This is a test contact."
  };

  EFContact JaneSmith = new EFContact {
    Id = Guid.NewGuid().ToString(),
    FirstName = "Jane",
    LastName = "Smith",
    Company = "Globex Inc",
    Title = "Project Manager",
    Notes = "This is another test contact."
  };

  EFContact AliceJohnson = new EFContact {
    Id = Guid.NewGuid().ToString(),
    FirstName = "Alice",
    LastName = "Johnson",
    Company = "Initech",
    Title = "UX Designer",
    Notes = "This is yet another test contact."
  };


  #endregion --- Contacts -----------------------------------------

  EFOrganization TechCompany = new EFOrganization {
    Id = Guid.NewGuid().ToString(),
    Name = "Tech Company",
    Description = "A leading technology company."
  };

  EFOrganization AnotherCompany = new EFOrganization {
    Id = Guid.NewGuid().ToString(),
    Name = "Another Company",
    Description = "Another leading company in the industry."
  };

  #region --- Departments --------------------------------------------
  EFDepartment engineeringDepartment = new EFDepartment {
    Id = Guid.NewGuid().ToString(),
    Name = "Engineering",
    Description = "The engineering department.",
    Organization = TechCompany
  };

  EFDepartment marketingDepartment = new EFDepartment {
    Id = Guid.NewGuid().ToString(),
    Name = "Marketing",
    Description = "The marketing department.",
    Organization = TechCompany
  };

  EFDepartment salesDepartment = new EFDepartment {
    Id = Guid.NewGuid().ToString(),
    Name = "Sales",
    Description = "The sales department.",
    Organization = TechCompany
  }; 
  #endregion --- Departments -----------------------------------------

  #region --- Locations --------------------------------------------
  EFLocation HeadQuarters = new EFLocation {
    Id = Guid.NewGuid().ToString(),
    Name = "Headquarters",
    Address1 = "123 Main St",
    Number = "Suite 100",
    City = "Anytown",
    ZipCode = "12345",
    Country = "USA"
  };

  EFLocation BranchOffice = new EFLocation {
    Id = Guid.NewGuid().ToString(),
    Name = "Branch Office",
    Address1 = "456 Elm St",
    Number = "Suite 200",
    City = "Othertown",
    ZipCode = "67890",
    Country = "USA"
  };

  EFLocation RemoteOffice = new EFLocation {
    Id = Guid.NewGuid().ToString(),
    Name = "Remote Office",
    Address1 = "789 Oak St",
    Number = "Suite 300",
    City = "Sometown",
    ZipCode = "54321",
    Country = "USA"
  };
  #endregion --- Locations -----------------------------------------

  #region --- Mail addresses --------------------------------------------
  EFMailAddress mailAddress1 = new EFMailAddress {
    Id = Guid.NewGuid().ToString(),
    Address = "john.doe@example.com"
  };

  EFMailAddress mailAddress2 = new EFMailAddress {
    Id = Guid.NewGuid().ToString(),
    Address = "jane.smith@example.com"
  };

  EFMailAddress mailAddress3 = new EFMailAddress {
    Id = Guid.NewGuid().ToString(),
    Address = "alice.johnson@example.com"
  };
  #endregion --- Mail addresses -----------------------------------------

  #region --- Phone numbers --------------------------------------------
  EFPhoneNumber phoneNumber1 = new EFPhoneNumber {
    Id = Guid.NewGuid().ToString(),
    Number = "+1-555-1234"
  };

  EFPhoneNumber phoneNumber2 = new EFPhoneNumber {
    Id = Guid.NewGuid().ToString(),
    Number = "+1-555-5678"
  };

  EFPhoneNumber phoneNumber3 = new EFPhoneNumber {
    Id = Guid.NewGuid().ToString(),
    Number = "+1-555-9012"
  };
  #endregion --- Phone numbers -----------------------------------------

  #region --- Pictures --------------------------------------------
  EFPicture picture1 = new EFPicture {
    Id = Guid.NewGuid().ToString(),
    PictureUrl = "https://example.com/picture1.jpg"
  };

  EFPicture picture2 = new EFPicture {
    Id = Guid.NewGuid().ToString(),
    PictureUrl = "https://example.com/picture2.jpg"
  };
  #endregion --- Pictures -----------------------------------------

  context.Organizations.Add(TechCompany);
  context.Organizations.Add(AnotherCompany);

  context.Departments.Add(engineeringDepartment);
  context.Departments.Add(marketingDepartment);
  context.Departments.Add(salesDepartment);  

  context.Locations.Add(HeadQuarters);
  context.Locations.Add(BranchOffice);
  context.Locations.Add(RemoteOffice);

  context.MailAddresses.Add(mailAddress1);
  context.MailAddresses.Add(mailAddress2);
  context.MailAddresses.Add(mailAddress3);
  context.PhoneNumbers.Add(phoneNumber1);
  context.PhoneNumbers.Add(phoneNumber2);
  context.PhoneNumbers.Add(phoneNumber3);

  context.Pictures.Add(picture1);
  context.Pictures.Add(picture2);

  context.Contacts.Add(JohnDoe);
  AnotherCompany.Contacts.Add(JaneSmith);
  context.Contacts.Add(AliceJohnson);
  
  TechCompany.Departments.Add(engineeringDepartment);
  TechCompany.Departments.Add(marketingDepartment); 
  AnotherCompany.Departments.Add(salesDepartment);

  TechCompany.Locations.Add(HeadQuarters);
  TechCompany.Locations.Add(BranchOffice);
  AnotherCompany.Locations.Add(RemoteOffice);

  AliceJohnson.Departments.Add(engineeringDepartment);
  AliceJohnson.PhoneNumbers.Add(phoneNumber3);
  AliceJohnson.MailAddresses.Add(mailAddress3);
  AliceJohnson.Pictures.Add(picture2);

  JohnDoe.Departments.Add(salesDepartment);
  JohnDoe.PhoneNumbers.Add(phoneNumber1);
  JohnDoe.MailAddresses.Add(mailAddress2);
  JohnDoe.Pictures.Add(picture1);

  await context.SaveChangesAsync();
  #endregion

  #region Read the data back
  var contacts = await context.Contacts.ToListAsync();

  foreach (var ContactItem in contacts) {
    Console.WriteLine($"{ContactItem.FirstName} {ContactItem.LastName} ({ContactItem.Company}) - {ContactItem.Title}");
    Console.WriteLine($"Organization => {ContactItem.Organization?.Name}");
    Console.WriteLine($"Department => {ContactItem.Departments.FirstOrDefault()?.Name}");
    Console.WriteLine($"Location => {ContactItem.Locations.FirstOrDefault()?.Name}");
    Console.WriteLine("------------------------------");
  }
  #endregion

}
