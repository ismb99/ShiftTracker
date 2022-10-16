using Microsoft.EntityFrameworkCore;
using ShiftTracker.API.Data;
using ShiftTracker.API.Interfaces;
using ShiftTracker.API.Models;

namespace ShiftTracker.API.Repository
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly ApplicationDbContext _db;

        public ShiftRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Shift> Add(Shift shift)
        {
            var result = await _db.Shifts.AddAsync(shift);
            _db.SaveChangesAsync();

            return result.Entity;
        }

        public void Delete(int id)
        {
            var shift = _db.Shifts.FirstOrDefault(i => i.Id == id);
            if(shift != null)
            {
                _db.Shifts.Remove(shift);
                _db.SaveChanges();
            }
        }

        public async Task<Shift> Get(int id)
        {
            return await _db.Shifts.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Shift>> GetAll()
        {
            return await _db.Shifts.ToListAsync();
        }

        public async Task<Shift> Update(Shift shift)
        {
            var result = await _db.Shifts.FirstOrDefaultAsync(i => i.Id == shift.Id);
            if (result != null)
            {
                result.Start = shift.Start;
                result.End = shift.End;
                result.Minutes = shift.Minutes;
                result.Location = shift.Location;
                result.Pay = shift.Pay;

                await _db.SaveChangesAsync();

            }
            return result;
        }
    }
}
