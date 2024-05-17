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
        public async ValueTask<LegalContact> RetrieveLegalContact(Employee employee)
        {
            while (employee != null)
            {
                LegalContact legalContact = await this.legalContactBroker.GetDesignatedLegalContact(employee.Id);
                if (legalContact != null)
                {
                    return legalContact;
                }
                employee = employee.Manager;
            }
            return null;
        }
    }
}

