using CourseGenerator.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Interfaces
{
    public interface ILanguageService : IDisposable
    {
        Task<IEnumerable<LanguageSelectDTO>> GetAllAsync();
    }
}
