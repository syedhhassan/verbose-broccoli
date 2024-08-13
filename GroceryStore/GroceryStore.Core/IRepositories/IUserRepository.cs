using GroceryStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.IRepositories
{
    public interface IUserRepository
    {
        public bool SignUp(UserModel user);

        public UserModel GetCreds(string Email);
    }
}
