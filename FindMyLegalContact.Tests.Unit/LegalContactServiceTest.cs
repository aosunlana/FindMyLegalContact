using FindMyLegalContact.Brokers;
using FindMyLegalContact.Services;
using Moq;

namespace FindMyLegalContact.Tests.Unit
{
   public class LegalContactServiceTests
   {
      private readonly Mock<ILegalContactService> legalContactService;
      private readonly Mock<ILegalContactBroker> legalContactBroker;
   }
}