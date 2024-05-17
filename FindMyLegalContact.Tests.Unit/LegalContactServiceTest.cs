using FindMyLegalContact.Brokers;
using FindMyLegalContact.Services;
using Moq;

namespace FindMyLegalContact.Tests.Unit
{
   public class LegalContactServiceTests
   {
      private readonly ILegalContactService legalContactService;
      private readonly Mock<ILegalContactBroker> legalContactBrokerMock;

      public LegalContactServiceTests()
      {
         this.legalContactBrokerMock = new Mock<ILegalContactBroker>();
         this.legalContactService = new LegalContactService(
            legalContactBroker: this.legalContactBrokerMock.Object);
      }
   }
   
}