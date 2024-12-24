using UserManagement.Models.DTO;

namespace UserManagement.Interfaces
{
    public interface IPatientService
    {
        public Task<PatientProfileDTO> UpdatePatient(PatientProfileDTO patientProfileDTO);
    }
}
