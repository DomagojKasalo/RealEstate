using System;

namespace domain.Dto.common
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string? CreatedUser { get; set; }
        public string? ModifiedUser { get; set; }
    }
}
