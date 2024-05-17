using FindMyLegalContact.Brokers;
using FindMyLegalContact.Models;
using FindMyLegalContact.Services;
using Moq;
using Tynamix.ObjectFiller;

namespace FindMyLegalContact.Tests.Unit
{
   public partial class LegalContactServiceTests
   {
      private readonly ILegalContactService legalContactService;
      private readonly Mock<ILegalContactBroker> legalContactBrokerMock;

      public LegalContactServiceTests()
      {
         this.legalContactBrokerMock = new Mock<ILegalContactBroker>();
         this.legalContactService = new LegalContactService(
            legalContactBroker: this.legalContactBrokerMock.Object);
      }

      private static Employee GetRandomEmployeeWithId(Guid employeeId)
      {
         
         var filler = new Filler<Employee>();
         filler.Setup()
            .OnProperty(employee => employee.Id).Use(employeeId);
    
         return filler.Create();
      }

      private static LegalContact GetRandomLegalContact()
      {
         var filler = new Filler<LegalContact>();
         return filler.Create();
      }
   }
   
}