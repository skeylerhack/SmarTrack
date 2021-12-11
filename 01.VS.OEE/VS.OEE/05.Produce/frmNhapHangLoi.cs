using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;
using Commons;
using DevExpress.Utils;

namespace VS.OEE
{
    public partial class frmNhapHangLoi : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;  // == 1  full; <> 1 la read only
        private Int64 iID = -1;
        Int64 ithem = 0;
        RepositoryItemSearchLookUpEdit cboItemID;

        public frmNhapHangLoi(int PQ)
        {
            InitializeComponent();
            this.lblDocNum.Font = new System.Drawing.Font(lblDocNum.Font, System.Drawing.FontStyle.Bold);
            this.lblQCName.Font = new System.Drawing.Font(lblQCName.Font, System.Drawing.FontStyle.Bold);
            this.lblQCDate.Font = new System.Drawing.Font(lblQCDate.Font, System.Drawing.FontStyle.Bold);
        }

        private void VisibleButon(bool flag)
        {
            btnThoat.Visible = flag;
            btnThem.Visible = flag;
            btnXoa.Visible = flag;
            btnSua.Visible = flag;
            btnGhi.Visible = !flag;
            btnKhongGhi.Visible = !flag;
            ReadonlyControl(flag);
            grdQCData.Enabled = flag;
            grvQCDataDetails.OptionsBehavior.ReadOnly = flag;
        }
        private void ReadonlyControl(bool flag)
        {
            txtDocNum.Properties.ReadOnly = flag;
            txtQCName.Properties.ReadOnly = flag;
            dedQCDate.Properties.ReadOnly = flag;
        }
        #region Event
        private void frmNhapHangLoi_Load(object sender, EventArgs e)
        {
            if (iPQ != 1)
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnGhi.Visible = false;
                btnKhongGhi.Visible = false;
                btnXoa.Visible = false;
            }
            else
            {
                VisibleButon(true);
            }
            LoadgrdQCData(-1);
            if (grvQCData.RowCount == 0)
            {
                LoadData(-1);
            }

