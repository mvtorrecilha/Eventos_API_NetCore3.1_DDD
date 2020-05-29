using Eventos.Domain.Core.Interfaces.Repositories;
using Eventos.Domain.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Eventos.Domain.Services.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        //public void DeleteRange<TEntity>(TEntity[] entityArray)
        //{
        //    _context.RemoveRange(entityArray);
        //}

        public async Task<bool> SaveChangesAsync()
        {
            return await _repository.SaveChangesAsync();
        }

        public IQueryable<TEntity> FindAll()
        {
            return _repository.FindAll();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.FindByCondition(expression);
        }

        public TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                  Expression<Func<TEntity, bool>> predicate = null,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                  bool disableTracking = true)
        {
            return _repository.GetFirstOrDefault(selector, predicate, orderBy, include, disableTracking);
        }

        public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate,
                                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
                                                        )
        {
            return await _repository.GetWhereAsync(predicate, orderBy, include);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
