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

        public static string update_address_query = "UPDATE STS892_SHOPPER SET ADDRESS = @ADDRESS WHERE USERID = @USERID;";

        public static string get_creds_query = "SELECT USERID, NAME, SALT, PASSWORDHASH, ADDRESS FROM STS892_SHOPPER WHERE EMAIL = @EMAIL AND IS_ACTIVE = 1;";

        public static string get_address_query = "SELECT ADDRESS FROM STS892_SHOPPER WHERE USERID = @USERID;";

        public static string get_products_query = "SELECT P.PRODUCTID, P.NAME, P.PRICE, P.QUANTITY, P.CATEGORY, PATH, COALESCE(C.QUANTITY, 0) AS PRODUCTQUANTITY FROM STS892_PRODUCTS P FULL OUTER JOIN STS892_CART C ON P.PRODUCTID = C.PRODUCTID AND USERID = @USERID;";

        public static string product_search_query = "SELECT P.PRODUCTID, P.NAME, P.PRICE, P.QUANTITY, P.CATEGORY, PATH, COALESCE(C.QUANTITY, 0) AS PRODUCTQUANTITY FROM STS892_PRODUCTS P FULL OUTER JOIN STS892_CART C ON P.PRODUCTID = C.PRODUCTID AND USERID = @USERID WHERE NAME LIKE '%' + @SEARCHQUERY + '%' OR CATEGORY LIKE '%' + @SEARCHQUERY + '%';";

        public static string fetch_cart_data_query = "SELECT C.PRODUCTID, P.NAME, P.PRICE, C.QUANTITY FROM STS892_CART C JOIN STS892_PRODUCTS P ON C.PRODUCTID = P.PRODUCTID WHERE USERID = @USERID;";

        public static string item_quantity_query = "SELECT QUANTITY FROM STS892_CART WHERE USERID = @USERID AND PRODUCTID = @PRODUCTID;";

        public static string total_quantity_query = "SELECT SUM(QUANTITY) FROM STS892_CART WHERE USERID = @USERID;";

        public static string add_to_cart_query = "MERGE INTO STS892_CART AS target\r\nUSING (VALUES (@PRODUCTID, @QUANTITY, @USERID)) AS source (PRODUCTID, QUANTITY, USERID)\r\nON target.PRODUCTID = source.PRODUCTID AND target.USERID = source.USERID\r\nWHEN MATCHED THEN\r\n    UPDATE SET target.QUANTITY = target.QUANTITY + 1\r\nWHEN NOT MATCHED THEN\r\n    INSERT (PRODUCTID, QUANTITY, USERID)\r\n    VALUES (source.PRODUCTID, source.QUANTITY, source.USERID);\r\n";

        public static string remove_from_cart_query = "MERGE INTO sts892_cart AS target\r\nUSING (VALUES (@PRODUCTID, @USERID)) AS source (PRODUCTID, USERID)\r\nON target.PRODUCTID = source.PRODUCTID AND target.USERID = source.USERID\r\nWHEN MATCHED AND target.QUANTITY > 1 THEN\r\n    UPDATE SET target.QUANTITY = target.QUANTITY - 1\r\nWHEN MATCHED AND target.QUANTITY = 1 THEN\r\n    DELETE;";

        public static string delete_item_from_cart_query = "DELETE FROM STS892_CART WHERE USERID = @USERID AND PRODUCTID = @PRODUCTID;";

        public static string delete_cart_for_user_query = "DELETE FROM STS892_CART WHERE USERID = @USERID;";

        public static string get_orderid_query = "SELECT TOP 1 ORDERID FROM STS892_ORDERS WHERE USERID = @USERID ORDER BY ORDERDATE DESC;";

        public static string new_order_query = "INSERT INTO STS892_ORDERS (USERID, ADDRESS, TOTAL) VALUES (@USERID, @ADDRESS, @TOTAL);";

        public static string insert_order_items_query = "INSERT INTO STS892_ORDERITEMS (ORDERID, PRODUCTID, QUANTITY, UNITPRICE) VALUES (@ORDERID, @PRODUCTID, @QUANTITY, @UNITPRICE);";

        public static string get_orders_query = "SELECT O.ORDERID, FORMAT(DATEADD(MINUTE, 330, O.ORDERDATE), 'dd-MM-yyyy hh:mm tt') AS ORDERDATE, O.ADDRESS, O.TOTAL, STRING_AGG(P.NAME, ', ') AS PRODUCTS FROM STS892_ORDERS O JOIN STS892_ORDERITEMS OI ON OI.ORDERID = O.ORDERID JOIN STS892_PRODUCTS P ON P.PRODUCTID = OI.PRODUCTID WHERE O.USERID = @USERID GROUP BY O.ORDERID, O.ORDERDATE, O.ADDRESS, O.TOTAL;";

        public static string get_order_items_query = "SELECT P.NAME, OI.QUANTITY, OI.UNITPRICE, OI.TOTALPRICE FROM STS892_ORDERITEMS OI JOIN STS892_PRODUCTS P ON OI.PRODUCTID = P.PRODUCTID WHERE ORDERID = @ORDERID;";

    }
}
