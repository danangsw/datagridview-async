using LoadGridWriteFileAsync.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoadGridWriteFileAsync.Classes
{
    public class GenerateDataAccess : AbstractDataAccess
    {
        private int rowCount = 0;
        private LoadGridWriteFileAsync callingForm;

        /// <summary> 
        /// Container for returned data back to calling form via a delegate 
        /// </summary> 
        public PersonViewModel[] ItemArray;

        public bool IsWriteFile { get; set; }

        public GenerateDataAccess(LoadGridWriteFileAsync form) {
            this.callingForm = form;
        }

        public override IEnumerable<object[]> LoadData(CancellationToken ct)
        {
            PersonViewModel personArray = new PersonViewModel();

            // prepare delegate
            LoadGridWriteFileAsync.UpdateDataTableDelegateProgress updateDelegate =
            delegate (int Total, PersonViewModel[] person)
            {
                callingForm.UpDateDataTableDelegate(Total, person);
            };

            int identifier = 1;

            while (true)
            {
                rowCount = identifier++;

                personArray.Identifier = rowCount;
                personArray.FirstName = StringUtils.RandomString(10);
                personArray.LastName = StringUtils.RandomString(10);

                ItemArray = new PersonViewModel[] { personArray };

                // return data to calling form 
                yield return ItemArray;

                // invoke calling form delegate 
                updateDelegate(this.RowCount(), ItemArray);
            }
        }

        public override int RowCount()
        {
            return rowCount;
        }
    }
}
