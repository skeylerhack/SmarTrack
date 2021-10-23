using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Repository;

namespace VS.OEE
{
    public partial class frmPhanQuyenChucNang : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;  // == 1  full; <> 1 la read only
        RepositoryItemLookUpEdit cboPQ = new RepositoryItemLookUpEdit();
         public frmPhanQuyenChucNang(int PQ)
        {
            iPQ = PQ;

            InitializeComponent();

            if (iPQ != 1)
            {
                btnSua.Visible = false;
                btnGhi.Visible = false;
                btnKhongGhi.Visible = false;
                treeListMenu.OptionsBehavior.Editable = false;
                treeListMenu.OptionsView.ShowCheckBoxes = false;
            }
            else
            {
                btnSua.Visible = true;
                btnGhi.Visible = true;
                btnKhongGhi.Visible = true;
                treeListMenu.OptionsBehavior.Editable = true;
                treeListMenu.OptionsView.ShowCheckBoxes = true;
            }
        }

        #region Event
        private void frmPhanQuyenChucNang_Load(object sender, EventArgs e)
        {
            EnableButon(true);
            EnableControl(false);
            LoadCbo();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void cboPQ_BeforePopup(object sender, EventArgs e)
        {
            try
            {
                if (sender is LookUpEdit cbo)
                {
                    cbo.Properties.Columns["ID_PERMISSION"].Visible = false;

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            LoadTreeMenu(false);
            EnableButon(true);
            EnableControl(false);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                treeListMenu.PostEditor();
                treeListMenu.RefreshDataSource();
                String sBT = "sBT" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, (DataTable)treeListMenu.DataSource, "");
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNguoiDung", conn);
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuPhanQuyenChucNang";
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 2;
                cmd.Parameters.Add("@iID", SqlDbType.Int).Value = int.Parse(cboNhom.SelectedValue.ToString());
                cmd.Parameters.Add("@sBT", SqlDbType.NVarChar).Value = sBT;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            EnableButon(true);
            EnableControl(false);
            LoadTreeMenu(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LoadTreeMenu(true);
            EnableButon(false);
            EnableControl(true);
        }

        private void treeListMenu_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            setValue_treeListMenu(e.Node);
        }

        private void cboNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboNhom.DataSource != null)
                    LoadTreeMenu(false);
            }
            catch { }
        }
        #endregion

        #region Function
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
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNguoiDung", conn);
            cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuPhanQuyenChucNang";
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
            cmd.Parameters.Add("@iID", SqlDbType.BigInt).Value = int.Parse(cboNhom.SelectedValue.ToString());
            cmd.Parameters.Add("@COT6", SqlDbType.Bit).Value = them;
            cmd.CommandType = CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0].Copy();
            dt.Columns["TEN_MENU"].ReadOnly = true;
            treeListMenu.DataSource = null;
            treeListMenu.BeginUpdate();
            treeListMenu.DataSource = dt;
            treeListMenu.KeyFieldName = "KEY_MENU";
            treeListMenu.ParentFieldName = "MENU_PARENT";
            treeListMenu.CheckBoxFieldName = "CHON";

            //Config treelist view
            treeListMenu.Columns["CHON"].Visible = false;
            treeListMenu.Columns["ID_MENU"].Visible = false;
            treeListMenu.Columns["TEN_MENU"].Width = 500;

            DataTable dt1 = new DataTable();
            dt1 = ds.Tables[1].Copy();

            Commons.Modules.ObjSystems.AddCombobyTree(cboPQ, "ID_PERMISSION", "TEN_PERMISSION", treeListMenu, dt1);
            try
            {
                cboPQ.BeforePopup += cboPQ_BeforePopup;
            }
            catch { }

            treeListMenu.Columns["TEN_MENU"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_MENU");
            treeListMenu.Columns["ID_PERMISSION"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "ID_PERMISSION");
            treeListMenu.EndUpdate();
            treeListMenu.ExpandAll();
            try
            {
                foreach (TreeListNode item in treeListMenu.Nodes)
                {
                    setcheck(item);
                }
            }
            catch { }
        }

        private void EnableButon(bool visible)
        {
            btnSua.Visible = visible;
            btnThoat.Visible = visible;
            btnGhi.Visible = !visible;
            btnKhongGhi.Visible = !visible;


        }

        private void setValue_treeListMenu(TreeListNode node)
        {
            try
            {
                if (int.Parse(node.GetValue(treeListMenu.Columns["ID_PERMISSION"]).ToString()) < int.Parse(node.ParentNode.GetValue(treeListMenu.Columns["ID_PERMISSION"]).ToString()))
                {
                    node.ParentNode.SetValue(treeListMenu.Columns["ID_PERMISSION"], node.GetValue(treeListMenu.Columns["ID_PERMISSION"]));
                    setValue_treeListMenu(node.ParentNode);
                }
            }
            catch { }

            try
            {
                foreach (TreeListNode ChildNode in node.Nodes)
                {
                    if (int.Parse(node.GetValue(treeListMenu.Columns["ID_PERMISSION"]).ToString()) > int.Parse(ChildNode.GetValue(treeListMenu.Columns["ID_PERMISSION"]).ToString()))
                    {
                        ChildNode.SetValue(treeListMenu.Columns["ID_PERMISSION"], node.GetValue(treeListMenu.Columns["ID_PERMISSION"]));
                        setValue_treeListMenu(ChildNode);
                    }
                }
            }
            catch { }
        }

        private void LoadCbo()
        {
            try
            {
                string sSQL = "SELECT ID_NHOM, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN TEN_NHOM WHEN 1 THEN ISNULL(NULLIF(TEN_NHOM_A, ''), TEN_NHOM) ELSE ISNULL(NULLIF(TEN_NHOM_H, ''), TEN_NHOM) END AS TEN_NHOM FROM dbo.NHOM";
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSQL));
                cboNhom.ValueMember = "ID_NHOM";
                cboNhom.DisplayMember = "TEN_NHOM";
                cboNhom.DataSource = dt;
            }
            catch { }
        }
        #endregion
    }
}
