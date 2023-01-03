using System;
using System.Collections.Generic;
using System.Text;
using TeduEcommerce.Dtos.Admin;

namespace TeduEcommerce.Dtos.Admin.Products
{
    public class ProductListFilterDto : BaseListFilterDto
    {
        public Guid? CategoryId { get; set; }
    }
}
