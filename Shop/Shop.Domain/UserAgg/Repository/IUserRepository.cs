using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Repository;

namespace Shop.Domain.UserAgg.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
