using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace TeduEcommerce.Dtos.Admin.Roles
{
    public class RoleInListDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; }

    }
}