            Commons.Modules.ObjSystems.ThayDoiNN(this);

        }
        private void LoadgrdQCData(Int64 id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID, DocNum,QCName,QCDate FROM dbo.QCData"));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
                if (grdQCData.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdQCData, grvQCData, dt, false, true, false, false, true, this.Name);
                    grvQCData.Columns["DocNum"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvQCData.Columns["QCName"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvQCData.Columns["ID"].Visible = false;
                }
                else
                    grdQCData.DataSource = dt;
                if (id != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                    grvQCData.FocusedRowHandle = grvQCData.GetRowHandle(index);
                }
                else {/* LoadText(false);*/ }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {

            //kiểm tra dữ liệu
            #region Kiem du lieu của mã item 
            if (txtDocNum.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblDocNum.Text, txtDocNum);
                return;
            }
            if (dedQCDate.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblQCDate.Text, dedQCDate);
                return;
            }

            object rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.QCData WHERE DocNum ='" + txtDocNum.Text.Trim() + "'  " + (ithem == -1 ? "" : "AND ID <> " + ithem + "") + "  ");
            if (rs != null && (Int32)rs > 0)
            {
                Modules.msgThayThe(ThongBao.msgDaTonTai, txtDocNum.Text, txtDocNum);
                return;
            }
            #endregion 
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                string sBT = "sBTNhapHangLoi" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, (DataTable)grdQCDataDetails.DataSource, "");
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
                    grvQCDataDetails.PostEditor();
                    grvQCDataDetails.UpdateCurrentRow();
                    Commons.Modules.ObjSystems.DeleteAddRow(grvQCDataDetails);
                    VisibleButon(true);
                    LoadData(iID);
                    LoadgrdQCData(iID);
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

            Commons.Modules.ObjSystems.DeleteAddRow(grvQCDataDetails);
            VisibleButon(true);
            grvQCData_FocusedRowChanged(null, null);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void grvQCDataDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            grvQCDataDetails.SetRowCellValue(e.RowHandle, grvQCDataDetails.Columns["ID"], -1);
            grvQCDataDetails.SetRowCellValue(e.RowHandle, grvQCDataDetails.Columns["ID_QC"], iID);
        }

        private void grvQCDataDetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                grvQCDataDetails.InvalidRowException += grvQCDataDetails_InvalidRowException;
                for (int i = 0; i < grvQCDataDetails.Columns.Count; i++)
                {
                    if (grvQCDataDetails.Columns[i].FieldName != "ItemName" && grvQCDataDetails.Columns[i].FieldName != "ProductionDate" && grvQCDataDetails.Columns[i].FieldName != "Quantity" && grvQCDataDetails.Columns[i].FieldName != "Note" && grvQCDataDetails.GetRowCellValue(e.RowHandle, grvQCDataDetails.Columns[i]).ToString() == "")
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(grvQCDataDetails.Columns[i].Caption + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                        grvQCDataDetails.FocusedRowHandle = e.RowHandle;
                        grvQCDataDetails.FocusedColumn = grvQCDataDetails.Columns[i];
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void grvQCDataDetails_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void grvQCDataDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            try
            {
                if (e.Column.FieldName == "ItemID")
                {
                    DataTable dt = new DataTable();
                    dt = ((DataTable)cboItemID.DataSource).Select("ItemID  = " + grvQCDataDetails.GetRowCellValue(e.RowHandle, grvQCDataDetails.Columns["ItemID"])).CopyToDataTable().Copy();
                    grvQCDataDetails.SetRowCellValue(e.RowHandle, grvQCDataDetails.Columns["ItemName"], dt.Rows[0]["ItemName"]);
                }

            }
            catch { }

        }

        private void grdQCDataDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                grvQCDataDetails.DeleteRow(grvQCDataDetails.FocusedRowHandle);
            }
        }
        #endregion

        #region Function
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

                if (grdQCDataDetails.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdQCDataDetails, grvQCDataDetails, dt1, false, true, true, false, true, this.Name);
                    LoadCbo_grvQCDataDetails();
                    Format_grvQCDataDetails();
                }
                else
                {
                    grdQCDataDetails.DataSource = dt1;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void LoadCbo_grvQCDataDetails()
        {
            try
            {
                if (grdQCDataDetails.DataSource != null)
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
                        Commons.Modules.ObjSystems.AddCombSearchLookUpEdit(cbo, "ID_PO", "PrOrNumber", grvQCDataDetails, dt, this.Name);
                        cbo.View.Columns["ID_PO"].Visible = false;

                    }

                    DataTable dt1 = new DataTable();
                    dt1 = ds.Tables[1].Copy();
                    cboItemID = new RepositoryItemSearchLookUpEdit();
                    if (dt1.Rows.Count > 0)
                    {
                        Commons.Modules.ObjSystems.AddCombSearchLookUpEdit(cboItemID, "ItemID", "ItemCode", grvQCDataDetails, dt1, this.Name);
                        cboItemID.View.Columns["ItemID"].Visible = false;
                    }

                    DataTable dt2 = new DataTable();
                    dt2 = ds.Tables[2].Copy();
                    RepositoryItemSearchLookUpEdit cbo2 = new RepositoryItemSearchLookUpEdit();
                    if (dt2.Rows.Count > 0)
                    {
                        Commons.Modules.ObjSystems.AddCombSearchLookUpEdit(cbo2, "MS_MAY", "MS_MAY", grvQCDataDetails, dt2, this.Name);
                    }

                    DataTable dt3 = new DataTable();
                    dt3 = ds.Tables[3].Copy();
                    RepositoryItemSearchLookUpEdit cbo3 = new RepositoryItemSearchLookUpEdit();
                    if (dt3.Rows.Count > 0)
                    {
                        Commons.Modules.ObjSystems.AddCombSearchLookUpEdit(cbo3, "ID_Defect", "DefectName", grvQCDataDetails, dt3, this.Name);
                        cbo3.View.Columns["ID_Defect"].Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void Format_grvQCDataDetails()
        {
            grvQCDataDetails.Columns["ID"].Visible = false;
            grvQCDataDetails.Columns["ID_QC"].Visible = false;
        }

        #endregion

        private void grvQCData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadData(Convert.ToInt64(grvQCData.GetFocusedRowCellValue("ID")));
            BingdingControl(false);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            iID = -1;
            VisibleButon(false);
            ithem = -1;
            LoadData(-1);
            BingdingControl(true);
            txtDocNum.Focus();
            Commons.Modules.ObjSystems.AddnewRow(grvQCDataDetails, true);
        }

        private void BingdingControl(bool them)
        {
            if (them == true)
            {
                txtDocNum.ResetText();
                txtQCName.ResetText();
                dedQCDate.ResetText();

            }
            else
            {
                txtDocNum.EditValue = grvQCData.GetFocusedRowCellValue("DocNum");
                txtQCName.EditValue = grvQCData.GetFocusedRowCellValue("QCName");
                dedQCDate.EditValue = grvQCData.GetFocusedRowCellValue("QCDate");
                try { iID = Modules.ToInt64(grvQCData.GetFocusedRowCellValue("ID").ToString()); } catch { }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtDocNum.Text == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuSua, lblDocNum.Text);
                return;
            }
            VisibleButon(false);
            Commons.Modules.ObjSystems.AddnewRow(grvQCDataDetails, true);
            ithem = Convert.ToInt64(grvQCData.GetFocusedRowCellValue("ID"));

        }
        private void DeleteData()
        {

            if (Modules.msgHoiThayThe(ThongBao.msgXoa, lblQCName.Text) == DialogResult.No) return;
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.QCDataDetails WHERE ID_QC ='" + Convert.ToInt64(grvQCData.GetFocusedRowCellValue("ID")) + "' DELETE dbo.QCData WHERE ID = '" + Convert.ToInt64(grvQCData.GetFocusedRowCellValue("ID")) + "'");
                grvQCData.DeleteSelectedRows();
                grvQCData_FocusedRowChanged(null, null);
            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }

        private void DeleteDatadetails()
        {
            try
            {
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groHangLoi.Text) == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.QCDataDetails WHERE ID_QC ='" + (grvQCDataDetails.GetFocusedRowCellValue("ID_QC") + "'"));
                grvQCDataDetails.DeleteSelectedRows();
            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);

            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (grvQCData.RowCount == 0) return;
            Int64 iId = -1;
            try { iId = Modules.ToInt64(grvQCData.GetFocusedRowCellValue("ID").ToString()); } catch { }
            if (iId == -1)
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuXoa, lblQCName.Text);
                return;
            }
            if (grvQCDataDetails.RowCount == 0)
            {
                DeleteData();
            }
            else
            {
                DeleteDatadetails();
            }
        }

        private void grvQCDataDetails_InvalidRowException_1(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvQCDataDetails_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grdQCData_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteDatadetails();
            }
        }
    }
}