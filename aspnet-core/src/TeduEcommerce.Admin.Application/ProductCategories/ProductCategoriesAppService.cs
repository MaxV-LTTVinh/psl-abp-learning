using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeduEcommerce.ProductCategories;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace TeduEcommerce.Admin.ProductCategories
{
    public class ProductCategoriesAppService : CrudAppService<ProductCategory, ProductCategoryDto, Guid, PagedResultRequestDto, CreateUpdateProductCategoryDto, CreateUpdateProductCategoryDto>, IProductCategoriesAppService
    {
        private readonly IMapper _mapper;
        public ProductCategoriesAppService(IRepository<ProductCategory, Guid> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async Task<PagedResultDto<ProductCategoryInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = _mapper.ProjectTo<ProductCategoryInListDto>(await Repository.GetQueryableAsync());
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), x => x.Name.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query.Skip(input.SkipCount).Take(input.MaxResultCount));
            return new PagedResultDto<ProductCategoryInListDto>(totalCount, data);
        }

        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public async Task<List<ProductCategoryInListDto>> GetListAllAsync()
        {
            var query = _mapper.ProjectTo<ProductCategoryInListDto>(await Repository.GetQueryableAsync());
            query = query.Where(x => x.IsActive);
            var data = await AsyncExecuter.ToListAsync(query);

            return data;

        }
    }
}
