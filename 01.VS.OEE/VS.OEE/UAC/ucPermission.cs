using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using Commons;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using System.Linq;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using DevExpress.Utils.Behaviors;
using DevExpress.XtraGrid;
using System.Drawing;
using DevExpress.LookAndFeel;

namespace VS.OEE
{
    public partial class ucPermission : DevExpress.XtraEditors.XtraForm
    {
        private int grid = 1;
        int ithem = 0;
        public ucPermission()
        {
            InitializeComponent();
        }


        private void ucPermission_Load(object sender, EventArgs e)
        {
            if (Modules.iPermission != 1)
            {
                this.btnThem.Visible = false;
                this.btnSua.Visible = false;
                this.btnXoa.Visible = false;
                this.btnGhi.Visible = false;
                this.btnKhong.Visible = false;
            }
            else
            {
                VisibleButon(true);
            }
            LoadGrdNhom(-1);
        }
        private void VisibleButon(bool flag)
        {
            switch (xtraTabPhanQuyen.SelectedTabPageIndex)
            {
                case 0:
                    {
                        btnThem.Visible = flag;
                        btnXoa.Visible = flag;
                        btnSua.Visible = flag;
                        btnGhi.Visible = !flag;
                        btnKhong.Visible = !flag;
                        break;
                    }
                case 1:
                    {
                        if (Modules.iPermission != 1)
                        {
                            this.btnThemSua2.Visible = false;
                        }
                        else
                        {
                            btnThemSua2.Visible = flag;
                            btnThoat2.Visible = flag;
                            btnGhi2.Visible = !flag;
                            btnKhong2.Visible = !flag;
                        }
                        break;
                    }
                default:
                    break;
            }
            for (int i = 0; i < xtraTabPhanQuyen.TabPages.Count; i++)
            {
                if (xtraTabPhanQuyen.SelectedTabPageIndex != i)
                {
                    xtraTabPhanQuyen.TabPages[i].PageEnabled = flag;
                }
            }
        }

        #region Tab1 Nhóm user

