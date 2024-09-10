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

        public static string get_creds_query = "SELECT USERID, NAME, SALT, PASSWORDHASH FROM STS892_SHOPPER WHERE EMAIL = @EMAIL AND IS_ACTIVE = 1;";

        public static string get_products_query = "SELECT PRODUCTID, NAME, PRICE, QUANTITY, CATEGORY, PATH FROM STS892_PRODUCTS;";

        public static string fetch_cart_data_query = "SELECT PRODUCTID, QUANTITY, PRODUCTNAME, PRICE FROM STS892_CART WHERE USERID = @USERID;";

        public static string add_to_cart_query = "INSERT INTO STS892_CART (PRODUCTID, QUANTITY, USERID, PRODUCTNAME, PRICE) VALUES (@PRODUCTID, @QUANTITY, @USERID, @PRODUCTNAME, @PRICE);";

    }
}
