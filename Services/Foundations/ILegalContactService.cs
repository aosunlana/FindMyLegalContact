using System.Threading.Tasks;
using FindMyLegalContact.Models;

namespace FindMyLegalContact.Services.Foundations
{
    public interface ILegalContactService
    {
        ValueTask<LegalContact> RetrieveLegalContact(Employee employee);
    }
}