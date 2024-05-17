using FindMyLegalContact.Models;

namespace FindMyLegalContact.Services;

public interface ILegalContactService
{
    ValueTask<LegalContact> RetrieveLegalContact(Employee employee);
}