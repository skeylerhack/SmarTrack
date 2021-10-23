using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace VS.OEE
{
    public partial class frmPopUp : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _tbsource = new DataTable();
        GridView viewChung;
        Point ptChung;
        public DataTable TableSource
        {
            set
            {
                _tbsource = value;
            }
        }
        // Dữ liệu được chọn
        private DataRow _dtrow;
        public DataRow RowSelected
        {
            get
            {
                return _dtrow;
            }
        }

        public frmPopUp()
        {
            InitializeComponent();
        }

        private void frmPopUp_Load(object sender, EventArgs e)
        {
            if (_tbsource.Columns.Count < 6)
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdSource, grvSource, _tbsource, false, false,true, true,true,this.Name);
            else
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdSource, grvSource, _tbsource, false, false, true, true,true,this.Name);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                _dtrow = ((DataRowView)grvSource.GetFocusedRow()).Row;
                this.DialogResult = DialogResult.OK;
            }
            catch { }

            this.Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void grvSource_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                _dtrow = ((DataRowView)grvSource.GetFocusedRow()).Row;
                this.DialogResult = DialogResult.OK;
            }
            catch { }

            this.Close();
        }
        private void grvSource_ShownEditor(object sender, EventArgs e)
        {
            viewChung = (GridView)sender;
            ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
            viewChung.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);
        }
        private void ActiveEditor_DoubleClick(object sender, System.EventArgs e)
        {
            grvSource.RefreshData();
        }
      
    }
}