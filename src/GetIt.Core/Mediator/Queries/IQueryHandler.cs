using MediatR;

namespace GetIt.Core.Mediator.Queries
{
    public interface IQueryHandler<in T, TR> : IRequestHandler<T, TR> where T : IQuery<TR>
    {
    }
}
