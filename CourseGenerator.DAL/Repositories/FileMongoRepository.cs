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
    public class FileMongoRepository
    {
        protected readonly MongoContext _context;
        IGridFSBucket gridFS; 

        public FileMongoRepository(MongoContext context)
        {
            _context = context;
            gridFS = new GridFSBucket(_context.GetDataBase());
        }

        public async Task<ObjectId> CreateAsync(FileStream item)
        {
            return await gridFS.UploadFromStreamAsync(item.Name,item);
        }

        public async Task DeleteAsync(ObjectId id)
        {
            try
            {
                await gridFS.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
        }

        public async Task<byte[]> GetFile(ObjectId Id)
        {
            //var expression = new ExpressionFilterDefinition<GridFSFileInfo>(d => d.Id == Id);
            //var file = await gridFS.FindAsync(expression);
            //var fileInfo = file.FirstOrDefault();

            //return fileInfo; //Повертає об'єкт типу GridFsFileInfo, що містить основну інформацію про файл. 

            var photo = gridFS.DownloadAsBytesAsync(Id);
            return await photo;
        }

        public async void Update(FileStream item, ObjectId Id)
        {
            await gridFS.UploadFromStreamAsync(
            item.Name,
            item,
            new GridFSUploadOptions { Metadata = new BsonDocument("Id", Id) });
        }
    }
}
