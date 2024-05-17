using FindMyLegalContact.Models;
using EFxceptions;

namespace FindMyLegalContact.Brokers;

public class LegalContactBroker : EFxceptionsContext, ILegalContactBroker
{
    public LegalContact GetDesignatedLegalContact(Guid employeeId)
    {
        throw new NotImplementedException();
    }
    
    
}