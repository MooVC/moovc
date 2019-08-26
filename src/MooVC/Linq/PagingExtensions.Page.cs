﻿namespace MooVC.Linq
{
    using System.Linq;

    public static class PagingExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, Paging paging)
        {
            return paging == null 
                ? queryable 
                : paging.Apply(queryable);
        }
    }
}