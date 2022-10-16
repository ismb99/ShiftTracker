using ShiftTracker.API.Models;

namespace ShiftTracker.API.Interfaces
{
    public interface IShiftRepository
    {
        Task<Shift> Add(Shift shift);
        Task<Shift> Update(Shift shift);
        void Delete(int id);
        Task<Shift> Get(int id);
        Task<IEnumerable<Shift>> GetAll();
        
    }
}
