using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.Common.Interfaces
{
    public interface IUser
    {
        public bool IsLogged(string username, string password);
    }
}
