using GetIt.Core.Attributes;
using GetIt.Data;
using GetIt.Domain.Products;
using GetIt.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Application.Users
{
    [Scoped]
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        public UserRepository(GetItDbContext db) : base(db)
        {
        }
    }
}
