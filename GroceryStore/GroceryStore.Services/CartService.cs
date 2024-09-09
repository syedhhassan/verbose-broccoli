using GroceryStore.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Services
{
    public class CartService
    {
        #region Declaration

        private readonly ICartRepository _cartRepository;

        #endregion

        #region Constructor

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        #endregion
    }
}
