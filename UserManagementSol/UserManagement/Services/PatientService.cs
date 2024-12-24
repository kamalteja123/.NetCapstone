using Microsoft.IdentityModel.Tokens;
using UserManagement.Interfaces;
using UserManagement.Models;
using UserManagement.Models.DTO;

namespace UserManagement.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<int, Patient> _repository;
        public PatientService(IRepository<int, Patient> repository)
        {
            _repository = repository;   
        }
        public Task<PatientProfileDTO> UpdatePatient(PatientProfileDTO patientProfileDTO)
        {
           
        }
    }
}
