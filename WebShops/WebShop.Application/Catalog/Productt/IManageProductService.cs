using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.ViewModels.Catalog.Productt;
using WebShop.ViewModels.Catalog.ProducttImages;
using WebShop.ViewModels.Common;

namespace WebShop.Application.Catalog.Productt
{

    /// <summary>
    /// Dùng Cho Admin
    /// </summary>
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task AddViewCount(int productId);

        Task< List<ProductViewMode>> GetAll(string languageId);
        Task<ProductViewMode>GetAllById(int productId,string languageId);

        Task<PagedResult<ProductViewMode>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId,ProductImageUpdateRequest request);

        Task<List<ProductImageViewModel>> GetListImage(int productId);
    }
}
