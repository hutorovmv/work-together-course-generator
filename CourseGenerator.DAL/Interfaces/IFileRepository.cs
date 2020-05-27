using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IFileRepository: IDisposable
    {
        Task<string> CreateAsync(FileStream item);

        Task DeleteAsync(string id);

        Task<byte[]> GetFile(string Id);

        Task Update(FileStream item, string Id);
    }
}
