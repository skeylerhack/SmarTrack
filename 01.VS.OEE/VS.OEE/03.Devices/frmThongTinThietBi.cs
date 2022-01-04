using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Reflection;
using Commons;

namespace VS.OEE
{
    public partial class frmThongTinThietBi : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ;
        string sMS_MAY = "-1";
        string sForm = "frmThongTinThietBi";
        public frmThongTinThietBi(int PQ)
        {
            iPQ = PQ;
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

        private void frmThongTinThietBi_Load(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            Commons.Modules.ObjSystems.MLoadTreeLookUpEdit(treHeThong, Commons.Modules.ObjSystems.DataHeThongTree(true), "MS_HE_THONG", "TEN_HE_THONG", "MS_CHA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_HE_THONG"));
            Commons.Modules.ObjSystems.MLoadTreeLookUpEdit(treDiaDiem, Commons.Modules.ObjSystems.DataNhaXuongTree(true), "MS_N_XUONG", "TEN_N_XUONG", "MS_CHA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "Ten_N_XUONG"));
            treDiaDiem.EditValue = "-1";
            treHeThong.EditValue = -1;
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiMay, Commons.Modules.ObjSystems.DataLoaiMay(true), "MS_LOAI_MAY", "TEN_LOAI_MAY", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_LOAI_MAY"));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomMay, Commons.Modules.ObjSystems.DataNhomMay(true, cboLoaiMay.EditValue.ToString()), "MS_NHOM_MAY", "TEN_NHOM_MAY", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_NHOM_MAY"));
            LoadLoaiMay2();
            LoadNCC();
            LoadNSX();
            LoadHIEN_TRANG_SD_MAY();
            LoadMUC_UU_TIEN();
            LoadDON_VI_TINH_RUN_TIME();
            LoadNGOAI_TE();
            LoadDVTSL();
            LoadDVTG();
            Commons.Modules.sId = "";
            LoadMay("-1");
            VisibleButon(true);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            if (iPQ != 1)
            {
                this.btnThem.Visible = false;
                this.btnSua.Visible = false;
                this.btnXoa.Visible = false;
                this.btnGhi.Visible = false;
            }
            else
            {
                VisibleButon(true);
            }
        }

        public void InitMayHeThongBPCPNhaXuongTmp(string sMS_MAY)
        {
            DataTable dtReader = new DataTable();
            TxtMS_HE_THONG.Text = "";
            string SQL = "SELECT TEN_HE_THONG FROM HE_THONG INNER JOIN MAY_HE_THONG ON " + "HE_THONG.MS_HE_THONG = MAY_HE_THONG.MS_HE_THONG WHERE MS_MAY=N'" + sMS_MAY + "' AND " + "NGAY_NHAP=(SELECT MAX(NGAY_NHAP) AS NGAY_MAX FROM MAY_HE_THONG WHERE MS_MAY=N'" + sMS_MAY + "')";
            dtReader.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL));
            TxtMS_HE_THONG.Text = dtReader.Rows[0]["TEN_HE_THONG"].ToString();
            SQL = "SELECT TEN_N_XUONG + CASE WHEN GHI_CHU IS NULL OR GHI_CHU = '' THEN '' ELSE '(' + GHI_CHU + ')' END AS TEN_N_XUONG,NHA_XUONG.MS_N_XUONG FROM NHA_XUONG INNER JOIN MAY_NHA_XUONG ON " + "NHA_XUONG.MS_N_XUONG = MAY_NHA_XUONG.MS_N_XUONG WHERE MS_MAY=N'" + sMS_MAY + "' AND " + "NGAY_NHAP=(SELECT MAX(NGAY_NHAP) AS NGAY_MAX FROM MAY_NHA_XUONG WHERE MS_MAY=N'" + sMS_MAY + "')";
            dtReader = new DataTable();
            dtReader.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL));
            TxtMS_NHA_XUONG.Text = "";
            TxtMS_NHA_XUONG.Text = dtReader.Rows[0]["TEN_N_XUONG"].ToString();
            SQL = "SELECT TEN_BP_CHIU_PHI FROM BO_PHAN_CHIU_PHI INNER JOIN MAY_BO_PHAN_CHIU_PHI ON " + "BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI = MAY_BO_PHAN_CHIU_PHI.MS_BP_CHIU_PHI WHERE MS_MAY=N'" + sMS_MAY + "' AND " + "NGAY_NHAP=(SELECT MAX(NGAY_NHAP) AS NGAY_MAX FROM MAY_BO_PHAN_CHIU_PHI WHERE MS_MAY=N'" + sMS_MAY + "')";
            dtReader = new DataTable();
            dtReader.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL));
            TxtMS_BP_CHIU_PHI.Text = dtReader.Rows[0]["TEN_BP_CHIU_PHI"].ToString();
        }

        private void VisibleButon(bool flag)
        {
            btnThoat.Visible = flag;
            btnThem.Visible = flag;
            btnXoa.Visible = flag;
            btnSua.Visible = flag;
            btnGhi.Visible = !flag;
            btnKhong.Visible = !flag;

            treDiaDiem.Properties.ReadOnly = !flag;
            treHeThong.Properties.ReadOnly = !flag;
            cboLoaiMay.Properties.ReadOnly = !flag;
            cboNhomMay.Properties.ReadOnly = !flag;
            
            //ReadonlyControl(flag);
            grdMay.Enabled = flag;
        }
        private void BingdingControl(bool them)
        {
            if (them == true)
            {
                Refesh();
            }
            else
            {
                try
                {
                    txtMS_MAY.Text = grvMay.GetFocusedRowCellValue("MS_MAY").ToString();
                    sMS_MAY = txtMS_MAY.Text.Trim();
                    try
                    {
                        DataTable tbHinh = new DataTable();
                        tbHinh.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT HINH_ANH FROM dbo.MAY WHERE MS_MAY = '" + txtMS_MAY.EditValue + "'"));
                        pctHINH_ANH.EditValue = Commons.Modules.ObjSystems.LoadHinh((byte[])tbHinh.Rows[0]["HINH_ANH"]);
                    }
                    catch
                    {
                        pctHINH_ANH.EditValue = null;
                    }


                    txtTEN_MAY.Text = grvMay.GetFocusedRowCellValue("TEN_MAY").ToString();
                    try
                    {
                        cboMS_LOAI_MAY.EditValue = grvMay.GetFocusedRowCellValue("MS_LOAI_MAY").ToString();
                        cboMS_NHOM_MAY.EditValue = grvMay.GetFocusedRowCellValue("MS_NHOM_MAY").ToString();
                    }
                    catch
                    {
                    }
                    if (string.IsNullOrEmpty(grvMay.GetFocusedRowCellValue("TEN_HSX").ToString()))
                        CboMS_HSX.EditValue = -99;
                    else
                        CboMS_HSX.EditValue = grvMay.GetFocusedRowCellValue("MS_HSX");

                    cboMS_HIEN_TRANG.EditValue = grvMay.GetFocusedRowCellValue("MS_HIEN_TRANG");

                    if (Commons.Modules.ObjSystems.IsnullorEmpty(grvMay.GetFocusedRowCellValue("MS_KH")))
                        cboMS_NCC.EditValue = "-99";
                    else
                        cboMS_NCC.EditValue = grvMay.GetFocusedRowCellValue("MS_KH").ToString();

                    txtSO_NAM_KHAU_HAO.Text = grvMay.GetFocusedRowCellValue("SO_NAM_KHAU_HAO").ToString();
                    txtMO_TA.Text = grvMay.GetFocusedRowCellValue("MO_TA").ToString();
                    txtNHIEM_VU_THIET_BI.Text = grvMay.GetFocusedRowCellValue("NHIEM_VU_THIET_BI").ToString();
                    txtMODEL.Text = grvMay.GetFocusedRowCellValue("MODEL").ToString();
                    txtSERIAL_NUMBER.Text = grvMay.GetFocusedRowCellValue("SERIAL_NUMBER").ToString();

                    if (grvMay.GetFocusedRowCellValue("NGAY_SX").ToString() != "")
                        txtNGAY_SX.DateTime = Convert.ToDateTime(grvMay.GetFocusedRowCellValue("NGAY_SX").ToString());
                    else
                        txtNGAY_SX.Text = "";


                    txtNUOC_SX.Text = grvMay.GetFocusedRowCellValue("NUOC_SX").ToString();

                    if (grvMay.GetFocusedRowCellValue("NGAY_BD_BAO_HANH").ToString() != "")
                        txtNGAY_BD_BAO_HANH.DateTime = Convert.ToDateTime(grvMay.GetFocusedRowCellValue("NGAY_BD_BAO_HANH").ToString());
                    else
                        txtNGAY_BD_BAO_HANH.Text = "";

                    if (grvMay.GetFocusedRowCellValue("NGAY_DUA_VAO_SD").ToString() != "")
                        txtNGAY_DUA_VAO_SD.DateTime = Convert.ToDateTime(grvMay.GetFocusedRowCellValue("NGAY_DUA_VAO_SD").ToString());
                    else
                        txtNGAY_DUA_VAO_SD.Text = "";


                    txtSO_THE.Text = grvMay.GetFocusedRowCellValue("SO_THE").ToString();
                    txtSoCT.Text = grvMay.GetFocusedRowCellValue("SO_CT").ToString();
                    if (grvMay.GetFocusedRowCellValue("TEN_DVT_RT").ToString() == "")
                        cboMS_DVT_RT.EditValue = -99;
                    else
                        cboMS_DVT_RT.EditValue = grvMay.GetFocusedRowCellValue("MS_DVT_RT");

                    try
                    {
                        txtDinhMucSL.Text = grvMay.GetFocusedRowCellValue("DINH_MUC_SL").ToString();
                        cmbDVTSL.Text = grvMay.GetFocusedRowCellValue("DVT_SL").ToString();
                        cmbDVTG.EditValue = Convert.ToInt32(grvMay.GetFocusedRowCellValue("DON_VI_THOI_GIAN").ToString());
                    }
                    catch
                    {
                        cmbDVTG.EditValue = 0;
                    }

                    txtTY_LE_CON_LAI.Text = grvMay.GetFocusedRowCellValue("TY_LE_CON_LAI").ToString();
                    cboMUC_UU_TIEN.EditValue = grvMay.GetFocusedRowCellValue("MUC_UU_TIEN");
                    txtSO_THANG_BH.Text = grvMay.GetFocusedRowCellValue("SO_THANG_BH").ToString();
                    txtGIA_MUA.Text = grvMay.GetFocusedRowCellValue("GIA_MUA").ToString();
                    txtTiGiaVND.Text = grvMay.GetFocusedRowCellValue("TI_GIA_VND").ToString();
                    if (string.IsNullOrEmpty(grvMay.GetFocusedRowCellValue("TI_GIA_USD").ToString()) == false)
                        txtTiGiaUSD.Text = System.Convert.ToDouble(grvMay.GetFocusedRowCellValue("TI_GIA_USD").ToString()).ToString("###,##0.######");
                    else
                        txtTiGiaUSD.Text = string.Empty;
                    cboNGOAI_TE.Text = grvMay.GetFocusedRowCellValue("NGOAI_TE").ToString();
                    txtChukyHC.Text = grvMay.GetFocusedRowCellValue("CHU_KY_HC_TB").ToString();

                    DataTable dtRead = new DataTable();
                    string SQL = "Select ISNULL(LUU_Y_SU_DUNG, '') LUU_Y_SU_DUNG FROM MAY WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                    dtRead.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, SQL));
                    txtCKHCTB_Ngoai.Text = grvMay.GetFocusedRowCellValue("CHU_KY_HIEU_CHUAN_TB_NGOAI").ToString();
                    txtCKKDTB.Text = grvMay.GetFocusedRowCellValue("CHU_KY_KD_TB").ToString();
                    //PtcAnhTB.ImageLocation = grvMay.GetFocusedRowCellValue("Anh_TB").ToString();
                    if (string.IsNullOrEmpty(grvMay.GetFocusedRowCellValue("USER_INSERT").ToString()))
                        txtUInsert.Text = "";
                    else
                        txtUInsert.Text = grvMay.GetFocusedRowCellValue("USER_INSERT").ToString();
                    if (string.IsNullOrEmpty(grvMay.GetFocusedRowCellValue("NGAY_INSERT").ToString()))
                        txtNInsert.Text = "";
                    else
                        txtNInsert.Text = grvMay.GetFocusedRowCellValue("NGAY_INSERT").ToString();


                    if (string.IsNullOrEmpty(grvMay.GetFocusedRowCellValue("USER_UPDATE").ToString()))
                        txtUUpdate.Text = "";
                    else
                        txtUUpdate.Text = grvMay.GetFocusedRowCellValue("USER_UPDATE").ToString();
                    if (string.IsNullOrEmpty(grvMay.GetFocusedRowCellValue("NGAY_UPDATE").ToString()))
                        txtNUpdate.Text = "";
                    else
                        txtNUpdate.Text = grvMay.GetFocusedRowCellValue("NGAY_UPDATE").ToString();




                    if (grvMay.GetFocusedRowCellValue("NGAY_MUA").ToString() != "")
                        txtNGAY_MUA.DateTime = Convert.ToDateTime(grvMay.GetFocusedRowCellValue("NGAY_MUA").ToString());
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
                    InitMayHeThongBPCPNhaXuongTmp(sMS_MAY);
                    //TxtMS_NHA_XUONG.Text = grvMay.GetFocusedRowCellValue("Ten_N_XUONG").ToString();
                    //TxtMS_HE_THONG.Text = grvMay.GetFocusedRowCellValue("TEN_HE_THONG").ToString();
                    //TxtMS_BP_CHIU_PHI.Text = grvMay.GetFocusedRowCellValue("TEN_BP_CHIU_PHI").ToString();
                    if (TxtMS_NHA_XUONG.Text != "")
                    {
                        txtMS_MAY.Properties.ReadOnly = true;
                    }
                    else
                    {
                        txtMS_MAY.Properties.ReadOnly = false;
                    }
                }
                catch (Exception ex)
                {
                }

            }
        }
        private void ReadonlyControl(bool flag)
        {
            GrpThongtinchung.Enabled = !flag;
            grpThongtinKT.Enabled = !flag;
            GrpAnhthietbi.Enabled = !flag;
            GrpTTHC.Enabled = !flag;
            grpThongtinSDTB.Enabled = !flag;
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
        public void LocDuLieu()
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = (DataTable)grdMay.DataSource;
                if ((optHienTrang.SelectedIndex == 0))
                    dtTmp.DefaultView.RowFilter = "MS_HIEN_TRANG = 2 AND MS_HT IS NOT NULL";
                else if ((optHienTrang.SelectedIndex == 1))
                    dtTmp.DefaultView.RowFilter = "MS_HIEN_TRANG <> 2 AND MS_HT IS NOT NULL";
                else
                    dtTmp.DefaultView.RowFilter = "MS_HT IS NULL";
                dtTmp = dtTmp.DefaultView.ToTable();
            }
            catch (Exception ex)
            {
                dtTmp.DefaultView.RowFilter = "";
                dtTmp = dtTmp.DefaultView.ToTable();
            }
            this.Cursor = Cursors.Default;
        }

        public void LoadMay(string sMsMay)
        {
            if (Commons.Modules.sId == "0load")
                return;
            this.Cursor = Cursors.WaitCursor;
            Refesh();

            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spThongtinthietbi_GET", Commons.Modules.UserName, treDiaDiem.EditValue, treHeThong.EditValue, cboLoaiMay.EditValue, cboNhomMay.EditValue, "-1", Commons.Modules.TypeLanguage + 3));
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["MS_MAY"] };
                if (grdMay.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, false, false, false, true, this.Name);
                    grvMay.Columns["MS_MAY"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvMay.Columns["TEN_MAY"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                }
                else
                {
                    grdMay.DataSource = dtTmp;
                }
                if (sMsMay != "-1")
                {
                    int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(sMsMay));
                    grvMay.FocusedRowHandle = grvMay.GetRowHandle(index);
                }
                else { }
            }
            catch (Exception ex)
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
            if (sMS_MAY != txtMS_MAY.Text)
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
                cmd.Parameters.Add("@MSMay", SqlDbType.NVarChar).Value = sMS_MAY;

                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Commons.Modules.UserName;

                cmd.Parameters.Add("@MS_MAY", SqlDbType.NVarChar).Value = txtMS_MAY.Text;
                cmd.Parameters.Add("@TEN_MAY", SqlDbType.NVarChar).Value = txtTEN_MAY.Text;
                cmd.Parameters.Add("@MS_NHOM_MAY", SqlDbType.NVarChar).Value = cboMS_NHOM_MAY.EditValue;
                if (CboMS_HSX.EditValue != null && Convert.ToInt32(CboMS_HSX.EditValue) != -1 && Convert.ToInt32(CboMS_HSX.EditValue) != -99)
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
                sMS_MAY = Convert.ToString(cmd.ExecuteScalar());
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                Commons.Modules.msgChung(Commons.ThongBao.msgCapNhatThanhCong);
                LoadMay(sMS_MAY);
                VisibleButon(true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnKhongghi_Click(object sender, EventArgs e)
        {
            VisibleButon(true);
            BingdingControl(false);
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
                sMS_MAY = grvMay.GetFocusedRowCellValue("MS_MAY").ToString();
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
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, lblTEN_MAY.Text) == DialogResult.No) return;
                SQL = "DELETE FROM MAY_NHA_XUONG WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, SQL);
                SQL = "DELETE FROM MAY_HE_THONG WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, SQL);
                SQL = "DELETE FROM MAY_BO_PHAN_CHIU_PHI WHERE MS_MAY=N'" + txtMS_MAY.Text + "'";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, SQL);
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "UpdateMAY_LOG", txtMS_MAY.Text, sForm, Commons.Modules.UserName, 3);
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "DeleteMAY", sMS_MAY);
                grvMay.DeleteSelectedRows();
                sMS_MAY = "-1";
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
            this.Close();
        }

        private void optHienTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void cboNhomMay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadMay("-1");
        }

        private void cboLoaiMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
            cboNhomMay_EditValueChanged(null, null);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            VisibleButon(false);
            sMS_MAY = "-1";
            BingdingControl(true);
            txtMS_MAY.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvMay.GetFocusedRowCellValue("MS_MAY") == null || grvMay.GetFocusedRowCellValue("MS_MAY").ToString() == "")
            {
                Modules.msgThayThe(ThongBao.msgBanChuaChonDuLieu, LblMathietbi.Text);
                return;
            }
            VisibleButon(false);
            sMS_MAY = grvMay.GetFocusedRowCellValue("MS_MAY").ToString();
        }

        private void grvMay_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BingdingControl(false);
        }
    }
}
