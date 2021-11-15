using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VS.OEE
{
    public partial class frmNNgu : DevExpress.XtraEditors.XtraForm
    {
        string sName = "";
        public frmNNgu(string fName)
        {
            sName = fName;
            InitializeComponent();
        }

        private void frmNNgu_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadData()
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.NVarChar).Value = 1;
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = sName;
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuEditLanguages";
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dtTmp = new DataTable();
                dtTmp = ds.Tables[0].Copy();
                dtTmp.TableName = "DataView";
                
                if (grdChung.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtTmp, true, true, true, true);
                    grvChung.Columns["STT"].OptionsColumn.AllowEdit = false; 
                    grvChung.Columns["FORM"].OptionsColumn.AllowEdit = false;
                    grvChung.Columns["KEYWORD"].OptionsColumn.AllowEdit = false;
                }
                else
                    grdChung.DataSource = dtTmp;
                


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }


        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            grvChung.PostEditor();
            grvChung.UpdateCurrentRow();
            string sBT = "NNTmp" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, (DataTable) grdChung.DataSource, "");
            try
            {
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.NVarChar).Value = 2;
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = sName;
                cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = sBT;
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuEditLanguages";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
