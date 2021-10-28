using BMSLoanService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSLoanService.Interfaces
{
    public interface IRegistrationRepository
    {
        Registration GetById(string Id);

        Registration GetByUserName(string username, string password);

        Registration Update(Registration _reg);

        Registration Add(Registration _reg);
    }
}
