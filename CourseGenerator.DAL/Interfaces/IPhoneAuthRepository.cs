using CourseGenerator.Models.Entities.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IPhoneAuthRepository : IRepository<PhoneAuth>
    {
        public Task<string> GetCodeByPhoneNumberAsync(string phoneNumber);
    }
}
