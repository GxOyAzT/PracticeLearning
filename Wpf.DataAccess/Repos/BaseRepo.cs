using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.DataAccess.DataAccess;
using Wpf.DataAccess.Tables;

namespace Wpf.DataAccess.Repos
{
    public class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : ParentModel
    {
        private readonly ApplicationContext _appContext;

        public BaseRepo(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public List<TEntity> Get() =>
            _appContext.Set<TEntity>()
                .AsNoTracking()
                .ToList();

        public TEntity Get(Guid id) =>
            _appContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);

        public List<Guid> GetIds() =>
            _appContext.Set<TEntity>()
                .Select(e => e.Id)
                .ToList();

        public void Insert(TEntity entity)
        {
            _appContext.Set<TEntity>()
                .Add(entity);

            _appContext.SaveChanges();
        }
    }
}
