using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11_ef_code_first.DTOs;
using cw11_ef_code_first.Models;

namespace cw11_ef_code_first.Services
{
    public class DbService : IDbService
    {
        private readonly HospitalContext _hospitalContext;

        public DbService(HospitalContext hospitalContext)
        {
            _hospitalContext = hospitalContext;
        }

        public Doctor AddDoctor(AddDoctorRequest request)
        {
            var doctor = new Doctor { IdDoctor = request.IdDoctor, FirstName = request.FirstName, LastName = request.LastName, Email = request.Email };
            _hospitalContext.Add(doctor);
            _hospitalContext.SaveChanges();

            return doctor;
        }

        public string DeleteDoctor(int id)
        {
            var doctor = _hospitalContext.Doctors.FirstOrDefault(d => d.IdDoctor == id);
            if (doctor != null)
            {
                _hospitalContext.Remove(doctor);
                _hospitalContext.SaveChanges();
                return "Doctor deleted";
            }
            else
                return "Doctor not found";
        }


        public IEnumerable<Doctor> GetDoctors()
        {
            return _hospitalContext.Doctors;
        }

        public Doctor UpdateDoctor(UpdateDoctorRequest request)
        {
            var doctor = _hospitalContext.Doctors.FirstOrDefault(d => d.IdDoctor == request.IdDoctor);
            if (doctor != null)
            {
                doctor.FirstName = request.FirstName;
                doctor.LastName = request.LastName;
                doctor.Email = request.Email;

                _hospitalContext.Update(doctor);
                _hospitalContext.SaveChanges();

                return doctor;
            }
            else
                return null;
        }

    }
}
