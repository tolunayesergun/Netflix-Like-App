using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorkFlix.Classes
{
    class MyDataGridView : DataGridView
    {
        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            //base.OnCellMouseDown(e);
            this.Rows[e.RowIndex].Selected = !this.Rows[e.RowIndex].Selected;
        }

        protected override void OnCellMouseClick(DataGridViewCellMouseEventArgs e)
        {
            //base.OnCellMouseClick(e);
        }
    }
}
