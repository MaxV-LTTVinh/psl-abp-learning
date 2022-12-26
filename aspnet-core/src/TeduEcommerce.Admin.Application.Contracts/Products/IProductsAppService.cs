using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeduEcommerce.Products;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TeduEcommerce.Admin.Products
{
    public interface IProductsAppService : ICrudAppService
        <ProductDto,
        Guid, 
        PagedResultRequestDto,
        CreateUpdateProductDto, 
        CreateUpdateProductDto>
    {
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
        Task<PagedResultDto<ProductInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<ProductInListDto>> GetListAllAsync();
    }
}
