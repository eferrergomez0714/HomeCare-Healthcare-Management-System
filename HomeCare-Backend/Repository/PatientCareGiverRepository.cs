using HomeCare.Data;
using HomeCare.Interfaces;
using HomeCare.Models;
using Microsoft.EntityFrameworkCore;
using HomeCare.Dtos.PatientCareGiver;

namespace HomeCare.Repository
{
    public class PatientCareGiverRepository : IPatientCareGiverRepository
    {
        private readonly ApplicationDBContext _context;
        public PatientCareGiverRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<PatientCareGiver>> GetAllAsync()
        {
            return await _context.PatientCareGivers
                .Include(pc => pc.Patient)
                .Include(pc => pc.CareGiver)
                .ToListAsync();
        }

    }
}
