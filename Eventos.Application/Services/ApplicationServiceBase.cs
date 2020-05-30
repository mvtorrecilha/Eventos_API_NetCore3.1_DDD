using Eventos.Application.Interfaces;
using Eventos.Domain.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Eventos.Application.Services
{
    public class ApplicationServiceBase<TEntity> : IDisposable, IApplicationServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public ApplicationServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _serviceBase.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _serviceBase.GetAllAsync();
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public void DeleteRange(TEntity[] entityArray)
        {
            _serviceBase.DeleteRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _serviceBase.SaveChangesAsync();
        }

        public IQueryable<TEntity> FindAll()
        {
            return _serviceBase.FindAll();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _serviceBase.FindByCondition(expression);
        }

        public TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                  Expression<Func<TEntity, bool>> predicate = null,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                  bool disableTracking = true)
        {
            return _serviceBase.GetFirstOrDefault(selector, predicate, orderBy, include, disableTracking);
        }

        public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate,
                                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
                                                        )
        {
            return await _serviceBase.GetWhereAsync(predicate, orderBy, include);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
