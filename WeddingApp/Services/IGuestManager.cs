using WeddingApp.Models;

namespace WeddingApp.Services
{
    /// <summary>
    /// Describes the operations the application needs in order to manage guest
    /// responses. 
    /// </summary>
    public interface IGuestManager
    {

        int NumOfGuests { get; }

        IReadOnlyList<Guest> GetAll();

        Guest GetById(int id);

        void Add(Guest guest);

        bool Update(Guest guest);

        bool Delete(int id);
    }
}
