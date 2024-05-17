using FindMyLegalContact.Brokers;
using FindMyLegalContact.Models;

namespace FindMyLegalContact.Services
{
    public class LegalContactService : ILegalContactService
    {
        private readonly ILegalContactBroker legalContactBroker;

        public LegalContactService(ILegalContactBroker legalContactBroker)
        {
            this.legalContactBroker = legalContactBroker;
        }
        public ValueTask<LegalContact> RetrieveLegalContact(Employee employee)
        {
            throw new System.NotImplementedException();
        }
    }
}

