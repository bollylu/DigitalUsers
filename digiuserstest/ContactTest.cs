using BLTools.Core.Logging;
using digiusersmodelslib;
using NUnit.Framework;

namespace digiuserstest;

public class ContactTest {

  private readonly ILogger Logger = new TConsoleLogger();

  [SetUp]
  public void Setup() {
  }

  [OneTimeTearDown]
  public void OneTimeTearDown() {
    Logger?.Dispose();
  }

  [Test]
  public void CreateContact() {
    Logger.Message("Create a contact");
    TContact Contact = new TContact();
    Assert.That(Contact, Is.Not.Null);
    Assert.That(Contact.FirstName, Is.EqualTo(string.Empty));
    Logger.Ok();
  }

  [Test]
  public void CreateContact_CompanyName_IsEmpty() {
    Logger.Message("Create a contact");
    TContact Contact = new TContact();
    Assert.That(Contact.Company.Name, Is.EqualTo(string.Empty));
    Logger.Ok();
  }

  [Test]
  public void CreateContact_CompanyName_IsACS() {
    Logger.Message("Create a contact");
    TContact Contact = new TContact() { Company = TCompany.ACS };
    Logger.Message($"Contact.Company.Name: {Contact.Company.Name}");
    Assert.That(Contact.Company.Name, Is.EqualTo(TCompany.ACS.Name));
    Logger.Ok();
  }
}
