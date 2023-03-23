using Demo.DataBase.EF;
using Demo.DataBase.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebShop.Application.Common;
using WebShop.ViewModels.Catalog.Productt;
using WebShop.ViewModels.Common;
using WebShops.Utilities.Exceptions;

namespace WebShop.Application.Catalog.Productt
{
    public class ManageProductService : IManageProductService
    {
        public readonly DemoDbcontext _contex;
        public readonly IStorageService _storageService;
        public ManageProductService(DemoDbcontext contex,IStorageService storageService)
        {
            _contex = contex;
            _storageService=storageService;
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _contex.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _contex.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                Originalprice = request.Originalprice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreacted = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name=request.Name,
                        Description=request.Description,
                        Details=request.Details,
                        SeoDescription=request.SeoDescription,
                        SeoAlias=request.SeoAlias,
                        SeoTitle=request.SeoTitle,
                        LanguageId=request.LanguageId,
                    }
                }
            };
            //Save Imge
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>
                {
                    new ProductImage()
                    {
                        Caption="ThumbnailImage",
                        DateCreated=DateTime.Now,
                        FileSize=request.ThumbnailImage.Length,
                        ImagePath=await this.SaveFile(request.ThumbnailImage),
                        IsDefault=true,
                        SortOrder=1,

                    }
                };
            }
            _contex.Products.Add(product);
             await _contex.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _contex.Products.FindAsync(productId);

            if (product == null) throw new WebShopExceptions($"Cannot find a product:{productId}");

            var images =  _contex.ProductImages.Where(i => i.ProductId == productId);
           foreach(var image in images)
            {
                _storageService.DeleteFileAsync(image.ImagePath);
            }
            _contex.Products.Remove(product);
            return await _contex.SaveChangesAsync();
        }

        public List<ProductViewMode> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ProductViewMode>> GetAllPaging(GetManageProductPagingRequest request)
        {
            // 1 select join
            var query = from p in _contex.Products
                        join pt in _contex.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _contex.ProductInCategories on p.Id equals pic.ProductId
                        join c in _contex.Categories on pic.CategoryId equals c.Id
                        //where pt.Name.Contains(request.Keyword)
                        select new { p, pt, pic };

            //2 filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            }

            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }
            //3 paging 
            int totalROw = await query.CountAsync();
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
                     SeoAlias = x.pt.SeoAlias,
                     SeoDescription = x.pt.SeoDescription,
                     SeoTitle = x.pt.SeoTitle,
                     Stock = x.p.Stock,
                     ViewCount = x.p.ViewCount,
                 }).ToListAsync();

            //4 select and projection
            var pageResult = new PagedResult<ProductViewMode>()
            {
                TotalRecord = totalROw,
                Items = data
            };
            return pageResult;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _contex.Products.FindAsync(request.Id);
            var productTranslations = await _contex.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id
            && x.LanguageId == request.LanguageId);
            if (product == null || productTranslations == null) throw new WebShopExceptions($"cannot find a product:{request.Id}");

            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.Description = request.Description;
            productTranslations.Details = request.Details;
            //Save Imge
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage =await _contex.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if(thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _contex.ProductImages.Update(thumbnailImage);
                }
               
            }
            return await _contex.SaveChangesAsync();

        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _contex.Products.FindAsync(productId);
            if (product == null)
            {
                throw new WebShopExceptions($"cannot find a product:{productId}");
            }
            product.Price = newPrice;
            return await _contex.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _contex.Products.FindAsync(productId);
            if (product == null)
            {
                throw new WebShopExceptions($"cannot find a product:{productId}");
            }
            product.Stock = addedQuantity;
            return await _contex.SaveChangesAsync() > 0;
        }
        public async Task<string>SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public Task<int> AddImage(int productId, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateImage(int imageId, string caption, bool Isdefault)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }

        Task<List<ProductViewMode>> IManageProductService.GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewMode> GetAllById(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
