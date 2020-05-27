using CourseGenerator.Models.Entities.Security;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IPhoneAuthRepository : IRepository<PhoneAuth>
    {
        Task<PhoneAuth> GetAsync(string phoneNumber);
    }
}