        #region function tab1
        private void LoadGrdNhom(int id)
        {
            DataTable dt = Commons.Modules.ObjSystems.DataNhom();

            try
            {
                if (grdGroup.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdGroup, grvGroup, dt, false, true, true, false, true, this.Name);
                    grvGroup.Columns["GROUP_ID"].Visible = false;
                    grvGroup.Columns["TYPE_LIC"].Visible = false;
                }
                else
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dt.Columns[i].ReadOnly = false;
                    }
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["GROUP_ID"] };
                    grdGroup.DataSource = dt;

                }
                if (id != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                    grvGroup.FocusedRowHandle = grvGroup.GetRowHandle(index);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadGrdUser()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT GROUP_ID, USERNAME, FULL_NAME, DESCRIPTION, MS_TO, USER_MAIL,MS_CONG_NHAN, ACTIVE FROM dbo.USERS WHERE GROUP_ID = " + Convert.ToInt32(grvGroup.GetFocusedRowCellValue("GROUP_ID")) + ""));
            try
            {
                if (grdUser.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdUser, grvUser, dt, false, true, true, false, true, this.Name);
                    grvUser.Columns["GROUP_ID"].Visible = false;
                    Commons.Modules.ObjSystems.AddCombXtra("MS_TO", "TEN_TO", grvUser, Commons.Modules.ObjSystems.DataTo());
                    Commons.Modules.ObjSystems.AddCombXtra("MS_CONG_NHAN", "FULL_NAME", grvUser, Commons.Modules.ObjSystems.DataNhanVien());
                }
                else
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dt.Columns[i].ReadOnly = false;
                    }
                    grdUser.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BingdingControl()
        {
            txtGroupName.EditValue = grvGroup.GetFocusedRowCellValue("GROUP_NAME");
            txtDescription.EditValue = grvGroup.GetFocusedRowCellValue("DESCRIPTION");
            txtIDGroup.EditValue = grvGroup.GetFocusedRowCellValue("GROUP_ID");
        }
        private bool KiemTraNhomTonTai(int id)
        {
            int n;
            bool resulst = false;
            n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.NHOM WHERE GROUP_ID = " + id + ""));
            if (n == 0) resulst = true;
            return resulst;
        }
        private void XoaNhom()
        {
            if (Modules.msgHoiThayThe(ThongBao.msgXoa, lblGroupName.Text) == DialogResult.No) return;
            //xóa
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.NHOM WHERE GROUP_ID = " + grvGroup.GetFocusedRowCellValue("GROUP_ID") + "");
                grvGroup.DeleteSelectedRows();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void XoaUser()
        {
            if (Modules.msgHoiThayThe(ThongBao.msgXoa, "UserName") == DialogResult.No) return;
            //xóa
            try
            {

                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.USERS WHERE USERNAME = '" + grvUser.GetFocusedRowCellValue("USERNAME") + "'");
                grvUser.DeleteSelectedRows();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool SaveDateGroup()
        {
            bool resust = false;
            try
            {
                string sBT = "BTUser" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.XoaTable(sBT);
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, Commons.Modules.ObjSystems.ConvertDatatable(grvUser), "");
                LoadGrdNhom(Convert.ToInt32(
                SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spEditNhomUser", ithem, txtGroupName.EditValue, txtDescription.EditValue, sBT)));
                resust = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resust;
        }
        #endregion
        #region sự kiện control tab1
        private void btnThem_Click(object sender, EventArgs e)
        {
            //thêm nhóm
            VisibleButon(false);
            ithem = -1;
            Commons.Modules.ObjSystems.AddnewRow(grvGroup, true);
            Commons.Modules.ObjSystems.AddnewRow(grvUser, true);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            //sữa nhóm
            ithem = Convert.ToInt32(txtIDGroup.EditValue);
            Commons.Modules.ObjSystems.AddnewRow(grvGroup, false);
            Commons.Modules.ObjSystems.AddnewRow(grvUser, true);
            VisibleButon(false);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grid == 1)
            {
                XoaNhom();
            }
            else
            {
                XoaUser();
            }

        }
        private void btnGhi_Click(object sender, EventArgs e)
        {

            if (!SaveDateGroup()) return;
            Commons.Modules.ObjSystems.DeleteAddRow(grvGroup);
            Commons.Modules.ObjSystems.DeleteAddRow(grvUser);
            VisibleButon(true);

        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            VisibleButon(true);
            Commons.Modules.ObjSystems.DeleteAddRow(grvGroup);
            Commons.Modules.ObjSystems.DeleteAddRow(grvUser);
            LoadGrdNhom(Convert.ToInt32(txtIDGroup.EditValue));
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            //thoát nhóm

        }
        private void grvGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadGrdUser();
            BingdingControl();

        }
        private void grvGroup_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                GridHitInfo info = grvGroup.CalcHitInfo(e.Location);
                DXMouseEventArgs a = (DXMouseEventArgs)e;
                if (btnGhi.Visible == true)
                {
                    if (ithem == -1)
                    {
                        try
                        {
                            if (KiemTraNhomTonTai(Convert.ToInt32(grvGroup.GetDataRow(info.RowHandle)["GROUP_ID"]))) return;
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        a.Handled = true;

                    }
                    else
                    {
                        if (Convert.ToInt32(grvGroup.GetDataRow(info.RowHandle)["GROUP_ID"]) == Convert.ToInt32(txtIDGroup.EditValue)) return;
                        a.Handled = true;
                    }
                }

            }
            catch { }
        }
        private void grvGroup_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            grvGroup.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        }
        private void grvGroup_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            BingdingControl();
        }
        private void grvGroup_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (view.FocusedColumn.Name == "colGROUP_NAME")
            {
                DataTable dt = Commons.Modules.ObjSystems.ConvertDatatable(grdGroup);
                int n = dt.AsEnumerable().Count(x => x.Field<string>("GROUP_NAME").ToString().Trim().ToUpper().Equals(e.Value.ToString().Trim().ToUpper()));
                if (dt.AsEnumerable().Count(x => x.Field<string>("GROUP_NAME").ToString().Trim().ToUpper().Equals(e.Value.ToString().Trim().ToUpper())) > 0 )
                {
                    if(ithem != -1)
                    {
                        if (e.Value.ToString().Trim().ToUpper() == txtIDGroup.EditValue.ToString().Trim().ToUpper()) return;
                    }
                    e.Valid = false;
                    e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "erTrungDuLieu"); return;
                }
            }
        }
        private void grvUser_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            //kiểm tra user tồn tại
            if (view.FocusedColumn.Name == "colUSERNAME")
            {
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.USERS WHERE USERNAME ='" + e.Value + "'")) > 0)
                {
                    e.Valid = false;
                    e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "erTrungDuLieu"); return;
                }
            }
            //kiểm tra mail hợp lệ
            if (view.FocusedColumn.Name == "colUSER_MAIL")
            {
                if (!Commons.Modules.ObjSystems.isEmail(e.Value.ToString().Trim()))
                {
                    e.Valid = false;
                    e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "erEmailKhonghople"); return;
                }
            }
        }
        private void grvUser_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            grvUser.SetFocusedRowCellValue("ACTIVE", true);
            grvUser.SetFocusedRowCellValue("GROUP_ID", -grvGroup.RowCount);

        }
        private void grvUser_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                GridHitInfo info = grvUser.CalcHitInfo(e.Location);
                DXMouseEventArgs a = (DXMouseEventArgs)e;
                //kiểm tra nếu có chọn thì không cho sữa username
                if (btnGhi.Visible == true)
                {
                    if (info.Column.Name == "colUSERNAME")
                    {
                        try
                        {
                            if (Convert.ToInt32(grvUser.GetDataRow(info.RowHandle)["GROUP_ID"]) < 0) return;
                            a.Handled = true;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch { }
        }

        private void grdUser_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
            {
                XoaUser();
            }
        }
        private void grdGroup_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
            {
                XoaNhom();
            }
        }
        private void grvGroup_Click(object sender, EventArgs e)
        {
            grid = 1;
        }
        private void grvUser_Click(object sender, EventArgs e)
        {
            grid = 2;
        }

        #endregion
        #endregion
        #region tab2 nhóm menu
        public void setcheck(TreeListNode node)
        {
            foreach (TreeListNode item in node.Nodes)
            {
                if (Convert.ToBoolean(item.GetValue("CHON")) == true)
                    treeListMenu.SetNodeCheckState(item, CheckState.Checked);
                setcheck(item); // recursive call
            }
        }
        private void EnableControl(bool enable)
        {
            treeListMenu.OptionsBehavior.Editable = enable;
            treeListMenu.OptionsView.ShowCheckBoxes = enable;
        }
        private void LoadTreeMenu(bool them)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetMenuPQOEE", Convert.ToInt32(txtIDGroup.EditValue), them, Commons.Modules.TypeLanguage));
            dtTmp.Columns["TEN_MENU"].ReadOnly = true;
            treeListMenu.DataSource = null;
            treeListMenu.BeginUpdate();
            treeListMenu.DataSource = dtTmp;
            treeListMenu.KeyFieldName = "ID_MENU";
            treeListMenu.ParentFieldName = "MS_CHA";
            treeListMenu.CheckBoxFieldName = "CHON";
            treeListMenu.Columns["CHON"].Visible = false;
            treeListMenu.Columns["STT_MENU"].Visible = false;
            Commons.Modules.ObjSystems.AddCombobyTree("ID_PERMISION", "PERMISION_NAME", treeListMenu, permision());
            treeListMenu.Columns["TEN_MENU"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_MENU");
            treeListMenu.Columns["ID_PERMISION"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "ID_PERMISION");
            EnableControl(false);
            treeListMenu.EndUpdate();
            treeListMenu.ExpandAll();
            try
            {
                TreeListColumn colum = new TreeListColumn();
                colum = treeListMenu.Columns["CHON"];
                foreach (TreeListNode item in treeListMenu.Nodes)
                {
                    setcheck(item);
                }
            }
            catch
            {
            }
        }
        private DataTable permision()
        {
            DataTable dtTempt = new DataTable();
            dtTempt.Columns.Add("ID_PERMISION", typeof(int));
            dtTempt.Columns.Add("PERMISION_NAME", typeof(string));
            dtTempt.Rows.Add(1, "Full access");
            dtTempt.Rows.Add(2, "Read Only");
            return dtTempt;
        }


        private void btnThemSua2_Click(object sender, EventArgs e)
        {
            LoadTreeMenu(true);
            EnableControl(true);
            VisibleButon(false);
        }

        private void btnThoat2_Click(object sender, EventArgs e)
        {

        }
        private void btnGhi2_Click(object sender, EventArgs e)
        {
            VisibleButon(true);
            //tạo bảng tạm từ lưới
            try
            {
                treeListMenu.PostEditor();
                treeListMenu.RefreshDataSource();
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "tabMenu" + Commons.Modules.UserName, (DataTable)treeListMenu.DataSource, "");
                string sSql = "DELETE  FROM dbo.NHOM_MENU_OEE WHERE GROUP_ID = " + Convert.ToInt32(txtIDGroup.EditValue) + " INSERT INTO dbo.NHOM_MENU_OEE (GROUP_ID, MENU_ID, ID_PERMISION) SELECT " + Convert.ToInt32(txtIDGroup.EditValue) + ", ID_MENU, ID_PERMISION FROM  tabMenu" + Commons.Modules.UserName + " WHERE ISNULL(CHON,1) = 1 AND ID_MENU != '-1'";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                Commons.Modules.ObjSystems.XoaTable("tabMenu" + Commons.Modules.UserName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadTreeMenu(false);
        }
        private void btnKhong2_Click(object sender, EventArgs e)
        {
            LoadTreeMenu(false);
            VisibleButon(true);
        }
        #endregion
        #region tab list user
        private void LoadGridListUser()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "getAllUsersOEE", Commons.Modules.TypeLanguage));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdListUser, grvListUser, dt, false, false, true, true, true, "");
            grvListUser.Columns["GROUP_ID"].Visible = false;
            grvListUser.Columns["TIME_LOGIN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            grvListUser.Columns["TIME_LOGIN"].DisplayFormat.FormatString = "dd/MM/yyy hh:mm:ss";
        }

        private void grvListUser_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (grvListUser.GetRowCellValue(e.RowHandle, "TIME_LOGIN").ToString() != "")
                    e.Appearance.BackColor = Color.LimeGreen;
            }
            catch
            {
            }
        }
        private void btnResetpass_Click(object sender, EventArgs e)
        {

            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.USERS SET PASS = N'̨̦̪̬' WHERE USERNAME ='"+ grvListUser.GetFocusedRowCellValue("USERNAME").ToString() + "'");
            Modules.msgChung("msgRessetpassSuccess");
        }
        private void btnThoatUser_Click(object sender, EventArgs e)
        {
            //kiểm tra nếu chính là user đăng nhập thì xóa và đăng xuất
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.LOGIN WHERE USER_LOGIN ='"+ grvListUser.GetFocusedRowCellValue("USERNAME").ToString() + "'");
            if(grvListUser.GetFocusedRowCellValue("USERNAME").ToString().ToUpper() == Commons.Modules.UserName.ToUpper())
            {
                Properties.Settings.Default.ApplicationSkinName = UserLookAndFeel.Default.SkinName;
                Properties.Settings.Default.Save();
                this.ParentForm.Hide();
                frmLogin login = new frmLogin();
                login.ShowDialog();
            }
        }
        #endregion

        private void xtraTabPhanQuyen_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (xtraTabPhanQuyen.SelectedTabPageIndex)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        VisibleButon(true);
                        LoadTreeMenu(false);
                        break;
                    }
                case 2:
                    {
                        LoadGridListUser();
                        break;
                    }
                default:
                    break;
            }
        }

     
    }
}
