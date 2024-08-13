using GroceryStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.IServices
{
    public interface IUserService
    {
        public bool SignUp(UserModel user);

        public string SignIn(UserModel user);
    }
}
