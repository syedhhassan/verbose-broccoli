using GroceryStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.IRepositories
{
    public interface IProductRepository
    {
        public List<ProductModel> GetProducts(Guid UserId);

        public List<ProductModel> SearchProducts(Guid UserId, string SearchQuery);
    }
}
