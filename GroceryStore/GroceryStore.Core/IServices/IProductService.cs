using GroceryStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.IServices
{
    public interface IProductService
    {
        public List<ProductModel> GetProducts(Guid UserId);

        public List<ProductModel> SearchProducts(Guid UserId, string SearchQuery);

    }
}
