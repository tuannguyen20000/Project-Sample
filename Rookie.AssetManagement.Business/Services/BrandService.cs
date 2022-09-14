using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Rookie.AssetManagement.DataAccessor.Enums;
using Rookie.AssetManagement.Contracts.Dtos.BrandDtos;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using EnsureThat;

namespace Rookie.AssetManagement.Business.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBaseRepository<Brand> brandRepository,
            IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponseModel<BrandDto>> GetByPageAsync(
            BrandQueryCriteriaDto brandQueryCriteria, 
            CancellationToken cancellationToken)
        {
            var brandQuery = BrandFilter(
                _brandRepository.Entities.Where(x => !x.IsDeleted).AsQueryable(), 
                brandQueryCriteria);

            var brands = await brandQuery
                .AsNoTracking()
                .PaginateAsync(
                    brandQueryCriteria,
                    cancellationToken);

            var brandssDto = _mapper.Map<IEnumerable<BrandDto>>(brands.Items);

            return new PagedResponseModel<BrandDto>
            {
                CurrentPage = brands.CurrentPage,
                TotalPages = brands.TotalPages,
                TotalItems = brands.TotalItems,
                Items = brandssDto
            };
        }

        public async Task<BrandDto> GetByIdAsync(int id)
        {
            var brand = await _brandRepository.Entities
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(b => b.Id == id);
            var brandDto = _mapper.Map<BrandDto>(brand);
            return brandDto;
        }

        public async Task<BrandDto> AddAsync(BrandCreateDto brandRequest)
        {
            Ensure.Any.IsNotNull(brandRequest);
            var newBrand = _mapper.Map<Brand>(brandRequest);
            var brand = await _brandRepository.Add(newBrand);
            return  _mapper.Map<BrandDto>(brand);
        }

        public async Task<BrandDto> UpdateAsync(int id, BrandUpdateDto brandRequest)
        {
            var brand = await _brandRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

            if (brand == null)
            {
                throw new NotFoundException("Not Found!");
            }

            brand.Type = (BrandTypeEnum)brandRequest.Type;

            var brandUpdated = await _brandRepository.Update(brand);

            var brandUpdatedDto = _mapper.Map<BrandDto>(brandUpdated);

            return brandUpdatedDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var brand = await _brandRepository.Entities
                .SingleOrDefaultAsync(b => b.Id.Equals(id));

            if (brand is null)
            {
                throw new NotFoundException($"Brand id {id} is Not Found");
            }

            brand.IsDeleted = true;
            await _brandRepository.Update(brand);

            return await Task.FromResult(true);
        }


        #region Private Method
        private IQueryable<Brand> BrandFilter(
            IQueryable<Brand> brandQuery,
            BrandQueryCriteriaDto brandQueryCriteria)
        {
            if (!String.IsNullOrEmpty(brandQueryCriteria.Search))
            {
                brandQuery = brandQuery.Where(b =>
                    b.Name.Contains(brandQueryCriteria.Search));
            }

            if (brandQueryCriteria.Types != null &&
                brandQueryCriteria.Types.Count() > 0 &&
               !brandQueryCriteria.Types.Any(x => x == (int)BrandTypeEnumDto.All))
            {
                brandQuery = brandQuery.Where(x => 
                    brandQueryCriteria.Types.Any(t => t == (int)x.Type));
            }

            return brandQuery;
        }
        #endregion
    }
}
