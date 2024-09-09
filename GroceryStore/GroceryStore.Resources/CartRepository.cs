using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Resources
{
    public class CartRepository
    {
        #region Declaration

        private readonly string _connectionstring;

        #endregion

        #region Constructor

        public CartRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        #endregion

    }
}
