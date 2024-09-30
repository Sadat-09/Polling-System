using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepo : IRepo<User, int, bool>
    {
        User GetByUsernameAndPassword(string UserName, string password);
    }
}
