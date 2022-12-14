using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Core.Mediator.Commands
{
    public class CommandResponse
    {
        public bool Succeded { get; set; }
        public string Message { get; set; }
        public CommandResponse(bool succeded, string message)
        {
            Succeded = succeded;
            Message = message;
        }
    }
}
