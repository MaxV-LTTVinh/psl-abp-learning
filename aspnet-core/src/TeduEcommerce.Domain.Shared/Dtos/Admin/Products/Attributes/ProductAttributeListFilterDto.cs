using System;
using System.Collections.Generic;
using System.Text;
using TeduEcommerce.Dtos.Admin;

namespace TeduEcommerce.Dtos.Admin.Products.Attributes
{
    public class ProductAttributeListFilterDto : BaseListFilterDto
    {
        public Guid ProductId { get; set; }
    }
}
