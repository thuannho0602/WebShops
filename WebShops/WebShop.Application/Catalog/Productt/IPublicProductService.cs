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
    /// Dùng Phương Thức Bên Ngoài Cho Khách Hàng Đọc
    /// </summary>
    public interface IPublicProductService
    {
       Task< PagedResult<ProductViewMode>> GetAllCategoryId(string languageId,GetPublictProductPadingRequest request);

        Task<List<ProductViewMode>> GetAll(string languageId);
    }
}
