using AutoMapper;
using CourseGenerator.BLL.DTO;
using CourseGenerator.BLL.Extensions;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.DAL.Pagination;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.InfoByThemes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        
        public CourseService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<OperationInfo> AddUserToCourseAsync(string userId, int courseId, int levelId)
        {
            try
            {
                await _uow.UserCourseRepository.CreateAsync(new UserCourse
                {
                    UserId = userId,
                    CourseId = courseId,
                    LevelId = levelId
                });
                await _uow.SaveAsync();

                return new OperationInfo(true, "User was added to course successfully");
            }
            catch (Exception ex)
            {
                return new OperationInfo(false, $"Error: {ex.Message}");
            }
        }

        public async Task<PagedList<CourseItemDTO>> GetByPhoneWithLangPagedAsync(
            string userPhoneNumber, string langCode, int pageSize, int pageIndex)
        {
            User user = await _uow.UserManager.FindByPhoneNumberAsync(userPhoneNumber);
            if (user == null)
                return null;

            PagedList<CourseLang> coursesPaged = await _uow.CourseRepository.GetForUserWithLangPagedAsync(
                user.Id, langCode, pageSize, pageIndex);
            return coursesPaged.ConvertPagedList<CourseLang, CourseItemDTO>(_mapper);
        }

        public void Dispose() => _uow.Dispose();
    }
}
