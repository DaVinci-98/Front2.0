using Front.Core.Models;

namespace Front.Core.Services
{
    public interface IPersonData
    {
        PersonModel GetPerson(string identity, string password);
        bool RegisterPerson(string nick, string name, string email, string password);
    }
}
