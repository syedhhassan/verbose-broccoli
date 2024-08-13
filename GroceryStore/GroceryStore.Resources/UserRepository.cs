using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GroceryStore.Core.IRepositories;
using GroceryStore.Core.Models;
using Microsoft.Extensions.Configuration;
using GroceryStore.Core.Utilities;

namespace GroceryStore.Resources
{
    public class UserRepository : IUserRepository
    {
        #region Declaration

        private readonly string _connectionstring;

        #endregion

        #region Constructor

        public UserRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        #endregion

        #region Sign Up
        /// <summary>
        /// Sign Up
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool SignUp(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                try
                {
                    connection.Open();
                    connection.Execute(SQLQueries.sign_up_query, new { NAME = user.Name, EMAIL = user.Email, PASSWORDHASH = user.PasswordHash, SALT = user.PasswordSalt, PHONE = user.Phone, ADDRESS = user.Address });
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Getting credentials for signing in
        /// <summary>
        /// Getting credentials for signing in
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public UserModel GetCreds(string Email)
        {
            UserModel user = new UserModel();
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                try
                {
                    connection.Open();
                    var creds = connection.QuerySingle(SQLQueries.get_creds_query, new { EMAIL = Email });
                    user.Name = creds.NAME;
                    user.PasswordSalt = creds.SALT;
                    user.PasswordHash = creds.PASSWORDHASH;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                return user;
            }
        }
        #endregion
    }
}
