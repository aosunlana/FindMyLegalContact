using System.Threading.Tasks;
using FindMyLegalContact.Brokers;
using FindMyLegalContact.Models;

namespace FindMyLegalContact.Services.Foundations
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
            LegalContact legalContact = await this.legalContactBroker.GetDesignatedLegalContact(employee.Id);
            if (legalContact != null)
            {
                return legalContact;
            }
            
            return await RetrieveLegalContact(employee.Manager);
        }
    }
}

