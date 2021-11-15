using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace VS.OEE
{
    public partial class frmQuanlynhanvien : XtraForm
    {
        static int iPQ = 1;  // == 1  full; <> 1 la read only
        private string iMS_CONG_NHAN = "-1";
        private DataTable dt_CONG_NHAN;
        private DataTable dt_TIM_MS_TO;
        private DataTable dt_MS_TO;
        private DataTable dt_MS_TO1;
        IEnumerable<Control> allControls;
        string sForm = "frmThongTinThietBi";

        public frmQuanlynhanvien(int PQ)
        {
            InitializeComponent();

            if (iPQ != 1)
            {
                btnXoa.Visible = false;
                btnGhi.Visible = false;
                btnKhongGhi.Visible = false;
            }
            else
            {
                btnXoa.Visible = true;
                btnGhi.Visible = true;
                btnKhongGhi.Visible = true;
            }

            var typeToBeSelected = new List<Type>
            {

                typeof(DevExpress.XtraEditors.TextEdit)
                , typeof(DevExpress.XtraEditors.MemoEdit)
                , typeof(DevExpress.XtraEditors.ButtonEdit)
            };
            allControls = GetAll(tableChung, typeToBeSelected);
        }

        private IEnumerable<Control> GetAll(Control control, IEnumerable<Type> filteringTypes)
        {
            var ctrls = control.Controls.Cast<Control>();

            return ctrls.SelectMany(ctrl => GetAll(ctrl, filteringTypes))
                        .Concat(ctrls)
                        .Where(ctl => filteringTypes.Any(t => ctl.GetType() == t));
        }

        private void frmQuanlynhanvien_Load(object sender, EventArgs e)
        {
            Commons.Modules.sPS = "0Load";
            LoadCbo_LyLich();
            LoadData("-1");
            Commons.Modules.sPS = "";
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            
        }

        #region Event
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(sForm, "msgXoa"), sForm, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spQuanLyNhanVien", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 2;
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iMS_CONG_NHAN;
                cmd.CommandType = CommandType.StoredProcedure;

                if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(sForm, "msgXoa_ThanhCong"));
                    iMS_CONG_NHAN = "-1";
                    LoadData(iMS_CONG_NHAN);
                }
                else
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(sForm, "msgXoa_DangSuDung"));
                }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                if (!KiemTrung()) return;
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spQuanLyNhanVien", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Commons.Modules.UserName;
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iMS_CONG_NHAN;
                cmd.Parameters.Add("@MS_CONG_NHAN", SqlDbType.NVarChar).Value = txtMS_CONG_NHAN.Text;
                cmd.Parameters.Add("@HO", SqlDbType.NVarChar).Value = txtHO.Text;
                cmd.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = txtTEN.Text;
                cmd.Parameters.Add("@NGAY_SINH", SqlDbType.DateTime).Value = dedNGAY_SINH.EditValue;
                cmd.Parameters.Add("@NOI_SINH", SqlDbType.NVarChar).Value = txtNOI_SINH.Text;
                cmd.Parameters.Add("@PHAI", SqlDbType.Bit).Value = chkPHAI.EditValue;
                cmd.Parameters.Add("@DIA_CHI_THUONG_TRU", SqlDbType.NVarChar).Value = txtDIA_CHI_THUONG_TRU.Text;
                cmd.Parameters.Add("@SO_CMND", SqlDbType.NVarChar).Value = txtSO_CMND.Text;
                cmd.Parameters.Add("@NGAY_CAP", SqlDbType.DateTime).Value = dedNGAY_CAP.EditValue;
                cmd.Parameters.Add("@NOI_CAP", SqlDbType.NVarChar).Value = txtNOI_CAP.Text;
                cmd.Parameters.Add("@MS_TO", SqlDbType.Int).Value = cboMS_TO1.EditValue;
                cmd.Parameters.Add("@NGAY_VAO_LAM", SqlDbType.DateTime).Value = dedNGAY_VAO_LAM.EditValue;
                cmd.Parameters.Add("@BO_VIEC", SqlDbType.Bit).Value = chkBO_VIEC.EditValue;
                cmd.Parameters.Add("@NGAY_NGHI_VIEC", SqlDbType.DateTime).Value = dedNGAY_NGHI_VIEC.EditValue;
                cmd.Parameters.Add("@LY_DO_NGHI", SqlDbType.NVarChar).Value = txtLY_DO_NGHI.Text;
                cmd.Parameters.Add("@MS_TRINH_DO", SqlDbType.SmallInt).Value = cboMS_TRINH_DO.EditValue == "" ?null :  cboMS_TRINH_DO.EditValue;
                cmd.Parameters.Add("@NGOAI_NGU", SqlDbType.NVarChar).Value = txtNGOAI_NGU.Text;
                cmd.Parameters.Add("@HINH_CN", SqlDbType.NVarChar).Value = txtHINH_CN.Text;
                cmd.Parameters.Add("@MS_THE_CC", SqlDbType.NVarChar).Value = txtMS_THE_CC.Text;
                cmd.Parameters.Add("@SO_DT_NHA_RIENG", SqlDbType.NVarChar).Value = txtSO_DT_NHA_RIENG.Text;
                cmd.Parameters.Add("@SO_DTDD", SqlDbType.NVarChar).Value = txtSO_DTDD.Text;
                cmd.Parameters.Add("@TEN_NGUOI_THAN", SqlDbType.NVarChar).Value = txtTEN_NGUOI_THAN.Text;
                cmd.Parameters.Add("@QUAN_HE", SqlDbType.NVarChar).Value = txtQUAN_HE.Text;
                cmd.Parameters.Add("@BANG_CAP", SqlDbType.NVarChar).Value = txtBANG_CAP.Text;
                cmd.Parameters.Add("@USER_MAIL", SqlDbType.NVarChar).Value = txtUSER_MAIL.Text;
                cmd.Parameters.Add("@TEN_CHUC_VU", SqlDbType.NVarChar).Value = txtTEN_CHUC_VU.Text;
                cmd.CommandType = CommandType.StoredProcedure;

                //if (txtHINH_CN.Text.Trim() != "")
                //{
                //    clsCONG_NHANController objCONG_NHANController = new clsCONG_NHANController();

                //    string strDuongDan = @"";
                //    strDuongDan = Commons.Modules.ObjSystems.CapnhatTL(false, MS_CN_Temp);
                //    string str = "";
                //    str = strDuongDan + "\\" + "NV_" + MS_CN_Temp.Replace("/", "_") + "_" + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + Commons.Modules.ObjSystems.LayDuoiFile(txtHINH_CN.Text.Trim());

                //    Commons.Modules.ObjSystems.LuuDuongDan(txtHINH_CN.Text.Trim(), str);
                //    txtHINH_CN.Text = str;
                //    objCONG_NHANController.UpdateHinhCONG_NHAN(MS_CN_Temp, str);
                //}

                string MS_CONG_NHAN = cmd.ExecuteScalar().ToString();

                if (MS_CONG_NHAN != "-1")
                {
                    iMS_CONG_NHAN = MS_CONG_NHAN;
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(sForm, "msgGhi_ThanhCong"));
                    LoadCbo_LyLich();
                    LoadData(iMS_CONG_NHAN);
                }
                else
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(sForm, "msgGhi_ThatBai"));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(sForm, "msgGhi_ThatBai"));
            }
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            iMS_CONG_NHAN = "-1";
            LoadData(iMS_CONG_NHAN);
            StatusControl();
        }


        private void cboMS_DON_VI_EditValueChanged(object sender, EventArgs e)
        {
            if (cboMS_DON_VI.EditValue != null)
            {
                DataTable dt = new DataTable();
                dt = dt_MS_TO.Select("MS_DON_VI IN ('-99','" + cboMS_DON_VI.EditValue.ToString() + "')").CopyToDataTable().Copy();
                cboMS_TO.Properties.DataSource = dt;
                cboMS_TO.EditValue = -99;
            }
        }

        private void cboMS_TO_EditValueChanged(object sender, EventArgs e)
        {
            if (cboMS_TO.EditValue != null)
            {
                DataTable dt = new DataTable();
                dt = dt_MS_TO1.Select("MS_TO IN (-99," + cboMS_TO.EditValue + ")").CopyToDataTable().Copy();
                cboMS_TO1.Properties.DataSource = dt;
            }
        }

        private void txtHINH_CN_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (btnGhi.Visible)
            {
                OpenFileDialog ofdHinh = new OpenFileDialog();
                ofdHinh.ShowDialog();
                if (ofdHinh.FileName == "")
                {
                    txtHINH_CN.Text = "";
                    return;
                }
                else
                    txtHINH_CN.Text = ofdHinh.FileName;
            }
        }

        private void cboMS_DON_VI_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                frmView frm = new frmView(iPQ, "-1", "spDonViPhongBanTo");
                frm.Tag = "mnuDonVi";
                frm.Text = "frmDonVi";
                frm.Name = "frmDonVi";
                frm.ShowDialog();
                LoadCbo_LyLich();
            }
        }

        private void cboMS_TO_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                frmView frm = new frmView(1, "-1", "spDonViPhongBanTo");
                frm.Tag = "mnuToPhongBan";
                frm.Text = "frmToPhongBan";
                frm.Name = "frmToPhongBan";
                frm.ShowDialog();
                LoadCbo_LyLich();
            }
        }

        private void cboMS_TO1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                frmView frm = new frmView(1, "-1", "spDonViPhongBanTo");
                frm.Tag = "mnuTo";
                frm.Text = "frmTo";
                frm.Name = "frmTo";
                frm.ShowDialog();
                LoadCbo_LyLich();
            }
        }
        #endregion

        #region Function

        public void LoadNN()
        {

        }

        private void LoadData(string MS_CONG_NHAN)
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spQuanLyNhanVien", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = MS_CONG_NHAN;
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //LOAD GRIDVIEW
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();

                LoadText(dt);

                StatusControl();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void LoadText(DataTable dt)
        {
            try
            {
                dedNGAY_SINH.EditValue = string.IsNullOrEmpty(dt.Rows[0]["NGAY_SINH"].ToString()) ? null : dt.Rows[0]["NGAY_SINH"];
                dedNGAY_CAP.EditValue = string.IsNullOrEmpty(dt.Rows[0]["NGAY_CAP"].ToString()) ? null : dt.Rows[0]["NGAY_CAP"];
                dedNGAY_VAO_LAM.EditValue = string.IsNullOrEmpty(dt.Rows[0]["NGAY_VAO_LAM"].ToString()) ? null : dt.Rows[0]["NGAY_VAO_LAM"];
                dedNGAY_NGHI_VIEC.EditValue = string.IsNullOrEmpty(dt.Rows[0]["NGAY_NGHI_VIEC"].ToString()) ? null : dt.Rows[0]["NGAY_NGHI_VIEC"];
                cboMS_DON_VI.EditValue = dt.Rows[0]["MS_DON_VI"];
                cboMS_TO.EditValue = dt.Rows[0]["MS_TO"];
                cboMS_TO1.EditValue = dt.Rows[0]["MS_TO1"];
                cboMS_TRINH_DO.EditValue = dt.Rows[0]["MS_TRINH_DO"];
                chkPHAI.EditValue = string.IsNullOrEmpty(dt.Rows[0]["PHAI"].ToString()) ? false : dt.Rows[0]["PHAI"];
                chkBO_VIEC.EditValue = string.IsNullOrEmpty(dt.Rows[0]["BO_VIEC"].ToString()) ? false : dt.Rows[0]["BO_VIEC"];

                foreach (var ctrl in allControls)
                {
                    try
                    {
                        if (ctrl.Name != "")
                        {
                            ctrl.Text = string.IsNullOrEmpty(dt.Rows[0][ctrl.Name.Substring(3)].ToString()) ? "" : dt.Rows[0][ctrl.Name.Substring(3)].ToString();
                        }
                    }
                    catch
                    {
                        if (ctrl.Name != "")
                        {
                            ctrl.Text = "";
                        }
                    }
                }
            }
            catch
            {
                LoadTextTrong();
            }
        }
        private void LoadTextTrong()
        {
            dedNGAY_SINH.EditValue = null;
            dedNGAY_CAP.EditValue = null;
            dedNGAY_VAO_LAM.EditValue = null;
            dedNGAY_NGHI_VIEC.EditValue = null;
            cboMS_DON_VI.EditValue = null;
            cboMS_TO.EditValue = null;
            cboMS_TO1.EditValue = null;
            cboMS_TRINH_DO.EditValue = null;
            chkPHAI.EditValue = false;
            chkBO_VIEC.EditValue = false;

            foreach (var ctrl in allControls)
            {
                try
                {
                    if (ctrl.Name != "")
                    {
                        ctrl.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void LoadCbo_LyLich()
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spQuanLyNhanVien", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 5;
                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //LOAD COMBO
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                DataTable dt_MS_DON_VI_TEMP2 = new DataTable();
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboMS_DON_VI, dt, "MS_DON_VI", "TEN_NGAN", sForm);
                cboMS_DON_VI.Properties.PopulateViewColumns();
                cboMS_DON_VI.Properties.View.Columns[0].Visible = false;

                dt_MS_TO = new DataTable();
                dt_MS_TO = ds.Tables[1].Copy();
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboMS_TO, dt_MS_TO, "MS_TO", "TEN_TO", sForm);
                //cboMS_TO.EditValue = Convert.ToInt32(dt_MS_TO.Rows[0]["MS_TO"]);
                cboMS_TO.Properties.PopulateViewColumns();
                cboMS_TO.Properties.View.Columns[0].Visible = false;
                cboMS_TO.Properties.View.Columns["STT_TO"].Visible = false;
                cboMS_TO.Properties.View.Columns["MS_DON_VI"].Visible = false;


                dt_MS_TO1 = new DataTable();
                dt_MS_TO1 = ds.Tables[2].Copy();
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboMS_TO1, dt_MS_TO1, "MS_TO1", "TEN_TO", sForm);
                cboMS_TO1.EditValue = Convert.ToInt32(dt_MS_TO1.Rows[0]["MS_TO1"]);
                cboMS_TO1.Properties.PopulateViewColumns();
                cboMS_TO1.Properties.View.Columns[0].Visible = false;
                cboMS_TO1.Properties.View.Columns["MS_TO"].Visible = false;

                DataTable dt5 = new DataTable();
                dt5 = ds.Tables[3].Copy();
                Commons.Modules.ObjLanguages.GetLanguage(sForm, "MS_TRINH_DO");
                Commons.Modules.ObjLanguages.GetLanguage(sForm, "TEN_GOI");
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboMS_TRINH_DO, dt5, "MS_TRINH_DO", "TEN_GOI", sForm);
                cboMS_TRINH_DO.Properties.PopulateViewColumns();
                cboMS_TRINH_DO.Properties.View.Columns[0].Visible = false;
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
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spQuanLyNhanVien", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iMS_CONG_NHAN;
                cmd.Parameters.Add("@MS_CONG_NHAN", SqlDbType.NVarChar).Value = txtMS_CONG_NHAN.Text;
                cmd.CommandType = CommandType.StoredProcedure;

                if (Convert.ToInt32(cmd.ExecuteScalar()) == 1)
                {
                    XtraMessageBox.Show(lblMS_CONG_NHAN.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
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

        private void StatusControl()
        {
            if (iMS_CONG_NHAN == "-1")
            {
                txtMS_CONG_NHAN.ReadOnly = false;
            }

            if (iMS_CONG_NHAN != "-1")
            {
                txtMS_CONG_NHAN.ReadOnly = true;
            }
        }
        #endregion

        private void btnMS_CONG_NHAN_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                LoadView();
            }
        }

        private void LoadView()
        {
            frmQuanLyNhanVienView ctl = new frmQuanLyNhanVienView(iPQ, txtMS_CONG_NHAN.Text, "spQuanLyNhanVien");

            Commons.Modules.sPS = "mnuQuanLyNhanVienView";
            ctl.Tag = "mnuQuanLyNhanVienView";
            ctl.Text = Commons.Modules.ObjLanguages.GetLanguage("frmQuanLyNhanVienView", "frmQuanLyNhanVienView");
            ctl.Name = "frmQuanLyNhanVienView";

            ctl.Size = new Size((this.Width / 2) + (ctl.Width / 2), (this.Height / 2) + (ctl.Height / 2));

            ctl.StartPosition = FormStartPosition.Manual;
            ctl.Location = new Point(this.Width / 2 - ctl.Width / 2 + this.Location.X,
                                      this.Height / 2 - ctl.Height / 2 + this.Location.Y);

            if (ctl.ShowDialog() == DialogResult.OK)
            {
                iMS_CONG_NHAN = ((frmQuanLyNhanVienView)ctl).MS_CONG_NHAN;
                LoadData(iMS_CONG_NHAN);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();

        }
        
    }
}
