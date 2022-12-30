using System;
using System.Collections.Generic;
using System.Text;

namespace TeduEcommerce.Admin.Products.Attributes
{
    public class AddUpdateProductAttributeDto
    {
        public Guid ProductId { get; set; }
        public Guid AttributeId { get; set; }

        public DateTime? DateTimeValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public int? IntValue { get; set; }
        public Guid? TextId { get; set; }
        public Guid? VarcharId { get; set; }

    }
}
