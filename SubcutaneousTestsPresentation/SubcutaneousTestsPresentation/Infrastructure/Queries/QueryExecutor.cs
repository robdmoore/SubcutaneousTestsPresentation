using System.Threading.Tasks;
using Autofac;

namespace SubcutaneousTestsPresentation.Infrastructure.Queries
{
    public interface IQueryExecutor
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }

    public class QueryExecutor
        : IQueryExecutor
    {
        private readonly ILifetimeScope _scope;

        public QueryExecutor(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof (QueryAdapter<,>).MakeGenericType(query.GetType(), typeof (TResult));
            var handler = _scope.Resolve(handlerType) as QueryAdapter<TResult>;

            return handler.QueryAsync(query);
        }
    }
}