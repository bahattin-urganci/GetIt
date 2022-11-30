using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Domain.Base
{
    public interface IAuditEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
