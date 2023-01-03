using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeduEcommerce.Dtos.Admin;
using TeduEcommerce.Dtos.Admin.Manufacturers;
using TeduEcommerce.Dtos.Admin.Roles;
using TeduEcommerce.Manufacturers;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TeduEcommerce.Admin.Manufacturers
{
    [Authorize]
    public class ManufacturersAppService : CrudAppService<
        Manufacturer,
        ManufacturerDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateManufacturerDto,
        CreateUpdateManufacturerDto>, IManufacturersAppService
    {
        private readonly IMapper _mapper;
        public ManufacturersAppService(IRepository<Manufacturer, Guid> repository, IMapper mapper)
            : base(repository)
        {
            _mapper = mapper;
        }

        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public async Task<List<ManufacturerInListDto>> GetListAllAsync()
        {
            var query = _mapper.ProjectTo<ManufacturerInListDto>(await Repository.GetQueryableAsync());
            query = query.Where(x=>x.IsActive);
            var data = await AsyncExecuter.ToListAsync(query);

            return data;

        }

        public async Task<PagedResultDto<ManufacturerInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = _mapper.ProjectTo<ManufacturerInListDto>(await Repository.GetQueryableAsync());
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), x => x.Name.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query.Skip(input.SkipCount).Take(input.MaxResultCount));

            return new PagedResultDto<ManufacturerInListDto>(totalCount,data);
        }
    }
}
