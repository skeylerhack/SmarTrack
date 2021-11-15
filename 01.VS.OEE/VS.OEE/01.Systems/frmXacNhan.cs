﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace VS.OEE
{
    public partial class frmXacNhan : DevExpress.XtraEditors.XtraForm
    {
        public frmXacNhan()
        {
            InitializeComponent();
        }

        private void frmXacNhan_Load(object sender, EventArgs e)
        {
            LoadNN();
            txtUSER_NAME.ReadOnly = true;
            txtUSER_NAME.Text = Commons.Modules.UserName;
            this.ActiveControl = txtPASSWORD;
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(txtPASSWORD.Text.Length == 0)
            {
                Commons.Modules.msgThayThe(Commons.ThongBao.msgKhongDuocTrong, lblPass.Text);
                return;
            }
            Confirm();
        }

        private void LoadNN()
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void Confirm()
        {
            try
            {
                string sPass = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT PASS FROM dbo.USERS WHERE USERNAME ='" + txtUSER_NAME.Text + "'").ToString();
                if (txtPASSWORD.EditValue.ToString() != Commons.Modules.OXtraGrid.GiaiMaDL(sPass))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgPassWorkkhongdung"));
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            this.Close();
        }
        private void frmXacNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Confirm();
            }
        }
    }
}