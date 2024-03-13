using AutoMapper;
using application.Specifications.cpm;
using domain.Dto.relestate;
using domain.Entities.releastate;
using domain.Entities.users;
using domain.Enums.realestate;
using domain.Interfaces.Repositories;
using domain.Interfaces.ICRUDservices.cpm;
using application.Specifications;
using Microsoft.AspNetCore.Http;
using application.Specifications.crm;
using domain.Dto.crm;
using NuGet.Protocol.Core.Types;
using System;

namespace application.CRUDservices.cpm
{
    public class RealestateCatalogItemServices : IRealestateCatalogItemServices
    {
        private readonly IRepository<CatalogItem> _realestateCatalogItemRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<UserWrapper> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RealestateCatalogItemServices(
            IRepository<CatalogItem> realestateCatalogItemRepository, 
            IRepository<UserWrapper> userRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _realestateCatalogItemRepository = realestateCatalogItemRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<RealEstateCatalogItemDto>> GetEntities()
        {
            var userCompanyId = GetCurrentUserCompanyIdNullable();

            BaseSpecification<CatalogItem> spec;
            if (userCompanyId.HasValue)
            {
                spec = new NotDeletedRealestateCatalogItemSpec(userCompanyId.Value);
            }
            else
            {
                spec = new AllRealestateCatalogItemSpec();
            }

            return _mapper.Map<List<RealEstateCatalogItemDto>>(await _realestateCatalogItemRepository.List(spec));
        }

        private int? GetCurrentUserCompanyIdNullable()
        {
            var companyIdClaim = _httpContextAccessor.HttpContext.User.FindFirst("CompanyIdClaimType");
            if (companyIdClaim != null && int.TryParse(companyIdClaim.Value, out var companyId))
            {
                return companyId;
            }
            return null; 
        }
        public async Task<List<RealEstateCatalogItemDto>> GetAllEntities()
        {
            return _mapper.Map<List<RealEstateCatalogItemDto>>(await _realestateCatalogItemRepository.List(new NotDeleatedCatalogItemSpec()));
        }
        public async Task<RealEstateCatalogItemDto> GetEntity(int id)
        {
            var brand = await _realestateCatalogItemRepository.GetSingleBySpec(new RealestateCatalogItemGetByIdAndIncludeAllSpecification(id));

            return _mapper.Map<RealEstateCatalogItemDto>(brand);
        }
        public async Task<RealEstateCatalogItemDto> UpdateEntity(int id, RealEstateCatalogItemDto dto)
        {
            var entity = await _realestateCatalogItemRepository.GetById(id);
            _mapper.Map(dto, entity);

            await _realestateCatalogItemRepository.Update(entity);

            if (dto.DeploymentStatusId == (int)DeploymentStatusEnum.Approved)
            {
                var user = await _userRepository.GetSingleBySpec(new UserSpecification(entity.ModifiedUser));
                entity.ApprovedUser = user.User.FirstName + " " + user.User.LastName;
                await _realestateCatalogItemRepository.Update(entity);
            }

            return _mapper.Map<RealEstateCatalogItemDto>(entity);
        }
        public async Task<RealEstateCatalogItemDto> AddEntity(RealEstateCatalogItemDto dto)
        {
            var entity = _mapper.Map<CatalogItem>(dto);
            

            entity.VersionIdentifier = Guid.NewGuid();
            entity.IsEnabled = true;
            entity.IsFeatured = false;

            await _realestateCatalogItemRepository.Add(entity);

            if (dto.DeploymentStatusId==(int)DeploymentStatusEnum.Approved)
            {
                var user = await _userRepository.GetSingleBySpec(new UserSpecification(entity.CreatedUser));
                entity.ApprovedUser = user.User.FirstName + " " + user.User.FirstName;
                await _realestateCatalogItemRepository.Update(entity);
            }

            return _mapper.Map<RealEstateCatalogItemDto>(entity);
        }
        public async Task<RealEstateCatalogItemDto> DeleteEntity(int id)
        {
            var entity = await _realestateCatalogItemRepository.GetSingleBySpec(new RealestateCatalogItemGetByIdSpecification(id));
            if (entity != null)
            {
                entity.IsDeleted = true;
                await _realestateCatalogItemRepository.Update(entity);
            }

            return _mapper.Map<RealEstateCatalogItemDto>(entity);
        }
        public async Task<RealEstateCatalogItemDto> UpdateIsEnabledCatalogItem(int catalogItemId, bool isEnabledValue)
        {
            var catalogItem = await _realestateCatalogItemRepository.GetSingleBySpec(new RealestateCatalogItemGetByIdSpecification(catalogItemId));
            if (catalogItem != null)
            {
                catalogItem.IsEnabled = isEnabledValue;
                await _realestateCatalogItemRepository.Update(catalogItem);
            }
            return _mapper.Map<RealEstateCatalogItemDto>(catalogItem);
        }
        public async Task<RealEstateCatalogItemDto> UpdateIsFeaturedCatalogItem(int catalogItemId, bool isFeaturedValue)
        {
            var catalogItem = await _realestateCatalogItemRepository.GetSingleBySpec(new RealestateCatalogItemGetByIdSpecification(catalogItemId));
            if (catalogItem != null)
            {
                catalogItem.IsFeatured = isFeaturedValue;
                await _realestateCatalogItemRepository.Update(catalogItem);
            }
            return _mapper.Map<RealEstateCatalogItemDto>(catalogItem);
        }
        public async Task<RealEstateCatalogItemDto> UpdateIsDisclamerCatalogItem(int catalogItemId, bool isDisclamerValue)
        {
            var catalogItem = await _realestateCatalogItemRepository.GetSingleBySpec(new RealestateCatalogItemGetByIdSpecification(catalogItemId));
            if (catalogItem != null)
            {
                catalogItem.IsDisclamer = isDisclamerValue;
                await _realestateCatalogItemRepository.Update(catalogItem);
            }
            return _mapper.Map<RealEstateCatalogItemDto>(catalogItem);
        }
        public class RealEstateCatalogItemsResultDto
        {
            public List<RealEstateCatalogItemDto> Items { get; set; }
            public int TotalCount { get; set; }
        }

        public async Task<RealEstateCatalogItemDto> GetFilteredRealestateCatalogItemsAsync(int page = 1, int pageSize = 10, string search = "")
        {
            var spec = new CatalogItemWithRelatedSpecification(search, page, pageSize);

            var items = await _realestateCatalogItemRepository.ListAsync(spec);
            var totalItems = await _realestateCatalogItemRepository.CountAsync(spec);

            var resultDto = new RealEstateCatalogItemDto
            {
                Items = _mapper.Map<List<RealEstateCatalogItemDto>>(items),
                TotalCount = totalItems
            };

            return resultDto;
        }
    }
}
