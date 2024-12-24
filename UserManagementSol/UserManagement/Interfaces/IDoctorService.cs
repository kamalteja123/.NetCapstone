using UserManagement.Models.DTO;

namespace UserManagement.Interfaces
{
    public interface IDoctorService
    {
        public Task<DoctorProfileDTO> UpdatePatient(DoctorProfileDTO doctorProfileDTO);
    }
}
