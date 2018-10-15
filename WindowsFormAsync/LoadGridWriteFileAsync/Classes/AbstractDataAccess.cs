using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoadGridWriteFileAsync.Classes
{
    public abstract class AbstractDataAccess
    {
        public abstract int RowCount();
        public abstract IEnumerable<object[]> LoadData(CancellationToken ct);
    }
}
