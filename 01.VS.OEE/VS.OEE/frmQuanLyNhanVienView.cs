using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace VS.OEE
{
    public partial class frmQuanLyNhanVienView : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;  // == 1  full; <> 1 la read only
        private string sSP;
        private string sFind;
        public string MS_CONG_NHAN = "-1";
        public frmQuanLyNhanVienView(int PQ, string Find, string SP)
        {
            iPQ = PQ;
            sSP = SP;
            InitializeComponent();

            if(Find != "")
                txtTim.Text = Find;
        }

        private void frmQuanLyNhanVienView_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadNN();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadNN()
        {
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnThoat");
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, this.Name);
        }

        private void LoadData()
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sSP, conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                if (dt != null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dt, false, true, false, false);
                }

                if (grdChung.DataSource != null)
                {
                    Format_grvView();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Format_grvView()
        {
            try
            {
                grvChung.Columns["MS_CONG_NHAN"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                grvChung.Columns["HO_TEN"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                grvChung.Columns["MS_CONG_NHAN"].Width = 100;
                grvChung.Columns["HO_TEN"].Width = 200;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }

        private void grdChung_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grvChung.DataSource != null && grvChung.RowCount > 0)
                {
                    MS_CONG_NHAN = grvChung.GetRowCellValue(grvChung.FocusedRowHandle, grvChung.Columns["MS_CONG_NHAN"]).ToString();
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}