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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace VS.OEE
{
    public partial class frmNhapHangLoi : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;  // == 1  full; <> 1 la read only
        private Int64 iID = -1;
        RepositoryItemSearchLookUpEdit cboItemID;

        public frmNhapHangLoi(int PQ)
        {
            InitializeComponent();

            if (iPQ != 1)
            {
                btnGhi.Visible = false;
                btnKhongGhi.Visible = false;
                btnXoa.Visible = false;
            }
            else
            {
                btnGhi.Visible = true;
                btnKhongGhi.Visible = true;
                btnXoa.Visible = true;
            }

            this.lblDocNum.Font = new System.Drawing.Font(lblDocNum.Font, System.Drawing.FontStyle.Bold);
            this.lblQCName.Font = new System.Drawing.Font(lblQCName.Font, System.Drawing.FontStyle.Bold);
            this.lblQCDate.Font = new System.Drawing.Font(lblQCDate.Font, System.Drawing.FontStyle.Bold);

        }



        #region Event
        private void frmNhapHangLoi_Load(object sender, EventArgs e)
        {
            LoadData(-1);
            LoadNN();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgXoa"), this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    System.Data.SqlClient.SqlConnection conn;
                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                    conn.Open();
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNhapHangLoi", conn);
                    cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 2;
                    cmd.Parameters.Add("@iID", SqlDbType.BigInt).Value = iID;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgXoa_ThanhCong"));
                        iID = -1;
                        LoadData(iID);
                    }
                    else
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgXoa_DangSuDung"));
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                if (!KiemTrung()) return;

                string sBT = "sBTNhapHangLoi" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, (DataTable)grdChung.DataSource, "");
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNhapHangLoi", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Commons.Modules.UserName;
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iID;
                cmd.Parameters.Add("@sBT", SqlDbType.NVarChar).Value = sBT;
                cmd.Parameters.Add("@DocNum", SqlDbType.NVarChar).Value = txtDocNum.Text;
                cmd.Parameters.Add("@QCName", SqlDbType.NVarChar).Value = txtQCName.Text;
                cmd.Parameters.Add("@QCDate", SqlDbType.DateTime).Value = dedQCDate.EditValue;
                cmd.CommandType = CommandType.StoredProcedure;

                Int64 ID = Convert.ToInt64(cmd.ExecuteScalar());

                if (ID != -1)
                {
                    iID = ID;
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgGhi_ThanhCong"));
                    LoadData(iID);
                }
                else
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgGhi_ThatBai"));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgGhi_ThatBai"));
            }
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            iID = -1;
            LoadData(iID);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDocNum_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                LoadView();
            }
        }

        private void grvChung_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            grvChung.SetRowCellValue(e.RowHandle, grvChung.Columns["ID"], -1);
            grvChung.SetRowCellValue(e.RowHandle, grvChung.Columns["ID_QC"], iID);
        }

        private void grvChung_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                grvChung.InvalidRowException += grvChung_InvalidRowException;
                for (int i = 0; i < grvChung.Columns.Count; i++)
                {
                    if (grvChung.Columns[i].FieldName != "ItemName" && grvChung.Columns[i].FieldName != "ProductionDate" && grvChung.Columns[i].FieldName != "Quantity" && grvChung.Columns[i].FieldName != "Note" && grvChung.GetRowCellValue(e.RowHandle, grvChung.Columns[i]).ToString() == "")
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(grvChung.Columns[i].Caption + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                        grvChung.FocusedRowHandle = e.RowHandle;
                        grvChung.FocusedColumn = grvChung.Columns[i];
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void grvChung_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void grvChung_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "ItemID")
                {
                    DataTable dt = new DataTable();
                    dt = ((DataTable)cboItemID.DataSource).Select("ItemID  = " + grvChung.GetRowCellValue(e.RowHandle, grvChung.Columns["ItemID"])).CopyToDataTable().Copy();
                    grvChung.SetRowCellValue(e.RowHandle, grvChung.Columns["ItemName"], dt.Rows[0]["ItemName"]);
                }
            }
            catch { }
        }

        private void grdChung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                grvChung.DeleteRow(grvChung.FocusedRowHandle);
            }
        }
        #endregion

        #region Function
        public void LoadNN()
        {
            lblDocNum.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblDocNum");
            lblQCName.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblQCName");
            lblQCDate.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblQCDate");
            btnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnXoa");
            btnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnGhi");
            btnKhongGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnKhongGhi");
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnThoat");
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChung, this.Name);
        }

        private void LoadView()
        {
            frmNhapHangLoiView ctl = new frmNhapHangLoiView(iPQ, txtDocNum.Text, "spNhapHangLoi");
            Commons.Modules.sPS = "mnuNhapHangLoiView";
            ctl.Tag = "mnuNhapHangLoiView";
            ctl.Text = Commons.Modules.ObjLanguages.GetLanguage("frmNhapHangLoiView", "frmNhapHangLoiView");
            ctl.Name = "frmNhapHangLoiView";

            ctl.Size = new Size((this.Width / 2) + (ctl.Width / 2), (this.Height / 2) + (ctl.Height / 2));

            ctl.StartPosition = FormStartPosition.Manual;
            ctl.Location = new Point(this.Width / 2 - ctl.Width / 2 + this.Location.X,
                                      this.Height / 2 - ctl.Height / 2 + this.Location.Y);

            if (ctl.ShowDialog() == DialogResult.OK)
            {
                iID = ((frmNhapHangLoiView)ctl).iID;
                LoadData(iID);

            }
        }

        private void LoadData(Int64 ID)
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNhapHangLoi", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                cmd.Parameters.Add("@iID", SqlDbType.BigInt).Value = ID;
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();

                if (dt.Rows.Count > 0)
                {
                    txtDocNum.Text = dt.Rows[0]["DocNum"].ToString();
                    txtQCName.Text = dt.Rows[0]["QCName"].ToString();
                    dedQCDate.EditValue = dt.Rows[0]["QCDate"];
                }
                else
                {
                    txtDocNum.Text = "";
                    txtQCName.Text = "";
                    dedQCDate.EditValue = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                }

                //LOAD GRIDVIEW
                DataTable dt1 = new DataTable();
                dt1 = ds.Tables[1].Copy();

                if (dt1 != null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dt1, true, true, false, false);
                    LoadCbo_grvChung();
                    Format_grvChung();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void LoadCbo_grvChung()
        {
            try
            {
                if (grdChung.DataSource != null)
                {
                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                    conn.Open();
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNhapHangLoi", conn);
                    cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 5;
                    cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                    cmd.CommandType = CommandType.StoredProcedure;
                    System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    DataTable dt = new DataTable();
                    dt = ds.Tables[0].Copy();
                    RepositoryItemSearchLookUpEdit cbo = new RepositoryItemSearchLookUpEdit();
                    if (dt.Rows.Count > 0)
                    {
                        Commons.Modules.ObjSystems.AddCombSearchLookUpEdit(cbo, "ID_PO", "PrOrNumber", grvChung, dt, this.Name);
                        cbo.View.Columns["ID_PO"].Visible = false;
                    }

                    DataTable dt1 = new DataTable();
                    dt1 = ds.Tables[1].Copy();
                    cboItemID = new RepositoryItemSearchLookUpEdit();
                    if (dt1.Rows.Count > 0)
                    {
                        Commons.Modules.ObjSystems.AddCombSearchLookUpEdit(cboItemID, "ItemID", "ItemCode", grvChung, dt1, this.Name);
                        cboItemID.View.Columns["ItemID"].Visible = false;
                    }

                    DataTable dt2 = new DataTable();
                    dt2 = ds.Tables[2].Copy();
                    RepositoryItemSearchLookUpEdit cbo2 = new RepositoryItemSearchLookUpEdit();
                    if (dt2.Rows.Count > 0)
                    {
                        Commons.Modules.ObjSystems.AddCombSearchLookUpEdit(cbo2, "MS_MAY", "MS_MAY", grvChung, dt2, this.Name);
                    }

                    DataTable dt3 = new DataTable();
                    dt3 = ds.Tables[3].Copy();
                    RepositoryItemSearchLookUpEdit cbo3 = new RepositoryItemSearchLookUpEdit();
                    if (dt3.Rows.Count > 0)
                    {
                        Commons.Modules.ObjSystems.AddCombSearchLookUpEdit(cbo3, "ID_Defect", "DefectName", grvChung, dt3, this.Name);
                        cbo3.View.Columns["ID_Defect"].Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private bool KiemTrung()
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNhapHangLoi", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                cmd.Parameters.Add("@iID", SqlDbType.BigInt).Value = iID;
                cmd.Parameters.Add("@DocNum", SqlDbType.NVarChar).Value = txtDocNum.Text;
                cmd.Parameters.Add("@QCName", SqlDbType.NVarChar).Value = txtQCName.Text;
                cmd.CommandType = CommandType.StoredProcedure;

                int KIEMTRUNG = Convert.ToInt32(cmd.ExecuteScalar());
                if (KIEMTRUNG  == 1)
                {
                    XtraMessageBox.Show(lblDocNum.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                    return false;
                }

                if (KIEMTRUNG == 2)
                {
                    XtraMessageBox.Show(lblQCName.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }
            }

        private void Format_grvChung()
        {
            try
            {
                if (grdChung.DataSource != null)
                {
                    grvChung.Columns[0].Visible = false;
                    grvChung.Columns["ID_QC"].Visible = false;

                    grvChung.Columns["ItemName"].OptionsColumn.AllowEdit = false;

                    grvChung.Columns["ID_PO"].Width = 100;
                    grvChung.Columns["ItemID"].Width = 100;
                    grvChung.Columns["ItemName"].Width = 150;
                    grvChung.Columns["MS_MAY"].Width = 100;
                    grvChung.Columns["ProductionDate"].Width = 100;
                    grvChung.Columns["ID_Defect"].Width = 100;
                    grvChung.Columns["Quantity"].Width = 60;
                    grvChung.Columns["Note"].Width = 200;
                }
            }
            catch { }
        }
        #endregion

       
    }
}