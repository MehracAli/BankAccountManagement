using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayiheEsas.Entities
{
    internal class Bank
    {
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = ++count; }
        }
        public User[] Users;
        static int count;
        public Bank()
        {
            Users = new User[0];
        }
    }   
}
