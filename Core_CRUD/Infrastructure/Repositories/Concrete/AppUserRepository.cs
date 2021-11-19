using Core_CRUD.Infrastructure.Context;
using Core_CRUD.Infrastructure.Repositories.Interface;
using Core_CRUD.Models.Entities.Abstract;
using Core_CRUD.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core_CRUD.Infrastructure.Repositories.Concrete
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly AppDbContext _context;

        public AppUserRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }
        public void Create(AppUser entity)
        {
            _context.AppUsers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(AppUser entity)
        {
            entity.Status = Status.Passive;
            entity.DeleteDate = DateTime.Now;
            _context.SaveChanges();
        }

        public AppUser GetByDefault(Expression<Func<AppUser, bool>> expression)
        {
            return _context.AppUsers.FirstOrDefault(expression);
        }

        List<AppUser> IAppUserRepository.GetByDefaults(Expression<Func<AppUser, bool>> expression)
        {
            return _context.AppUsers.Where(expression).ToList();
        }
        public void Update(AppUser entity)
        {
            entity.Status = Status.Modified;
            entity.UpdateDate =DateTime.Now;
            _context.SaveChanges();

        }

        
    }
}
