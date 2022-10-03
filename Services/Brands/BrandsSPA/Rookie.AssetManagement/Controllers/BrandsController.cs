using EnsureThat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Business.Interfaces;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Constants;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts.Dtos.BrandDtos;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Brands.BrandsSPA.Rookie.AssetManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<PagedResponseModel<BrandDto>>> GetBrands(
            [FromQuery] BrandQueryCriteriaDto brandCriteriaDto,
            CancellationToken cancellationToken)
        {
            var brandResponses = await _brandService.GetByPageAsync(
                                            brandCriteriaDto,
                                            cancellationToken);
            return Ok(brandResponses);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<BrandDto>> GetBrandById(int id)
        {
            var brandResponses = await _brandService.GetByIdAsync(id);
            if (brandResponses == null)
            {
                return NotFound();
            }
            return Ok(brandResponses);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<BrandDto>> AddBrand([FromBody] BrandCreateDto brandRequest)
        {
            var brand = await _brandService.AddAsync(brandRequest);
            return Created(Endpoints.Brand, brand);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BrandDto>> UpdateBrand(
            [FromRoute] int id,
            [FromBody] BrandUpdateDto brandRequest)
        {
            Ensure.Any.IsNotNull(brandRequest, nameof(brandRequest));

            var updatedBrand = await _brandService.UpdateAsync(id, brandRequest);

            return Ok(updatedBrand);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteBrandAsync([FromRoute] int id)
        {
            var deleteResult = await _brandService.DeleteAsync(id);

            return Ok(deleteResult);
        }
    }
}