using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Repositories
{
    public class PhoneAuthRepository : GenericEFRepository<PhoneAuth>, IPhoneAuthRepository
    {
        public PhoneAuthRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<PhoneAuth> GetAsync(string phoneNumber)
        {
            PhoneAuth phoneAuth = await _context.PhoneAuths.FirstOrDefaultAsync(p => p.PhoneNumber == phoneNumber);
            return phoneAuth;
        }
    }
}
