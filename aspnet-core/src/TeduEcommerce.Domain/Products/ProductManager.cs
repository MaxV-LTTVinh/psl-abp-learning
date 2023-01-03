using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduEcommerce.Dtos.Admin.Products;
using TeduEcommerce.ProductCategories;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace TeduEcommerce.Products
{
    public class ProductManager : DomainService
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<ProductCategory, Guid> _productCategoryRepository;
        private readonly IMapper _mapper;
        public ProductManager(IRepository<Product,Guid> productRepository,
             IRepository<ProductCategory, Guid> productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Product> CreateAsync(CreateUpdateProductDto input)
        {
            if (await _productRepository.AnyAsync(x => x.Name == input.Name))
                throw new UserFriendlyException("Tên sản phẩm đã tồn tại", TeduEcommerceDomainErrorCodes.ProductNameAlreadyExists);
            if (await _productRepository.AnyAsync(x => x.Code == input.Code))
                throw new UserFriendlyException("Mã sản phẩm đã tồn tại", TeduEcommerceDomainErrorCodes.ProductCodeAlreadyExists);
            if (await _productRepository.AnyAsync(x => x.SKU == input.SKU))
                throw new UserFriendlyException("Mã SKU sản phẩm đã tồn tại", TeduEcommerceDomainErrorCodes.ProductSKUAlreadyExists);

            var category = await _productCategoryRepository.GetAsync(input.CategoryId);
            var result = new Product(Guid.NewGuid());
            _mapper.Map(input, result);
            result.CategoryName = category.Name;
            result.CategorySlug = category.Slug;
            return result;
        }
    }
}
