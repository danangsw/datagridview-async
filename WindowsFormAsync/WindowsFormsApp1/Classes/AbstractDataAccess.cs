using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    public abstract class AbstractDataAccess
    {
        public virtual Form DelegateForm { get; set; }
        public abstract int RowCount();
        public abstract IEnumerable<object[]> LoadData(CancellationToken ct);
    }
}
