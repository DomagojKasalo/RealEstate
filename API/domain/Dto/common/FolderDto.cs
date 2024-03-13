using System;
using System.Collections.Generic;
using System.Text;

namespace domain.Dto.common
{
    public class FolderDto : BaseDto
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int BrandId { get; set; }
    }
}
