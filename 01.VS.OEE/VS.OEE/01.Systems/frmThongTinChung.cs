using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VS.OEE
{
    public partial class frmThongTinChung : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ;
        public frmThongTinChung(int iPQCN)
        {
            iPQ = iPQCN;
            InitializeComponent();
        }
        private void frmThongTinChung_Load(object sender, EventArgs e)
        {
            EnableButton(true);
            ShowInfo();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            if(iPQ != 1)
            {
                btnChon.Visible = false;
                btnCapnhat.Visible = false;
                btnXoa.Visible = false;
            }    
        }
        public void EnableButton(bool chon)
        {
            btnCapnhat.Enabled = chon;
            btnChon.Enabled = chon;
            btnXoa.Enabled = chon;
        }
        public void ShowInfo()
        {
            DataTable dtTest = new DataTable();
            dtTest.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM THONG_TIN_CHUNG"));
            if (dtTest.Rows.Count > 0)
            {
                foreach (DataRow dr in dtTest.Rows)
                {
                    txtTenct_V.Text = dr["TEN_CTY_TIENG_VIET"].ToString();
                    txtTenct_A.Text = dr["TEN_CTY_TIENG_ANH"].ToString();
                    txtTentat_V.Text = dr["TEN_NGAN_TIENG_VIET"].ToString();
                    txtTentat_A.Text = dr["TEN_NGAN_TIENG_ANH"].ToString();


                    txtDiachi_V.Text = dr["DIA_CHI_VIET"].ToString();
                    txtDiachi_A.Text = dr["DIA_CHI_ANH"].ToString();
                    txtDienthoai.Text = dr["PHONE"].ToString();
                    txtSofax.Text = dr["FAX"].ToString();
                    txtChieucao.Text = dr["HEIGHT"].ToString();
                    txtDorong.Text = dr["WIDTH"].ToString();
                    txtTTCCao.Text = dr["TTC_CAO"].ToString();
                    txtSoLeSL.Text = dr["SO_LE_SL"].ToString();
                    txtSoLeDG.Text = dr["SO_LE_DG"].ToString();
                    txtSoLeTT.Text = dr["SO_LE_TT"].ToString();
                    txtTTCRong.Text = dr["TTC_RONG"].ToString();
                    txtPhantram.Text = dr["TI_LE_PHAN_TRAM"].ToString();
                    txtLePhai.Text = dr ["LE_PHAI_LOGO"].ToString();
                    txtLetren.Text = dr["LE_TREN_LOGO"].ToString();
                    txtDUONGDANTL.Text = dr["DUONG_DAN_TL"].ToString();
                    txtEmail.Text = dr["EMAIL"].ToString();
                    txtTaiKhoan.Text = dr["TAI_KHOAN"].ToString();
                    txtTaiKhoanAnh.Text = dr["TAI_KHOAN_ANH"].ToString();
                    txtMaSoThue.Text = dr["MS_THUE"].ToString();
                    txtSoPhut.Text = dr["SO_PHUT_HIEN_MSG"].ToString();


                    txtFont.Text = dr["FONT_REPORT"].ToString();

                    if (dr["DOI_FONT"] == null)
                        chkDoiFont.Checked = false;
                    else if (Convert.ToBoolean(dr["DOI_FONT"]))
                    {
                        chkDoiFont.Checked = true;
                    }
                    else
                        chkDoiFont.Checked = false;


                    if (dr["SENT_MAIL"] == null)
                        chkMail.Checked = false;
                    else if (Convert.ToBoolean(dr["SENT_MAIL"]))
                        chkMail.Checked = true;
                    else
                        chkMail.Checked = false;

                    txtMail.Text = dr["MAIL_FROM"].ToString();
                    string sPass;
                    sPass = dr["PASS_MAIL"].ToString();
                    sPass = Commons.Modules.OXtraGrid.GiaiMaDL(sPass);
                    txtPass.Text = sPass;
                    txtSmtp.Text = dr["SMTP_MAIL"].ToString();
                    txtPort.Text = dr["PORT_MAIL"].ToString();
                    try
                    {
                        picLogo.EditValue = Commons.Modules.ObjSystems.LoadHinh((byte[])dr["LOGO"]);
                    }
                    catch
                    {
                        picLogo.EditValue = null;
                    }
                }
            }
            dtTest.Dispose();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            UpdateData();
            Commons.Modules.iSoLeSL = Convert.ToInt16(txtSoLeSL.Text);
            Commons.Modules.iSoLeDG = Convert.ToInt16(txtSoLeDG.Text);
            Commons.Modules.iSoLeTT = Convert.ToInt16(txtSoLeTT.Text);

            Commons.Modules.sSoLeSL = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL);
            Commons.Modules.sSoLeDG = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
            Commons.Modules.sSoLeTT = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT);

        }
        public void UpdateData()
        {
            string chuoicanthaythe = "";
            string chuoithaythe = "";
            DataTable vtb = new DataTable();
            string sql, SqlText;

            sql = "select duong_dan_tl from thong_tin_chung";
            vtb.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sql));
            if (vtb.Rows.Count > 0)
                try
                {
                    bool lRecordExists = false;        // Không có record nào

                    DataTable dtTest = SqlHelper.ExecuteDataset(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM THONG_TIN_CHUNG").Tables[0];
                    if (dtTest.Rows.Count > 0)
                        lRecordExists = true;// Đã có dữ liệu rồi
                    dtTest.Dispose();                            // Giải phóng bộ nhớ


                    if (lRecordExists)
                    {
                        // Tồn tại thì cập nhật
                        SqlText = "exec UPDATE_THONG_TIN_CHUNG_LOG '" + this.Name + "','" + Commons.Modules.UserName + "',2";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, SqlText);

                        SqlText = "UPDATE THONG_TIN_CHUNG SET TEN_CTY_TIENG_VIET=@TEN_CTY_TIENG_VIET,TEN_CTY_TIENG_ANH=@TEN_CTY_TIENG_ANH, TEN_NGAN_TIENG_VIET=@TEN_NGAN_TIENG_VIET,TEN_NGAN_TIENG_ANH=@TEN_NGAN_TIENG_ANH,LOGO= @LOGO,DIA_CHI_VIET=@DIA_CHI_VIET,DIA_CHI_ANH=@DIA_CHI_ANH,PHONE=@PHONE,FAX=@FAX,WIDTH=@WIDTH,HEIGHT=@LENGTH,TI_LE_PHAN_TRAM=@TI_LE_PHAN_TRAM,STRETCH=@STRETCH,LE_PHAI_LOGO=@LE_PHAI_LOGO,LE_TREN_LOGO=@LE_TREN_LOGO,LOGO_TEN_CTY=@LOGO_TEN_CTY,DUONG_DAN_TL=@DUONG_DAN_TL,EMAIL = @EMAIL,TAI_KHOAN=@TAI_KHOAN,TAI_KHOAN_ANH=@TAI_KHOAN_ANH,SO_PHUT_HIEN_MSG=@SO_PHUT_HIEN_MSG,MS_THUE=@MS_THUE,MAIL_FROM=@MAIL_FROM,PASS_MAIL = @PASS_MAIL,SMTP_MAIL = @SMTP_MAIL, PORT_MAIL = @PORT_MAIL, SENT_MAIL = @SENT_MAIL, " + "TTC_CAO=@TTC_CAO, TTC_RONG = @TTC_RONG ,SO_LE_SL = @SO_LE_SL ,  SO_LE_DG = @SO_LE_DG ,  SO_LE_TT = @SO_LE_TT,DOI_FONT = @DOI_FONT,FONT_REPORT = @FONT_REPORT ";
                    }
                    else
                        // Chưa có thì nhập mới
                        SqlText = "INSERT INTO THONG_TIN_CHUNG(TEN_CTY_TIENG_VIET,TEN_CTY_TIENG_ANH,TEN_NGAN_TIENG_VIET,TEN_NGAN_TIENG_ANH," + "LOGO,DIA_CHI_VIET,DIA_CHI_ANH,PHONE,FAX,WIDTH,HEIGHT,TI_LE_PHAN_TRAM,STRETCH,LE_PHAI_LOGO," + "LE_TREN_LOGO,LOGO_TEN_CTY,DUONG_DAN_TL,TAI_KHOAN,TAI_KHOAN_ANH,MS_THUE,SO_PHUT_HIEN_MSG, " + "MAIL_FROM, PASS_MAIL, SMTP_MAIL, PORT_MAIL,SENT_MAIL,TTC_CAO,TTC_RONG,SO_LE_SL,SO_LE_DG,SO_LE_TT, DOI_FONT,FONT_REPORT )  VALUES(@TEN_CTY_TIENG_VIET,@TEN_CTY_TIENG_ANH,@TEN_NGAN_TIENG_VIET,@TEN_NGAN_TIENG_ANH,@LOGO_PATH,@LOGO , @DIA_CHI_VIET,@DIA_CHI_ANH,@PHONE,@FAX,@WIDTH,@LENGTH,@TI_LE_PHAN_TRAM,@STRETCH,@LE_PHAI_LOGO," + "@LE_TREN_LOGO,@LOGO_TEN_CTY,@DUONG_DAN_TL,@EMAIL,@TAI_KHOAN,@TAI_KHOAN_ANH,@MS_THUE,@SO_PHUT_HIEN_MSG," + "@MAIL_FROM, @PASS_MAIL, @SMTP_MAIL,@PORT_MAIL,@SENT_MAIL,@TTC_CAO,@TTC_RONG,@SO_LE_SL,@SO_LE_DG,@SO_LE_TT,@DOI_FONT,@FONT_REPORT )";
                    SqlConnection SqlConnect = new SqlConnection(Commons.IConnections.CNStr);
                    SqlCommand mycom = new SqlCommand(SqlText, SqlConnect);

                    mycom.Parameters.Add(new SqlParameter("@TEN_CTY_TIENG_VIET", SqlDbType.NVarChar)).Value = txtTenct_V.Text;
                    mycom.Parameters.Add(new SqlParameter("@TEN_CTY_TIENG_ANH", SqlDbType.NVarChar)).Value = txtTenct_A.Text;
                    mycom.Parameters.Add(new SqlParameter("@TEN_NGAN_TIENG_VIET", SqlDbType.NVarChar)).Value = txtTentat_V.Text;
                    mycom.Parameters.Add(new SqlParameter("@TEN_NGAN_TIENG_ANH", SqlDbType.NVarChar)).Value = txtTentat_A.Text;
                        mycom.Parameters.Add(new SqlParameter("@LOGO", SqlDbType.Image)).Value = Commons.Modules.ObjSystems.SaveHinh(picLogo.Image); 
                    mycom.Parameters.Add(new SqlParameter("@DIA_CHI_VIET", SqlDbType.NVarChar)).Value = txtDiachi_V.Text;
                    mycom.Parameters.Add(new SqlParameter("@DIA_CHI_ANH", SqlDbType.NVarChar)).Value = txtDiachi_A.Text;
                    mycom.Parameters.Add(new SqlParameter("@PHONE", SqlDbType.NVarChar)).Value = txtDienthoai.Text;
                    mycom.Parameters.Add(new SqlParameter("@FAX", SqlDbType.NVarChar)).Value = txtSofax.Text;
                    mycom.Parameters.Add(new SqlParameter("@WIDTH", SqlDbType.Int)).Value = txtDorong.Text;
                    mycom.Parameters.Add(new SqlParameter("@LENGTH", SqlDbType.Int)).Value = txtChieucao.Text;
                    mycom.Parameters.Add(new SqlParameter("@TI_LE_PHAN_TRAM", SqlDbType.Float)).Value = txtPhantram.Text;
                    mycom.Parameters.Add(new SqlParameter("@STRETCH", SqlDbType.Bit)).Value = true;
                    mycom.Parameters.Add(new SqlParameter("@LE_PHAI_LOGO", SqlDbType.Int)).Value = txtLePhai.Text;
                    mycom.Parameters.Add(new SqlParameter("@LE_TREN_LOGO", SqlDbType.Int)).Value = txtLetren.Text;
                    mycom.Parameters.Add(new SqlParameter("@LOGO_TEN_CTY", SqlDbType.Int)).Value = txtLogoTenct.Text;
                    mycom.Parameters.Add(new SqlParameter("@DUONG_DAN_TL", SqlDbType.NVarChar)).Value = txtDUONGDANTL.Text;
                    mycom.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.NVarChar)).Value = txtEmail.Text;

                    mycom.Parameters.Add(new SqlParameter("@TAI_KHOAN", SqlDbType.NVarChar)).Value = txtTaiKhoan.Text;
                    mycom.Parameters.Add(new SqlParameter("@TAI_KHOAN_ANH", SqlDbType.NVarChar)).Value = txtTaiKhoanAnh.Text;
                    mycom.Parameters.Add(new SqlParameter("@MS_THUE", SqlDbType.NVarChar)).Value = txtMaSoThue.Text;

                    mycom.Parameters.Add(new SqlParameter("@MAIL_FROM", SqlDbType.NVarChar)).Value = txtMail.Text;
                    mycom.Parameters.Add(new SqlParameter("@PASS_MAIL", SqlDbType.NVarChar)).Value = Commons.Modules.OXtraGrid.MaHoaDL(txtPass.Text);
                    mycom.Parameters.Add(new SqlParameter("@SMTP_MAIL", SqlDbType.NVarChar)).Value = txtSmtp.Text;
                    mycom.Parameters.Add(new SqlParameter("@PORT_MAIL", SqlDbType.NVarChar)).Value = txtPort.Text;

                    if (chkMail.Checked == true)
                        mycom.Parameters.Add(new SqlParameter("@SENT_MAIL", SqlDbType.NVarChar)).Value = 1;
                    else
                        mycom.Parameters.Add(new SqlParameter("@SENT_MAIL", SqlDbType.NVarChar)).Value = 0;
                    if (txtSoPhut.Text != "")
                        mycom.Parameters.Add(new SqlParameter("@SO_PHUT_HIEN_MSG", SqlDbType.Int)).Value = txtSoPhut.Text;
                    else
                        mycom.Parameters.Add(new SqlParameter("@SO_PHUT_HIEN_MSG", SqlDbType.Int)).Value = 0;
                    mycom.Parameters.Add(new SqlParameter("@TTC_CAO", SqlDbType.Int)).Value = txtTTCCao.Text;
                    mycom.Parameters.Add(new SqlParameter("@TTC_RONG", SqlDbType.Int)).Value = txtTTCRong.Text;
                    mycom.Parameters.Add(new SqlParameter("@SO_LE_SL", SqlDbType.Int)).Value = txtSoLeSL.Text;
                    mycom.Parameters.Add(new SqlParameter("@SO_LE_DG", SqlDbType.Int)).Value = txtSoLeDG.Text;
                    mycom.Parameters.Add(new SqlParameter("@SO_LE_TT", SqlDbType.Int)).Value = txtSoLeTT.Text;


                    if (chkDoiFont.Checked == true)
                    {
                        mycom.Parameters.Add(new SqlParameter("@DOI_FONT", SqlDbType.Bit)).Value = 1;
                        mycom.Parameters.Add(new SqlParameter("@FONT_REPORT", SqlDbType.NVarChar)).Value = txtFont.Text;
                    }
                    else
                    {
                        mycom.Parameters.Add(new SqlParameter("@DOI_FONT", SqlDbType.Bit)).Value = 0;
                        mycom.Parameters.Add(new SqlParameter("@FONT_REPORT", SqlDbType.NVarChar)).Value = "";
                    }
                    mycom.Connection.Open();
                    mycom.ExecuteNonQuery();
                    mycom.Connection.Close();
                    if (!lRecordExists)
                    {
                        SqlText = "exec UPDATE_THONG_TIN_CHUNG_LOG '" + this.Name + "','" + Commons.Modules.UserName + "',1";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, SqlText);
                    }
                    chuoithaythe = txtDUONGDANTL.Text;
                    sql = "exec UpdateTable '" + chuoicanthaythe + "','" + chuoithaythe + "'";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sql);

                    XtraMessageBox.Show("Đã cập nhật xong", "VietSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            picLogo.LoadImage();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            picLogo.Image = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}