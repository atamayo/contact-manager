using System.Threading.Tasks;
using Domain;

namespace Services.ContactManager
{
    public interface IContactCreationService
    {
        Task AddNewAsync(Contact contact);
    }
}