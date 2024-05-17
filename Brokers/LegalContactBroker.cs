using System;
using System.Threading.Tasks;
using FindMyLegalContact.Models;
using EFxceptions;

namespace FindMyLegalContact.Brokers;

public class LegalContactBroker : EFxceptionsContext, ILegalContactBroker
{
    public ValueTask<LegalContact> GetDesignatedLegalContact(Guid employeeId)
    {
        throw new NotImplementedException();
    }
    
    
}