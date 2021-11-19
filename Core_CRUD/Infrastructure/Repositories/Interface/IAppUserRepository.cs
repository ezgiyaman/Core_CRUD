using Core_CRUD.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core_CRUD.Infrastructure.Repositories.Interface
{
    public interface IAppUserRepository
    {
        void Create(AppUser entity);
        void Update(AppUser entity);
        void Delete(AppUser entity);

        AppUser GetByDefault(Expression<Func<AppUser, bool>> expression); 
        List<AppUser> GetByDefaults(Expression<Func<AppUser, bool>> expression);
        
    }
}
