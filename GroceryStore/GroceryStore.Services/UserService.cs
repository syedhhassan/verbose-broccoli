using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Core.IRepositories;
using GroceryStore.Core.IServices;
using GroceryStore.Core.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace GroceryStore.Services
{
    public class UserService : IUserService
    {

        #region Declaration

        private readonly IUserRepository _userRepository;

        #endregion

        #region Constrcutor

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: user.Password!, salt: salt, prf: KeyDerivationPrf.HMACSHA256, iterationCount: 100000, numBytesRequested: 256 / 8));
            user.PasswordSalt = salt;
            user.PasswordHash = hashed;
            return _userRepository.SignUp(user);
        }
        #endregion

        #region Sign In
        /// <summary>
        /// Sign In
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Dictionary<string, string> SignIn(UserModel user)
        {
            Dictionary<string, string> details = new Dictionary<string, string>();
            var user_creds = _userRepository.GetCreds(user.Email);
            byte[] user_salt = user_creds.PasswordSalt;
            if (user_salt != null)
            {
                string user_hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: user.Password!, salt: user_salt, prf: KeyDerivationPrf.HMACSHA256, iterationCount: 100000, numBytesRequested: 256 / 8));
                //Comparing hash values
                if (user_hashed == user_creds.PasswordHash)
                {
                    details["Name"] = user_creds.Name;
                    details["UserId"] = user_creds.UserId.ToString();
                    details["Address"] = user_creds.Address;
                    return details;
                }
                else
                {
                    return [];
                }
            }
            else
            {
                return [];
            }
        }
        #endregion
    
    }
}
