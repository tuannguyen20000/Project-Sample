using Rookie.AssetManagement.Contracts.Dtos.BrandDtos;
using Rookie.AssetManagement.DataAccessor.Entities;

namespace Rookie.AssetManagement.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
             CreateMap<BrandCreateDto, Brand>()
                .ForMember(d => d.Id, t => t.Ignore())
                .ForMember(d => d.IsDeleted, t => t.Ignore());
        }

        private void FromDataAccessorLayer()
        {
            CreateMap<Brand, BrandCreateDto>()
                .ReverseMap();
            CreateMap<BrandDto, BrandCreateDto>()
                .ReverseMap();
            CreateMap<Brand, BrandDto>()
                .ReverseMap(); 
        }
    }
}
