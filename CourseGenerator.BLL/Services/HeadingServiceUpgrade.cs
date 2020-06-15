using CourseGenerator.BLL.DTO.Entities;
using CourseGenerator.BLL.DTO.Locals;
using CourseGenerator.BLL.DTO.Security;
using CourseGenerator.BLL.DTO.Selection;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.BLL.Interfaces.Generic;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Info;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using AutoMapper;

namespace CourseGenerator.BLL.Services
{
    /// <summary>
    /// Фасад
    /// </summary>
    public class HeadingServiceUpgrade : IHeadingServiceUpgrade

    {
        protected readonly ICrudService<Heading, HeadingDTO> _crudService;
        protected readonly ICrudLocalService<HeadingLang, HeadingLangDTO>
            _localCrudService;
        protected readonly IHierarchyLocalService<string, HeadingLang,
            HeadingSelectDTO> _hierarchyService;
        protected readonly IAccessCheckService<HeadingManager>
            _accessCheckService;
        protected readonly IManagerAccessService<HeadingManager,
            HeadingManagerDTO> _managerAccessService;
        
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        public HeadingServiceUpgrade(
            IMapper mapper,
            IUnitOfWork uow,
            ICrudService<Heading, HeadingDTO> crudService,
            ICrudLocalService<HeadingLang, HeadingLangDTO> localCrudService,
            IHierarchyLocalService<string, HeadingLang, HeadingSelectDTO>
                hierarchyService,
            IAccessCheckService<HeadingManager> accessCheckService,
            IManagerAccessService<HeadingManager, HeadingManagerDTO>
                managerAccessService)
        {
            _uow = uow;
            _mapper = mapper;

            _crudService = crudService;
            _localCrudService = localCrudService;
            _hierarchyService = hierarchyService;
            _accessCheckService = accessCheckService;
            _managerAccessService = managerAccessService;
        }

