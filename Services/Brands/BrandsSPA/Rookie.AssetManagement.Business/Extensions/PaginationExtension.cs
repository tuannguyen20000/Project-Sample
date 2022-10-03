using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts.Constants;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts.Dtos.EnumDtos;

namespace Services.Brands.BrandsSPA.Rookie.AssetManagement.Business
{
    public static class DataPagerExtension
    {
        public static async Task<PagedModel<TModel>> PaginateAsync<TModel>(
            this IQueryable<TModel> query,
            BaseQueryCriteria criteriaDto,
            CancellationToken cancellationToken)
            where TModel : class
        {

            var paged = new PagedModel<TModel>();

            paged.CurrentPage = (criteriaDto.Page < 0) ? 1 : criteriaDto.Page;
            paged.PageSize = criteriaDto.Limit;

            if (!string.IsNullOrEmpty(criteriaDto.SortOrder.ToString()) &&
                !string.IsNullOrEmpty(criteriaDto.SortColumn))
            {
                var sortOrder = criteriaDto.SortOrder == (int)SortOrderEnumDto.Accsending ?
                                    PagingSortingConstants.ASC :
                                    PagingSortingConstants.DESC;
                var orderString = $"{criteriaDto.SortColumn} {sortOrder}";
                query = query.OrderBy(orderString);
            }

            var startRow = (paged.CurrentPage - 1) * paged.PageSize;

            paged.Items = await query
                        .Skip(startRow)
                        .Take(paged.PageSize)
                        .ToListAsync(cancellationToken);

            paged.TotalItems = await query.CountAsync(cancellationToken);
            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)paged.PageSize);

            return paged;
        }
    }
}