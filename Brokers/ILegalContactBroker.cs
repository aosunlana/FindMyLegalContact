using System;
using System.Threading.Tasks;
using FindMyLegalContact.Models;

namespace FindMyLegalContact.Brokers;

public interface ILegalContactBroker
{
    ValueTask<LegalContact> GetDesignatedLegalContact(Guid employeeId);
}