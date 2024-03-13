using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using domain.Dto.relestate;
using domain.Interfaces.ICRUDservices.cpm;
using persistance.Datacontext;
using Microsoft.EntityFrameworkCore;
using domain.Entities.realestate;
using domain.Dto.realestate;
using AutoMapper;
using System.Linq.Expressions;
using domain.Entities.releastate;
using System.Linq;


namespace api.Controllers.CPM.V1
{
    //[Authorize(Roles = "Admin, Client, Basic User", AuthenticationSchemes = "Bearer")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RealestateCatalogItemsController : ControllerBase
    {
        private readonly IRealestateCatalogItemServices _realestateCatalogItemServices;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RealestateCatalogItemsController
            (AppDbContext context,
            IRealestateCatalogItemServices realestateCatalogItemServices,
            IMapper mapper)
        {
            _realestateCatalogItemServices = realestateCatalogItemServices;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{catalogItemId}/images")]
        public async Task<ActionResult<List<CatalogItemImageDto>>> GetCatalogItemImages(int catalogItemId)
        {
            var images = await _context.CatalogItemImages
                                        .Where(x => x.CatalogItemId == catalogItemId)
                                        .Select(x => new CatalogItemImageDto
                                        {
                                            Id = x.Id,
                                            CatalogItemId = x.CatalogItemId,
                                            ImagePath = x.ImagePath
                                        })
                                        .ToListAsync();

            return Ok(images);
        }

        [HttpPost("{catalogItemId}/images")]
        public async Task<IActionResult> UploadImageForCatalogItem(int catalogItemId, [FromForm] IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                var catalogItemImage = new CatalogItemImage
                {
                    CatalogItemId = catalogItemId,
                    ImagePath = "/images/" + fileName
                };

                _context.CatalogItemImages.Add(catalogItemImage);
                await _context.SaveChangesAsync();

                return Ok(new CatalogItemImageDto { });
            }

            return BadRequest("Image file is missing");
        }

        [HttpDelete("{catalogItemId}/images/{imageId}")]
        public async Task<IActionResult> DeleteImageFromCatalogItem(int catalogItemId, int imageId)
        {
            var imageEntity = await _context.CatalogItemImages
                                            .FirstOrDefaultAsync(x => x.Id == imageId && x.CatalogItemId == catalogItemId);

            if (imageEntity == null)
            {
                return NotFound("Image not found");
            }

            var filePath = Path.Combine("wwwroot", imageEntity.ImagePath);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            _context.CatalogItemImages.Remove(imageEntity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // GET: api/cpm/v1/CatalogItems
        [HttpGet("all")]
        public async Task<List<RealEstateCatalogItemDto>> GetAllRealestateCatalogItems()
        {
            var dto = await _realestateCatalogItemServices.GetAllEntities();

            return dto;
        }

        // GET: api/cpm/v1/CatalogItems
        [HttpGet]
        public async Task<List<RealEstateCatalogItemDto>> GetRealestateCatalogItems()
        {
            var dto = await _realestateCatalogItemServices.GetEntities();
            return dto;
        }

        [AllowAnonymous]
        [HttpGet("filtered")]
        public async Task<IActionResult> GetFilteredRealestateCatalogItems(
                [FromQuery] int? catalogId = null,
                [FromQuery] string filter = "",
                [FromQuery] int page = 1,
                [FromQuery] int pageSize = 10,
                [FromQuery] string search = "",
                [FromQuery] string sort = "")
        {
            try
            {
                var query = _context.RealestateCatalogItems
                    .Include(item => item.CatalogItemType)
                    .Include(item => item.CatalogItemStatus)
                    .Include(item => item.Catalog)
                    .AsNoTracking()
                    .AsQueryable();

                if (catalogId != null)
                {
                    query = query.Where(item => item.CatalogId == catalogId);
                }

                if (filter != null)
                {
                    query = ApplyDynamicFilter(query, filter);
                }

                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(item => item.Name.ToLower().Contains(search.ToLower()));
                }

                if (!string.IsNullOrEmpty(sort))
                {
                    string[] sortParams = sort.Split(',');
                    bool isFirstSort = true;

                    foreach (var sortParam in sortParams)
                    {
                        string[] parts = sortParam.Split('_');
                        string sortBy = parts[0].ToLower();
                        string sortDir = parts.Length > 1 ? parts[1].ToLower() : "asc";

                        if (isFirstSort)
                        {
                            query = ApplySort(query, sortBy, sortDir);
                            isFirstSort = false;
                        }
                        else
                        {
                            query = ApplyThenBy(query, sortBy, sortDir);
                        }
                    }
                }

                var totalItems = await query.CountAsync();

                var pagedItems = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

                var pagedItemsDTOs = _mapper.Map<List<RealEstateCatalogItemDto>>(pagedItems);

                return Ok(new { Items = pagedItemsDTOs, TotalCount = totalItems });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private IQueryable<CatalogItem> ApplySort(IQueryable<CatalogItem> query, string sortBy, string sortDir)
        {
            switch (sortBy)
            {
                case "catalogname":
                    return sortDir == "desc"
                        ? query.OrderByDescending(item => item.Catalog.Name)
                        : query.OrderBy(item => item.Catalog.Name);
                case "name":
                    return sortDir == "desc"
                        ? query.OrderByDescending(item => item.Name)
                        : query.OrderBy(item => item.Name);
                // Handle other sort cases as needed
                default:
                    return query;
            }
        }

        private IQueryable<CatalogItem> ApplyThenBy(IQueryable<CatalogItem> query, string sortBy, string sortDir)
        {
            switch (sortBy)
            {
                case "catalogname":
                    return sortDir == "desc"
                        ? ((IOrderedQueryable<CatalogItem>)query).ThenByDescending(item => item.Catalog.Name)
                        : ((IOrderedQueryable<CatalogItem>)query).ThenBy(item => item.Catalog.Name);
                case "name":
                    return sortDir == "desc"
                        ? ((IOrderedQueryable<CatalogItem>)query).ThenByDescending(item => item.Name)
                        : ((IOrderedQueryable<CatalogItem>)query).ThenBy(item => item.Name);
                // Handle other sort cases as needed
                default:
                    return query;
            }
        }

        //public static class DynamicFilter
        //{
        //    public static Func<CatalogItem, bool> GenerateFilter(string filter)
        //    {
        //        var parameter = Expression.Parameter(typeof(CatalogItem), "item");
        //        Expression finalExpression = null;

        //        var conditions = filter.Split(';');

        //        foreach (var condition in conditions)
        //        {
        //            var parts = condition.Split('#');
        //            if (parts.Length == 2)
        //            {
        //                var propertyPath = parts[0].Split('.');
        //                var values = parts[1].Split(',');

        //                Expression propertyExpression = parameter;
        //                foreach (var propertyName in propertyPath)
        //                {
        //                    propertyExpression = Expression.PropertyOrField(propertyExpression, propertyName);
        //                }

        //                var valuesConstant = Expression.Constant(values);

        //                var containsMethod = typeof(IEnumerable<string>).GetMethod("Contains", new[] { typeof(string) });
        //                var containsExpression = Expression.Call(valuesConstant, containsMethod, propertyExpression);

        //                finalExpression = finalExpression == null ? containsExpression : Expression.AndAlso(finalExpression, containsExpression);
        //            }
        //        }

        //        return Expression.Lambda<Func<CatalogItem, bool>>(finalExpression, parameter).Compile();
        //    }
        //}


        //// Modify the GetFilteredRealestateCatalogItems method
        //private IQueryable<CatalogItem> ApplyDynamicFilter(IQueryable<CatalogItem> query, string filter)
        //{
        //    if (!string.IsNullOrEmpty(filter))
        //    {
        //        var dynamicFilter = DynamicFilter.GenerateFilter(filter);
        //        query = (IQueryable<CatalogItem>)query.Where(dynamicFilter);
        //    }

        //    return query;
        //}

        private IQueryable<CatalogItem> ApplyDynamicFilter(IQueryable<CatalogItem> query, string filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                var conditions = filter.Split(';');

                foreach (var condition in conditions)
                {
                    var parts = condition.Split('#');
                    if (parts.Length == 2)
                    {
                        var fieldName = parts[0];
                        var values = parts[1].Split(',');

                        switch (fieldName.ToLower())
                        {
                            case "catalogname":
                                if (values.Any() && values.All(v => !string.IsNullOrEmpty(v)))
                                {
                                    query = query.Where(item => values.Contains(item.Catalog.Name.ToLower()));
                                }
                                break;
                            case "catalogtype":
                                if (values.Any() && values.All(v => !string.IsNullOrEmpty(v)))
                                {
                                    query = query.Where(item => values.Contains(item.CatalogItemType.Name.ToLower()));
                                }
                                break;
                        }
                    }
                }
            }

            return query;
        }

        private static IQueryable<CatalogItem> SortByProperty(
            IQueryable<RealEstateCatalogItemDto> query,
            Expression<Func<RealEstateCatalogItemDto, object>> propertySelector,
            string sortDir)
        {
            var dtoQuery = query.Select(item => new RealEstateCatalogItemDto
            {
                Name = item.Name,
                CatalogName = item.CatalogName,
            });

            return (IQueryable<CatalogItem>)(sortDir == "desc" ? dtoQuery.OrderByDescending(propertySelector) : dtoQuery.OrderBy(propertySelector));
        }


        // GET: api/cpm/v1/CatalogItems/5
        [HttpGet("{id}")]
        public async Task<RealEstateCatalogItemDto> GetCatalogItem([FromRoute] int id)
        {
            var dto = await _realestateCatalogItemServices.GetEntity(id);

            return dto;
        }

        // PUT: api/cpm/v1/CatalogItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogItem([FromRoute] int id, [FromForm] RealEstateCatalogItemDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dto.Id)
            {
                return BadRequest();
            }

            var result = await _realestateCatalogItemServices.UpdateEntity(id, dto);
            return Ok(result);
        }


        // PUT: api/cpm/v1/CatalogItems/5/updateIsDisclamer
        [HttpPut("{catalogItemId}/updateIsDisclamer/{isDisclamerValue}")]
        public async Task<IActionResult> UpdateShowDisclamerCatalogItem([FromRoute] int catalogItemId, bool isDisclamerValue)
        {
            var dto = await _realestateCatalogItemServices.UpdateIsDisclamerCatalogItem(catalogItemId, isDisclamerValue);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.SaveChangesAsync();

            return Ok(dto);
        }

        // POST: api/cpm/v1/CatalogItems
        [HttpPost]
        public async Task<IActionResult> PostCatalogItem([FromForm] RealEstateCatalogItemDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _realestateCatalogItemServices.AddEntity(dto);
            return Ok(result);
        }

        // DELETE: api/cpm/v1/CatalogItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogItem([FromRoute] int id)
        {
            var result = await _realestateCatalogItemServices.DeleteEntity(id);
            return Ok(result);
        }
    }
}