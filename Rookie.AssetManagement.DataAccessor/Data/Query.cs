using HotChocolate.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.DataAccessor.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Brand> GetBrands => 
            new List<Brand>().AsQueryable();
    }
}
