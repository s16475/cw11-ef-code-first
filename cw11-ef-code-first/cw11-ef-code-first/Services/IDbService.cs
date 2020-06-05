using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11_ef_code_first.DTOs;
using cw11_ef_code_first.Models;

namespace cw11_ef_code_first.Services
{
    public interface IDbService
    {
        Doctor AddDoctor(AddDoctorRequest request);
        Doctor UpdateDoctor(UpdateDoctorRequest request);
        public IEnumerable<Doctor> GetDoctors();
        public string DeleteDoctor(int id);
    }
}