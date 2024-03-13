using System;
using domain.Dto.common;
using Microsoft.AspNetCore.Http;

namespace domain.Dto.relestate
{
    public class RealEstateCatalogItemDto : BaseDto
    {
        public string? Name { get; set; }
        public int CatalogId { get; set; }
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public string? CatalogName { get; set; }
        public Guid? VersionIdentifier { get; set; }
        public string? Quote { get; set; }
        public bool? IsEnabled { get; set; }

        public float? Floors { get; set; }
        public int? Rooms { get; set; }
        public int? Bathrooms { get; set; }
        public int? GaragePlaces { get; set; }
        public string? Lamella { get; set; }
        public int? Floor { get; set; }
        public int? Units { get; set; }

        public string? Dimensions { get; set; }
        public float? NetArea { get; set; }
        public float? BruttoArea { get; set; }
        public bool? IsFeatured { get; set; }

        public int? CatalogItemTypeId { get; set; }
        public string? CatalogItemTypeName { get; set; }
        public int? CatalogItemStatusId { get; set; }

        public string? Disclaimer { get; set; }
        public bool? IsDisclamer { get; set; }
        public string? ApprovedUser { get; set; }
        public int? DeploymentStatusId { get; set; }

        public List<RealEstateCatalogItemDto> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
