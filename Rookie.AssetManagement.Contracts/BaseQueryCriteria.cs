using System.Collections.Generic;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;

namespace Rookie.AssetManagement.Contracts
{
    public class BaseQueryCriteria
    {
        public string Search { get; set; }
        public int Limit { get; set; } = 10;
        public int Page { get; set; } = 1;
        public SortOrderEnumDto SortOrder { get; set; }
        public string SortColumn { get; set; }
    }
}