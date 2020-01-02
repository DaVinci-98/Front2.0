using Front.Core.Models;

namespace Front.Core.Services.Interfaces
{
    public interface IPersonDataService
    {
        PersonModel GetPerson(PersonModel person);
        void RegisterPerson(PersonModel person);
        bool CanRegister(PersonModel person);
    }
}
