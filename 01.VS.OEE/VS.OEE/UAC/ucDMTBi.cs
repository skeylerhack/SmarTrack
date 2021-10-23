using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Reflection;

namespace VS.OEE
{
    public partial class ucDMTBi : UserControl
    {
        string MS_MAY = "-1";
        string sForm = "frmThongTinThietBi"; 
        public ucDMTBi()
        {
            InitializeComponent();
        }
        public void LoadLoaiMay2()
        {
            var dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "PermisionLOAI_MAY", Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMS_LOAI_MAY, dtTmp.Copy(), "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
        }
        // load nhóm máy theo loai may
        public void LoadNhomMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMS_NHOM_MAY, "GetMAY_NHOM_MAYs", "MS_NHOM_MAY", "TEN_NHOM_MAY", "", true, cboMS_LOAI_MAY.EditValue.ToString());
            }
            catch
            {
            }
        }
        public void LoadNCC()
        {
            var dtTmp = new DataTable();
            DataRow dtRow;

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetKHACH_HANGs"));
            dtRow = dtTmp.NewRow();
            dtRow[0] = "-99";
            dtRow[1] = "";
            for (int i = 1; i <= dtTmp.Columns.Count - 2; i++)
                dtRow[i + 1] = "";
            dtTmp.Rows.Add(dtRow);

            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMS_NCC, dtTmp, "MS_KH", "TEN_CONG_TY", "");
        }
        // load nhà sản xuất
        public void LoadNSX()
        {
            var dtTmp = new DataTable();
            DataRow dtRow;

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetHANG_SAN_XUATs"));
            dtRow = dtTmp.NewRow();
            dtRow[0] = -99;
            dtRow[1] = "";
            for (int i = 1; i <= dtTmp.Columns.Count - 2; i++)
                dtRow[i + 1] = "";
            dtTmp.Rows.Add(dtRow);
            Commons.Modules.ObjSystems.MLoadLookUpEdit(CboMS_HSX, dtTmp, "MS_HSX", "TEN_HSX", "");
        }
        // load hiện trạng mấy
        public void LoadHIEN_TRANG_SD_MAY()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMS_HIEN_TRANG, "GetHIEN_TRANG_SU_DUNG_MAYs", "MS_HIEN_TRANG", "TEN_HIEN_TRANG", "", true, Commons.Modules.TypeLanguage.ToString());
        }
        // load mức ưu tiên
        public void LoadMUC_UU_TIEN()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMUC_UU_TIEN, "GetMUC_UU_TIENs", "MS_UU_TIEN", "TEN_UU_TIEN", "", true);
            try
            {
            }
            catch
            {
            }
        }
        // load dơn vị tính
        public void LoadDON_VI_TINH_RUN_TIME()
        {
            var dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetDON_VI_TINH_RUN_TIMEs"));
            DataRow row = dtTmp.NewRow();
            row["MS_DVT_RT"] = "-99";
            row["TEN_DVT_RT"] = "";
            dtTmp.Rows.InsertAt(row, 0);
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMS_DVT_RT, dtTmp, "MS_DVT_RT", "TEN_DVT_RT", "");
        }
        // load ngoại tệ
        public void LoadNGOAI_TE()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNGOAI_TE, "GetNGOAI_TEs", "NGOAI_TE", "NGOAI_TE", "", true);
        }
        // load đơn vị tính sản lượng
        public void LoadDVTSL()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "Get_DVT_PT", Commons.Modules.TypeLanguage));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbDVTSL, _table, "DVT", "TEN", "");
        }
        // load đơn vị tính thời gian
        public void LoadDVTG()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "SP_NHU_Y_GET_DON_VI_TG", Commons.Modules.TypeLanguage));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbDVTG, _table, "MS_DV_TG", "TEN", "");
        }

        private void ucDMTBi_Load(object sender, EventArgs e)
        {
            LoadLoaiMay2();
            LoadNhomMay();
            LoadNCC();
            LoadNSX();
            LoadHIEN_TRANG_SD_MAY();
            LoadMUC_UU_TIEN();
            LoadDON_VI_TINH_RUN_TIME();
            LoadNGOAI_TE();
            LoadDVTSL();
            LoadDVTG();
        }
        private void cboMS_LOAI_MAY_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
        }
        private void BtnNoilapdat_Click(object sender, EventArgs e)
        {
            if (txtMS_MAY.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenKT6", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // XtraMessageBox.Show("Bạn vui lòng nhập mã số máy ", MsgBoxStyle.Information, "Thông báo")
                return;
            }
            FrmNXHTBPCP NXHTBPCP = new FrmNXHTBPCP();
            NXHTBPCP.MS_MAY = txtMS_MAY.Text;
            NXHTBPCP.ShowDialog();
            TxtMS_NHA_XUONG.Text = NXHTBPCP.sNX;
            TxtMS_HE_THONG.Text = NXHTBPCP.sHT;
            TxtMS_BP_CHIU_PHI.Text = NXHTBPCP.sBPCP;
            if (TxtMS_NHA_XUONG.Text != "")
            {
                txtMS_MAY.Properties.ReadOnly = true;
            }
            else
            {
                txtMS_MAY.Properties.ReadOnly = false;
            }
        }

        private void txtMS_MAY_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LoadView(txtMS_MAY.Text);
        }
        private void LoadView(string sFind)
        {
            try
            {
                XtraForm ctl = new XtraForm();
                Type newType = Type.GetType("VS.OEE.frmView", true, true);
                object o1 = Activator.CreateInstance(newType, 1, sFind, "spThongtinthietbi");
                ctl = o1 as XtraForm;
                ctl.StartPosition = FormStartPosition.CenterParent;
                Commons.Modules.sPS = "mnuThongtinthietbi";
                ctl.Tag = "mnuThongtinthietbi";
                ctl.Text = Commons.Modules.ObjLanguages.GetLanguage("frmThongTinThietBi", "frmThongTinThietBi");
                ctl.Name = "frmThongTinThietBi";
                ctl.WindowState = FormWindowState.Maximized;
                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    txtMS_MAY.Text = Commons.Modules.sId;
                    MS_MAY = txtMS_MAY.Text;
                    LoadData();

                }
            }
            catch { }
        }

        private void LoadData()
        {
            var ds = new DataSet();

            try
            {
                var sqlcom = new SqlCommand();
                var con = new SqlConnection(Commons.IConnections.CNStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sqlcom.Connection = con;
                sqlcom.Parameters.AddWithValue("@MSMay", MS_MAY);
                sqlcom.Parameters.AddWithValue("@iLoai", 1);
                sqlcom.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Commons.Modules.UserName;
                sqlcom.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spThongtinthietbi";
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlcom);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                ShowMAY(dt.Rows[0]);
                if (dt.Rows.Count == 0) return;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            finally
            {

                if (MS_MAY == "-1")
                {//reret text control
                    Refesh();
                }

            }
        }
        public void Refesh()
        {
            txtMS_MAY.Text = "";
            txtSERIAL_NUMBER.Text = "";
            txtTEN_MAY.Text = "";
            txtMO_TA.Text = "";
            txtMODEL.Text = "";
            txtNGAY_SX.Text = "";
            txtNUOC_SX.Text = "";
            txtNHIEM_VU_THIET_BI.Text = "";
            txtNGAY_DUA_VAO_SD.Text = "";
            txtSO_NAM_SD.Text = "";
            TxtMS_BP_CHIU_PHI.Text = "";
            TxtMS_HE_THONG.Text = "";
            TxtMS_NHA_XUONG.Text = "";
            txtNGAY_BD_BAO_HANH.Text = "";
            txtSO_THANG_BH.Text = "";
            txtNgayKTBH.Text = "";
            txtSO_THE.Text = "";
            txtSoCT.Text = "";
            txtNGAY_MUA.Text = "";
            txtGIA_MUA.Text = "";
            txtTiGiaVND.Text = "";
            txtTiGiaUSD.Text = "";
            txtSO_NAM_KHAU_HAO.Text = "";
            txtNgayHHKH.Text = "";
            txtTY_LE_CON_LAI.Text = "";
            txtNgayHCtieptheo.Text = "";
            txtCKHCTB_Ngoai_Ngay_TT.Text = "";
            txtCKKDTB_NGAY_TT.Text = "";
            cboMS_HIEN_TRANG.EditValue = "-1";
            cboMS_NCC.EditValue = "-1";
            CboMS_HSX.EditValue = -1;
            cboMUC_UU_TIEN.EditValue = "-1";
            txtChukyHC.Text = "";
            txtUInsert.Text = "";
            txtUUpdate.Text = "";
            txtNInsert.Text = "";
            txtNUpdate.Text = "";
            pctHINH_ANH.EditValue = null;
            txtMS_MAY.Properties.ReadOnly = false;
        }
        public void ShowMAY(DataRow row)
        {
            if (row is null)
            {
                Refesh();
                txtSO_NAM_KHAU_HAO.EditValue = 0;
                txtSO_THANG_BH.EditValue = 0;
                txtGIA_MUA.EditValue = 0;
                txtTiGiaVND.EditValue = 0;
                txtTiGiaUSD.EditValue = 0;
                txtChukyHC.EditValue = 0;
                txtCKHCTB_Ngoai.EditValue = 0;
                txtCKKDTB.EditValue = 0;
                txtSO_NAM_KHAU_HAO.EditValue = 0;
                txtTY_LE_CON_LAI.EditValue = 100;
                cboMS_NCC.Text = string.Empty;
                //LoadTextTrang();
                this.Cursor = Cursors.Default;
                return;
            }
            // If txtM0.Text = row["MS_MAY"].ToString() Then Exit Sub
            try
            {
                try
                {
                    pctHINH_ANH.EditValue = Commons.Modules.ObjSystems.LoadHinh((byte[])row["HINH_ANH"]);
                }
                catch
                {
                    pctHINH_ANH.EditValue = null;
                }

                txtMS_MAY.Text = row["MS_MAY"].ToString();
                txtTEN_MAY.Text = row["TEN_MAY"].ToString();
                try
                {
                    cboMS_LOAI_MAY.EditValue = row["MS_LOAI_MAY"].ToString();
                    cboMS_NHOM_MAY.EditValue = row["MS_NHOM_MAY"].ToString();
                }
                catch
                {
                }
                if (string.IsNullOrEmpty(row["TEN_HSX"].ToString()))
                    CboMS_HSX.EditValue = -99;
                else
                    CboMS_HSX.EditValue = row["MS_HSX"];

                cboMS_HIEN_TRANG.EditValue = row["MS_HIEN_TRANG"];

                if (string.IsNullOrEmpty(row["TEN_CONG_TY"].ToString()))
                    cboMS_NCC.EditValue = "-99";
                else
                    cboMS_NCC.EditValue = row["MS_KH"].ToString();

                txtSO_NAM_KHAU_HAO.Text = row["SO_NAM_KHAU_HAO"].ToString();
                txtMO_TA.Text = row["MO_TA"].ToString();
                txtNHIEM_VU_THIET_BI.Text = row["NHIEM_VU_THIET_BI"].ToString();
                txtMODEL.Text = row["MODEL"].ToString();
                txtSERIAL_NUMBER.Text = row["SERIAL_NUMBER"].ToString();

                if (row["NGAY_SX"].ToString() != "")
                    txtNGAY_SX.DateTime = Convert.ToDateTime(row["NGAY_SX"].ToString());
                else
                    txtNGAY_SX.Text = "";


                txtNUOC_SX.Text = row["NUOC_SX"].ToString();

                if (row["NGAY_BD_BAO_HANH"].ToString() != "")
                    txtNGAY_BD_BAO_HANH.DateTime = Convert.ToDateTime(row["NGAY_BD_BAO_HANH"].ToString());
                else
                    txtNGAY_BD_BAO_HANH.Text = "";

                if (row["NGAY_DUA_VAO_SD"].ToString() != "")
                    txtNGAY_DUA_VAO_SD.DateTime = Convert.ToDateTime(row["NGAY_DUA_VAO_SD"].ToString());
                else
                    txtNGAY_DUA_VAO_SD.Text = "";


                txtSO_THE.Text = row["SO_THE"].ToString();
                txtSoCT.Text = row["SO_CT"].ToString();
                if (row["TEN_DVT_RT"].ToString() == "")
                    cboMS_DVT_RT.EditValue = -99;
                else
                    cboMS_DVT_RT.EditValue = row["MS_DVT_RT"];

                try
                {
                    txtDinhMucSL.Text = row["DINH_MUC_SL"].ToString();
                    cmbDVTSL.Text = row["DVT_SL"].ToString();
                    cmbDVTG.EditValue = Convert.ToInt32(row["DON_VI_THOI_GIAN"].ToString());
                }
                catch
                {
                    cmbDVTG.EditValue = 0;
                }

                txtTY_LE_CON_LAI.Text = row["TY_LE_CON_LAI"].ToString();
                cboMUC_UU_TIEN.EditValue = row["MUC_UU_TIEN"];
                txtSO_THANG_BH.Text = row["SO_THANG_BH"].ToString();
                txtGIA_MUA.Text = row["GIA_MUA"].ToString();
                txtTiGiaVND.Text = row["TI_GIA_VND"].ToString();
                if (string.IsNullOrEmpty(row["TI_GIA_USD"].ToString()) == false)
                    txtTiGiaUSD.Text = System.Convert.ToDouble(row["TI_GIA_USD"].ToString()).ToString("###,##0.######");
                else
                    txtTiGiaUSD.Text = string.Empty;
                cboNGOAI_TE.Text = row["NGOAI_TE"].ToString();
                txtChukyHC.Text = row["CHU_KY_HC_TB"].ToString();

                DataTable dtRead = new DataTable();
                string SQL = "Select ISNULL(LUU_Y_SU_DUNG, '') LUU_Y_SU_DUNG FROM MAY WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                dtRead.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL));
                txtCKHCTB_Ngoai.Text = row["CHU_KY_HIEU_CHUAN_TB_NGOAI"].ToString();
                txtCKKDTB.Text = row["CHU_KY_KD_TB"].ToString();
                //PtcAnhTB.ImageLocation = row["Anh_TB"].ToString();
                if (string.IsNullOrEmpty(row["USER_INSERT"].ToString()))
                    txtUInsert.Text = "";
                else
                    txtUInsert.Text = row["USER_INSERT"].ToString();
                if (string.IsNullOrEmpty(row["NGAY_INSERT"].ToString()))
                    txtNInsert.Text = "";
                else
                    txtNInsert.Text = row["NGAY_INSERT"].ToString();


                if (string.IsNullOrEmpty(row["USER_UPDATE"].ToString()))
                    txtUUpdate.Text = "";
                else
                    txtUUpdate.Text = row["USER_UPDATE"].ToString();
                if (string.IsNullOrEmpty(row["NGAY_UPDATE"].ToString()))
                    txtNUpdate.Text = "";
                else
                    txtNUpdate.Text = row["NGAY_UPDATE"].ToString();




                if (row["NGAY_MUA"].ToString() != "")
                    txtNGAY_MUA.DateTime = Convert.ToDateTime(row["NGAY_MUA"].ToString());
                else
                    txtNGAY_MUA.Text = "";

                try
                {
                    txtNgayHHKH.Text = txtNGAY_DUA_VAO_SD.DateTime.Date.Day + "/" + txtNGAY_DUA_VAO_SD.DateTime.Date.Month + "/" + (txtNGAY_DUA_VAO_SD.DateTime.Date.Year + Convert.ToInt32(txtSO_NAM_KHAU_HAO.Text == "" ? 0 : txtSO_NAM_KHAU_HAO.EditValue)).ToString();
                }
                catch
                {
                    txtNgayHHKH.Text = "";
                }

                try
                {
                    txtNgayKTBH.Text = txtNGAY_BD_BAO_HANH.DateTime.Date.AddMonths(Convert.ToInt32(txtSO_THANG_BH.EditValue)).ToString();
                }
                catch
                {
                    txtNgayKTBH.Text = "";
                }
                try
                {
                    DateTime ngay;
                    ngay = txtNGAY_DUA_VAO_SD.DateTime.Date;
                    double i = (DateTime.Now - ngay).TotalDays;
                    int k = Convert.ToInt32(i / 365);
                    double j = Convert.ToInt32((i - (365 * k)) / 30);

                    if (j > 0)
                        txtSO_NAM_SD.Text = k + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "Nam_sd", Commons.Modules.TypeLanguage) + " " + j + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "Thang_sd", Commons.Modules.TypeLanguage);
                    else
                        txtSO_NAM_SD.Text = k + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "Nam_sd", Commons.Modules.TypeLanguage);
                }
                catch
                {
                    txtSO_NAM_SD.EditValue = 0;
                }
                TxtMS_NHA_XUONG.Text = row["Ten_N_XUONG"].ToString();
                TxtMS_HE_THONG.Text = row["TEN_HE_THONG"].ToString();
                TxtMS_BP_CHIU_PHI.Text = row["TEN_BP_CHIU_PHI"].ToString();
                if (TxtMS_NHA_XUONG.Text != "")
                {
                    txtMS_MAY.Properties.ReadOnly = true;
                }
                else
                {
                    txtMS_MAY.Properties.ReadOnly = false;
                }
            }
            catch(Exception ex)
            {
            }
            this.Cursor = Cursors.Default;
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if (txtMS_MAY.Text.Trim() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenGhi1", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMS_MAY.Focus();
                return;
            }
            if (MS_MAY != txtMS_MAY.Text)
            {
                DataTable dtReader = new DataTable();
                dtReader.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM MAY WHERE MS_MAY = N'" + txtMS_MAY.Text + "'"));
                if ((dtReader.Rows.Count > 0))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenKT20", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMS_MAY.Focus();
                    return;
                }
            }
            if (txtTEN_MAY.Text.Trim() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "msgChuaNhapTenMay", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTEN_MAY.Focus();
                return;
            }

            if (cboMS_LOAI_MAY.EditValue == null/* TODO Change to default(_) if this is not a reference type */ )
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenGhi2", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMS_LOAI_MAY.Focus();
                return;
            }
            if (cboMS_NHOM_MAY.EditValue == null/* TODO Change to default(_) if this is not a reference type */ )
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMS_NHOM_MAY.Focus();
                return;
            }
            if (txtNGAY_DUA_VAO_SD.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenGhi4", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNGAY_DUA_VAO_SD.Focus();
                return;
            }
            if (cboMS_HIEN_TRANG.EditValue == null/* TODO Change to default(_) if this is not a reference type */ )
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenGhi5", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                cboMS_HIEN_TRANG.Focus();
                return;
            }
            if (cboMUC_UU_TIEN.EditValue == null/* TODO Change to default(_) if this is not a reference type */ )
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenGhi6", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                cboMUC_UU_TIEN.Focus();
                return;
            }
            if (TxtMS_HE_THONG.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "ChuaNhapHeThong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                TxtMS_HE_THONG.Focus();
                return;
            }
            if (cboMS_DVT_RT.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "msgChuaNhapDonViThoiGian", Commons.Modules.TypeLanguage) + " runtime", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMS_DVT_RT.Focus();
                return;
            }

            if (cmbDVTG.EditValue.ToString() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "msgChuaNhapDonViThoiGian", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tab.SelectedTabPageIndex = 1;
                cmbDVTG.Focus();
                return;
            }

            if (TxtMS_NHA_XUONG.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenGhi7", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                TxtMS_NHA_XUONG.Focus();
                return;
            }
            if (TxtMS_HE_THONG.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "ChuaNhapHeThong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtMS_HE_THONG.Focus();
                return;
            }


            if (TxtMS_BP_CHIU_PHI.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenGhi8", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                TxtMS_BP_CHIU_PHI.Focus();
                return;
            }
            try
            {
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spThongtinthietbi", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@MSMay", SqlDbType.NVarChar).Value = MS_MAY;

                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Commons.Modules.UserName;

                cmd.Parameters.Add("@MS_MAY", SqlDbType.NVarChar).Value = txtMS_MAY.Text;
                cmd.Parameters.Add("@TEN_MAY", SqlDbType.NVarChar).Value = txtTEN_MAY.Text;
                cmd.Parameters.Add("@MS_NHOM_MAY", SqlDbType.NVarChar).Value = cboMS_NHOM_MAY.EditValue;
                if(CboMS_HSX.EditValue != null && Convert.ToInt32(CboMS_HSX.EditValue) != -1 && Convert.ToInt32(CboMS_HSX.EditValue) != -99)
                    cmd.Parameters.Add("@MS_HSX", SqlDbType.NVarChar).Value = CboMS_HSX.EditValue;
                cmd.Parameters.Add("@MS_HIEN_TRANG", SqlDbType.NVarChar).Value = cboMS_HIEN_TRANG.EditValue;
                if (cboMS_NCC.EditValue != null && cboMS_NCC.EditValue.ToString() != "-1" && cboMS_NCC.EditValue.ToString() != "-99")
                    cmd.Parameters.Add("@MS_KH", SqlDbType.NVarChar).Value = cboMS_NCC.EditValue;
                cmd.Parameters.Add("@SO_NAM_KHAU_HAO", SqlDbType.Int).Value = txtSO_NAM_KHAU_HAO.Text == "" ? 0 : Convert.ToInt32(txtSO_NAM_KHAU_HAO.Text);
                cmd.Parameters.Add("@MO_TA", SqlDbType.NVarChar).Value = txtMO_TA.Text;
                cmd.Parameters.Add("@NHIEM_VU_THIET_BI", SqlDbType.NVarChar).Value = txtNHIEM_VU_THIET_BI.Text;
                cmd.Parameters.Add("@MODEL", SqlDbType.NVarChar).Value = txtMODEL.Text;


                cmd.Parameters.Add("@SERIAL_NUMBER", SqlDbType.NVarChar).Value = txtSERIAL_NUMBER.Text;
                cmd.Parameters.Add("@NGAY_SX", SqlDbType.DateTime).Value = Convert.ToDateTime((String.IsNullOrEmpty(txtNGAY_SX.Text) ? "1753-01-01 12:00:00.000" : txtNGAY_SX.EditValue));
                cmd.Parameters.Add("@NUOC_SX", SqlDbType.NVarChar).Value = txtNUOC_SX.Text;
                cmd.Parameters.Add("@NGAY_MUA", SqlDbType.DateTime).Value = Convert.ToDateTime((String.IsNullOrEmpty(txtNGAY_MUA.Text) ? "1753-01-01 12:00:00.000" : txtNGAY_MUA.EditValue));
                cmd.Parameters.Add("@NGAY_BD_BAO_HANH", SqlDbType.DateTime).Value = Convert.ToDateTime((String.IsNullOrEmpty(txtNGAY_BD_BAO_HANH.Text) ? "1753-01-01 12:00:00.000" : txtNGAY_BD_BAO_HANH.EditValue));
                cmd.Parameters.Add("@NGAY_DUA_VAO_SD", SqlDbType.DateTime).Value = Convert.ToDateTime((String.IsNullOrEmpty(txtNGAY_DUA_VAO_SD.Text) ? "1753-01-01 12:00:00.000" : txtNGAY_DUA_VAO_SD.EditValue));
                cmd.Parameters.Add("@SO_THE", SqlDbType.NVarChar).Value = txtSO_THE.Text;
                cmd.Parameters.Add("@MS_DVT_RT", SqlDbType.Int).Value = cboMS_DVT_RT.EditValue;


                cmd.Parameters.Add("@TY_LE_CON_LAI", SqlDbType.NVarChar).Value = txtTY_LE_CON_LAI.Text;
                cmd.Parameters.Add("@MUC_UU_TIEN", SqlDbType.SmallInt).Value = cboMUC_UU_TIEN.EditValue;
                cmd.Parameters.Add("@SO_THANG_BH", SqlDbType.SmallInt).Value = txtSO_THANG_BH.Text == "" ? 0 : Convert.ToInt32(txtSO_THANG_BH.Text);
                cmd.Parameters.Add("@GIA_MUA", SqlDbType.Float).Value = txtGIA_MUA.Text == "" ? 0 : Convert.ToInt32(txtGIA_MUA.Text);
                cmd.Parameters.Add("@NGOAI_TE", SqlDbType.NVarChar).Value = cboNGOAI_TE.EditValue;
                cmd.Parameters.Add("@CHU_KY_HC_TB", SqlDbType.Int).Value = txtChukyHC.Text == "" ? 0 : Convert.ToInt32(txtChukyHC.Text);
                cmd.Parameters.Add("@SO_CT", SqlDbType.NVarChar).Value = txtSoCT.Text;
                cmd.Parameters.Add("@TI_GIA_VND", SqlDbType.Float).Value = txtTiGiaVND.Text == "" ? 0 : Convert.ToInt32(txtTiGiaVND.Text);
                cmd.Parameters.Add("@TI_GIA_USD", SqlDbType.Float).Value = txtTiGiaUSD.Text == "" ? 0 : Convert.ToInt32(txtTiGiaUSD.Text);
                cmd.Parameters.Add("@CHU_KY_HC_TB_NGOAI", SqlDbType.Int).Value = txtCKHCTB_Ngoai.Text == "" ? 0 : Convert.ToInt32(txtCKHCTB_Ngoai.Text);
                cmd.Parameters.Add("@CHU_KY_KD_TB", SqlDbType.Int).Value = txtCKKDTB.Text == "" ? 0 : Convert.ToInt32(txtCKKDTB.Text);
                cmd.Parameters.Add("@DON_VI_TG", SqlDbType.Int).Value = cmbDVTG.EditValue;
                cmd.Parameters.Add("@HINH_ANH", SqlDbType.Image).Value = Commons.Modules.ObjSystems.SaveHinh(pctHINH_ANH.Image);
                cmd.CommandType = CommandType.StoredProcedure;



                if (MS_MAY == "-1")
                {
                    MS_MAY = Convert.ToString(cmd.ExecuteScalar());
                    BtnKhongghi_Click(null, null);
                }
                else
                {
                    MS_MAY = Convert.ToString(cmd.ExecuteScalar());
                }
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnKhongghi_Click(object sender, EventArgs e)
        {
            string str = "";
            str = "Delete A from MAY_NHA_XUONG A WHERE NOT EXISTS (SELECT MS_MAY FROM MAY B WHERE  ( A.MS_MAY = B.MS_MAY )) ";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, str);
            str = "Delete A from MAY_HE_THONG A WHERE NOT EXISTS (SELECT MS_MAY FROM MAY B WHERE  ( A.MS_MAY = B.MS_MAY )) ";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, str);
            str = "Delete A from MAY_BO_PHAN_CHIU_PHI A WHERE NOT EXISTS (SELECT MS_MAY FROM MAY B WHERE ( A.MS_MAY = B.MS_MAY )) ";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, str);
            MS_MAY = "-1";
            Refesh();
        }

        private void btnChenhinh_Click(object sender, EventArgs e)
        {
            pctHINH_ANH.LoadImage();
        }

        private void btnXoahinh_Click(object sender, EventArgs e)
        {
            pctHINH_ANH.EditValue = null;
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {

            try
            {



                string SQL = "";
                DialogResult traloi;
                SqlDataReader dtReader;
                if (txtMS_MAY.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenXoa1", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                SQL = "SELECT * FROM CONG_VIEC_HANG_NGAY_THIET_BI WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL);
                while (dtReader.Read())
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenXoa35", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtReader.Close();
                    return;
                }
                dtReader.Close();
                SQL = "SELECT * FROM LICH_TAU_THIET_BI WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL);
                while (dtReader.Read())
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtReader.Close();
                    return;
                }
                dtReader.Close();
                SQL = "SELECT * FROM THOI_GIAN_CHAY_MAY WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL);
                while (dtReader.Read())
                {
                    // Thiết bị này đang được sử dụng trong thời gian chạy máy ! bạn không thể xóa !
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenXoa4", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtReader.Close();
                    return;
                }
                dtReader.Close();
                // 
                SQL = "SELECT * FROM PHIEU_BAO_TRI WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL);
                while (dtReader.Read())
                {
                    // Thiết bị này đang được sử dụng trong phiếu bảo trì ! Bạn không thể xóa !
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenXoa23", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtReader.Close();
                    return;
                }
                dtReader.Close();

                SQL = "SELECT * FROM KE_HOACH_TONG_THE WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL);
                while (dtReader.Read())
                {
                    // Thiết bị này đang được sử dụng trong kế hoạch tổng thể ! Bạn không thể xóa !
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenXoa24", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtReader.Close();
                    return;
                }
                dtReader.Close();

                SQL = "SELECT * FROM THONG_SO_CHINH_MAY WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL);
                while (dtReader.Read())
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenXoa26", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    // dữ liệu đang được sử dụng o table THONG_SO_CHINH_MAY
                    dtReader.Close();
                    return;
                }
                dtReader.Close();

                SQL = "SELECT * FROM MAY_PHAN_BO_ATT WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL);
                while (dtReader.Read())
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenXoa29", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    // dữ liệu đang được sử dụng o table MAY_LOAI_BTPN_CONG_VIEC
                    dtReader.Close();
                    return;
                }
                dtReader.Close();
                SQL = "SELECT * FROM MAY_ATTACHMENT WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL);
                while (dtReader.Read())
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenXoa30", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    // dữ liệu đang được sử dụng o table MAY_LOAI_BTPN_CONG_VIEC_PHU_TUNG
                    dtReader.Close();
                    return;
                }
                dtReader.Close();
                SQL = "SELECT * FROM TRUC_CA_CHI_TIET WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL);
                while (dtReader.Read())
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenXoa31", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    // dữ liệu đang được sử dụng o table TRUC_CA_CHI_TIET
                    dtReader.Close();
                    return;
                }
                dtReader.Close();
                SQL = "SELECT * FROM YEU_CAU_NSD_CHI_TIET WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL);
                while (dtReader.Read())
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenXoa45", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    // Dữ liệu đang được sử dụng trong yêu cầu người sử dụng ! Bạn không thể xoá !
                    dtReader.Close();
                    return;
                }
                dtReader.Close();

                SQL = "SELECT * FROM HIEU_CHUAN_MAY WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL);
                while (dtReader.Read())
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenXoa47", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    // Dữ liệu đang được sử dụng trong hiệu chuẩn thiết bị ! Bạn không thể xoá !
                    dtReader.Close();
                    return;
                }
                dtReader.Close();

                SQL = "SELECT * FROM THOI_GIAN_NGUNG_MAY WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL);
                while (dtReader.Read())
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenXoa047", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    // Dữ liệu đang được sử dụng trong Downtime ! Bạn không thể xoá !
                    dtReader.Close();
                    return;
                }
                dtReader.Close();

                traloi = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "MsgQuyenXoa5", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.No)
                    return;
                SQL = "DELETE FROM MAY_NHA_XUONG WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, SQL);
                SQL = "DELETE FROM MAY_HE_THONG WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, SQL);
                SQL = "DELETE FROM MAY_BO_PHAN_CHIU_PHI WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, SQL);
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "UpdateMAY_LOG", txtMS_MAY.Text, sForm, Commons.Modules.UserName, 3);
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "DeleteMAY", MS_MAY);
                MS_MAY = "-1";
                Refesh();
            }
            catch
            {
            }
        }

        private void txtNGAY_DUA_VAO_SD_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime ngay;
                ngay = txtNGAY_DUA_VAO_SD.DateTime.Date;
                double i = (DateTime.Now - ngay).TotalDays;
                int k = Convert.ToInt32(i / 365);
                double j = Convert.ToInt32((i - (365 * k)) / 30);

                if (j > 0)
                    txtSO_NAM_SD.Text = k + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "Nam_sd", Commons.Modules.TypeLanguage) + " " + j + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "Thang_sd", Commons.Modules.TypeLanguage);
                else
                    txtSO_NAM_SD.Text = k + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, "Nam_sd", Commons.Modules.TypeLanguage);
            }
            catch
            {
                txtSO_NAM_SD.EditValue = 0;
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
