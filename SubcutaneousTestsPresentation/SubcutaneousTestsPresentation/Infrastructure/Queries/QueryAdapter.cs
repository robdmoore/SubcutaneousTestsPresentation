using System.Threading.Tasks;

namespace SubcutaneousTestsPresentation.Infrastructure.Queries
{
    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> QueryAsync(TQuery query);
    }

    public abstract class QueryAdapter<TResult>
    {
        public abstract Task<TResult> QueryAsync(object query);
    }

    public class QueryAdapter<TQuery, TResult>
        : QueryAdapter<TResult>
        where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> _handler;

        public QueryAdapter(IQueryHandler<TQuery, TResult> handler)
        {
            _handler = handler;
        }

        public override Task<TResult> QueryAsync(object query)
        {
            return _handler.QueryAsync((TQuery) query);
        }
    }
}