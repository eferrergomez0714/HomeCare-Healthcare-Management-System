using HomeCare.Data;
using HomeCare.Dtos.CareGivers;
using HomeCare.Interfaces;
using HomeCare.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeCare.Repository
{
    public class CareGiversRepository : ICareGiversRepository
    {
        private readonly ApplicationDBContext _context;
        public CareGiversRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<CareGivers> CreateAsync(CareGivers careGiversModel)
        {
            await _context.CareGivers.AddAsync(careGiversModel);
            await _context.SaveChangesAsync();
            return careGiversModel;
        }

        public async Task<CareGivers?> DeleteAsync(int id)
        {
            var careGiversModel = await _context.CareGivers.FirstOrDefaultAsync(x => x.Id == id);
            if (careGiversModel == null)
            {
                return null;
            }

            _context.CareGivers.Remove(careGiversModel);
            await _context.SaveChangesAsync();
            return careGiversModel;
        }

        public async Task<List<CareGivers>> GetAllAsync()
        {
            return await _context.CareGivers.ToListAsync();
        }

        public async Task<CareGivers?> GetByIdAsync(int id)
        {
            return await _context.CareGivers.FindAsync(id);
        }

        public async Task<CareGivers?> UpdateAsync(int id, UpdateCareGiversDto careGiversDto)
        {
            var existingCareGiver = await _context.CareGivers.FirstOrDefaultAsync((x) => x.Id == id);

            if (existingCareGiver == null)
            {
                return null;
            }

            existingCareGiver.Name = careGiversDto.Name;
            existingCareGiver.Email = careGiversDto.Email;
            existingCareGiver.Rate = careGiversDto.Rate;
            existingCareGiver.City = careGiversDto.City;

            await _context.SaveChangesAsync();

            return existingCareGiver;
        }
    }
}
