using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenia_11.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia_11.Service
{
    public class DoctorDbService:IDbService
    {
        private readonly SqlDbContext _context;

        public DoctorDbService(SqlDbContext context)
        {
            _context = context;
        }


        public List<Doctor> GetDoctors()
        {
            
            return _context.Doctor.ToList();
        }


        public bool AddDoctor(Doctor doctor)
        {
            try
            {
                _context.Doctor.Add(doctor);
                _context.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ModifyDoctor(Doctor modDoctor)
        {
          
                var doctor = _context.Doctor.SingleOrDefault(d => d.IdDoctor == modDoctor.IdDoctor);

                if (doctor == null) return false;

                if (modDoctor.FirstName != null)
                {
                    doctor.FirstName = modDoctor.FirstName;
                }

                if (modDoctor.LastName != null)
                {
                    doctor.LastName = modDoctor.LastName;
                }

                if (modDoctor.Email != null)
                {
                    doctor.Email = modDoctor.Email;
                }

                _context.SaveChanges();

                return true;
           
        }

        
        public bool DeleteDoctor(int id)
        {
                var doctor = _context.Doctor.SingleOrDefault(d => d.IdDoctor == id);
                if (doctor == null) return  false;

                _context.Doctor.Remove(doctor);
                _context.SaveChanges();
                return true;
          
            
        }
    }
}

