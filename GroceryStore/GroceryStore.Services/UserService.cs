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

        public string SignIn(UserModel user)
        {
            var user_creds = _userRepository.GetCreds(user.Email);
            byte[] user_salt = user_creds.PasswordSalt;
            if (user_salt != null)
            {
                string user_hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: user.Password!, salt: user_salt, prf: KeyDerivationPrf.HMACSHA256, iterationCount: 100000, numBytesRequested: 256 / 8));
                //Comparing hash values
                if (user_hashed == user_creds.PasswordHash)
                {
                    return user_creds.Name;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
    }
}
