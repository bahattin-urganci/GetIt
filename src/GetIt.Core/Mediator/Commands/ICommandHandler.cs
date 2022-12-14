using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Core.Mediator.Commands
{
    public interface ICommandHandler<in T> : IRequestHandler<T> where T : ICommand
    {
    }
    public interface ICommandHandler<in T, TR> : IRequestHandler<T, TR> where T : ICommand<TR>
    {

    }
}
