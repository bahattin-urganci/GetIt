using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Application.Base
{
    public class BaseResponse<T>
    {
        public bool Succedded { get; set; } = true;
        public T Result { get; set; }
        public string Message { get; set; }
    }
}
