using FindMyLegalContact.Models;

namespace FindMyLegalContact.Brokers;

public interface ILegalContactBroker
{
    LegalContact GetDesignatedLegalContact(Guid employeeId);
}