﻿namespace MooVC.Persistence
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MooVC.Linq;

    public abstract class SynchronousStore<T, TKey>
        : IStore<T, TKey>
    {
        public virtual async Task<TKey> CreateAsync(T item)
        {
            return await Task.FromResult(PerformCreate(item));
        }

        public virtual Task DeleteAsync(T item)
        {
            PerformDelete(item);

            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync(TKey key)
        {
            PerformDelete(key);

            return Task.CompletedTask;
        }

        public virtual Task<T?> GetAsync(TKey key)
        {
            return Task.FromResult(PerformGet(key));
        }

        public virtual Task<IEnumerable<T>> GetAsync(Paging? paging = default)
        {
            return Task.FromResult(PerformGet(paging: paging));
        }

        public virtual Task UpdateAsync(T item)
        {
            PerformUpdate(item);

            return Task.CompletedTask;
        }

        protected abstract TKey PerformCreate(T item);

        protected abstract void PerformDelete(T item);

        protected abstract void PerformDelete(TKey key);

        protected abstract T? PerformGet(TKey key);

        protected abstract IEnumerable<T> PerformGet(Paging? paging = default);

        protected abstract void PerformUpdate(T item);
    }
}