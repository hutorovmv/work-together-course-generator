using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Repositories
{
    public class FileMongoRepository:IFileRepository
    {
        protected readonly MongoContext _context;
        IGridFSBucket gridFS; 

        public FileMongoRepository(MongoContext context)
        {
            _context = context;
            gridFS = new GridFSBucket(_context.GetDataBase());
        }

        public async Task<string> CreateAsync(FileStream item)
        {
            var photoId = await gridFS.UploadFromStreamAsync(item.Name, item);
            return photoId.ToString();
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                await gridFS.DeleteAsync(new ObjectId(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
        }

        public async Task<byte[]> GetFile(string Id)
        {
            //var expression = new ExpressionFilterDefinition<GridFSFileInfo>(d => d.Id == Id);
            //var file = await gridFS.FindAsync(expression);
            //var fileInfo = file.FirstOrDefault();

            //return fileInfo; //Повертає об'єкт типу GridFsFileInfo, що містить основну інформацію про файл. 

            var photo = gridFS.DownloadAsBytesAsync(new ObjectId(Id));
            return await photo;
        }

        public async Task Update(FileStream item, string Id)
        {
            await gridFS.UploadFromStreamAsync(
            item.Name,
            item,
            new GridFSUploadOptions { Metadata = new BsonDocument("Id", Id) });
        }
    }
}
