using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;

namespace VS.OEE
{
    public partial class frmPhanQuyenDuLieu : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanQuyenDuLieu(int iPQ)
        {
            InitializeComponent();
            if (iPQ != 1)
            {
                btnSua.Visible = false;
                btnGhi.Visible = false;
                btnKhong.Visible = false;
            }
            else
            {
                btnSua.Visible = true;
                btnGhi.Visible = true;
                btnKhong.Visible = true;
            }
        }

        private void frmPhanQuyenDuLieu_Load(object sender, EventArgs e)
        {
            Commons.Modules.sPS = "0Load";
            EnableButon(true);
            LoadCbo();
            Commons.Modules.sPS = "";
            LoadDiaDiemDayChuyen(Convert.ToInt32(cboNhom.SelectedValue));
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void EnableButon(bool visible)
        {
            btnSua.Visible = visible;
            btnThoat.Visible = visible;
            btnGhi.Visible = !visible;
            btnKhong.Visible = !visible;
            cboNhom.Enabled = visible;
        }
        private void LoadCbo()
        {
            try
            {
                string sSQL = "SELECT GROUP_ID AS ID_NHOM,GROUP_NAME AS TEN_NHOM FROM dbo.NHOM";
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSQL));
                cboNhom.ValueMember = "ID_NHOM";
                cboNhom.DisplayMember = "TEN_NHOM";
                cboNhom.DataSource = dt;
            }
            catch { }
        }

        private void LoadDiaDiemDayChuyen(int GroupID)
        {
            if (Commons.Modules.sPS == "0Load") return;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetNHOM_NHA_XUONG", GroupID));
            for (int i = 0; i < dtTmp.Columns.Count; i++)
            {
                if (i == 0)
                    dtTmp.Columns[i].ReadOnly = false;
                else
                    dtTmp.Columns[i].ReadOnly = false;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDiaDiem, grvDiaDiem, dtTmp, false, false, true, true, true, Name);
            grvDiaDiem.Columns["TINH"].Visible = false;
            grvDiaDiem.Columns["QUAN"].Visible = false;
            grvDiaDiem.Columns["DIA_CHI"].Visible = false;
            grvDiaDiem.Columns["IS_UPDATE"].Visible = false;
            grvDiaDiem.Columns["GROUP_ID"].Visible = false;


            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetNHOM_HE_THONG", GroupID));
            for (int i = 0; i < dtTmp.Columns.Count; i++)
            {
                if(i ==0)
                    dtTmp.Columns[i].ReadOnly = false;
                else
                    dtTmp.Columns[i].ReadOnly = false;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDayChuyen, grvDayChuyen, dtTmp, false, false, true, true, true, Name);
            grvDayChuyen.Columns["IS_UPDATE"].Visible = false;
            grvDayChuyen.Columns["GROUP_ID"].Visible = false;


            grvDiaDiem.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            grvDiaDiem.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            grvDiaDiem.OptionsSelection.CheckBoxSelectorField = "CHON";

            grvDayChuyen.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            grvDayChuyen.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            grvDayChuyen.OptionsSelection.CheckBoxSelectorField = "CHON";


            grvDiaDiem.ActiveFilterString = "CHON =True";
            grvDayChuyen.ActiveFilterString = "CHON =True";

            grvDiaDiem.Columns["CHON"].Visible = false;
            grvDayChuyen.Columns["CHON"].Visible = false;
        }

        private void LoadLoaiTB_BPCP(int GroupID)
        {
            if (Commons.Modules.sPS == "0Load") return;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetLOAI_MAY_QUYEN", GroupID));
            for (int i = 0; i < dtTmp.Columns.Count; i++)
            {
                if (i == 0)
                    dtTmp.Columns[i].ReadOnly = false;
                else
                    dtTmp.Columns[i].ReadOnly = false;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdLoaiMay, grvLoaiMay, dtTmp, false, false, true, true, true, Name);
            grvLoaiMay.Columns["IS_UPDATE"].Visible = false;
            grvLoaiMay.Columns["GROUP_ID"].Visible = false;

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetNHOM_BO_PHAN_CHIU_PHI_QUYEN", GroupID));
            for (int i = 0; i < dtTmp.Columns.Count; i++)
            {
                if (i == 0)
                    dtTmp.Columns[i].ReadOnly = false;
                else
                    dtTmp.Columns[i].ReadOnly = false;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBPCP, grvBPCP, dtTmp, false, false, true, true, true, Name);
            grvBPCP.Columns["TEN_DON_VI"].Visible = false;
            grvBPCP.Columns["IS_UPDATE"].Visible = false;
            grvBPCP.Columns["GROUP_ID"].Visible = false;

            grvLoaiMay.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            grvLoaiMay.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            grvLoaiMay.OptionsSelection.CheckBoxSelectorField = "CHON";

            grvBPCP.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            grvBPCP.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            grvBPCP.OptionsSelection.CheckBoxSelectorField = "CHON";

            grvLoaiMay.ActiveFilterString = "CHON =True";
            grvBPCP.ActiveFilterString = "CHON =True";

            grvLoaiMay.Columns["CHON"].Visible = false;
            grvBPCP.Columns["CHON"].Visible = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tabPhanQuyen.SelectedTabPageIndex == 0)
            {
                grvDiaDiem.ActiveFilter.Clear();
                grvDayChuyen.ActiveFilter.Clear();
                grvDiaDiem.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
                grvDiaDiem.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                grvDayChuyen.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
                grvDayChuyen.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            }
            else
            {
                grvLoaiMay.ActiveFilter.Clear();
                grvBPCP.ActiveFilter.Clear();
                grvLoaiMay.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
                grvLoaiMay.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                grvBPCP.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
                grvBPCP.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            }    
            EnableButon(false);
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            if (tabPhanQuyen.SelectedTabPageIndex == 0)
            {
                LoadDiaDiemDayChuyen(Convert.ToInt32(cboNhom.SelectedValue));
            }
            else
            {
                LoadLoaiTB_BPCP(Convert.ToInt32(cboNhom.SelectedValue));
            }    
            EnableButon(true);
        }

        public Boolean SaveDiaDiemDC(DataTable tbNX, DataTable tbDC)
        {
            DataTable dt = new DataTable();
            SqlTransaction transaction = null/* TODO Change to default(_) if this is not a reference type */;
            using (SqlConnection con = new SqlConnection(Commons.IConnections.CNStr))
            {
                SqlCommand sqlcom = con.CreateCommand();
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    transaction = con.BeginTransaction("Transaction");
                    sqlcom.Connection = con;
                    sqlcom.Transaction = transaction;
                    sqlcom.Parameters.AddWithValue("ACTION", "SAVE_NXDC");
                    if ((tbNX != null))
                        sqlcom.Parameters.AddWithValue("@TBNX", tbNX);
                    if ((tbDC != null))
                        sqlcom.Parameters.AddWithValue("@TBDC", tbDC);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.CommandText = "SP_NHOM";
                    sqlcom.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                        transaction.Rollback();
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public Boolean SaveLTBBPCP(DataTable tbLTB, DataTable tbBPCP)
        {
            DataTable dt = new DataTable();
            SqlTransaction transaction = null/* TODO Change to default(_) if this is not a reference type */;
            using (SqlConnection con = new SqlConnection(Commons.IConnections.CNStr))
            {
                SqlCommand sqlcom = con.CreateCommand();
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    transaction = con.BeginTransaction("Transaction");
                    sqlcom.Connection = con;
                    sqlcom.Transaction = transaction;
                    sqlcom.Parameters.AddWithValue("ACTION", "SAVE_LTB_BPCP");
                    if ((tbLTB != null))
                        sqlcom.Parameters.AddWithValue("@TBLTB", tbLTB);
                    if ((tbBPCP != null))
                        sqlcom.Parameters.AddWithValue("@TBBPCP", tbBPCP);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.CommandText = "SP_NHOM";
                    sqlcom.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                        transaction.Rollback();
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (tabPhanQuyen.SelectedTabPageIndex == 0)
            {
                DataView dataView = new DataView((DataTable)grdDiaDiem.DataSource, "IS_UPDATE =0", "", DataViewRowState.CurrentRows);
                DataTable tbNX = new System.Data.DataTable();
                DataTable tbDC = new System.Data.DataTable();
                tbNX = dataView.ToTable(true, "MS_N_XUONG", "Ten_N_XUONG", "DIA_CHI", "QUAN", "TINH", "GROUP_ID", "CHON", "IS_UPDATE");
                dataView = new DataView((DataTable)grdDayChuyen.DataSource, "IS_UPDATE =0", "", DataViewRowState.CurrentRows);
                tbDC = dataView.ToTable(true, "MS_HE_THONG", "TEN_HE_THONG", "GROUP_ID", "CHON", "IS_UPDATE");
                if (SaveDiaDiemDC(tbNX, tbDC))
                {
                    LoadDiaDiemDayChuyen(Convert.ToInt32(cboNhom.SelectedValue));
                    EnableButon(true);
                }
                else
                {
                    Commons.Modules.msgChung(Commons.ThongBao.msgCapNhatThatBai);
                }
            }
            else
            {
                DataView dataView = new DataView((DataTable)grdLoaiMay.DataSource, "IS_UPDATE =0", "", DataViewRowState.CurrentRows);
                DataTable tbLTB = new System.Data.DataTable();
                DataTable tbBPCP = new System.Data.DataTable();
                tbLTB = dataView.ToTable(true, "MS_LOAI_MAY", "TEN_LOAI_MAY", "GROUP_ID", "CHON", "IS_UPDATE");
                dataView = new DataView((DataTable)grdBPCP.DataSource, "IS_UPDATE =0", "", DataViewRowState.CurrentRows);
                tbBPCP = dataView.ToTable(true, "MS_BP_CHIU_PHI", "TEN_BP_CHIU_PHI", "TEN_DON_VI", "GROUP_ID", "CHON", "IS_UPDATE");
                if (SaveLTBBPCP(tbLTB, tbBPCP))
                {
                    LoadLoaiTB_BPCP(Convert.ToInt32(cboNhom.SelectedValue));
                    EnableButon(true);
                }
                else
                {
                    Commons.Modules.msgChung(Commons.ThongBao.msgCapNhatThatBai);
                }
            }    
        }
        private void tabPhanQuyen_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (btnGhi.Visible == true)
                e.Cancel = true;
        }
        private void tabPhanQuyen_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                if (tabPhanQuyen.SelectedTabPageIndex != 0)
                {
                    if (grdLoaiMay.DataSource == null)
                    {
                        LoadLoaiTB_BPCP(Convert.ToInt32(cboNhom.SelectedValue));
                    }
                    else
                    {
                        if (Convert.ToInt32(grvLoaiMay.GetRowCellValue(0, "GROUP_ID")) != Convert.ToInt32(cboNhom.SelectedValue))
                        {
                            LoadLoaiTB_BPCP(Convert.ToInt32(cboNhom.SelectedValue));
                        }
                    }
                }
                else
                {
                    if (grdDiaDiem.DataSource == null)
                    {
                        LoadDiaDiemDayChuyen(Convert.ToInt32(cboNhom.SelectedValue));
                    }
                    else
                    {
                        if (Convert.ToInt32(grvDiaDiem.GetRowCellValue(0, "GROUP_ID")) != Convert.ToInt32(cboNhom.SelectedValue))
                        {
                            LoadDiaDiemDayChuyen(Convert.ToInt32(cboNhom.SelectedValue));
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void cboNhom_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabPhanQuyen.SelectedTabPageIndex != 0)
                {
                    LoadLoaiTB_BPCP(Convert.ToInt32(cboNhom.SelectedValue));
                }
                else
                {
                    LoadDiaDiemDayChuyen(Convert.ToInt32(cboNhom.SelectedValue));
                }
            }
            catch
            {
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
