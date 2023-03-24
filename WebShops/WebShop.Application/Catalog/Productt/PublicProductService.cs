using Demo.DataBase.EF;
using Demo.DataBase.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.ViewModels.Catalog.Productt;
using WebShop.ViewModels.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebShop.Application.Catalog.Productt
{
    public class PublicProductService : IPublicProductService
    {
        public readonly DemoDbcontext _contex;
        public PublicProductService(DemoDbcontext contex)
        {
            _contex = contex;
        }

        public async Task<List<ProductViewMode>> GetAll(string languageId)
        {
            var query = from p in _contex.Products
                        join pt in _contex.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _contex.ProductInCategories on p.Id equals pic.ProductId
                        join c in _contex.Categories on pic.CategoryId equals c.Id
                        //where pt.Name.Contains(request.Keyword)
                        where pt.LanguageId == languageId
                        select new { p, pt, pic };
            var data = await query
               .Select(x => new ProductViewMode()
               {
                   Id = x.p.Id,
                   Name = x.pt.Name,
                   DateCreacted = x.p.DateCreacted,
                   Description = x.pt.Description,
                   Details = x.pt.Details,
                   LanguageId = x.pt.LanguageId,
                   Originalprice = x.p.Originalprice,
                   SeoAlias = x.pt.SeoAlias,
                   SeoDescription = x.pt.SeoDescription,
                   SeoTitle = x.pt.SeoTitle,
                   Stock = x.p.Stock,
                   ViewCount = x.p.ViewCount,
               }).ToListAsync();
            return data;
        }

        public async Task<PagedResult<ProductViewMode>> GetAllCategoryId(string languageId, GetPublictProductPadingRequest request)
        {
            //1. Select join
            var query = from p in _contex.Products
                        join pt in _contex.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _contex.ProductInCategories on p.Id equals pic.ProductId
                        join c in _contex.Categories on pic.CategoryId equals c.Id
                        where pt.LanguageId == languageId
                        select new { p, pt, pic };
            //2. filter
            if (request.CatogeryId.HasValue && request.CatogeryId.Value > 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CatogeryId);
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndext - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewMode()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreacted = x.p.DateCreacted,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    Originalprice = x.p.Originalprice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProductViewMode>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }
    }
}