        public async Task<int?> CreateAsync(string userId, HeadingDTO dto)
        {
            OperationInfo result = await _accessCheckService
                .HasCreateAccess(userId, dto.Id);

            if (!result.Succeeded)
                return null;

            try
            {
                Heading entity = _mapper.Map<Heading>(dto);

                await _uow.HeadingRepository.CreateAsync(entity);
                await _uow.SaveAsync();

                return entity.Id;
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        //TODO: Add to all hierarchable methods (allows to add subheadings) and returns id
        public async Task<int?> CreateAsync(string userId,
            HeadingDTO dto, string parentCode)
        {
            OperationInfo result = await _accessCheckService
                .HasCreateAccess(userId, dto.Id);

            if (!result.Succeeded || dto == null)
                return null;

            try
            {
                Heading entity = _mapper.Map<Heading>(dto);

                string lastCode = _uow.HeadingRepository.GetLastCode(parentCode);
                //TODO: Create a separate method for the operation
                List<string> segments = new List<string>(lastCode.Split('.'));
                string lastSegment = segments.LastOrDefault();

                if (int.TryParse(lastSegment, out int lastSegmentNum))
                {
                    segments.RemoveAt(segments.Count - 1);
                    string newLastSegment = Convert.ToString(++lastSegmentNum);
                    segments.Add(newLastSegment);
                    entity.Code = string.Join(".", segments);
                }

                await _uow.HeadingRepository.CreateAsync(entity);
                await _uow.SaveAsync();

                return entity.Id;
            }
            catch (Exception ex)
            {
                
            }

            return null;
        }

        public async Task<HeadingDTO> GetAsync(string userId,
            params object[] id)
        {
            OperationInfo result = await _accessCheckService
                .HasGetAccess(userId, id);

            if (!result.Succeeded)
                return null;

            return await _crudService.GetAsync(userId, id);
        }

        public async Task<OperationInfo> UpdateAsync(string userId,
            HeadingDTO dto)
        {
            OperationInfo result = await _accessCheckService
                .HasUpdateAccess(userId, dto.Id);

            if (!result.Succeeded)
                return null;

            return await _crudService.UpdateAsync(userId, dto);
        }

        public async Task<OperationInfo> DeleteAsync(string userId,
            params object[] id)
        {
            OperationInfo result = await _accessCheckService
                .HasDeleteAccess(userId, id);

            if (!result.Succeeded)
                return null;

            return await _crudService.DeleteAsync(userId, id);
        }

        async Task<OperationInfo> ICrudService<Heading, HeadingDTO>
            .CreateAsync(string userId, HeadingDTO dto)
        {
            bool result = await CreateAsync(userId, dto) != null;
            
            if (result)
                return new OperationInfo(true, "Heading created successfully");

            return new OperationInfo(false, "Error while creating heading");
        }



        public async Task<OperationInfo> CreateLocalAsync(string userId,
            HeadingLangDTO dto)
        {
            OperationInfo result = await _accessCheckService
                .HasCreateAccess(userId, dto.HeadingId);

            if (!result.Succeeded)
                return null;

            return await _localCrudService.CreateLocalAsync(userId, dto);
        }

        public async Task<HeadingLangDTO> GetLocalAsync(string userId,
            string langCode, params object[] id)
        {
            OperationInfo result = await _accessCheckService
                .HasGetAccess(userId, id);

            if (!result.Succeeded)
                return null;

            return await _localCrudService.GetLocalAsync(userId, langCode, id);
        }

        public async Task<OperationInfo> UpdateLocalAsync(string userId,
            HeadingLangDTO dto)
        {
            OperationInfo result = await _accessCheckService
                .HasUpdateAccess(userId, dto.HeadingId);

            if (!result.Succeeded)
                return null;

            return await _localCrudService.UpdateLocalAsync(userId, dto);
        }

        public async Task<OperationInfo> DeleteLocalAsync(string userId,
            string langCode, params object[] id)
        {
            OperationInfo result = await _accessCheckService
                .HasDeleteAccess(userId, id);

            if (!result.Succeeded)
                return null;

            return await _localCrudService.DeleteLocalAsync(userId, langCode,
                id);
        }



        public async Task<IEnumerable<HeadingSelectDTO>> GetRootLocalAsync(
            string userId, string langCode)
        {
            IEnumerable<HeadingSelectDTO> items = await _hierarchyService
                .GetRootLocalAsync(userId, langCode);

            return await SelectAccessableAsync(userId, items);
        }

        public async Task<IEnumerable<HeadingSelectDTO>> GetParentsLocalAsync(
            string userId, string langCode, string id)
        {
            IEnumerable<HeadingSelectDTO> items = await _hierarchyService
                .GetParentsLocalAsync(userId, langCode, id);

            return await SelectAccessableAsync(userId, items);
        }

        public async Task<IEnumerable<HeadingSelectDTO>> GetChildrenLocalAsync(
            string userId, string langCode, string id)
        {
            IEnumerable<HeadingSelectDTO> items = await _hierarchyService
                .GetChildrenLocalAsync(userId, langCode, id);

            return await SelectAccessableAsync(userId, items);
        }



        public async Task<OperationInfo> CreateManagerAsync(string userId,
            HeadingManagerDTO dto)
        {
            return await _managerAccessService.CreateAsync(userId, dto);
        }

        public async Task<HeadingManagerDTO> GetManagerAsync(string userId,
            params object[] id)
        {
            return await _managerAccessService.GetManagerAsync(userId, id);
        }

        public async Task<OperationInfo> UpdateManagerAsync(string userId,
            HeadingManagerDTO dto)
        {
            return await _managerAccessService.UpdateManagerAsync(userId, dto);
        }

        public async Task<OperationInfo> DeleteManagerAsync(string userId,
            params object[] id)
        {
            return await _managerAccessService.DeleteManagerAsync(userId, id);
        }


        async Task<OperationInfo> ICrudService<HeadingManager, HeadingManagerDTO>
            .CreateAsync(string userId, HeadingManagerDTO dto)
        {
            return await CreateManagerAsync(userId, dto);
        }

        async Task<HeadingManagerDTO> ICrudService<HeadingManager, HeadingManagerDTO>
            .GetAsync(string userId, params object[] id)
        {
            return await GetManagerAsync(userId, id);
        }

        async Task<OperationInfo> ICrudService<HeadingManager, HeadingManagerDTO>
            .UpdateAsync(string userId, HeadingManagerDTO dto)
        {
            return await UpdateManagerAsync(userId, dto);
        }

        async Task<OperationInfo> ICrudService<HeadingManager, HeadingManagerDTO>
            .DeleteAsync(string userId, params object[] id)
        {
            return await DeleteManagerAsync(userId, id);
        }


        private async Task<List<HeadingSelectDTO>> SelectAccessableAsync(
            string userId, IEnumerable<HeadingSelectDTO> items)
        {
            List<HeadingSelectDTO> itemList = new List<HeadingSelectDTO>(items);
            
            for (int i = 0; i < itemList.Count; i++)
            {
                OperationInfo result = await _accessCheckService
                    .HasGetAccess(userId, itemList[i].Id);
                if (!result.Succeeded)
                    itemList.RemoveAt(i--);
                else
                    itemList[i].Code = await _uow.HeadingRepository
                        .GetCode(itemList[i].Id);
            }

            return itemList;
        }

        public virtual void Dispose()
        {
            _crudService.Dispose();
            _localCrudService.Dispose();
            _accessCheckService.Dispose();
            _managerAccessService.Dispose();
        }
    }
}