using Rookie.AssetManagement.Contracts.Dtos;
using System.Threading.Tasks;
using System.Threading;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.BrandDtos;

namespace Rookie.AssetManagement.Business.Interfaces
{
    public interface IBrandService
    {
        Task<PagedResponseModel<BrandDto>> GetByPageAsync(BrandQueryCriteriaDto assetQueryCriteria, CancellationToken cancellationToken);
        Task<BrandDto> GetByIdAsync(int id);
        Task<BrandDto> AddAsync(BrandCreateDto assetRequest);
        Task<BrandDto> UpdateAsync(int id, BrandUpdateDto assetUpdateDto);
        Task<bool> DeleteAsync(int id);
    }
}
