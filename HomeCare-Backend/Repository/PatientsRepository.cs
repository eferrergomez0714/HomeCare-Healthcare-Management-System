using HomeCare.Data;
using HomeCare.Dtos.Patients;
using HomeCare.Interfaces;
using HomeCare.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeCare.Repository
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly ApplicationDBContext _context;
        public PatientsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Patients>> SearchByAgeAsync(int age)
        {
            return await _context.Patients
                .Where(p => p.Age >= age)
                .ToListAsync();
        }

        public async Task<List<Patients>> SearchByNameAsync(string name)
        {
            return await _context.Patients
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<Patients> CreateAsync(Patients patientModel)
        {
            await _context.Patients.AddAsync(patientModel);
            await _context.SaveChangesAsync();
            return patientModel;
        }

        public async Task<Patients?> DeleteAsync(int id)
        {
            var patientModel = await _context.Patients.FirstOrDefaultAsync(x=>x.Id == id);
            if (patientModel == null)
            {
                return null;
            }

            _context.Patients.Remove(patientModel);
            await _context.SaveChangesAsync();
            return patientModel;
        }

        public async Task<List<Patients>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patients?> GetByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<Patients?> UpdateAsync(int id, UpdatePatientsDto patientsDto)
        {
            var existingPatient = await _context.Patients.FirstOrDefaultAsync((x) => x.Id == id);

            if (existingPatient == null)
            {
                return null;
            }

            existingPatient.Name = patientsDto.Name;
            existingPatient.Email = patientsDto.Email;
            existingPatient.Age = patientsDto.Age;
            existingPatient.City = patientsDto.City;

            await _context.SaveChangesAsync();

            return existingPatient;
        }
    }
}
