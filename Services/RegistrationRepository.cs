using BMSLoanService.Data;
using BMSLoanService.Interfaces;
using BMSLoanService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSLoanService.Services
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ApplicationDBContext _context;
        public RegistrationRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Registration GetById(string Id)
        {
            try
            {
                var data = _context.Registrations.FirstOrDefault(e => e.Id == Id);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Registration GetByUserName(string username, string password)
        {
            var data = _context.Registrations.FirstOrDefault(e => e.UserName == username && e.Password == password);
            return data;
        }

        public Registration Update(Registration _reg)
        {
            try
            {
                _context.Update(_reg);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _reg;
        }

        public Registration Add(Registration _reg)
        {
            try
            {
                _context.Add(_reg);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _reg;
        }

    }
}
