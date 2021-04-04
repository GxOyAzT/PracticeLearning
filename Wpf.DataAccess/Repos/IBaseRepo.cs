using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.DataAccess.Repos
{
    public interface IBaseRepo<TEntity>
    {
        void Insert(TEntity entity);
        List<TEntity> Get();
        List<Guid> GetIds();
        TEntity Get(Guid id);
    }
}
