using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Core.Mediator.Queries
{
    public interface IQuery<T> : IRequest<T>
    {
    }
}
