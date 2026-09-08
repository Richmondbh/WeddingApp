using WeddingApp.Models;

namespace WeddingApp.Services
{
    /// <summary>
    /// This Stores guest responses in a list held in memory and the list lives as long as
    /// the application is running and is emptied when the application restarts.
    /// </summary>
    public class GuestManager: IGuestManager
    {
        private readonly List<Guest> guests = new List<Guest>();

        // Only ever increases, so an Id is never reused after a guest is deleted.
        private int nextId = 1;

        public int NumOfGuests => guests.Count;

        public IReadOnlyList<Guest> GetAll()
        {
            return guests;
        }

        public Guest GetById(int id)
        {
            return guests.FirstOrDefault(guest => guest.Id == id);
        }

        public void Add(Guest guest)
        {
            if (guest == null)
            {
                return;
            }

            guest.Id = nextId;
            nextId++;
            guests.Add(guest);
        }

        public bool Update(Guest guest)
        {
            if (guest == null)
            {
                return false;
            }

            Guest existing = GetById(guest.Id);
            if (existing == null)
            {
                return false;
            }

            // The stored object is edited in place so that the Id stays the same
            // and the guest keeps its position in the list.
            existing.Name = guest.Name;
            existing.Email = guest.Email;
            existing.WillAttend = guest.WillAttend;
            existing.Message = guest.Message;

            return true;
        }

        public bool Delete(int id)
        {
            Guest guest = GetById(id);
            if (guest == null)
            {
                return false;
            }

            return guests.Remove(guest);
        }
    }
}
