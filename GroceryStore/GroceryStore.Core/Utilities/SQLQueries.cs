using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.Utilities
{
    public class SQLQueries
    {
        public static string sign_up_query = "INSERT INTO STS892_SHOPPER (NAME, EMAIL, PASSWORDHASH, SALT, PHONE) VALUES (@NAME, @EMAIL, @PASSWORDHASH, @SALT, @PHONE);";

        public static string get_creds_query = "SELECT NAME, SALT, PASSWORDHASH FROM STS892_SHOPPER WHERE EMAIL = @EMAIL AND IS_ACTIVE = 1;";

        public static string get_products_query = "SELECT NAME, PRICE, QUANTITY, CATEGORY, PATH FROM STS892_PRODUCTS;";

        public static string get_products_by_category_query = "SELECT NAME, PRICE, QUANTITY, PATH FROM STS892_PRODUCTS WHERE CATEGORY = @CATEGORY;";

    }
}
