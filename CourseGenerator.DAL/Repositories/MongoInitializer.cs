using CourseGenerator.DAL.Context;
using CourseGenerator.Models;
using CourseGenerator.Models.Entities.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.DAL.Repositories
{
    public class MongoInitializer
    {
        GenericMongoRepository<Article> _mongoRepository;
        static Article[] Articles = TestData.Articles;
        public MongoInitializer(GenericMongoRepository<Article> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async void Initialize()
        {
            await _mongoRepository.CreateManyAsync(Articles);
        }

        public void Drop()
        {
            _mongoRepository.DropCollection(typeof(Article).Name.ToLower());
        }
        
    }
}
