using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Commons;
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;
using DevExpress.Utils;
using System.Web.UI.WebControls;

namespace VS.OEE
{
    public partial class frmHieuSuatTheoNam : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ =1;
        public frmHieuSuatTheoNam(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
        }
        int inam = 0;
        private void LockControl(Boolean bLock)
        {
            this.btnCopy.Visible = bLock;
            this.btnSua.Visible = bLock;
            this.btnXoa.Visible = bLock;
            this.btnThoat.Visible = bLock;
            this.btnGhi.Visible = !bLock;
            this.btnKhong.Visible = !bLock;
            this.btnLayMay.Visible = !bLock;
            txtSearch.ReadOnly = !bLock;
            datNam.Properties.ReadOnly = !bLock;
        }
        private void frmHieuSuatTheoNam_Load(object sender, EventArgs e)
        {
            if (iPQ != 1)
            {
                this.btnCopy.Visible = false;
                this.btnSua.Visible = false;
                this.btnXoa.Visible = false;
                this.btnLayMay.Visible = false;
                this.btnGhi.Visible = false;
                this.btnKhong.Visible = false;
            }
            else
            {
                LockControl(true);
            }
            Commons.Modules.sId = "0Load";
            datNam.DateTime = DateTime.Now;
            LoadgrdTarget(false);
            Commons.Modules.sId = "";
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        //load griddata
        private void LoadgrdTarget(bool flag)
        {
            Commons.Modules.sId = "";
            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListTarget", flag,datNam.DateTime.Year, Commons.Modules.UserName, Commons.Modules.TypeLanguage));

                for (int i = 0; i < dtmp.Columns.Count; i++)
                {
                    if(i>1)
                    {
                        dtmp.Columns[i].ReadOnly =false;
                    }
                }
                if (grvTarget.DataSource == null)
                {
                    //OEE,PE,EL,SpeedVar
                    Modules.ObjSystems.MLoadXtraGrid(grdTarget, grvTarget, dtmp,false,false,true,true, true,this.Name);
                    grvTarget.Columns["OEE"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTarget.Columns["OEE"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
            

                    grvTarget.Columns["PE"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTarget.Columns["PE"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    

                    grvTarget.Columns["EL"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTarget.Columns["EL"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    

                    grvTarget.Columns["SpeedVar"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTarget.Columns["SpeedVar"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    


                }
                else
                    grdTarget.DataSource = dtmp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //copy dữ liệu của năm hiện tại đến năm cần copy
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if(grvTarget.RowCount <= 1)
            {
                Modules.msgform(this.Name,"msgKhongCoDuLieuCopy");
                return;
            }
            Commons.Modules.sId = "0Load";
            LockControl(false);
            inam = datNam.DateTime.Year;
            datNam.Properties.ReadOnly = false;
            btnLayMay.Visible = false;
            lblNam.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblChonNam");
            datNam.EditValue = null;
        }
        //sửa target KPI
        private void btnSua_Click(object sender, EventArgs e)
        {
            LockControl(false);
            Commons.Modules.ObjSystems.AddnewRow(grvTarget, false);
        }
        private void DeleteData()
        {
            if (Modules.msgHoiThayThe(ThongBao.msgXoa,groDanhSachHieuXuatKPI.Text) == DialogResult.No) return;
            try
            {
                if (!Commons.Modules.ObjSystems.IsnullorEmpty(grvTarget.GetFocusedRowCellValue("MS_MAY")))
                {
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.Target WHERE YEAR = " + datNam.DateTime.Year + " AND MS_MAY = '"+ grvTarget.GetFocusedRowCellValue("MS_MAY") + "' ");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //xóa target
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvTarget.RowCount <=1 )
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuXoa, "");
                return;
            }
            DeleteData();
            LoadgrdTarget(false);
        }
        //thoát form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //tính KPI của dữ liệu cho năm hiện tại
        private void btnbtnLayMay_Click(object sender, EventArgs e)
        {
            
            LoadgrdTarget(true);
        }
        //lưu dữ liệu
        private void btnGhi_Click(object sender, EventArgs e)
        {
            if(!SaveData())
            {
                //Commons.Modules.msgChung(Commons.ThongBao.msgCapNhatThatBai);
                return;
            }
            LockControl(true);
            Commons.Modules.ObjSystems.DeleteAddRow(grvTarget);
            LoadgrdTarget(false);
            lblNam.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, lblNam.Name);

        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            LockControl(true);
            Commons.Modules.ObjSystems.DeleteAddRow(grvTarget);
            if (datNam.Text == "")
            {
                datNam.DateTime = DateTime.Now;
            }
            else
            {
                LoadgrdTarget(false);
            }
            lblNam.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, lblNam.Name);
        }
        private bool SaveData()
        {
            try
            {
                if (datNam.Properties.ReadOnly == false)
                {
                    //kiểm tra chọn năm
                    if (datNam.Text.Trim() == "")
                    {
                        Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblNam.Text);
                        return false;
                    }
                    //kiểm tra chọn năm khác năm hiện tại
                    if(inam == datNam.DateTime.Year)
                    {
                        Modules.msgform(this.Name, "MsgNamCopyDenPhaiKhac");
                        return false;
                    }
                    //kiểm tra năm copy có dữ liệu hay chưa
                    int n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT count(*) FROM dbo.Target WHERE YEAR = "+inam+""));
                    if(n>0)
                    {
                        if(Modules.msgformHoi(this.Name, "MsgDuLieuDaTonTaiBanCoMuonGhiDe") == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr,"BTtarget"+ Commons.Modules.UserName, Commons.Modules.ObjSystems.ConvertDatatable(grdTarget), "");
                SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spSaveTarget", datNam.DateTime.Year,"BTtarget" + Commons.Modules.UserName);
                Commons.Modules.ObjSystems.XoaTable("BTtarget" + Commons.Modules.UserName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void grvTarget_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle != grvTarget.RowCount -1)
                return;
            e.Appearance.BackColor = Color.FromArgb(255, 204, 255);
        }

        private void datNam_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadgrdTarget(false);
        }

        private void grdTarget_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && btnGhi.Visible == false)
            {
                DeleteData();
                LoadgrdTarget(false);
            }
        }
    }
}