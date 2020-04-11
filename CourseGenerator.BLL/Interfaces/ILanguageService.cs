using CourseGenerator.BLL.DTO;
using CourseGenerator.Models.Entities.Info;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Interfaces
{
    public interface ILanguageService : IDisposable
    {
        Task<IEnumerable<LanguageSelectDTO>> GetAllAsync();
    }
}
