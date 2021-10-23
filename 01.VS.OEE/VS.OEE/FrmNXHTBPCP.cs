using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace VS.OEE
{
    public partial class FrmNXHTBPCP : DevExpress.XtraEditors.XtraForm
    {
        public FrmNXHTBPCP()
        {
            InitializeComponent();
        }
        public string sNX, sHT, sBPCP = "";
        private string _MS_MAY = "";
        private bool ThemSua = false;
        public string MS_MAY
        {
            get { return _MS_MAY; }
            set { _MS_MAY = value; }
        }

        public void BindData()
        {
            BindDataBoPhanChiuPhi();
            BindDataHeThong();
            BindDataNhaXuong();
        }



        private void FrmNXHTBPCP_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (grvHThong.RowCount == 0)
                MS_MAY = "";
            if (grvBPCP.RowCount == 0)
                MS_MAY = "";
            if (grvNXuong.RowCount == 0)
                MS_MAY = "";
        }

        private void frmPartner_Load(System.Object sender, System.EventArgs e)
        {

            txtMsMay.Text = _MS_MAY; // frmThongTinThietBi.txtMsMay.Text
            ComboNhaXuong();
            ComboHeThong();
            ComboBPCP();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            BindData();
            VisibleButton(true);
            HienGhi(false);

            EnableDataGridView(true);
            LblTieudeNXHTBPCP.Text = (GrpThietBi.Text + " : " + txtMsMay.Text).ToUpper();
            grvNXuong.BestFitColumns();
            grvHThong.BestFitColumns();
            grvBPCP.BestFitColumns();

            LoadNN();
        }

        public void LoadNN()
        {
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvBPCP, this.Name);
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvHThong, this.Name);
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvNXuong, this.Name);
            grpNX.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "grpNX");
            grpHT.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "grpHT");
            grpBPCP.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "grpBPCP");
            GrpThietBi.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "GrpThietBi");
            lblTenNX.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTenNX");
            lblNgayNX.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblNgayNX");
            lblTenHT.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTenHT");
            lblNgayHT.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblNgayHT");
            lblTenBPCP.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTenBPCP");
            lblNgayBPCP.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblNgayBPCP");
            LblMS_THIET_BI.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "LblMS_THIET_BI");
            BtnXoaNX.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "BtnXoaNX");
            BtnTroVe.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "BtnTroVe");
            BtnXoaBPCP.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "BtnXoaBPCP");
            BtnXoaHT.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "BtnXoaHT");
            BtnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "BtnXoa");
            btnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnThem");
            BtnSua.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "BtnSua");
            BtnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "BtnThoat");
            LblTieudeNXHTBPCP.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "LblTieudeNXHTBPCP");
        }

        public void EnableDataGridView(bool chon)
        {
            grdBPCP.Enabled = chon;
            grdHThong.Enabled = chon;
            grdNXuong.Enabled = chon;
        }


        public void HideDelButton(bool An)
        {
            if (An)
            {
                BtnXoaHT.Visible = An;
                BtnXoaHT.Focus();
                btnThem.Visible = !An;
                BtnSua.Visible = !An;
            }
            else
            {
                btnThem.Visible = !An;
                BtnSua.Visible = !An;
                btnThem.Focus();
                BtnSua.Focus();
                BtnXoaHT.Visible = An;
            }
            BtnXoaNX.Visible = An;
            BtnXoaBPCP.Visible = An;
            BtnTroVe.Visible = An;
            BtnXoa.Visible = !An;
            BtnThoat.Visible = !An;
        }
        private void BtnXoa_Click(System.Object sender, System.EventArgs e)
        {
            EnableDataGridView(true);
            HideDelButton(true);
        }

        private void BtnGhi_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (cbtNXuong.EditValue.ToString().Trim() != "")
                {
                    if (KiemDL("MAY_NHA_XUONG", "MS_N_XUONG", cbtNXuong.EditValue.ToString(), datNgayNX.DateTime, "NhaXuong") == false)
                    {
                        cbtNXuong.Focus();
                        return;
                    }
                }

                if (cbtHThong.EditValue.ToString().Trim() != "")
                {
                    if (KiemDL("MAY_HE_THONG", "MS_HE_THONG", cbtHThong.EditValue.ToString(), datNgayHT.DateTime, "HeThong") == false)
                    {
                        cbtHThong.Focus();
                        return;
                    }
                }



                if (cboTenBPCP.Text.ToString().Trim() != "")
                {
                    if (KiemDL("MAY_BO_PHAN_CHIU_PHI", "MS_BP_CHIU_PHI", cboTenBPCP.EditValue.ToString(), datNgayBPCP.DateTime, "BPCP") == false)
                    {
                        cboTenBPCP.Focus();
                        return;
                    }
                }

                SqlConnection con = new SqlConnection(Commons.IConnections.CNStr);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    // Them
                    if (ThemSua)
                    {
                        // NX
                        if (cbtNXuong.EditValue.ToString().Trim() != "")
                        {
                            SqlHelper.ExecuteScalar(tran, "AddMAY_NHA_XUONG", txtMsMay.Text, datNgayNX.DateTime.Date, cbtNXuong.EditValue);
                            SqlHelper.ExecuteScalar(tran, "UPDATE_MAY_NHA_XUONG_LOG", txtMsMay.Text, datNgayNX.DateTime, this.Name, Commons.Modules.UserName, 1);
                        }
                        // May He Thong
                        if (cbtHThong.EditValue.ToString().Trim() != "")
                        {
                            SqlHelper.ExecuteScalar(tran, "AddMAY_HE_THONG", txtMsMay.Text, datNgayHT.DateTime.Date, cbtHThong.EditValue);
                            SqlHelper.ExecuteScalar(tran, "UPDATE_MAY_HE_THONG_LOG", txtMsMay.Text, datNgayHT.DateTime.Date, this.Name, Commons.Modules.UserName, 1);
                        }

                        // BPCP
                        if (cboTenBPCP.Text.ToString().Trim() != "")
                        {
                            SqlHelper.ExecuteScalar(tran, "AddMAY_BPCP", txtMsMay.Text, datNgayBPCP.DateTime.Date, cboTenBPCP.EditValue);
                            SqlHelper.ExecuteNonQuery(tran, "UPDATE_MAY_BO_PHAN_CHIU_PHI_LOG", txtMsMay.Text, datNgayBPCP.DateTime.Date, this.Name, Commons.Modules.UserName, 1);
                        }
                    }
                    else
                    {
                        // Sua
                        if (cbtNXuong.EditValue.ToString().Trim() == "")
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgLoiChuaNhapNhaXuong", Commons.Modules.TypeLanguage));
                            cbtNXuong.Focus();
                            return;
                        }
                        if (cbtHThong.EditValue.ToString().Trim() == "")
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgLoiChuaNhapHeThong", Commons.Modules.TypeLanguage));
                            cbtHThong.Focus();
                            return;
                        }

                        if (cboTenBPCP.Text.ToString().Trim() == "")
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgLoiChuaNhapBPCP", Commons.Modules.TypeLanguage));
                            cboTenBPCP.Focus();
                            return;
                        }

                        // NX
                        SqlHelper.ExecuteScalar(tran, "UPDATE_MAY_NHA_XUONG_LOG", txtMsMay.Text, datNgayNX.DateTime.Date, this.Name, Commons.Modules.UserName, 2);
                        if (grvNXuong.RowCount == 0)
                            SqlHelper.ExecuteScalar(tran, "AddMAY_NHA_XUONG", txtMsMay.Text, datNgayNX.DateTime.Date, cbtNXuong.EditValue);
                        else
                            SqlHelper.ExecuteScalar(tran, "UpdateMAY_NHA_XUONG", txtMsMay.Text, datNgayNX.DateTime.Date, cbtNXuong.EditValue, grvNXuong.GetFocusedRowCellValue("NGAY_NHAP"));
                        // HT
                        SqlHelper.ExecuteScalar(tran, "UPDATE_MAY_HE_THONG_LOG", txtMsMay.Text, datNgayHT.DateTime.Date, this.Name, Commons.Modules.UserName, 2);

                        if (grvHThong.RowCount == 0)
                            SqlHelper.ExecuteScalar(tran, "AddMAY_HE_THONG", txtMsMay.Text, datNgayHT.DateTime.Date, cbtHThong.EditValue);
                        else
                            SqlHelper.ExecuteScalar(tran, "UpdateMAY_HE_THONG", txtMsMay.Text, datNgayHT.DateTime.Date, System.Convert.ToInt32(cbtHThong.EditValue), grvHThong.GetFocusedRowCellValue("NGAY_NHAP"));

                        // BPCP
                        SqlHelper.ExecuteScalar(tran, "UPDATE_MAY_BO_PHAN_CHIU_PHI_LOG", txtMsMay.Text, datNgayBPCP.DateTime.Date, this.Name, Commons.Modules.UserName, 2);
                        if (grvBPCP.RowCount == 0)
                            SqlHelper.ExecuteScalar(tran, "AddMAY_BPCP", txtMsMay.Text, datNgayBPCP.DateTime.Date, cboTenBPCP.EditValue);
                        else
                            SqlHelper.ExecuteScalar(tran, "UpdateMAY_BPCP", txtMsMay.Text, datNgayBPCP.DateTime.Date, System.Convert.ToInt32(cboTenBPCP.EditValue), grvBPCP.GetFocusedRowCellValue("NGAY_NHAP"));
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "DELETE MAY_NHA_XUONG WHERE MS_MAY = '" + txtMsMay.Text + "' AND MS_N_XUONG IS NULL");
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "DELETE MAY_HE_THONG WHERE MS_MAY = '" + txtMsMay.Text + "' AND MS_HE_THONG IS NULL");
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "DELETE MAY_BO_PHAN_CHIU_PHI WHERE MS_MAY = '" + txtMsMay.Text + "' AND MS_BP_CHIU_PHI IS NULL");
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgLoiCapNhap0ThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message.ToString());
                }
                BindData();
                HienGhi(false);
            }
            catch 
            {
            }

        }

        private void BtnKhongghi_Click(object sender, System.EventArgs e)
        {
            BindData();
            HienGhi(false);
        }



        public void BindDataHeThong()
        {
            grdHThong.DataSource = null;
            DataTable dtHThong = new DataTable();
            dtHThong.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetMAY_HE_THONG", txtMsMay.Text, Commons.Modules.UserName));
            dtHThong.Columns["NGAY_NHAP_CU"].AllowDBNull = true;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdHThong, grvHThong, dtHThong, false, true, true, true, true, this.Name);
            grvHThong_FocusedRowChanged(null/* TODO Change to default(_) if this is not a reference type */, null/* TODO Change to default(_) if this is not a reference type */);
            grvHThong.Columns[0].Width = 35;
            grvHThong.Columns[4].Visible = false;
            grvHThong.Columns[3].Visible = false;
            grvHThong.Columns[2].Visible = false;
        }

        public void BindDataBoPhanChiuPhi()
        {
            grdBPCP.DataSource = null;
            DataTable dtBPCP = new DataTable();
            dtBPCP.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetMAY_BPCP", txtMsMay.Text, Commons.Modules.UserName));
            dtBPCP.Columns["NGAY_NHAP_CU"].AllowDBNull = true;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBPCP, grvBPCP, dtBPCP, false, true, true, true, true, this.Name);
            grvBPCP_FocusedRowChanged(null/* TODO Change to default(_) if this is not a reference type */, null/* TODO Change to default(_) if this is not a reference type */);
            grvBPCP.Columns[0].Width = 35;
            grvBPCP.Columns[4].Visible = false;
            grvBPCP.Columns[3].Visible = false;
            grvBPCP.Columns[2].Visible = false;
        }

        public void BindDataNhaXuong()
        {
            grdNXuong.DataSource = null;
            DataTable dtNXuong = new DataTable();
            //dtNXuong = new NXHTBPCPController().GetMAY_NHA_XUONG(txtMsMay.Text);
            dtNXuong.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetMAY_NHA_XUONG1", txtMsMay.Text, Commons.Modules.UserName));
            dtNXuong.Columns["NGAY_NHAP_CU"].AllowDBNull = true;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNXuong, grvNXuong, dtNXuong, false, true, true, true, true, this.Name);
            grvNXuong_FocusedRowChanged(null/* TODO Change to default(_) if this is not a reference type */, null/* TODO Change to default(_) if this is not a reference type */);
            grvNXuong.Columns[0].Width = 35;
            grvNXuong.Columns[4].Visible = false;
            grvNXuong.Columns[3].Visible = false;
            grvNXuong.Columns[2].Visible = false;
        }

        public void ComboHeThong()
        {
            Commons.Modules.ObjSystems.MLoadTreeLookUpEdit(cbtHThong, Commons.Modules.ObjSystems.DataHeThongTree(false), "MS_HE_THONG", "TEN_HE_THONG", "MS_CHA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_HE_THONG"));
        }

        public void ComboNhaXuong()
        {
            Commons.Modules.ObjSystems.MLoadTreeLookUpEdit(cbtNXuong, Commons.Modules.ObjSystems.DataNhaXuongTree(false), "MS_N_XUONG", "TEN_N_XUONG", "MS_CHA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_HE_THONG"));

        }

        public void ComboBPCP()
        {
            // Dim dtTmp As New DataTable
            // dtTmp = New NXHTBPCPController().GetBO_PHAN_CHIU_PHIs
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetBO_PHAN_CHIU_PHIs"));
            cboTenBPCP.Properties.DataSource = dtTmp;
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTenBPCP, dtTmp, "MS_BP_CHIU_PHI", "TEN_BP_CHIU_PHI", "");
        }

        public void VisibleButton(bool blnVisible)
        {
            btnThem.Visible = blnVisible;
            BtnSua.Visible = blnVisible;
            BtnThoat.Visible = blnVisible;
            BtnXoa.Visible = blnVisible;
            BtnGhi.Visible = !blnVisible;
            BtnKhongghi.Visible = !blnVisible;
        }

        private void BtnThoa_Click(System.Object sender, System.EventArgs e)
        {
            if (grvHThong.RowCount == 0)
                MS_MAY = "";
            if (grvBPCP.RowCount == 0)
                MS_MAY = "";
            if (grvNXuong.RowCount == 0)
                MS_MAY = "";

            this.Close();
        }

        private void BtnTroVe_Click(object sender, System.EventArgs e)
        {
            EnableDataGridView(true);
            HideDelButton(false);
        }

        private void BtnXoaBPCP_Click(object sender, System.EventArgs e)
        {
            DialogResult traLoi;

            if (grvBPCP.RowCount <= 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage));
                return;
            }
            if (grvBPCP.RowCount == 1)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "Co1DongKhongTheXoaBPCP", Commons.Modules.TypeLanguage));
                return;
            }
            traLoi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo);
            if (traLoi == DialogResult.No)
                return;
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "UPDATE_MAY_BO_PHAN_CHIU_PHI_LOG", txtMsMay.Text, grvBPCP.GetFocusedRowCellValue("NGAY_NHAP"), this.Name, Commons.Modules.UserName, 3);
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "DeleteMAY_BPCP", txtMsMay.Text, grvBPCP.GetFocusedRowCellValue("NGAY_NHAP"));
            BindDataBoPhanChiuPhi();
        }

        private void BtnXoaHT_Click(object sender, System.EventArgs e)
        {
            DialogResult traLoi;
            if (grvHThong.RowCount <= 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage));
                return;
            }
            if (grvHThong.RowCount == 1)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "Co1DongKhongTheXoaHT", Commons.Modules.TypeLanguage));
                return;
            }
            traLoi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo);
            if (traLoi == DialogResult.No)
                return;
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "UPDATE_MAY_HE_THONG_LOG", txtMsMay.Text, grvHThong.GetFocusedRowCellValue("NGAY_NHAP"), this.Name, Commons.Modules.UserName, 3);
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "DeleteMAY_HE_THONG", txtMsMay.Text,grvHThong.GetFocusedRowCellValue("NGAY_NHAP"));
            BindDataHeThong();
        }

        private void BtnXoaNX_Click(object sender, System.EventArgs e)
        {
            DialogResult traLoi;
            if (grvNXuong.RowCount <= 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage));
                return;
            }
            if (grvNXuong.RowCount == 1)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "Co1DongKhongTheXoaNX", Commons.Modules.TypeLanguage));
                return;
            }

            traLoi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage));
            if (traLoi == DialogResult.No)
                return;
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "UPDATE_MAY_NHA_XUONG_LOG", txtMsMay.Text, grvNXuong.GetFocusedRowCellValue("NGAY_NHAP"), this.Name, Commons.Modules.UserName,3);
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "DeleteMAY_NHA_XUONG", txtMsMay.Text, grvNXuong.GetFocusedRowCellValue("NGAY_NHAP"));

            BindDataNhaXuong();
        }


        private void btnThem_Click(System.Object sender, System.EventArgs e)
        {
            HienGhi(true);
            cboTenBPCP.ItemIndex = 0;

            datNgayBPCP.DateTime = DateTime.Now;
            datNgayNX.DateTime = DateTime.Now;
            datNgayHT.DateTime = DateTime.Now;
            ThemSua = true;
        }

        private void BtnSua_Click(System.Object sender, System.EventArgs e)
        {
            HienGhi(true);
            ThemSua = false;
        }
        public void HienGhi(bool UnLock)
        {
            VisibleButton(!UnLock);

            cboTenBPCP.Enabled = UnLock;
            cbtNXuong.Enabled = UnLock;
            cbtHThong.Enabled = UnLock;

            datNgayBPCP.Enabled = UnLock;
            datNgayNX.Enabled = UnLock;
            datNgayHT.Enabled = UnLock;


            grdHThong.Enabled = !UnLock;
            grdBPCP.Enabled = !UnLock;
            grdNXuong.Enabled = !UnLock;
        }


        public bool KiemDL(string sTable, string sCotMaso, string sMaSoGT, DateTime dNgay, string sLoi)
        {
            bool resulst = false;
            string sSql;
            DataTable dtTmp;

            if (ThemSua)
            {
                dtTmp = new DataTable();
                sSql = " SELECT * FROM " + sTable + " WHERE  (MS_MAY = '" + txtMsMay.Text + "')   AND NGAY_NHAP = '" + dNgay.Date.ToString("MM/dd/yyyy") + "' ";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgLoiNhap" + sLoi + "DaCoVaoNgayNay", Commons.Modules.TypeLanguage));
                    return false;
                }
            }
            string s;
            try
            {

                sSql = " SELECT ISNULL(CONVERT(NVARCHAR," + sCotMaso + "), '')  FROM " + sTable + " A INNER JOIN (SELECT MAX(NGAY_NHAP) AS NGAY_NHAP, MS_MAY " + " FROM " + sTable + " WHERE (dbo." + sTable + ".MS_MAY = '" + txtMsMay.Text + "')  " + " AND NGAY_NHAP < '" + dNgay.Date.ToString("MM/dd/yyyy") + "' GROUP BY MS_MAY ) B ON A.MS_MAY = B.MS_MAY AND A.NGAY_NHAP = B.NGAY_NHAP ";
                s = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql).ToString();

            }
            catch
            {
                s = "";
            }

            if (ThemSua & sMaSoGT.ToString().Trim() == s)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgLoiNhap" + sLoi + "lientuc", Commons.Modules.TypeLanguage));
                return false;
            }

            sSql = " SELECT ISNULL(CONVERT(NVARCHAR," + sCotMaso + "), '')  FROM " + sTable + " A INNER JOIN (SELECT MIN(NGAY_NHAP ) AS NGAY_NHAP, MS_MAY " + " FROM " + sTable + " WHERE (dbo." + sTable + ".MS_MAY = '" + txtMsMay.Text + "')  " + " AND NGAY_NHAP > '" + dNgay.Date.ToString("MM/dd/yyyy") + "' GROUP BY MS_MAY ) B ON A.MS_MAY = B.MS_MAY AND A.NGAY_NHAP = B.NGAY_NHAP ";

            if (ThemSua & sMaSoGT.ToString().Trim() == SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql) as string)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgLoiNhap" + sLoi + "lientuc", Commons.Modules.TypeLanguage));
                return false;
            }
            resulst = true;
            return resulst;
        }

        private void grvNXuong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                cbtNXuong.EditValue = (grvNXuong.GetFocusedRowCellValue("MS_N_XUONG").ToString());
                datNgayNX.DateTime = Convert.ToDateTime(grvNXuong.GetFocusedRowCellValue("NGAY_NHAP").ToString());
            }
            catch 
            {
            }
        }

        private void grvHThong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                cbtHThong.EditValue = (Convert.ToInt32(grvHThong.GetFocusedRowCellValue("MS_HE_THONG")));
                datNgayHT.DateTime = Convert.ToDateTime(grvHThong.GetFocusedRowCellValue("NGAY_NHAP").ToString());
            }
            catch 
            {
            }
        }

        private void grvBPCP_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                cboTenBPCP.EditValue = grvBPCP.GetFocusedRowCellValue("MS_BP_CHIU_PHI");
                datNgayBPCP.DateTime = Convert.ToDateTime(grvBPCP.GetFocusedRowCellValue("NGAY_NHAP").ToString());
            }
            catch 
            {
            }
        }

        private void FrmNXHTBPCP_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (grvNXuong.RowCount >0)
            {
                sNX = grvNXuong.GetRowCellValue(0, grvNXuong.Columns[1]).ToString();
            }
            if(grvHThong.RowCount > 0)
            {
                sHT += grvHThong.GetRowCellValue(0, grvHThong.Columns[1]).ToString();
            }
            if (grvHThong.RowCount > 0)
            {
                sBPCP += grvBPCP.GetRowCellValue(0, grvBPCP.Columns[1]).ToString();
            }

        }
    }
}