using LayiheEsas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayiheEsas.Repositories
{
    internal interface IUserRepository
    {
        public Bank bank { get; }
        public void UserRegistration(User user);
        public void UserLogin(User user);
        public void FindUser(User user);
    }
}
