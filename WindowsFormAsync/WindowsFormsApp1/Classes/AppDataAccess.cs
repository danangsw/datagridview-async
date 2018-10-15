using LoadAsync.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Data;

namespace WindowsFormsApp1.Classes
{
    public class AppDataAccess : AbstractDataAccess
    {
        private DataModelEntities db;

        public int CurrentIdentifier = 0;
        private LoadDataGridViewAsync callingForm;

        /// <summary> 
        /// Container for returned data back to calling form via a delegate 
        /// </summary> 
        public PersonViewModel[] ItemArray;

        public AppDataAccess(LoadDataGridViewAsync form)
        {
            this.callingForm = form;
            db = new DataModelEntities();
        }

        public override IEnumerable<object[]> LoadData(CancellationToken ct)
        {
            int RecordCount = this.RowCount();
            PersonViewModel personArray = new PersonViewModel();

            // prepare delegate
            LoadDataGridViewAsync.UpdateDataTableDelegateProgress updateDelegate =
            delegate (int CurrentPosition, int Total, PersonViewModel[] person)
            {
                callingForm.UpDateDataTable(CurrentPosition, Total, person);
            };

            foreach (var item in db.People.Select(x => x))
            {
                CurrentIdentifier = item.Identifier;

                personArray.Identifier = item.Identifier;
                personArray.FirstName = item.FirstName;
                personArray.LastName = item.LastName;

                ItemArray = new PersonViewModel[] { personArray  };

                // return data to calling form 
                yield return ItemArray;

                // invoke calling form delegate 
                updateDelegate(this.CurrentIdentifier, this.RowCount(), ItemArray);
            }
        }

        public override int RowCount()
        {
            int count = 0;

            count = db.People.Count();

            return count;
        }
    }
}
