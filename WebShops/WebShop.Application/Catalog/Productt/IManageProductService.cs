using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.ViewModels.Catalog.Productt;
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

        Task< List<ProductViewMode>> GetAll();
        Task<ProductViewMode>GetAllById(int productId);

        Task<PagedResult<ProductViewMode>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, List<IFormFile> files);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, string caption, bool Isdefault);

        Task<List<ProductImageViewModel>> GetListImage(int productId);
    }
}
