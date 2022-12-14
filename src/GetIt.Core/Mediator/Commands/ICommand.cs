using MediatR;

namespace GetIt.Core.Mediator.Commands
{
    public interface ICommand : IRequest
    {
    }
    public interface ICommand<out T> : IRequest<T>
    {
    }
}
