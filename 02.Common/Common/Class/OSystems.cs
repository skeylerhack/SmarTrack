
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraBars.Navigation;
using DevExpress.Utils.Layout;
using System.Threading;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraReports.UI;
using DevExpress.Utils;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using DevExpress.XtraPrinting;
using DevExpress.Export;
using System.Data.SqlClient;

namespace Commons
{
    public class OSystems
    {

        private string strSql;
        public DataTable MOpenData()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD,VIETNAM AS NN FROM dbo.LANGUAGES WHERE	FORM = 'ucLyLich'"));
            return dt;
        }


        #region lưu tài liệu
        public bool KiemFileTonTai(string sFile)
        {
            try
            {
                return (System.IO.File.Exists(sFile));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetDUONG_DAN_HINH(int STT)
        {
            DataTable objDataTable = new DataTable();
            objDataTable.Load(SqlHelper.ExecuteReader(IConnections.CNStr, "GetDUONG_DAN_HINH", STT));
            return objDataTable;
        }
        public void Xoahinh(string strDuongdan)
        {
            if (System.IO.File.Exists(strDuongdan))
            {
                try
                {
                    System.IO.File.Delete(strDuongdan);
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void LuuDuongDan(string strDUONG_DAN, string strHINH)
        {
            if (strHINH.Equals(""))
                return;
            if (System.IO.File.Exists(strDUONG_DAN) & !System.IO.File.Exists(strHINH))
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(strHINH));
                    foreach (FileInfo item in dir.EnumerateFiles())
                    {
                        item.Delete();
                    }
                    System.IO.File.Copy(strDUONG_DAN, strHINH);
                }
                catch (Exception ex)
                {
                }
            }
        }

        public string LocKyTuDB(string sChuoi)
        {
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace("/", "-");
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace(@"\", "-");
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace("*", "-");
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace("-", "-");
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace(".", "-");
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace("!", "-");
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace("@", "-");
            if (sChuoi.Length > 0)
                sChuoi = sChuoi.Replace("#", "-");
            return sChuoi;
        }
        public string LayDuoiFile(string strFile)
        {
            string[] FILE_NAMEArr, arr;
            string FILE_NAME = "";
            FILE_NAMEArr = strFile.Split('\\');
            FILE_NAME = FILE_NAMEArr[FILE_NAMEArr.Length - 1];
            arr = FILE_NAME.Split('.');
            return "." + arr[arr.Length - 1];
        }

        public string STTFileCungThuMuc(string sThuMuc, string sFile)
        {
            string TenFile = sFile;
            string DuoiFile;
            try
            {
                DuoiFile = LayDuoiFile(sFile);
            }
            catch (Exception ex)
            {
                DuoiFile = "";
            }


            try
            {
                string[] sTongFile;
                int i = 1;

                TenFile = sFile;
                sTongFile = System.IO.Directory.GetFiles(sThuMuc);


                for (i = 1; i <= sTongFile.Length + 1; i++)
                {
                    if (System.IO.File.Exists(sThuMuc + @"\" + TenFile) == true)
                    {
                        if (i.ToString().Length == 1)
                            TenFile = sFile.Replace(DuoiFile, "-00" + i.ToString()) + DuoiFile;
                        else if (i.ToString().Length == 2)
                            TenFile = sFile.Replace(DuoiFile, "-0" + i.ToString()) + DuoiFile;
                        else
                            TenFile = sFile.Replace(DuoiFile, "-" + i.ToString()) + DuoiFile;
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                TenFile = "";
            }

            return TenFile;
        }
        public void OpenHinh(string strDuongdan)
        {
            if (strDuongdan.Equals(""))
                return;
            if (System.IO.File.Exists(strDuongdan))
            {
                try
                {
                    System.Diagnostics.Process.Start(strDuongdan);
                }
                catch (Exception ex)
                {
                }
            }
        }

        public string CapnhatTL(string strMS_MAY)
        {
            strMS_MAY = LocKyTuDB(strMS_MAY);
            string SERVER_FOLDER_PATH = "";
            string SERVER_PATH = "";
            SERVER_PATH = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 DUONG_DAN_TL FROM dbo.THONG_TIN_CHUNG").ToString();
            if (!System.IO.Directory.Exists(SERVER_PATH))
                SERVER_PATH = "";
            if (!SERVER_PATH.EndsWith(@"\"))
                SERVER_PATH = SERVER_PATH + @"\";
            SERVER_FOLDER_PATH = SERVER_PATH;
            if (System.IO.Directory.Exists(SERVER_PATH))
            {
                string[] FILE_TEMPArr;
                FILE_TEMPArr = System.IO.Directory.GetFileSystemEntries(SERVER_PATH);
                int i = 0;
                string[] arr;
                while (i < FILE_TEMPArr.Length) // tài liệu
                {
                    arr = FILE_TEMPArr[i].Split('\\');
                    if (arr[arr.Length - 1].Equals("Tai_Lieu_MH"))
                    {
                        SERVER_FOLDER_PATH = SERVER_FOLDER_PATH + arr[arr.Length - 1];
                        // kiểm tra folder MS_MAY đã tồn tại chưa
                        string[] FILE_TEMPArr1;
                        FILE_TEMPArr1 = System.IO.Directory.GetFileSystemEntries(SERVER_FOLDER_PATH);
                        int j = 0; // MS_MAY
                        while (j < FILE_TEMPArr1.Length)
                        {
                            arr = FILE_TEMPArr1[j].Split('\\');
                            if (arr[arr.Length - 1].Equals(strMS_MAY))
                            {
                                SERVER_FOLDER_PATH = SERVER_FOLDER_PATH + @"\" + arr[arr.Length - 1];
                                break; // MS_MAY
                            }
                            j = j + 1;
                        } // MS_MAY
                        if (j == FILE_TEMPArr1.Length)
                        {
                            SERVER_FOLDER_PATH = SERVER_FOLDER_PATH + @"\" + strMS_MAY;
                            System.IO.Directory.CreateDirectory(SERVER_FOLDER_PATH);
                        }
                        break; // tài liệu
                    }
                    i = i + 1;
                } // tài liệu
                if (i == FILE_TEMPArr.Length)
                {
                    // nếu chưa tồn tại folder bảo trì thì tạo mới folder bảo trì và các folder hình máy và tài liệu máy
                    SERVER_FOLDER_PATH = SERVER_FOLDER_PATH + @"Tai_Lieu_MH\" + strMS_MAY;
                    System.IO.Directory.CreateDirectory(SERVER_FOLDER_PATH);
                }
            }
            else
            {
            }
            return SERVER_FOLDER_PATH;
        }

        #endregion


        #region LoadLookupedit

        public void MLoadTreeLookUpEdit(TreeListLookUpEdit cbo, DataTable dt, string Ma, string Ten, string Cha, string TenCot)
        {
            cbo.Properties.TreeList.DataSource = null;
            cbo.Properties.DisplayMember = Ten;
            cbo.Properties.ValueMember = Ma;
            cbo.Properties.DataSource = dt;
            cbo.Properties.TreeList.KeyFieldName = Ma;
            cbo.Properties.TreeList.ParentFieldName = Cha;
            cbo.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            cbo.Properties.AppearanceDropDown.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            if (Ten == "TEN_HE_THONG")
            {
                cbo.Properties.TreeList.Columns["STT"].Visible = false;
            }
            cbo.Properties.TreeList.Columns[Ten].Caption = TenCot;
            cbo.EditValue = -1;
        }


        public bool MLoadLookUpEdit(DevExpress.XtraEditors.LookUpEdit cbo, string sQuery, string Ma, string Ten, string TenCot)
        {
            try
            {
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = "";
                cbo.Properties.ValueMember = "";
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, CommandType.Text, sQuery));
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.Columns.Clear();
                cbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(Ten));
                cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.Properties.SearchMode = SearchMode.AutoComplete;
                cbo.EditValue = dtTmp.Rows[0][Ma];
                if (dtTmp.Rows.Count > 10)
                    cbo.Properties.DropDownRows = 15;
                else
                    cbo.Properties.DropDownRows = 10;
                cbo.Properties.Columns[Ten].Caption = TenCot;
                if (TenCot == "")
                    cbo.Properties.ShowHeader = false;
                else
                    cbo.Properties.ShowHeader = true;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool MLoadComboboxEdit(DevExpress.XtraEditors.ComboBoxEdit cbo, DataTable dt, string cot)
        {
            try
            {
                cbo.Properties.Items.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    cbo.Properties.Items.Add(item[cot]);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadLookUpEditTab(DevExpress.XtraEditors.LookUpEdit cbo, DataTable dtTmp, string Ma, string Ten, string form)
        {
            try
            {
                cbo.Properties.DataSource = null;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.PopulateColumns();
                cbo.Properties.Columns[Ma].Visible = false;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                for (int i = 0; i < cbo.Properties.Columns.Count; i++)
                {
                    cbo.Properties.Columns[i].Caption = Commons.Modules.ObjLanguages.GetLanguage(form, cbo.Properties.Columns[i].FieldName);
                }
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.Properties.SearchMode = SearchMode.AutoComplete;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadLookUpEdit(DevExpress.XtraEditors.LookUpEdit cbo, DataTable dtTmp, string Ma, string Ten, string TenCot)
        {
            try
            {
                cbo.Properties.DataSource = null;
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.Columns.Clear();
                cbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(Ten));
                cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.Properties.SearchMode = SearchMode.AutoComplete;
                cbo.EditValue = dtTmp.Rows[0][Ma];
                if (dtTmp.Rows.Count > 10)
                    cbo.Properties.DropDownRows = 15;
                else
                    cbo.Properties.DropDownRows = 10;
                cbo.Properties.Columns[Ten].Caption = TenCot;
                if (TenCot == "")
                    cbo.Properties.ShowHeader = false;
                else
                    cbo.Properties.ShowHeader = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadLookUpEdit2Colums(DevExpress.XtraEditors.LookUpEdit cbo, DataTable dtTmp, string Ma, string Ten, string TenCot, string MaCot)
        {
            try
            {
                cbo.Properties.DataSource = null;
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.Columns.Clear();
                cbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(Ma));
                cbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(Ten));
                cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.Properties.SearchMode = SearchMode.AutoComplete;
                cbo.EditValue = dtTmp.Rows[0][Ma];
                if (dtTmp.Rows.Count > 10)
                    cbo.Properties.DropDownRows = 15;
                else
                    cbo.Properties.DropDownRows = 10;
                cbo.Properties.Columns[Ten].Caption = TenCot;
                cbo.Properties.Columns[Ma].Caption = MaCot;
                if (TenCot == "")
                    cbo.Properties.ShowHeader = false;
                else
                    cbo.Properties.ShowHeader = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadLookUpEdit(DevExpress.XtraEditors.LookUpEdit cbo, DataTable dtTmp, string Ma, string Ten, string TenCot, bool CoNull)
        {
            try
            {
                if (CoNull)
                    dtTmp.Rows.Add(-99, "");
                cbo.Properties.DataSource = null;
                //cbo.Properties.DisplayMember = "";
                //cbo.Properties.ValueMember = "";
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.Columns.Clear();
                cbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(Ten));
                cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.Properties.SearchMode = SearchMode.AutoComplete;
                if (CoNull)
                    cbo.EditValue = dtTmp.Rows[dtTmp.Rows.Count - 1][Ma];
                else
                    cbo.EditValue = dtTmp.Rows[0][Ma];
                if (dtTmp.Rows.Count > 10)
                    cbo.Properties.DropDownRows = 15;
                else
                    cbo.Properties.DropDownRows = 10;
                cbo.Properties.Columns[Ten].Caption = TenCot;
                if (TenCot == "")
                    cbo.Properties.ShowHeader = false;
                else
                    cbo.Properties.ShowHeader = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadLookUpEdit(DevExpress.XtraEditors.LookUpEdit cbo, string sStored, string Ma, string Ten, string TenCot, bool bStored)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                if (bStored)
                    dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, sStored));
                else
                    dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, CommandType.Text, sStored));
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = "";
                cbo.Properties.ValueMember = "";
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.Columns.Clear();
                cbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(Ten));
                cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.Properties.SearchMode = SearchMode.AutoComplete;
                cbo.EditValue = dtTmp.Rows[0][Ma];
                if (dtTmp.Rows.Count > 10)
                    cbo.Properties.DropDownRows = 15;
                else
                    cbo.Properties.DropDownRows = 10;
                cbo.Properties.Columns[Ten].Caption = TenCot;
                if (TenCot == "")
                    cbo.Properties.ShowHeader = false;
                else
                    cbo.Properties.ShowHeader = true;

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadLookUpEdit(DevExpress.XtraEditors.LookUpEdit cbo, string sStored, string Ma, string Ten, string TenCot, bool bStored, string Param)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                if (bStored)
                    dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, sStored, Param));
                else
                    dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, CommandType.Text, sStored));
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = "";
                cbo.Properties.ValueMember = "";

                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.Columns.Clear();
                cbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(Ten));
                cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.Properties.SearchMode = SearchMode.AutoComplete;
                cbo.EditValue = dtTmp.Rows[0][Ma];
                if (dtTmp.Rows.Count > 10)
                    cbo.Properties.DropDownRows = 15;
                else
                    cbo.Properties.DropDownRows = 10;
                cbo.Properties.Columns[Ten].Caption = TenCot;
                if (TenCot == "")
                    cbo.Properties.ShowHeader = false;
                else
                    cbo.Properties.ShowHeader = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadLookUpEdit(DevExpress.XtraEditors.LookUpEdit cbo, string sStored, string Ma, string Ten, string TenCot, bool bStored, string Param, string Param1)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                if (bStored)
                    dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, sStored, Param, Param1));
                else
                    dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, CommandType.Text, sStored));
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = "";
                cbo.Properties.ValueMember = "";
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.Columns.Clear();
                cbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(Ten));
                cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.Properties.SearchMode = SearchMode.AutoComplete;
                cbo.EditValue = dtTmp.Rows[0][Ma];
                if (dtTmp.Rows.Count > 10)
                    cbo.Properties.DropDownRows = 15;
                else
                    cbo.Properties.DropDownRows = 10;
                cbo.Properties.Columns[Ten].Caption = TenCot;
                if (TenCot == "")
                    cbo.Properties.ShowHeader = false;
                else
                    cbo.Properties.ShowHeader = true;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool MLoadLookUpEditNoRemove(DevExpress.XtraEditors.LookUpEdit cbo, string sQuery, string Ma, string Ten, string TenCot)
        {
            try
            {
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = "";
                cbo.Properties.ValueMember = "";

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, CommandType.Text, sQuery));
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.Properties.SearchMode = SearchMode.AutoComplete;
                cbo.EditValue = dtTmp.Rows[0][Ma];
                if (dtTmp.Rows.Count > 10)
                    cbo.Properties.DropDownRows = 15;
                else
                    cbo.Properties.DropDownRows = 10;
                cbo.Properties.Columns[Ten].Caption = TenCot;
                if (TenCot == "")
                    cbo.Properties.ShowHeader = false;
                else
                    cbo.Properties.ShowHeader = true;

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadLookUpEditNoRemove(DevExpress.XtraEditors.LookUpEdit cbo, DataTable dtTmp, string Ma, string Ten, string sForm)
        {
            try
            {
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = "";
                cbo.Properties.ValueMember = "";
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.Properties.SearchMode = SearchMode.AutoComplete;
                cbo.EditValue = dtTmp.Rows[0][Ma];
                cbo.Properties.Columns.Clear();
                DevExpress.XtraEditors.Controls.LookUpColumnInfo column;
                for (int intColumn = 0; intColumn <= dtTmp.Columns.Count - 1; intColumn++)
                {
                    column = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                    column.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sForm, dtTmp.Columns[intColumn].ColumnName, Commons.Modules.TypeLanguage);
                    column.FieldName = dtTmp.Columns[intColumn].ColumnName;
                    cbo.Properties.Columns.Add(column);
                }
                if (dtTmp.Rows.Count > 10)
                    cbo.Properties.DropDownRows = 15;
                else
                    cbo.Properties.DropDownRows = 10;
                cbo.Properties.ShowHeader = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadLookUpEditNoRemove(DevExpress.XtraEditors.LookUpEdit cbo, string sStored, string Ma, string Ten, string TenCot, bool bStored)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                if (bStored)
                    dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, sStored));
                else
                    dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, CommandType.Text, sStored));
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = "";
                cbo.Properties.ValueMember = "";
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.Properties.SearchMode = SearchMode.AutoComplete;
                cbo.EditValue = dtTmp.Rows[0][Ma];
                if (dtTmp.Rows.Count > 10)
                    cbo.Properties.DropDownRows = 15;
                else
                    cbo.Properties.DropDownRows = 10;
                cbo.Properties.Columns[Ten].Caption = TenCot;
                if (TenCot == "")
                    cbo.Properties.ShowHeader = false;
                else
                    cbo.Properties.ShowHeader = true;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool MLoadLookUpEditNoRemove(DevExpress.XtraEditors.LookUpEdit cbo, string sStored, string Ma, string Ten, string TenCot, bool bStored, string Param)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                if (bStored)
                    dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, sStored, Param));
                else
                    dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, CommandType.Text, sStored));
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = "";
                cbo.Properties.ValueMember = "";

                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.Properties.SearchMode = SearchMode.AutoComplete;
                cbo.EditValue = dtTmp.Rows[0][Ma];
                if (dtTmp.Rows.Count > 10)
                    cbo.Properties.DropDownRows = 15;
                else
                    cbo.Properties.DropDownRows = 10;
                cbo.Properties.Columns[Ten].Caption = TenCot;
                if (TenCot == "")
                    cbo.Properties.ShowHeader = false;
                else
                    cbo.Properties.ShowHeader = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool MLoadLookUpEditNoRemove(DevExpress.XtraEditors.LookUpEdit cbo, string sStored, string Ma, string Ten, string TenCot, bool bStored, string Param, string Param1)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                if (bStored)
                    dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, sStored, Param, Param1));
                else
                    dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, CommandType.Text, sStored));
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = "";
                cbo.Properties.ValueMember = "";
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;

                cbo.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.Properties.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.Properties.SearchMode = SearchMode.AutoComplete;
                cbo.EditValue = dtTmp.Rows[0][Ma];
                if (dtTmp.Rows.Count > 10)
                    cbo.Properties.DropDownRows = 15;
                else
                    cbo.Properties.DropDownRows = 10;
                cbo.Properties.Columns[Ten].Caption = TenCot;
                if (TenCot == "")
                    cbo.Properties.ShowHeader = false;
                else
                    cbo.Properties.ShowHeader = true;

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region AutoComplete
        public bool MAutoCompleteTextEdit(DevExpress.XtraEditors.TextEdit txt, string sQuery, string Ma)
        {
            try
            {
                txt.MaskBox.AutoCompleteCustomSource = null;
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, CommandType.Text, sQuery));
                string[] postSource;
                dtTmp = dtTmp.DefaultView.ToTable(true, Ma);
                postSource = dtTmp.Rows.Cast<DataRow>().Select(dr => dr[Ma].ToString()).ToArray();
                var source = new AutoCompleteStringCollection();
                source.AddRange(postSource);
                txt.MaskBox.AutoCompleteCustomSource = source;
                txt.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool MAutoCompleteTextEdit(DevExpress.XtraEditors.TextEdit txt, DataTable dtData, string Ma)
        {
            try
            {
                txt.MaskBox.AutoCompleteCustomSource = null;
                string[] postSource;
                dtData = dtData.DefaultView.ToTable(true, Ma);
                postSource = dtData.Rows.Cast<DataRow>().Select(dr => dr[Ma].ToString()).ToArray();
                var source = new AutoCompleteStringCollection();
                source.AddRange(postSource);
                txt.MaskBox.AutoCompleteCustomSource = source;
                txt.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Load định dạng lưới
        public void RestoreLayoutFromRegistry(GridControl grd)
        {
            DevExpress.Utils.OptionsLayoutGrid opts = new DevExpress.Utils.OptionsLayoutGrid();
            opts.Columns.StoreAllOptions = true;
            grd.MainView.RestoreLayoutFromRegistry(@"DevExpress\XtraGrid\Layouts\" + grd.Name);
        }
        public void DeleteSubKeyTree(GridControl grd)
        {
            Microsoft.Win32.RegistryKey rkSubKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"DevExpress\XtraGrid\Layouts", true);
            rkSubKey.DeleteSubKeyTree(grd.Name);
        }
        public void SaveLayoutToRegistry(GridControl grd)
        {
            DevExpress.Utils.OptionsLayoutGrid opts = new DevExpress.Utils.OptionsLayoutGrid();
            opts.Columns.StoreAllOptions = true;
            grd.MainView.SaveLayoutToRegistry(@"DevExpress\XtraGrid\Layouts\" + grd.Name);
        }
        #endregion


        #region Load xtraserch
        public void MLoadSearchLookUpEdit(DevExpress.XtraEditors.SearchLookUpEdit cbo, DataTable dtTmp, string Ma, string Ten, string form, bool isNgonNgu = true)
        {
            //try
            //{
            //    cbo.Properties.DataSource = null;
            //    cbo.Properties.DisplayMember = "";
            //    cbo.Properties.ValueMember = "";
            //    cbo.Properties.DataSource = dtTmp;
            //    cbo.Properties.DisplayMember = Ten;
            //    cbo.Properties.ValueMember = Ma;
            //    cbo.Properties.BestFitMode = BestFitMode.BestFit;
            //    DevExpress.XtraGrid.Views.Grid.GridView grv = (DevExpress.XtraGrid.Views.Grid.GridView)cbo.Properties.PopupView;
            //    grv.Columns[Ma].Caption = Commons.Modules.ObjLanguages.GetLanguage(form, Ma);
            //    grv.Columns[Ten].Caption = Commons.Modules.ObjLanguages.GetLanguage(form, Ten);
            //    cbo.EditValue = dtTmp.Rows[0][Ma];
            //    cbo.Properties.PopulateViewColumns();
            //    cbo.Properties.View.Columns[0].Visible = false;
            //}
            //catch { }
            try
            {
                cbo.Properties.DataSource = null;
                cbo.Properties.DisplayMember = "";
                cbo.Properties.ValueMember = "";
                cbo.Properties.DataSource = dtTmp;
                cbo.Properties.DisplayMember = Ten;
                cbo.Properties.ValueMember = Ma;
                cbo.Properties.BestFitMode = BestFitMode.BestFit;
                cbo.EditValue = dtTmp.Rows[0][Ma];
                cbo.Properties.PopulateViewColumns();
                cbo.Properties.View.Columns[0].Visible = false;
                if (isNgonNgu)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView grv = (DevExpress.XtraGrid.Views.Grid.GridView)cbo.Properties.PopupView;
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in grv.Columns)
                    {
                        if (col.Visible)
                        {

                            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                            col.AppearanceHeader.Options.UseTextOptions = true;
                            col.Caption = Modules.ObjLanguages.GetLanguage(Modules.ModuleName, form, col.FieldName, Modules.TypeLanguage);
                        }
                    }
                    cbo.Refresh();
                }

            }
            catch { }

        }

        #endregion

        #region Load xtragrid
        public bool MLoadXtraGrid(DevExpress.XtraGrid.GridControl grd, DevExpress.XtraGrid.Views.Grid.GridView grv, string sQuery, bool MEditable, bool MPopulateColumns, bool MColumnAutoWidth, bool MBestFitColumns)
        {
            try
            {
                if (grv.Tag == null)
                {
                    grv.Tag = grv.Name;
                }
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, CommandType.Text, sQuery));

                grd.DataSource = dtTmp;
                grv.OptionsBehavior.Editable = MEditable;
                if (MPopulateColumns == true)
                    grv.PopulateColumns();
                grv.OptionsView.ColumnAutoWidth = MColumnAutoWidth;
                grv.OptionsView.AllowHtmlDrawHeaders = true;
                grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
                grv.OptionsBehavior.FocusLeaveOnTab = true;
                if (MBestFitColumns)
                    grv.BestFitColumns();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadXtraGrid(DevExpress.XtraGrid.GridControl grd, DevExpress.XtraGrid.Views.Grid.GridView grv, DataTable dtTmp, bool MEditable, bool MPopulateColumns, bool MColumnAutoWidth, bool MBestFitColumns)
        {
            try
            {
                if (grv.Tag == null)
                {
                    grv.Tag = grv.Name;
                }
                grd.DataSource = dtTmp;
                grv.OptionsBehavior.Editable = MEditable;
                if (MPopulateColumns == true)
                    grv.PopulateColumns();
                grv.OptionsView.ColumnAutoWidth = MColumnAutoWidth;
                grv.OptionsView.AllowHtmlDrawHeaders = true;
                grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
                if (MBestFitColumns)
                    grv.BestFitColumns();
                grv.OptionsBehavior.FocusLeaveOnTab = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadXtraGrid(DevExpress.XtraGrid.GridControl grd, DevExpress.XtraGrid.Views.Grid.GridView grv, string sQuery, bool MEditable, bool MPopulateColumns, bool MColumnAutoWidth, bool MBestFitColumns, bool MloadNNgu, string fName)
        {
            try
            {
                if (grv.Tag == null)
                {
                    grv.Tag = grv.Name;
                }
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(IConnections.CNStr, CommandType.Text, sQuery));

                grd.DataSource = dtTmp;
                grv.OptionsBehavior.Editable = MEditable;
                if (MPopulateColumns == true)
                    grv.PopulateColumns();
                grv.OptionsView.ColumnAutoWidth = MColumnAutoWidth;
                grv.OptionsView.AllowHtmlDrawHeaders = true;
                grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
                if (MBestFitColumns)
                    grv.BestFitColumns();
                if (MloadNNgu)
                    MLoadNNXtraGrid(grv, fName);
                grv.OptionsBehavior.FocusLeaveOnTab = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadXtraGrid(DevExpress.XtraGrid.GridControl grd, DevExpress.XtraGrid.Views.Grid.GridView grv, DataTable dtTmp, bool MEditable, bool MPopulateColumns, bool MColumnAutoWidth, bool MBestFitColumns, bool MloadNNgu, string fName)
        {
            try
            {
                if (grv.Tag == null)
                {
                    grv.Tag = grv.Name;
                }
                grd.DataSource = dtTmp;
                grv.OptionsBehavior.Editable = MEditable;
                if (MPopulateColumns == true)
                    grv.PopulateColumns();
                grv.OptionsView.ColumnAutoWidth = MColumnAutoWidth;
                grv.OptionsView.AllowHtmlDrawHeaders = true;
                grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                grv.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
                grv.OptionsSelection.MultiSelect = true;
                grv.DoubleClick += delegate (object a, EventArgs b) { Grv_DoubleClick(a, b, fName); };
                if (MBestFitColumns)
                    grv.BestFitColumns();
                grv.OptionsBehavior.FocusLeaveOnTab = true;
                //kiểm tra có trong table định dạng lưới chưa có thì load
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.DINH_DANG_LUOI WHERE MS_LUOI ='" + grv.Name + "'")) == 1)
                {
                    // RESTORE  
                    string text = (Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT DINH_DANG_LUOI FROM dbo.DINH_DANG_LUOI WHERE MS_LUOI ='" + grv.Name + "'")));
                    byte[] byteArray = Encoding.ASCII.GetBytes(text);
                    MemoryStream stream = new MemoryStream(byteArray);
                    grv.RestoreLayoutFromStream(stream);
                }

                grv.PopupMenuShowing += delegate (object a, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs b) { Grv_PopupMenuShowing(grv, b, grv); };

                if (MloadNNgu)
                    MLoadNNXtraGrid(grv, fName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool MLoadXtraGrid(DevExpress.XtraGrid.GridControl grd, DevExpress.XtraGrid.Views.Grid.GridView grv, DataTable dtTmp, bool MPopulateColumns, bool MColumnAutoWidth, bool MBestFitColumns, bool MloadNNgu, string fName)
        {
            try
            {
                if (grv.Tag == null)
                {
                    grv.Tag = grv.Name;
                }
                grd.DataSource = dtTmp;
                grv.OptionsBehavior.Editable = false;
                if (MPopulateColumns == true)
                    grv.PopulateColumns();
                grv.OptionsView.ColumnAutoWidth = MColumnAutoWidth;
                //grv.OptionsView.ColumnHeaderAutoHeight = DefaultBoolean.True;
                grv.OptionsView.AllowHtmlDrawHeaders = true;
                grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                grv.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
                grv.OptionsSelection.MultiSelect = true;
                grv.DoubleClick += delegate (object a, EventArgs b) { Grv_DoubleClick(a, b, fName); };
                if (MBestFitColumns)
                    grv.BestFitColumns();
                grv.OptionsBehavior.FocusLeaveOnTab = true;

                //kiểm tra có trong table định dạng lưới chưa có thì load
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.DINH_DANG_LUOI WHERE MS_LUOI ='" + grv.Tag + "'")) == 1)
                {
                    // RESTORE  
                    string text = (Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT DINH_DANG_LUOI FROM dbo.DINH_DANG_LUOI WHERE MS_LUOI ='" + grv.Tag + "'")));
                    byte[] byteArray = Encoding.ASCII.GetBytes(text);
                    MemoryStream stream = new MemoryStream(byteArray);
                    grv.RestoreLayoutFromStream(stream);
                }
                grv.PopupMenuShowing += delegate (object a, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs b) { Grv_PopupMenuShowing(grv, b, grv); };
                if (MloadNNgu)
                    MLoadNNXtraGrid(grv, fName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void Grv_DoubleClick(object sender, EventArgs e, string sName)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                try
                {
                    DevExpress.XtraGrid.Views.Grid.GridView View;
                    string sText = "";
                    View = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                    DevExpress.Utils.DXMouseEventArgs dxMouseEventArgs = e as DevExpress.Utils.DXMouseEventArgs;
                    DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = View.CalcHitInfo(dxMouseEventArgs.Location);
                    if (hitInfo.InColumn)
                    {
                        try
                        {
                            sText = XtraInputBox.Show(hitInfo.Column.GetTextCaption(), "Sửa ngôn ngữ", "");
                            if (sText == "")
                                return;
                            else if (sText == "Windows.Forms.DialogResult.Retry")
                            {
                                sText = "";
                                CapNhapNN(sName, hitInfo.Column.FieldName, sText, true);
                            }
                            else
                                CapNhapNN(sName, hitInfo.Column.FieldName, sText, false);
                            sText = " SELECT TOP 1 " + (Commons.Modules.TypeLanguage == 0 ? "VIETNAM" : "ENGLISH") + " FROM LANGUAGES WHERE FORM = '" + sName + "' AND KEYWORD = '" + hitInfo.Column.FieldName + "' AND MS_MODULE = 'ECOMAIN' ";
                            sText = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sText));
                            hitInfo.Column.Caption = sText;
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void Grv_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e, GridView grv)
        {
            if (e.MenuType != DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
                return;
            try
            {
                DevExpress.XtraGrid.Menu.GridViewMenu headerMenu = (DevExpress.XtraGrid.Menu.GridViewMenu)e.Menu;

                if (headerMenu.Items.Count(x => x.Caption.Equals("Reset Grid")) > 0)
                {
                    return;
                }
                // menu resetgrid
                if (Commons.Modules.UserName.ToLower() == "admin")
                {
                    DevExpress.Utils.Menu.DXMenuItem menuItem = new DevExpress.Utils.Menu.DXMenuItem("Reset Grid");
                    menuItem.BeginGroup = true;
                    menuItem.Tag = e.Menu;
                    menuItem.Click += delegate (object a, EventArgs b) { MenuItemReset_Click(null, null, grv); };
                    headerMenu.Items.Add(menuItem);
                    // menu resetgrid
                    DevExpress.Utils.Menu.DXMenuItem menuSave = new DevExpress.Utils.Menu.DXMenuItem("Save Grid");
                    menuSave.BeginGroup = true;
                    menuSave.Tag = e.Menu;
                    menuSave.Click += delegate (object a, EventArgs b) { MyMenuItemSave(null, null, grv); };
                    headerMenu.Items.Add(menuSave);
                
                }
                // menu export to excel
                DevExpress.Utils.Menu.DXMenuItem menuExport = new DevExpress.Utils.Menu.DXMenuItem("Export to Excel");
                menuExport.BeginGroup = true;
                menuExport.Tag = e.Menu;
                menuExport.Click += delegate (object a, EventArgs b) { ExportToExcel(null, null, grv); };
                headerMenu.Items.Add(menuExport);
            }
            catch
            {
            }
        }




        private void MenuItemReset_Click(object sender, EventArgs e, GridView grv)
        {
            try
            {
                grv.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                for (int i = 0; i <= grv.Columns.Count - 1; i++)
                {
                    try
                    {
                        grv.Columns[i].Visible = true;
                        grv.Columns[i].VisibleIndex = i + 1;
                    }
                    catch
                    {
                    }
                }
                switch (grv.Tag)
                {
                    case "grv":
                        {
                            grv.Columns["MS_MAY"].VisibleIndex = 1;
                            grv.Columns["TEN_MAY"].VisibleIndex = 2;
                            grv.Columns["OEE"].VisibleIndex = 2;
                            grv.Columns["PE"].VisibleIndex = 3;
                            grv.Columns["EL"].VisibleIndex = 4;
                            grv.Columns["SpeedVar"].VisibleIndex = 5;

                            grv.Columns["MS_MAY"].Width = 150;
                            grv.Columns["TEN_MAY"].Width = 200;
                            grv.Columns["OEE"].Width = 100;
                            grv.Columns["PE"].Width = 100;
                            grv.Columns["EL"].Width = 100;
                            grv.Columns["SpeedVar"].Width = 100;
                            break;
                        }
                    case "grvNgungMay":
                        {
                            grv.Columns["CaID"].Visible = false;
                            grv.Columns["MS_NGUYEN_NHAN"].Visible = false;
                            grv.Columns["THOI_GIAN_SUA_CHUA"].Visible = false;
                            grv.Columns["ProductionRunDetailsID"].Visible = false;
                            grv.Columns["Planned"].Visible = false;

                            grv.Columns["MS_LAN"].Width = 100;
                            grv.Columns["NGAY"].Width = 100;
                            grv.Columns["CA"].Width = 80;
                            grv.Columns["ItemName"].Width = 200;
                            grv.Columns["TU_NGAY"].Width = 150;
                            grv.Columns["DEN_NGAY"].Width = 150;
                            grv.Columns["THOI_GIAN_SUA"].Width = 80;
                            grv.Columns["TEN_NGUYEN_NHAN"].Width = 400;

                            grv.Columns["MS_LAN"].VisibleIndex = 1;
                            grv.Columns["NGAY"].VisibleIndex = 2;
                            grv.Columns["CA"].VisibleIndex = 3;
                            grv.Columns["ItemName"].VisibleIndex = 4;
                            grv.Columns["TU_NGAY"].VisibleIndex = 5;
                            grv.Columns["DEN_NGAY"].VisibleIndex = 6;
                            grv.Columns["THOI_GIAN_SUA"].VisibleIndex = 7;
                            grv.Columns["TEN_NGUYEN_NHAN"].VisibleIndex = 8;
                            break;
                        }

                    case "grvDeviceCause":
                        {
                            grv.Columns["MS_NGUYEN_NHAN"].Visible = false;

                            grv.Columns["CauseCode"].Width = 100;
                            grv.Columns["TEN_NGUYEN_NHAN"].Width = 300;
                            grv.Columns["DVT"].Width = 80;
                            grv.Columns["DINH_MUC"].Width = 80;

                            grv.Columns["CauseCode"].VisibleIndex = 1;
                            grv.Columns["TEN_NGUYEN_NHAN"].VisibleIndex = 2;
                            grv.Columns["DVT"].VisibleIndex = 3;
                            grv.Columns["DINH_MUC"].VisibleIndex = 4;

                            break;
                        }
                    case "grvMay":
                        {
                            grv.Columns["MS_MAY"].Width = 150;
                            grv.Columns["TEN_MAY"].Width = 280;
                            grv.Columns["MS_MAY"].VisibleIndex = 1;
                            grv.Columns["TEN_MAY"].VisibleIndex = 2;
                            break;
                        }
                    case "grvDownTimeType":
                        {
                            //ID, DownTimeTypeName, DownTimeTypeNameA, DownTimeTypeNameH, Note
                            grv.Columns["ID"].Visible = false;
                            grv.Columns["DownTimeTypeName"].Width = 200;
                            grv.Columns["DownTimeTypeNameA"].Width = 200;
                            grv.Columns["DownTimeTypeNameH"].Width = 200;
                            grv.Columns["Note"].Width = 200;

                            grv.Columns["DownTimeTypeName"].VisibleIndex = 1;
                            grv.Columns["DownTimeTypeNameA"].VisibleIndex = 2;
                            grv.Columns["DownTimeTypeNameH"].VisibleIndex = 3;
                            grv.Columns["Note"].VisibleIndex = 4;
                            break;
                        }
                    case "grvDownTimeCause":
                        {
                            grv.Columns["MS_NGUYEN_NHAN"].Visible = false;
                            grv.Columns["DownTimeTypeID"].Visible = false;
                            grv.Columns["MAC_DINH"].Visible = false;
                            grv.Columns["Planned"].Visible = false;

                            grv.Columns["TEN_NGUYEN_NHAN"].Width = 200;
                            grv.Columns["TEN_NGUYEN_NHAN_ANH"].Width = 200;
                            grv.Columns["DownTimeTypeName"].Width = 200;
                            grv.Columns["HU_HONG"].Width = 50;
                            grv.Columns["BTDK"].Width = 50;
                            grv.Columns["CauseCode"].Width = 150;
                            grv.Columns["StopTypeName"].Width = 50;

                            grv.Columns["CauseCode"].VisibleIndex = 1;
                            grv.Columns["TEN_NGUYEN_NHAN"].VisibleIndex = 2;
                            grv.Columns["TEN_NGUYEN_NHAN_ANH"].VisibleIndex = 3;
                            grv.Columns["DownTimeTypeName"].VisibleIndex = 4;
                            grv.Columns["HU_HONG"].VisibleIndex = 5;
                            grv.Columns["BTDK"].VisibleIndex = 6;
                            grv.Columns["StopTypeName"].VisibleIndex = 7;

                            break;
                        }
                    case "grvPrRunDetails":
                        {
                            grv.Columns["DetailID"].Visible = false;

                            grv.Columns["PrOID"].Width = 90;
                            grv.Columns["ItemCode"].Width = 90;
                            grv.Columns["ItemID"].Width = 90;
                            grv.Columns["MS_HE_THONG"].Width = 100;
                            grv.Columns["MS_MAY"].Width = 120;
                            grv.Columns["TEN_MAY"].Width = 150;
                            grv.Columns["OperatorID"].Width = 90;
                            grv.Columns["StartTime"].Width = 140;
                            grv.Columns["EndTime"].Width = 140;
                            grv.Columns["SumMinute"].Width = 70;
                            grv.Columns["ActualQuantity"].Width = 90;
                            grv.Columns["UOM"].Width = 90;
                            grv.Columns["ConvertQuantity"].Width = 150;
                            grv.Columns["DefectQuantity"].Width = 90;
                            grv.Columns["ActualSpeed"].Width = 90;
                            grv.Columns["StandardSpeed"].Width = 90;
                            grv.Columns["StandardOutput"].Width = 90;
                            grv.Columns["WorkingCycle"].Width = 90;
                            grv.Columns["NumberPerCycle"].Width = 90;

                            grv.Columns["PrOID"].VisibleIndex = 1;

                            grv.Columns["ItemCode"].VisibleIndex = 2;
                            grv.Columns["ItemID"].VisibleIndex = 3;
                            grv.Columns["MS_HE_THONG"].VisibleIndex = 4;
                            grv.Columns["MS_MAY"].VisibleIndex = 5;
                            grv.Columns["TEN_MAY"].VisibleIndex = 6;
                            grv.Columns["OperatorID"].VisibleIndex = 7;
                            grv.Columns["StartTime"].VisibleIndex = 8;
                            grv.Columns["EndTime"].VisibleIndex = 9;
                            grv.Columns["SumMinute"].VisibleIndex = 10;
                            grv.Columns["ActualQuantity"].VisibleIndex = 11;
                            grv.Columns["UOM"].VisibleIndex = 12;
                            grv.Columns["ConvertQuantity"].VisibleIndex = 13;
                            grv.Columns["DefectQuantity"].VisibleIndex = 14;
                            grv.Columns["ActualSpeed"].VisibleIndex = 15;
                            grv.Columns["StandardSpeed"].VisibleIndex = 16;
                            grv.Columns["StandardOutput"].VisibleIndex = 17;
                            grv.Columns["WorkingCycle"].VisibleIndex = 18;
                            grv.Columns["NumberPerCycle"].VisibleIndex = 19;

                            break;
                        }
                    case "grvProDuctRun":
                        {
                            //ID, Code, StartTime, EndTime, CaSTT, Note
                            grv.Columns["ID"].Visible = false;
                            grv.Columns["CaSTT"].Visible = false;
                            grv.Columns["EndTime"].Visible = false;
                            grv.Columns["Note"].Visible = false;

                            grv.Columns["Code"].Width = 120;
                            grv.Columns["EndTime"].Width = 150;

                            grv.Columns["Code"].VisibleIndex = 1;
                            grv.Columns["EndTime"].Width = 2;
                            break;
                        }
                    case "grvItem":
                        {
                            grv.Columns["ID"].Visible = false;
                            grv.Columns["IDItemGroup"].Visible = false;
                            grv.Columns["Description"].Visible = false;
                            grv.Columns["UOMConverionGroupID"].Visible = false;
                            grv.Columns["UOM"].Visible = false;
                            grv.Columns["ItemCode"].Width = 100;
                            grv.Columns["ItemName"].Width = 200;
                            grv.Columns["ItemCode"].VisibleIndex = 1;
                            grv.Columns["ItemName"].VisibleIndex = 2;
                            break;
                        }
                    case "grvItemMay":
                        {
                            grv.Columns["DeviceID"].VisibleIndex = 0;
                            grv.Columns["MS_MAY"].VisibleIndex = 1;
                            grv.Columns["StandardSpeed"].VisibleIndex = 2;
                            grv.Columns["CapacityUOM"].VisibleIndex = 3;

                            grv.Columns["DeviceID"].Width = 150;
                            grv.Columns["MS_MAY"].Width = 300;
                            grv.Columns["StandardSpeed"].Width = 120;
                            grv.Columns["CapacityUOM"].Width = 120;

                            grv.Columns["MS_DV_TG_Output"].Visible = false;
                            grv.Columns["StandardOutput"].Visible = false;
                            grv.Columns["DataCollectionCycle"].Visible = false;
                            grv.Columns["DownTimeRecord"].Visible = false;
                            grv.Columns["WorkingCycle"].Visible = false;
                            grv.Columns["NumberPerCyle"].Visible = false;
                            grv.Columns["TimeSendMgs"].Visible = false;
                            grv.Columns["MS_DV_TG_Speed"].Visible = false;

                            break;
                        }
                    case "grvGroup":
                        {
                            grv.Columns["ID"].Visible = false;
                            grv.Columns["GroupNameA"].Visible = false;
                            grv.Columns["GroupNameH"].Visible = false;
                            grv.Columns["BasedUOMID"].Visible = false;
                            grv.Columns["Note"].Visible = false;
                            grv.Columns["CapacityUOM"].Visible = false;
                            break;
                        }
                    case "grvGroupDetails":
                        {
                            grv.Columns["ID"].Visible = false;
                            grv.Columns["UOMConversionGroupID"].Visible = false;

                            grv.Columns["UOMQuantity"].Width = 100;
                            grv.Columns["UOMID"].Width = 100;
                            grv.Columns["BasedUOMQuantity"].Width = 100;
                            grv.Columns["BasedUOMID"].Width = 100;
                            grv.Columns["Note"].Width = 150;

                            grv.Columns["UOMQuantity"].VisibleIndex = 1;
                            grv.Columns["UOMID"].VisibleIndex = 2;
                            grv.Columns["BasedUOMQuantity"].VisibleIndex = 3;
                            grv.Columns["BasedUOMID"].VisibleIndex = 4;
                            grv.Columns["Note"].VisibleIndex = 5;


                            break;
                        }
                    case "grvProDuctOD":
                        {
                            grv.Columns["ID"].Visible = false;
                            grv.Columns["DueDate"].Visible = false;
                            grv.Columns["Status"].Visible = false;
                            grv.Columns["Note"].Visible = false;
                            grv.Columns["PrOrNumber"].Width = 120;
                            grv.Columns["OrderDate"].Width = 110;
                            grv.Columns["StartDate"].Width = 110;

                            grv.Columns["PrOrNumber"].VisibleIndex = 1;
                            grv.Columns["OrderDate"].VisibleIndex = 2;
                            grv.Columns["StartDate"].VisibleIndex = 3;
                            break;
                        }
                    case "grvSchedule":
                        {
                            grv.Columns["DetailsID"].Visible = false;
                            grv.Columns["PrOID"].Visible = false;
                            grv.Columns["ScheduleID"].Visible = false;
                            grv.Columns["MS_TO"].Width = 90;
                            grv.Columns["MS_HE_THONG"].Width = 90;
                            grv.Columns["MS_MAY"].Width = 120;
                            grv.Columns["BOMVersion"].Width = 90;
                            grv.Columns["PlannedQuantity"].Width = 90;
                            grv.Columns["SoCaSX"].Width = 90;
                            grv.Columns["UOMID"].Width = 90;
                            grv.Columns["PlannedStartTime"].VisibleIndex = 110;
                            grv.Columns["CaID"].Width = 90;
                            grv.Columns["DueTime"].Width = 110;
                            grv.Columns["CaIDKT"].Width = 90;
                            grv.Columns["ActualQuantity"].Width = 90;
                            grv.Columns["StandardOutput"].Width = 90;
                            grv.Columns["MS_DV_TG_Output"].Width = 90;
                            grv.Columns["MS_DV_TG_Speed"].Width = 90;
                            grv.Columns["WorkingCycle"].Width = 90;
                            grv.Columns["NumberPerCycle"].Width = 90;
                            grv.Columns["DownTimeRecord"].Width = 90;
                            grv.Columns["SumStandardOutput"].Width = 90;
                            grv.Columns["CapacityUOM"].Width = 90;


                            grv.Columns["MS_TO"].VisibleIndex = 1;
                            grv.Columns["MS_HE_THONG"].VisibleIndex = 2;
                            grv.Columns["MS_MAY"].VisibleIndex = 3;
                            grv.Columns["BOMVersion"].VisibleIndex = 4;
                            grv.Columns["PlannedQuantity"].VisibleIndex = 5;
                            grv.Columns["SoCaSX"].VisibleIndex = 6;
                            grv.Columns["UOMID"].VisibleIndex = 7;
                            grv.Columns["PlannedStartTime"].VisibleIndex = 8;
                            grv.Columns["CaID"].VisibleIndex = 9;
                            grv.Columns["DueTime"].VisibleIndex = 10;
                            grv.Columns["CaIDKT"].VisibleIndex = 11;
                            grv.Columns["ActualQuantity"].VisibleIndex = 12;
                            grv.Columns["StandardOutput"].VisibleIndex = 13;
                            grv.Columns["MS_DV_TG_Output"].VisibleIndex = 14;
                            grv.Columns["MS_DV_TG_Speed"].VisibleIndex = 15;
                            grv.Columns["WorkingCycle"].VisibleIndex = 16;
                            grv.Columns["NumberPerCycle"].VisibleIndex = 17;
                            grv.Columns["DownTimeRecord"].VisibleIndex = 18;
                            grv.Columns["SumStandardOutput"].VisibleIndex = 19;
                            grv.Columns["CapacityUOM"].VisibleIndex = 20;
                            break;
                        }
                    case "grvPrODetails":
                        {
                            grv.Columns["DetailsID"].Visible = false;
                            grv.Columns["PrOID"].Visible = false;
                            grv.Columns["ItemID"].Width = 100;
                            grv.Columns["ItemName"].Width = 120;
                            grv.Columns["UOMID"].Width = 110;
                            grv.Columns["PlannedStartTime"].Width = 120;
                            grv.Columns["DueDate"].Width = 120;
                            grv.Columns["PlannedQuantity"].Width = 100;
                            grv.Columns["ModerQuantity"].Width = 100;
                            grv.Columns["AllocatedQuantity"].Width = 100;


                            grv.Columns["ItemID"].VisibleIndex = 1;
                            grv.Columns["ItemName"].VisibleIndex = 2;
                            grv.Columns["UOMID"].VisibleIndex = 3;
                            grv.Columns["PlannedStartTime"].VisibleIndex = 4;
                            grv.Columns["DueDate"].VisibleIndex = 5;
                            grv.Columns["PlannedQuantity"].VisibleIndex = 6;
                            grv.Columns["ModerQuantity"].VisibleIndex = 7;
                            grv.Columns["AllocatedQuantity"].VisibleIndex = 8;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                MyMenuItemSave(null, null, grv);
                //Commons.Modules..DeleteSubKeyTree(grdItemMay);
                return;
            }
            catch
            {
            }
        }

        public void MyMenuItemSave(System.Object sender, System.EventArgs e, GridView grv)
        {
            // SAVE  
            Stream str = new System.IO.MemoryStream();
            grv.SaveLayoutToStream(str);
            str.Seek(0, System.IO.SeekOrigin.Begin);
            StreamReader reader = new StreamReader(str);
            string text = reader.ReadToEnd();
            //kiểm tra xem tồn tại chưa có thì update chưa có thì inser
            if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.DINH_DANG_LUOI WHERE MS_LUOI ='" + grv.Tag + "'")) == 0)
            {
                //insert
                SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "INSERT INTO dbo.DINH_DANG_LUOI ( MS_LUOI, DINH_DANG_LUOI )VALUES  ( N'" + grv.Tag + "',N'" + text + "')");
            }
            else
            {
                //update
                SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.DINH_DANG_LUOI SET DINH_DANG_LUOI = '" + text + "' WHERE MS_LUOI  = '" + grv.Tag + "'");
            }
        }

        public void ExportToExcel(System.Object sender, System.EventArgs e, GridView grv)
        {
            // SAVE  
            grv.BestFitColumns();
            grv.OptionsPrint.AutoWidth = false;
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            var options = new XlsExportOptionsEx();
            options.ExportType = ExportType.WYSIWYG;
            grv.ExportToXls(sPath, options);
            Process.Start(sPath);
        }

        public void MLoadNNXtraGrid(DevExpress.XtraGrid.Views.Grid.GridView grv, string fName)
        {
            //DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repoMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            //repoMemo.WordWrap = true;
            //grv.OptionsView.RowAutoHeight = true;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in grv.Columns)
            {
                if (col.Visible)
                {
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    col.AppearanceHeader.Options.UseTextOptions = true;
                    try
                    {
                        Convert.ToDateTime(col.FieldName);
                    }
                    catch
                    {
                        col.Caption = Modules.ObjLanguages.GetLanguage(Modules.ModuleName, fName, col.FieldName, Modules.TypeLanguage);
                    }
                }
            }
        }

        public void MLoadNNXtraGrid(DevExpress.XtraGrid.Views.Grid.GridView grv, string fName, int NN)
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in grv.Columns)
            {
                if (col.Visible)
                {
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    col.AppearanceHeader.Options.UseTextOptions = true;
                    col.Caption = Modules.ObjLanguages.GetLanguage(Modules.ModuleName, fName, col.FieldName, NN);
                }
            }
        }
        #endregion

        #region SaveGrid


        public void MSaveResertGrid(DevExpress.XtraGrid.Views.Grid.GridView grv, string fName)
        {
            try
            {
                //kiểm tra có trong table định dạng lưới chưa có thì load
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT count(*) FROM dbo.DINH_DANG_LUOI WHERE MS_LUOI = '" + fName.ToString() + "'")) == 1)
                {
                    // RESTORE  
                    var layoutString = (string)SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT DINH_DANG_LUOI FROM dbo.DINH_DANG_LUOI WHERE MS_LUOI = '" + fName.ToString() + "'");
                    Stream s = new MemoryStream();
                    StreamWriter sw = new StreamWriter(s);
                    sw.Write(layoutString);
                    sw.Flush();
                    s.Seek(0, SeekOrigin.Begin);
                    grv.RestoreLayoutFromStream(s);
                    sw.Close();
                }
                else
                {
                    // SAVE  
                    SaveLayOutGrid(grv, fName);
                }
                grv.PopupMenuShowing += delegate (object a, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs b) { Grv_PopupMenuShowing(grv, b, grv, fName); };
            }
            catch
            {
            }
        }

        private void MenuItemReset_Click(object sender, EventArgs e, GridView grv, string fName)
        {
            try
            {
                //update
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.DINH_DANG_LUOI SET DINH_DANG = MAC_DINH WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + grv.Name + "'");


                string text = (Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT DINH_DANG FROM dbo.DINH_DANG_LUOI WHERE TEN_FORM = '" + fName + "' AND TEN_GRID = '" + grv.Name + "'")));
                byte[] byteArray = Encoding.ASCII.GetBytes(text);
                MemoryStream stream = new MemoryStream(byteArray);
                grv.RestoreLayoutFromStream(stream);
                MLoadNNXtraGrid(grv, fName);
            }
            catch { }
        }

        public void MyMenuItemSave(System.Object sender, System.EventArgs e, GridView grv, string fName)
        {
            // SAVE  
            SaveLayOutGrid(grv, fName);
        }
        private void SaveLayOutGrid(GridView grv, string fName)
        {
            // SAVE  grid.SaveLayoutToStream(s);
            try
            {
                Stream str = new System.IO.MemoryStream();
                grv.SaveLayoutToStream(str);
                str.Seek(0, System.IO.SeekOrigin.Begin);
                StreamReader reader = new StreamReader(str);
                string text = reader.ReadToEnd();
                //kiểm tra xem tồn tại chưa có thì update chưa có thì inser
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.DINH_DANG_LUOI WHERE MS_LUOI = '" + fName.ToString() + "'")) == 0)
                {
                    //insert
                    SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "INSERT INTO dbo.DINH_DANG_LUOI ( MS_LUOI, DINH_DANG_LUOI )VALUES  ( N'" + fName.ToString() + "',N'" + text + "')");
                }
                else
                {
                    //update
                    SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.DINH_DANG_LUOI SET DINH_DANG_LUOI = '" + text + "' WHERE MS_LUOI  = '" + fName.ToString() + "'");
                }
            }
            catch { }
        }

        private void Grv_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e, GridView grv, string fName)
        {
            if (e.MenuType != DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
                return;
            try
            {
                DevExpress.XtraGrid.Menu.GridViewMenu headerMenu = (DevExpress.XtraGrid.Menu.GridViewMenu)e.Menu;
                if (Commons.Modules.UserName.ToLower() == "admin")
                {
                    DevExpress.Utils.Menu.DXMenuItem menuItem = new DevExpress.Utils.Menu.DXMenuItem("Reset Grid");
                    menuItem.BeginGroup = true;
                    menuItem.Tag = e.Menu;
                    menuItem.Click += delegate (object a, EventArgs b) { MenuItemReset_Click(null, null, grv); };
                    headerMenu.Items.Add(menuItem);
                    // menu resetgrid
                    DevExpress.Utils.Menu.DXMenuItem menuSave = new DevExpress.Utils.Menu.DXMenuItem("Save Grid");
                    menuSave.BeginGroup = true;
                    menuSave.Tag = e.Menu;
                    menuSave.Click += delegate (object a, EventArgs b) { MyMenuItemSave(null, null, grv); };
                    headerMenu.Items.Add(menuSave);

                }
                // menu export to excel
                DevExpress.Utils.Menu.DXMenuItem menuExport = new DevExpress.Utils.Menu.DXMenuItem("Export to Excel");
                menuExport.BeginGroup = true;
                menuExport.Tag = e.Menu;
                menuExport.Click += delegate (object a, EventArgs b) { ExportToExcel(null, null, grv); };
                headerMenu.Items.Add(menuExport);
            }
            catch
            {
            }
        }




        #endregion

        #region Load hình database
        public byte[] SaveHinh(Image inImg)
        {
            if (inImg == null) return null;
            //ImageConverter imgCon = new ImageConverter();
            //return (byte[])imgCon.ConvertTo(inImg, typeof(byte[]));

            ImageConverter imgCon = new ImageConverter();
            byte[] imgConvert = (byte[])imgCon.ConvertTo(inImg, typeof(byte[]));
            byte[] currentByteImageArray = imgConvert;
            double scale = 1f;
            MemoryStream inputMemoryStream = new MemoryStream(imgConvert);
            Image fullsizeImage = Image.FromStream(inputMemoryStream);
            while (currentByteImageArray.Length > 20000)
            {
                Bitmap fullSizeBitmap = new Bitmap(fullsizeImage, new Size((int)(fullsizeImage.Width * scale), (int)(fullsizeImage.Height * scale)));
                MemoryStream resultStream = new MemoryStream();

                fullSizeBitmap.Save(resultStream, fullsizeImage.RawFormat);

                currentByteImageArray = resultStream.ToArray();
                resultStream.Dispose();
                resultStream.Close();
                scale -= 0.05f;
            }
            return currentByteImageArray;
        }
        public Image LoadHinh(Byte[] hinh)
        {
            Byte[] data = new Byte[0];
            data = (Byte[])(hinh);
            MemoryStream mem = new MemoryStream(data);
            return Image.FromStream(mem);
        }

        #endregion
        #region thay doi ngon ngu xtralabel
        public void NgonNguLabel(Control control, string sName)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + sName + "' AND SUBSTRING(KEYWORD,1,3) = 'lbl'"));

            List<Control> c = control.Controls.OfType<DevExpress.XtraEditors.LabelControl>().Cast<Control>().ToList();
            for (int i = 0; i <= c.Count - 1; i++)
            {
                if (c[i].Name.Length > 4)
                    c[i].Text = GetNN(dtTmp, c[i].Name, sName);
            }

        }
        public void NgonNguLabel(Control control, XtraUserControl UCName)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + UCName.Name + "' AND SUBSTRING(KEYWORD,1,3) = 'lbl' "));

            List<Control> c = control.Controls.OfType<DevExpress.XtraEditors.LabelControl>().Cast<Control>().ToList();
            for (int i = 0; i <= c.Count - 1; i++)
            {
                if (c[i].Name.Length > 4)
                    c[i].Text = GetNN(dtTmp, c[i].Name, UCName.Name);
            }

        }

        public void NgonNguLabel(Control control, XtraForm frmName)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + frmName.Name + "' AND SUBSTRING(KEYWORD,1,3) = 'lbl' "));
            frmName.Text = GetNN(dtTmp, frmName.Name, frmName.Name);

            List<Control> c = control.Controls.OfType<DevExpress.XtraEditors.LabelControl>().Cast<Control>().ToList();
            for (int i = 0; i <= c.Count - 1; i++)
            {
                if (c[i].Name.Length > 4)
                    c[i].Text = GetNN(dtTmp, c[i].Name, frmName.Name);
            }

        }
        #endregion

        #region thay doi ngon ngu Botton
        public void NgonNguButton(Control control, string sName)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + sName + "' AND SUBSTRING(KEYWORD,1,3) = 'btn' "));

            List<Control> c = control.Controls.OfType<DevExpress.XtraEditors.SimpleButton>().Cast<Control>().ToList();
            for (int i = 0; i <= c.Count - 1; i++)
            {
                if (c[i].Name.Length > 4)
                    c[i].Text = GetNN(dtTmp, c[i].Name, sName);
            }
        }
        public void NgonNguRadioGroup(RadioGroup control, string sName)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + sName + "' AND SUBSTRING(KEYWORD,1,3) = 'rdo' "));
            for (int i = 0; i <= control.Properties.Items.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(control.Properties.Items[i].Value.ToString()))
                    control.Properties.Items[i].Value = control.Properties.Items[i].Description;
                control.Properties.Items[i].Description = GetNN(dtTmp, control.Properties.Items[i].Value.ToString(), sName);
            }
        }
        public void NgonNguButton(Control control, XtraForm frmName)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + frmName.Name + "' AND SUBSTRING(KEYWORD,1,3) = 'btn' "));
            frmName.Text = GetNN(dtTmp, frmName.Name, frmName.Name);

            List<Control> c = control.Controls.OfType<DevExpress.XtraEditors.SimpleButton>().Cast<Control>().ToList();
            for (int i = 0; i <= c.Count - 1; i++)
            {
                if (c[i].Name.Length > 4)
                    c[i].Text = GetNN(dtTmp, c[i].Name, frmName.Name);
            }
        }

        public void NgonNguButton(Control control, XtraUserControl UCName)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + UCName.Name + "' "));


            List<Control> c = control.Controls.OfType<DevExpress.XtraEditors.SimpleButton>().Cast<Control>().ToList();
            for (int i = 0; i <= c.Count - 1; i++)
            {
                if (c[i].Name.Length > 4)
                    c[i].Text = GetNN(dtTmp, c[i].Name, UCName.Name);
            }

        }
        #endregion

        #region thay doi nn
        public void ThayDoiNN(XtraForm frm)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + frm.Name + "' "));
            frm.Text = GetNN(dtTmp, frm.Name, frm.Name);
            List<Control> resultControlList = new List<Control>();
            GetControlsCollection(frm, ref resultControlList, null);
            foreach (Control control1 in resultControlList)
            {
                try
                {
                    DoiNN(control1, frm, dtTmp);
                }
                catch
                { }
            }
        }

        public void ThayDoiNN(XtraReport report)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + report.Tag.ToString() + "' "));

            foreach (DevExpress.XtraReports.UI.Band band in report.Bands)
            {
                foreach (DevExpress.XtraReports.UI.SubBand subband in band.SubBands)
                {
                    foreach (DevExpress.XtraReports.UI.XRControl control in subband)
                    {
                        if (control.GetType() == typeof(DevExpress.XtraReports.UI.XRTable))
                        {
                            DevExpress.XtraReports.UI.XRTable table = (DevExpress.XtraReports.UI.XRTable)control;
                            foreach (DevExpress.XtraReports.UI.XRTableRow row in table)
                            {
                                foreach (DevExpress.XtraReports.UI.XRTableCell cell in row)
                                {
                                    cell.Text = GetNN(dtTmp, cell.Name, report.Tag.ToString());// translation processing here
                                }
                            }
                        }
                        else
                        {
                            control.Text = GetNN(dtTmp, control.Name, report.Tag.ToString());
                        }
                    }
                }
                foreach (DevExpress.XtraReports.UI.XRControl control in band)
                {
                    if (control.GetType() == typeof(DevExpress.XtraReports.UI.XRTable))
                    {
                        DevExpress.XtraReports.UI.XRTable table = (DevExpress.XtraReports.UI.XRTable)control;
                        foreach (DevExpress.XtraReports.UI.XRTableRow row in table)
                        {
                            foreach (DevExpress.XtraReports.UI.XRTableCell cell in row)
                            {
                                cell.Text = GetNN(dtTmp, cell.Name, report.Tag.ToString());// translation processing here
                            }
                        }
                    }
                    else
                    {
                        control.Text = GetNN(dtTmp, control.Name, report.Tag.ToString());
                    }

                }

            }
        }

        public void ThayDoiNN(XtraUserControl frm)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + frm.Name + "' "));
            frm.Text = GetNN(dtTmp, frm.Name, frm.Name);
            List<Control> resultControlList = new List<Control>();
            GetControlsCollection(frm, ref resultControlList, null);
            foreach (Control control1 in resultControlList)
            {
                try
                {
                    DoiNN(control1, frm, dtTmp);
                }
                catch
                { }
            }
            try
            {
                //MTabOrder MTab = new MTabOrder(frm);
                //MTab.MSetTabOrder(MTabOrder.TabScheme.AcrossFirst);
            }
            catch
            {
            }
        }

        public void ThayDoiNN(XtraUserControl frm, WindowsUIButtonPanel btnWinUIB)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + frm.Name + "' "));
            frm.Text = GetNN(dtTmp, frm.Name, frm.Name);
            List<Control> resultControlList = new List<Control>();
            GetControlsCollection(frm, ref resultControlList, null);
            foreach (Control control in resultControlList)
            {
                try
                {
                    DoiNN(control, frm, dtTmp);
                }
                catch
                { }
            }
            foreach (Control control1 in resultControlList)
            {
                try
                {
                    DoiNN(control1, frm, dtTmp);
                }
                catch
                { }
            }
            try
            {
                foreach (WindowsUIButton btn in btnWinUIB.Buttons)
                {
                    btn.Caption = GetNN(dtTmp, btn.Tag.ToString(), frm.Name);
                }
            }
            catch
            { }
        }
        public void ThayDoiNN(XtraForm frm, LayoutControlGroup group)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + frm.Name + "' "));
            frm.Text = GetNN(dtTmp, frm.Name, frm.Name);
            //load nn control bên trong
            LoadNNGroupControl(frm, group, dtTmp);
            //load nn windowbitton

        }

        private void LoadNNGroupControl(XtraForm frm, LayoutControlGroup group, DataTable dtTmp)
        {
            foreach (var gr in group.Items)
            {
                if (gr.GetType().Name == "LayoutControlGroup")
                {

                    LayoutControlGroup gro = (LayoutControlGroup)gr;
                    gro.Text = GetNN(dtTmp, gro.Name, frm.Name);
                    LoadNNGroupControl(frm, (LayoutControlGroup)gr, dtTmp);
                }
                else
                {
                    try
                    {
                        LayoutControlItem control1 = (LayoutControlItem)gr;
                        try
                        {
                            if (control1.Control.GetType().Name.ToLower() == "checkedit")
                            {
                                control1.Control.Text = GetNN(dtTmp, control1.Name, frm.Name);
                            }
                            else
                            if (control1.Control.GetType().Name.ToLower() == "radiogroup")
                            {
                                DoiNN(control1.Control, frm, dtTmp);
                            }

                            else
                            {
                                control1.Text = GetNN(dtTmp, control1.Name, frm.Name);
                            }
                            control1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 2, 2);
                            ((DevExpress.XtraEditors.BaseEdit)control1.Control).EnterMoveNextControl = true;
                        }
                        catch
                        { }
                    }
                    catch (Exception)
                    {
                    }
                }

            }
        }

        public void ThayDoiNN(XtraUserControl frm, LayoutControlGroup group)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + frm.Name + "' "));
            frm.Text = GetNN(dtTmp, frm.Name, frm.Name);
            //load nn control bên trong
            LoadNNGroupControl(frm, group, dtTmp);
            //load nn windowbitton
        }

        private void LoadNNGroupControl(XtraUserControl frm, LayoutControlGroup group, DataTable dtTmp)
        {
            //TabbedControlGroup
            foreach (var gr in group.Items)
            {
                if (gr.GetType().Name == "LayoutControlGroup")
                {
                    LayoutControlGroup gro = (LayoutControlGroup)gr;
                    gro.Text = GetNN(dtTmp, gro.Name, frm.Name);
                    LoadNNGroupControl(frm, (LayoutControlGroup)gr, dtTmp);
                }
                else
                {
                    try
                    {
                        LayoutControlItem control1 = (LayoutControlItem)gr;
                        try
                        {
                            if (control1.Control.GetType().Name.ToLower() == "checkedit")
                            {
                                control1.Control.Text = GetNN(dtTmp, control1.Name, frm.Name);
                            }
                            else
                            if (control1.Control.GetType().Name.ToLower() == "radiogroup")
                            {
                                DoiNN(control1.Control, frm, dtTmp);
                            }

                            else
                            {
                                control1.Text = GetNN(dtTmp, control1.Name, frm.Name);
                            }
                            control1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 2, 2);
                            ((DevExpress.XtraEditors.BaseEdit)control1.Control).EnterMoveNextControl = true;
                        }
                        catch
                        { }
                    }
                    catch (Exception)
                    {
                    }
                }

            }
        }


        public void ThayDoiNN(XtraUserControl frm, LayoutControlGroup group, TabbedControlGroup Tab, WindowsUIButtonPanel btnWinUIB)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + frm.Name + "' "));
            frm.Text = GetNN(dtTmp, frm.Name, frm.Name);
            LoadNNGroupControl(frm, group, dtTmp);
            foreach (LayoutControlGroup item in Tab.TabPages)
            {
                LoadNNGroupControl(frm, item, dtTmp);
            }
            foreach (LayoutGroup item in Tab.TabPages)
            {
                item.Text = GetNN(dtTmp, item.Name, frm.Name);
            }
            try
            {
                foreach (WindowsUIButton btn in btnWinUIB.Buttons)
                {
                    btn.Caption = GetNN(dtTmp, btn.Tag.ToString(), frm.Name);
                }
            }
            catch
            { }
        }
        private void LoadNNGroupControl(LayoutControlGroup group, DataTable dtTmp, string name)
        {
            group.Text = GetNN(dtTmp, group.Name, name);
            foreach (var gr in group.Items)
            {
                if (gr.GetType().Name == "LayoutControlGroup")
                    LoadNNGroupControl((LayoutControlGroup)gr, dtTmp, name);
                else
                {
                    try
                    {
                        LayoutControlItem control1 = (LayoutControlItem)gr;
                        control1.Text = GetNN(dtTmp, control1.Name, name);
                        control1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 2, 2);
                        ((DevExpress.XtraEditors.BaseEdit)control1.Control).EnterMoveNextControl = true;

                    }
                    catch (Exception)
                    {
                    }
                }

            }
        }
        public void ThayDoiNN(XtraUserControl frm, List<LayoutControlGroup> group, WindowsUIButtonPanel btnWinUIB)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD , CASE " + Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'" + frm.Name + "' "));
            frm.Text = GetNN(dtTmp, frm.Name, frm.Name);
            List<Control> resultControlList = new List<Control>();
            GetControlsCollection(frm, ref resultControlList, null);
            foreach (Control control in resultControlList)
            {
                try
                {
                    DoiNN(control, frm, dtTmp);
                }
                catch
                { }
            }

            try
            {
                foreach (LayoutControlGroup gr in group)
                {
                    LoadNNGroupControl(gr, dtTmp, frm.Name);
                }
            }
            catch
            {
            }
            try
            {
                foreach (WindowsUIButton btn in btnWinUIB.Buttons)
                {
                    btn.Caption = GetNN(dtTmp, btn.Tag.ToString(), frm.Name);
                }
            }
            catch
            { }
        }
        public void LoadImageDev(DevExpress.XtraEditors.SimpleButton CtlDev)
        {
            string sTenControl;
            sTenControl = CtlDev.Name.ToUpper();
            CtlDev.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            try
            {
                if (sTenControl.Contains("IMPORT"))
                {
                    CtlDev.Image = Commons.Properties.Resources.Import; return;
                }
                if (sTenControl.Contains("THEM") | sTenControl.Contains("ADD"))
                {
                    CtlDev.Image = Commons.Properties.Resources.Add; return;
                }
                if (sTenControl.Contains("SUA") | sTenControl.Contains("EDIT"))
                {
                    CtlDev.Image = Commons.Properties.Resources.Edit; return;
                }
                if (sTenControl.Contains("DEL") | sTenControl.Contains("XOA") | sTenControl.Contains("DELETE"))
                {
                    CtlDev.Image = Commons.Properties.Resources.Delete; return;
                }
                if (sTenControl.Contains("THOAT") | sTenControl.Contains("EXIT"))
                {
                    CtlDev.Image = Commons.Properties.Resources.Thoat; return;
                }
                if (sTenControl.Contains("LUA") | sTenControl.Contains("LUU") | sTenControl.Contains("GHI") | sTenControl.Contains("SAVE"))
                {
                    CtlDev.Image = Commons.Properties.Resources.Save; return;
                }
                if (sTenControl.Contains("KHONG") | sTenControl.Contains("CANCEL"))
                {
                    CtlDev.Image = Commons.Properties.Resources.Cancel; return;
                }
                if (sTenControl.Contains("SCHEDULE"))
                {
                    CtlDev.Image = Commons.Properties.Resources.Schedule; return;
                }

                if (sTenControl.Contains("IN") | sTenControl.Contains("PRINT"))
                {
                    CtlDev.Image = Commons.Properties.Resources.Print; return;
                }
                if (sTenControl.Contains("EXCEL") | sTenControl.Contains("XUATEXCEL"))
                {
                    CtlDev.Image = Commons.Properties.Resources.Excel; return;
                }
                if (sTenControl.Contains("EXCUTE") | sTenControl.Contains("EXECUTE") | sTenControl.Contains("THUCHIEN"))
                {
                    CtlDev.Image = Commons.Properties.Resources.ThucHien; return;
                }
                if (sTenControl.Contains("TROVE") | sTenControl.Contains("RETURN"))
                {
                    CtlDev.Image = Commons.Properties.Resources.TroVe; return;
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void DoiNN(Control Ctl, Form frm, DataTable dtNgu)
        {
            // iFontsize
            // sFontForm
            try
            {
                switch (Ctl.GetType().Name.ToString())
                {
                    case "LookUpEdit":
                        {
                            DevExpress.XtraEditors.LookUpEdit CtlDev;
                            CtlDev = (DevExpress.XtraEditors.LookUpEdit)Ctl;
                            CtlDev.Properties.NullText = "";
                            break;
                        }

                    case "Label":
                    case "RadioButton":
                    case "CheckBox":
                        {
                            if (Ctl.Name.ToUpper().Substring(0, 4) != "NONN" & Ctl.Name.Length > 4)
                                Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name);// Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, Ctl.Name, Modules.TypeLanguage)

                            if (Ctl.GetType().Name.ToString() == "Label")
                            {
                                try
                                {
                                    Ctl.MouseDoubleClick -= this.Label_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    //Ctl.MouseDoubleClick += this.Label_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                            }

                            if (Ctl.GetType().Name.ToString() == "RadioButton")
                            {
                                try
                                {
                                    //Ctl.MouseDoubleClick -= this.RadioButton_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    //Ctl.MouseDoubleClick += this.RadioButton_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                            }

                            if (Ctl.GetType().Name.ToString() == "CheckBox")
                            {
                                try
                                {
                                    //Ctl.MouseDoubleClick -= this.CheckBox_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    //Ctl.MouseDoubleClick += this.CheckBox_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                            }

                            break;
                        }

                    //case "GroupBox":
                    //    {
                    //        Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name);
                    //        if ((Ctl.Name == "grbList"))
                    //        {
                    //            DataTable dtItem = new DataTable();
                    //            try
                    //            {
                    //                dtItem.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "Get_lstDanhsachbaocao", Commons.Modules.UserName, -1, Commons.Modules.TypeLanguage, 1));
                    //            }
                    //            catch (Exception ex)
                    //            {
                    //            }
                    //            foreach (Control ctl1 in Ctl.Controls)
                    //            {
                    //                if ((ctl1.GetType().Name.ToLower() == "navbarcontrol"))
                    //                {
                    //                    foreach (NavBarGroup cl in (NavBarControl)ctl1.Groups)
                    //                        cl.Caption = GetNN(dtNgu, cl.Name, frm.Name);
                    //                    foreach (NavBarItem cl in (NavBarControl)ctl1.Items)
                    //                    {
                    //                        try
                    //                        {
                    //                            cl.Caption = dtItem.Select().Where(x => x("REPORT_NAME").ToString() == cl.Name).Take(1).Single()("TEN_REPORT");
                    //                        }
                    //                        catch (Exception ex)
                    //                        {
                    //                            cl.Caption = GetNN(dtNgu, cl.Name, frm.Name);
                    //                        }
                    //                    }
                    //                    break;
                    //                }
                    //            }
                    //        }
                    //        break;
                    //    }

                    case "TabPage":
                        {
                            Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name);          // Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, Ctl.Name, Modules.TypeLanguage)
                            break;
                        }

                    case "LabelControl":
                    case "CheckButton":
                    case "CheckEdit":
                    case "XtraTabPage":
                    case "GroupControl":
                        {
                            if (Ctl.Name.ToUpper().Substring(0, 4) != "NONN" & Ctl.Name.Length > 4)
                                Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name);// Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, Ctl.Name, Modules.TypeLanguage)
                            if (Ctl.GetType().Name.ToString() == "CheckEdit")
                            {
                                try
                                {
                                    //Ctl.MouseDoubleClick -= this.CheckEdit_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    //Ctl.MouseDoubleClick += this.CheckEdit_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                            }
                            if (Ctl.GetType().Name.ToString() == "LabelControl")
                            {
                                try
                                {
                                    Ctl.MouseDoubleClick += this.Label_MouseDoubleClick;
                                }
                                catch
                                {
                                }

                            }

                            break;
                        }

                    case "Button":
                        {
                            if (Ctl.Name.ToUpper().Substring(0, 4) != "NONN" & Ctl.Name.Length > 4)
                            {
                                Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name);
                                //LoadImage(Ctl);
                            }

                            break;
                        }

                    case "SimpleButton":
                        {
                            DevExpress.XtraEditors.SimpleButton CtlDev;
                            CtlDev = (DevExpress.XtraEditors.SimpleButton)Ctl;
                            if (Ctl.Name.ToUpper().Substring(0, 4) != "NONN" & Ctl.Name.Length > 4)
                            {
                                Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name);
                                LoadImageDev(CtlDev);
                            }

                            break;
                        }

                    case "RadioGroup":
                        {
                            DevExpress.XtraEditors.RadioGroup radGroup;
                            radGroup = (DevExpress.XtraEditors.RadioGroup)Ctl;
                            for (int i = 0; i <= radGroup.Properties.Items.Count - 1; i++)
                            {
                                if (string.IsNullOrEmpty(radGroup.Properties.Items[i].Value.ToString()))
                                    radGroup.Properties.Items[i].Value = radGroup.Properties.Items[i].Description;
                                radGroup.Properties.Items[i].Description = GetNN(dtNgu, radGroup.Properties.Items[i].Value.ToString(), frm.Name);          // Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, radGroup.Properties.Items(i).Description, Modules.TypeLanguage)
                            }
                            try
                            {
                                if (radGroup.SelectedIndex == -1)
                                    radGroup.SelectedIndex = 0;
                            }
                            catch
                            {
                            }

                            break;
                        }

                    case "CheckedListBoxControl":
                        {
                            DevExpress.XtraEditors.CheckedListBoxControl chkGroup;
                            chkGroup = (DevExpress.XtraEditors.CheckedListBoxControl)Ctl;

                            for (int i = 0; i <= chkGroup.Items.Count - 1; i++)
                                chkGroup.Items[i].Description = GetNN(dtNgu, chkGroup.Items[i].Description, frm.Name);// Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, chkGroup.Items(i).Description, Modules.TypeLanguage)
                            break;
                        }

                    case "XtraTabControl":
                        {
                            DevExpress.XtraTab.XtraTabControl tabControl;
                            tabControl = (DevExpress.XtraTab.XtraTabControl)Ctl;
                            for (int i = 0; i <= tabControl.TabPages.Count - 1; i++)
                                tabControl.TabPages[i].Text = GetNN(dtNgu, tabControl.TabPages[i].Name, frm.Name);
                            break;
                        }
                }
            }
            catch
            {
            }
        }

        public void DoiNNTooltip(ContextMenuStrip ctl, Form frm)
        {
            foreach (ToolStripMenuItem item in ctl.Items)
            {
                item.Text = Commons.Modules.ObjLanguages.GetLanguage(frm.Name, item.Name);
            }
        }
        public void DoiNNTooltip(ContextMenuStrip ctl, XtraUserControl frm)
        {
            foreach (ToolStripMenuItem item in ctl.Items)
            {
                item.Text = Commons.Modules.ObjLanguages.GetLanguage(frm.Name, item.Name);
            }
        }

        public Form GetParentForm(Control parent)
        {
            Form form = parent as Form;
            if (form != null)
                return form;
            if (parent != null)
                return GetParentForm(parent.Parent);
            return null/* TODO Change to default(_) if this is not a reference type */;
        }


        private void Label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control & e.Button == MouseButtons.Left)
            {
                LabelControl Ctl;
                string sText = "";
                Ctl = (LabelControl)sender;
                try
                {
                    string sName = GetParentForm(Ctl).Name.ToString(); // DirectCast(Ctl.TopLevelControl, System.Windows.Forms.ContainerControl).ActiveControl.Name.ToString
                    if ("frmReports".ToUpper() == sName.ToUpper())
                    {
                        sName = Ctl.Parent.Parent.ToString().Substring(Ctl.Parent.Parent.ProductName.Length + 1);
                        sName = "SELECT TOP 1 REPORT_NAME FROM dbo.DS_REPORT WHERE NAMES = '" + sName + "' ";
                        try
                        {
                            sName = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sName));
                        }
                        catch
                        {
                            sName = GetParentForm(Ctl).Name.ToString();
                        }
                    }
                    if (sName.ToString() == "")
                        sName = GetParentForm(Ctl).Name.ToString();
                    sText = XtraInputBox.Show(Ctl.Text, "Sửa ngôn ngữ", "");
                    if (sText == "")
                        return;
                    else if (sText == "Windows.Forms.DialogResult.Retry")
                    {
                        sText = "";
                        CapNhapNN(sName, Ctl.Name, sText, true);
                    }
                    else
                        CapNhapNN(sName, Ctl.Name, sText, false);
                    sText = " SELECT TOP 1 " + (Commons.Modules.TypeLanguage == 0 ? "VIETNAM" : "ENGLISH") + " FROM LANGUAGES WHERE FORM = '" + sName + "' AND KEYWORD = '" + Ctl.Name + "' AND MS_MODULE = 'ECOMAIN'";
                    sText = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sText));

                    Ctl.Text = sText;
                }
                catch
                {
                    sText = "";
                }
            }
        }
        private void CapNhapNN(string sForm, string sKeyWord, string sChuoi, bool bReset)
        {
            string sSql;
            if (bReset)
                sSql = "UPDATE LANGUAGES SET " + (Commons.Modules.TypeLanguage == 0 ? "VIETNAM" : "ENGLISH") + " = " + (Commons.Modules.TypeLanguage == 0 ? "VIETNAM_OR" : "ENGLISH_OR") + " WHERE FORM = '" + sForm + "' AND KEYWORD = '" + sKeyWord + "' AND MS_MODULE = 'ECOMAIN'";
            else
                sSql = "UPDATE LANGUAGES SET " + (Commons.Modules.TypeLanguage == 0 ? "VIETNAM" : "ENGLISH") + " = N'" + sChuoi + "' WHERE FORM = '" + sForm + "' AND KEYWORD = '" + sKeyWord + "' AND MS_MODULE = 'ECOMAIN'";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
        }

        public void DoiNN(Control Ctl, XtraUserControl frm, DataTable dtNgu)
        {
            // iFontsize
            // sFontForm
            try
            {
                switch (Ctl.GetType().Name.ToString())
                {
                    case "LookUpEdit":
                        {
                            DevExpress.XtraEditors.LookUpEdit CtlDev;
                            CtlDev = (DevExpress.XtraEditors.LookUpEdit)Ctl;
                            CtlDev.Properties.NullText = "";
                            break;
                        }
                    case "Label":
                    case "LayoutControlGroup":
                    case "LabelControl":
                    case "GroupControl":
                    case "TextBoxMaskBox":
                    case "RadioButton":
                    case "CheckEdit":
                    case "CheckBox":
                        {
                            if (Ctl.Name.ToUpper().Substring(0, 4) != "NONN" & Ctl.Name.Length > 4)
                                Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name);// Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, Ctl.Name, Modules.TypeLanguage)

                            if (Ctl.GetType().Name.ToString() == "Label")
                            {
                                try
                                {
                                    //Ctl.MouseDoubleClick -= this.Label_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    //Ctl.MouseDoubleClick += this.Label_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                            }

                            if (Ctl.GetType().Name.ToString() == "RadioButton")
                            {
                                try
                                {
                                    //Ctl.MouseDoubleClick -= this.RadioButton_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    //Ctl.MouseDoubleClick += this.RadioButton_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                            }

                            if (Ctl.GetType().Name.ToString() == "CheckBox")
                            {
                                try
                                {
                                    //Ctl.MouseDoubleClick -= this.CheckBox_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    //Ctl.MouseDoubleClick += this.CheckBox_MouseDoubleClick;
                                }
                                catch
                                {
                                }
                            }

                            break;
                        }

                    case "TabPage":
                        {
                            Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name);          // Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, Ctl.Name, Modules.TypeLanguage)
                            break;
                        }
                    case "Button":
                        {
                            if (Ctl.Name.ToUpper().Substring(0, 4) != "NONN" & Ctl.Name.Length > 4)
                            {
                                Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name);
                                //LoadImage(Ctl);
                            }

                            break;
                        }

                    case "SimpleButton":
                        {
                            DevExpress.XtraEditors.SimpleButton CtlDev;
                            CtlDev = (DevExpress.XtraEditors.SimpleButton)Ctl;
                            if (Ctl.Name.ToUpper().Substring(0, 4) != "NONN" & Ctl.Name.Length > 4)
                            {
                                Ctl.Text = GetNN(dtNgu, Ctl.Name, frm.Name);
                                //LoadImageDev(CtlDev);
                            }

                            break;
                        }

                    case "RadioGroup":
                        {
                            DevExpress.XtraEditors.RadioGroup radGroup;
                            radGroup = (DevExpress.XtraEditors.RadioGroup)Ctl;
                            for (int i = 0; i <= radGroup.Properties.Items.Count - 1; i++)
                            {
                                if (string.IsNullOrEmpty(radGroup.Properties.Items[i].Tag.ToString()))
                                    radGroup.Properties.Items[i].Tag = radGroup.Properties.Items[i].Description;
                                radGroup.Properties.Items[i].Description = GetNN(dtNgu, radGroup.Properties.Items[i].Tag.ToString(), frm.Name);          // Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, radGroup.Properties.Items(i).Description, Modules.TypeLanguage)
                            }
                            try
                            {
                                if (radGroup.SelectedIndex == -1)
                                    radGroup.SelectedIndex = 0;
                            }
                            catch
                            {
                            }

                            break;
                        }

                    case "CheckedListBoxControl":
                        {
                            DevExpress.XtraEditors.CheckedListBoxControl chkGroup;
                            chkGroup = (DevExpress.XtraEditors.CheckedListBoxControl)Ctl;

                            for (int i = 0; i <= chkGroup.Items.Count - 1; i++)
                                chkGroup.Items[i].Description = GetNN(dtNgu, chkGroup.Items[i].Description, frm.Name);// Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, chkGroup.Items(i).Description, Modules.TypeLanguage)
                            break;
                        }

                    case "XtraTabControl":
                        {
                            DevExpress.XtraTab.XtraTabControl tabControl;
                            tabControl = (DevExpress.XtraTab.XtraTabControl)Ctl;
                            for (int i = 0; i <= tabControl.TabPages.Count - 1; i++)
                                tabControl.TabPages[i].Text = GetNN(dtNgu, tabControl.TabPages[i].Name, frm.Name);
                            break;
                        }

                        //case "GridControl":
                        //    {
                        //        DevExpress.XtraGrid.GridControl grid;
                        //        grid = (DevExpress.XtraGrid.GridControl)Ctl;
                        //        DevExpress.XtraGrid.Views.Grid.GridView mainView = (DevExpress.XtraGrid.Views.Grid.GridView)grid.MainView;
                        //        try { Commons.Modules.OXtraGrid.CreateMenuReset(grid); } catch { }

                        //        foreach (DevExpress.XtraGrid.Views.Base.ColumnView view in grid.ViewCollection)
                        //        {
                        //            if ((view) is DevExpress.XtraGrid.Views.Grid.GridView)
                        //            {
                        //                foreach (DevExpress.XtraGrid.Columns.GridColumn col in view.Columns)
                        //                {
                        //                    if (col.Visible)
                        //                    {
                        //                        col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //                        col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        //                        col.AppearanceHeader.Options.UseTextOptions = true;
                        //                        col.Caption = GetNN(dtNgu, col.FieldName, frm.Name);      // Modules.ObjLanguages.GetLanguage(Modules.ModuleName, frm.Name, col.Name, Modules.TypeLanguage),

                        //                        AutoCotDev(col);
                        //                    }
                        //                }
                        //                MVisGrid((DevExpress.XtraGrid.Views.Grid.GridView)view, frm.Name, view.Name.ToString(), Commons.Modules.UserName, true);
                        //                try
                        //                {
                        //                    //view.MouseUp -= this.GridView_MouseUp;
                        //                }
                        //                catch
                        //                {
                        //                }
                        //                try
                        //                {
                        //                    //view.MouseUp += this.GridView_MouseUp;
                        //                }
                        //                catch
                        //                {
                        //                }

                        //                try
                        //                {
                        //                    //view.DoubleClick -= this.GridView_DoubleClick;
                        //                }
                        //                catch
                        //                {
                        //                }

                        //                try
                        //                {
                        //                    //view.DoubleClick += this.GridView_DoubleClick;
                        //                }
                        //                catch
                        //                {
                        //                }
                        //            }
                        //        }

                        //        break;
                        //    }

                        //case "DataGridView":
                        //    {
                        //        foreach (DataGridViewColumn cl in (DataGridView)Ctl.Columns)
                        //        {
                        //            cl.HeaderText = GetNN(dtNgu, cl.Name, frm.Name);
                        //            AutoCotGrid(cl);
                        //        }
                        //        (DataGridView)Ctl.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1;
                        //        (DataGridView)Ctl.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2;
                        //        MVisGrid((DataGridView)Ctl, frm.Name, (DataGridView)Ctl.Name.ToString(), Commons.Modules.UserName);
                        //        break;
                        //    }

                        //case "DataGridViewNew":
                        //    {
                        //        foreach (DataGridViewColumn cl in (DataGridView)Ctl.Columns)
                        //        {
                        //            cl.HeaderText = GetNN(dtNgu, cl.Name, frm.Name);
                        //            AutoCotGrid(cl);
                        //        }

                        //        MVisGrid((DataGridView)Ctl, frm.Name, (DataGridView)Ctl.Name.ToString(), Commons.Modules.UserName);
                        //        break;
                        //    }

                        //case "DataGridViewEditor":
                        //    {
                        //        foreach (DataGridViewColumn cl in (DataGridView)Ctl.Columns)
                        //        {
                        //            cl.HeaderText = GetNN(dtNgu, cl.Name, frm.Name);
                        //            AutoCotGrid(cl);
                        //        }

                        //        (DataGridView)Ctl.ColumnHeadersDefaultCellStyle = Commons.Modules.DataGridViewCellStyle1;
                        //        (DataGridView)Ctl.DefaultCellStyle = Commons.Modules.DataGridViewCellStyle2;

                        //        MVisGrid((DataGridView)Ctl, frm.Name, (DataGridView)Ctl.Name.ToString(), Commons.Modules.UserName);
                        //        break;
                        //    }

                        //case object _ when "NavBarControl" | "navBarControl":
                        //    {
                        //        foreach (NavBarGroup cl in (NavBarControl)Ctl.Groups)
                        //            cl.Caption = GetNN(dtNgu, cl.Name, frm.Name);
                        //        foreach (NavBarItem cl in (NavBarControl)Ctl.Items)
                        //            cl.Caption = GetNN(dtNgu, cl.Name, frm.Name);
                        //        break;
                        //    }
                }
            }
            catch
            {
            }
        }

        public void MVisGrid(DevExpress.XtraGrid.Views.Grid.GridView grv, string sForm, string sControl, string UName, bool MDev)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                string sDLieuForm = "";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "MGetDsCotVis", sForm, sControl, UName));
                if (dtTmp.Rows.Count <= 0)
                    return;

                sDLieuForm = Convert.ToString(dtTmp.Rows[0]["COL_VIS"].ToString());
                if (sDLieuForm.ToUpper() == "ALL")
                    return;


                string[] chuoi_tach = sDLieuForm.Split(new Char[] { '@' });

                foreach (string s in chuoi_tach)
                {
                    if (s.ToString() != "")
                    {
                        try
                        {
                            grv.Columns[s].Visible = false;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public void AutoCotDev(DevExpress.XtraGrid.Columns.GridColumn col)
        {
            try
            {
                if (col.ColumnType.ToString() == typeof(DateTime).ToString())
                    col.BestFit();
                else if (col.Name.Contains("MS_MAY"))
                    col.BestFit();
                else if (col.Name.Contains("MS_PT"))
                    col.BestFit();
            }
            catch
            {
            }
        }


        public string GetNN(DataTable dtNN, string sKeyWord, string sFormName)
        {
            string sNN = "";
            try
            {
                sNN = dtNN.Select("KEYWORD = '" + sKeyWord.ToUpper().Replace("ItemFor".ToUpper(), "") + "' OR KEYWORD = '" + sKeyWord + "' ")[0][1].ToString();
            }
            catch
            {
                sNN = Modules.ObjLanguages.GetLanguage(Modules.ModuleName, sFormName, sKeyWord, Modules.TypeLanguage);
            }
            return sNN;
        }
        public void GetControlsCollection(Control root, ref List<Control> AllControls, Func<Control, Control> filter)
        {
            foreach (Control child in root.Controls)
            {
                if (Commons.Modules.lstControlName.Any(x => x.ToString() == child.GetType().Name))
                    AllControls.Add(child);
                if (child.Controls.Count > 0)
                    GetControlsCollection(child, ref AllControls, filter);
            }
        }

        //public string GetNN(LayoutControlGroup layout, string sKeyWord, string sFormName)
        //{
        //}
        #endregion

        #region kiểm tra null or rỗng

        public bool IsnullorEmpty(object input)
        {
            bool resust = false;
            try
            {
                if (input.ToString() == "" || input.ToString() == "0")
                {
                    resust = true;
                }
            }
            catch (Exception)
            {
                resust = true;
            }
            return resust;
        }


        #endregion

        #region MA HOA

        static string SecurityKey = "vietsoft.com.vn";
        static string chuoi = "_13579_";
        /// <summary>
        /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
        /// </summary>
        /// <param name="toEncrypt">string to be encrypted</param>
        /// <param name="useHashing">use hashing? send to for extra secirity</param>
        /// <returns></returns>
        /// 
        public string Encrypt(string toEncrypt, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(chuoi + toEncrypt + chuoi);

                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                // Get the key from config file
                string key = SecurityKey; /*(string)settingsReader.GetValue("SecurityKey", typeof(String));*/
                                          //System.Windows.Forms.MessageBox.Show(key);
                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch
            {
                byte[] byteData = Encoding.Unicode.GetBytes("");
                return Convert.ToBase64String(byteData);
            }
        }
        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public string Decrypt(string cipherString, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                //Get your key from config file to open the lock!
                string key = SecurityKey;//(string)settingsReader.GetValue("SecurityKey", typeof(String));

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray).Split(new string[] { chuoi }, StringSplitOptions.None)[1];
            }
            catch
            {
                byte[] byteData = Encoding.Unicode.GetBytes("");
                //return UTF8Encoding.UTF8.GetString(byteData).Split(new string[] { chuoi }, StringSplitOptions.None)[1];
                return Convert.ToBase64String(byteData);
            }
        }


        #endregion

        #region creatbt
        public bool MCreateTableToDatatable(string connectionString, string tableSQLName, DataTable table, string sTaoTable)
        {
            try
            {
                if (sTaoTable == "")
                {
                    if (!MCreateTable(tableSQLName, table, connectionString))
                        return false;
                }
                else
                {
                    Commons.Modules.ObjSystems.XoaTable(tableSQLName);
                    SqlHelper.ExecuteReader(connectionString, CommandType.Text, sTaoTable);
                }

                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(connection, System.Data.SqlClient.SqlBulkCopyOptions.TableLock | System.Data.SqlClient.SqlBulkCopyOptions.FireTriggers | System.Data.SqlClient.SqlBulkCopyOptions.UseInternalTransaction, null);

                    bulkCopy.DestinationTableName = tableSQLName;
                    connection.Open();

                    bulkCopy.WriteToServer(table);
                    connection.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool MCreateTable(string tableName, DataTable table, string connectionString)
        {
            try
            {
                string sql = "CREATE TABLE " + tableName + " (" + "\n";

                // columns
                int i = 1;
                foreach (DataColumn col in table.Columns)
                {
                    sql += "[" + col.ColumnName + "] " + MGetTypeSql(col.DataType, col.MaxLength, 10, 2) + "," + "\n";
                    i += 1;
                }
                sql += ")";

                Commons.Modules.ObjSystems.XoaTable(tableName);
                SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void XoaTable(string strTableName)
        {
            try
            {
                strSql = "DROP TABLE " + strTableName;
                SqlHelper.ExecuteScalar(IConnections.CNStr, CommandType.Text, strSql);
            }
            catch
            {
            }
        }

        public string MGetTypeSql(object type, int columnSize, int numericPrecision, int numericScale)
        {
            switch (type.ToString())
            {
                case "System.String":
                    {
                        if ((columnSize >= 2147483646))
                            return "NVARCHAR(MAX)";
                        else
                            return (columnSize == -1) ? "NVARCHAR(MAX)" : "NVARCHAR(" + columnSize.ToString() + ")";
                    }

                case "System.Decimal":
                    {
                        if (numericScale > 0)
                            return "REAL";
                        else if (numericPrecision > 10)
                            return "BIGINT";
                        else
                            return "INT";
                    }

                case "System.Boolean":
                    {
                        return "BIT";
                    }

                case "System.Double":
                    {
                        return "FLOAT";
                    }

                case "System.Single":
                    {
                        return "REAL";
                    }

                case "System.Int64":
                    {
                        return "BIGINT";
                    }

                case "System.Int16":
                    {
                        return "INT";
                    }

                case "System.Int32":
                    {
                        return "INT";
                    }

                case "System.DateTime":
                    {
                        return "DATETIME";
                    }

                case "System.Byte[]":
                    {
                        return "IMAGE";
                    }

                case "System.Drawing.Image":
                    {
                        return "IMAGE";
                    }

                default:
                    {
                        throw new Exception(type.ToString() + " not implemented.");
                    }
            }
        }
        #endregion

        #region add combobox search
        public void AddCombSearchLookUpEdit(RepositoryItemSearchLookUpEdit cboSearch, string Value, string Display, GridView grv, DataTable dtTmp, string form)
        {
            cboSearch.NullText = "";
            cboSearch.ValueMember = Value;
            cboSearch.DisplayMember = Display;
            cboSearch.DataSource = dtTmp;
            cboSearch.View.PopulateColumns(cboSearch.DataSource);
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(cboSearch.View, form);
            grv.Columns[Value].ColumnEdit = cboSearch;
        }
        public void AddCombXtra(string Value, string Display, GridView grv, string sSql, string form)
        {
            DataTable tempt = new DataTable();
            tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, sSql, Commons.Modules.UserName, Commons.Modules.TypeLanguage, 0));
            RepositoryItemSearchLookUpEdit cbo = new RepositoryItemSearchLookUpEdit();
            cbo.NullText = "";
            cbo.ValueMember = Value;
            cbo.DisplayMember = Display;
            cbo.DataSource = tempt;
            cbo.View.PopulateColumns(cbo.DataSource);
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(cbo.View, form);
            grv.Columns[Value].ColumnEdit = cbo;

        }
        public void AddCombXtra(string Value, string Display, string cot, GridView grv, DataTable dt)
        {
            RepositoryItemSearchLookUpEdit cbo = new RepositoryItemSearchLookUpEdit();
            cbo.NullText = "";
            cbo.ValueMember = Value;
            cbo.DisplayMember = Display;
            cbo.DataSource = dt;
            grv.Columns[cot].ColumnEdit = cbo;

        }
        public void AddCombXtra(string Value, string Display, GridView grv, DataTable dt)
        {
            RepositoryItemSearchLookUpEdit cbo = new RepositoryItemSearchLookUpEdit();
            cbo.NullText = "";
            cbo.ValueMember = Value;
            cbo.DisplayMember = Display;
            cbo.DataSource = dt;
            grv.Columns[Value].ColumnEdit = cbo;

        }

        public void AddCombDateTimeEdit(string col, GridView grv)
        {
            RepositoryItemDateEdit cbo = new RepositoryItemDateEdit();
            cbo.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            cbo.EditMask = "G";
            cbo.DisplayFormat.FormatString = "G";
            cbo.EditFormat.FormatString = "G";
            cbo.CalendarView = CalendarView.TouchUI;

            grv.Columns[col].Width = 150;
            grv.Columns[col].ColumnEdit = cbo;
        }
        public void AddCombDateMinuteEdit(string col, GridView grv)
        {
            RepositoryItemDateEdit cbo = new RepositoryItemDateEdit();
            cbo.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            cbo.EditMask = "dd/MM/yyyy HH:mm";
            cbo.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            cbo.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            cbo.CalendarView = CalendarView.TouchUI;

            grv.Columns[col].Width = 150;
            grv.Columns[col].ColumnEdit = cbo;
        }
        public void AddCombXtra(string Value, string Display, string Cot, GridView grv, DataTable tempt, bool Search, string form)
        {
            if (Search == true)
            {
                RepositoryItemSearchLookUpEdit cbo = new RepositoryItemSearchLookUpEdit();
                cbo.NullText = "";
                cbo.ValueMember = Value;
                cbo.DisplayMember = Display;
                cbo.DataSource = tempt;
                grv.Columns[Cot].ColumnEdit = cbo;
                cbo.View.PopulateColumns(cbo.DataSource);
                Commons.Modules.ObjSystems.MLoadNNXtraGrid(cbo.View, form);
                grv.Columns[Cot].ColumnEdit = cbo;
                cbo.View.Columns[0].Visible = false;
            }
            else
            {
                RepositoryItemLookUpEdit cbo = new RepositoryItemLookUpEdit();
                cbo.NullText = "";
                cbo.ValueMember = Value;
                cbo.DisplayMember = Display;
                cbo.DataSource = tempt;
                cbo.Columns.Clear();
                cbo.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(Display));
                cbo.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.BestFitMode = BestFitMode.BestFit;
                cbo.SearchMode = SearchMode.AutoComplete;
                grv.Columns[Cot].ColumnEdit = cbo;
                cbo.Columns[Display].Caption = Commons.Modules.ObjLanguages.GetLanguage(form, Display);
            }
        }
        public void AddCombo(string Value, string Display, GridView grv, DataTable tempt)
        {
            try
            {
                RepositoryItemLookUpEdit cbo = new RepositoryItemLookUpEdit();
                cbo.NullText = "";
                cbo.ValueMember = Value;
                cbo.DisplayMember = Display;
                cbo.DataSource = tempt;
                cbo.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cbo.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cbo.BestFitMode = BestFitMode.BestFit;
                cbo.SearchMode = SearchMode.AutoComplete;
                grv.Columns[Value].ColumnEdit = cbo;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddCombobyTree(string Value, string Display, TreeList tree, DataTable tempt)
        {
            RepositoryItemLookUpEdit cbo = new RepositoryItemLookUpEdit();
            cbo.NullText = "";
            cbo.ValueMember = Value;
            cbo.DisplayMember = Display;
            cbo.DataSource = tempt;
            cbo.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            cbo.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            cbo.BestFitMode = BestFitMode.BestFit;
            cbo.SearchMode = SearchMode.AutoComplete;
            tree.Columns[Value].ColumnEdit = cbo;
        }
        #endregion


        public void AddCombobyTree(RepositoryItemLookUpEdit cbo, string Value, string Display, TreeList tree, DataTable tempt)
        {
            cbo.NullText = "";
            cbo.ValueMember = Value;
            cbo.DisplayMember = Display;
            cbo.DataSource = tempt;
            cbo.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            cbo.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            cbo.BestFitMode = BestFitMode.BestFit;
            cbo.SearchMode = SearchMode.AutoComplete;
            tree.Columns[Value].ColumnEdit = cbo;
        }
        public void MReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        public void AddnewRow(GridView view, bool add)
        {
            try
            {
                view.OptionsBehavior.Editable = true;
                if (add == true)
                {
                    view.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                    view.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                    view.MoveLastVisible();
                }
            }
            catch
            {
            }
        }
        public void DeleteAddRow(GridView view)
        {
            try
            {
                view.OptionsBehavior.Editable = false;
                view.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            catch
            {
            }
        }
        public bool isEmail(string inputEmail)
        {
            bool resulst = false;
            if (string.IsNullOrEmpty(inputEmail))
            {
                resulst = true;
            }
            else
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(inputEmail))
                    resulst = true;
                else
                    resulst = false;
            }
            return resulst;
        }

        #region lấy table từ grid
        public DataTable ConvertDatatable(GridControl grid)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)grid.DataSource;
            return dt;
        }
        public DataTable ConvertDatatable(GridView view)
        {
            view.PostEditor();
            view.UpdateCurrentRow();
            DataView dt = (DataView)view.DataSource;
            DataTable tempt = dt.ToTable();
            return tempt;
        }


        public DataRow ThongTinChung()
        {
            DataTable tempt = new DataTable();
            tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM dbo.THONG_TIN_CHUNG"));
            return tempt.Rows[0];
        }

        public DataRow BLMCPC(Int64 idcn, DateTime ngayhd)
        {

            DataTable tempt = new DataTable();
            tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM [funGetLuongKyHopDong](" + idcn + ",'" + ngayhd.ToString("MM/dd/yyyy") + "')"));
            if (tempt.Rows.Count == 0)
                tempt.Rows.Add(idcn, 0, 0, 0);
            return tempt.Rows[0]; ;
        }
        public DataRow TienTroCap(Int64 idcn, DateTime ngaynv, int idldtv)
        {
            //ID_CN	LUONG_TRO_CAP	TIEN_TRO_CAP
            DataTable tempt = new DataTable();
            tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM [dbo].[GetTienTroCap]('" + ngaynv.ToString("MM/dd/yyyy") + "'," + idcn + "," + idldtv + ")"));
            return tempt.Rows[0];
        }

        public DataRow TienPhep(Int64 idcn, DateTime ngaynv)
        {
            //ID_CN	LUONG_TP	SO_NGAY_PHEP	TIEN_PHEP
            DataTable tempt = new DataTable();
            tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM [dbo].[GetTienPhep]('" + ngaynv.ToString("MM/dd/yyyy") + "'," + idcn + ")"));
            return tempt.Rows[0];
        }



        #endregion
        #region Loadcombo phân quyền
        public void LoadCboDonVi(SearchLookUpEdit cboSearch_DV)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComboDON_VI", Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboSearch_DV, dt, "ID_DV", "TEN_DV", "frmChung");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        public void LoadCboXiNghiep(SearchLookUpEdit cboSearch_DV, SearchLookUpEdit cboSearch_XN)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComboXI_NGHIEP", cboSearch_DV.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboSearch_XN, dt, "ID_XN", "TEN_XN", "frmChung");
                cboSearch_XN.EditValue = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        public void LoadCboTo(SearchLookUpEdit cboSearch_DV, SearchLookUpEdit cboSearch_XN, SearchLookUpEdit cboSearch_TO)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComboTO", cboSearch_DV.EditValue, cboSearch_XN.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboSearch_TO, dt, "ID_TO", "TEN_TO", "frmChung");
                cboSearch_TO.EditValue = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        #region Định dạng
        public string sDinhDangSoLe(int iSoLe)
        {
            string sChuoi = "#,##0";
            if (iSoLe != 0)
            {
                sChuoi = sChuoi + ".";
                for (int i = 0; i <= iSoLe - 1; i++)
                    sChuoi = sChuoi + "0";
            }
            return sChuoi;
        }

        public string sDinhDangSoLe(int iSoLe, string sChuoi)
        {
            if (iSoLe != 0)
            {
                sChuoi = sChuoi + ".";
                for (int i = 0; i <= iSoLe - 1; i++)
                    sChuoi = sChuoi + "0";
            }
            return sChuoi;
        }
        #endregion
        #region datacomboboxchung
        public DataTable DataItemGroup(bool coAll)
        {
            //ID,ItemGroupName
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetItemGroup", Commons.Modules.UserName, Commons.Modules.TypeLanguage, coAll));
            return dt;
        }
        public DataTable DataItem(int coAll, string msmay)
        {
            //ID,ItemName 
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetItem", Commons.Modules.UserName, Commons.Modules.TypeLanguage, coAll, msmay));
            return dt;
        }
        public DataTable DataItemByPro(Int64 ProID)
        {
            //ID,ItemName 
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetItemByPro", ProID, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            return dt;
        }

        public DataTable DataSatusProDuct(bool coAll)
        {
            //ID,NAME_STATUS
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetSatusProDuct", Commons.Modules.UserName, Commons.Modules.TypeLanguage, coAll));
            return dt;
        }

        public DataTable DataDownTimeType(bool coAll)
        {
            //ID,DownTimeType
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetDownTimeType", Commons.Modules.UserName, Commons.Modules.TypeLanguage, coAll));
            return dt;
        }
        public DataTable DataPlanned(bool coAll)
        {
            //ID,StopTypeName
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetPlaned", Commons.Modules.UserName, Commons.Modules.TypeLanguage, coAll));
            return dt;
        }
        public DataTable DataUOM(bool coAll)
        {
            //ID,UOMName
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetcbUOM", Commons.Modules.UserName, Commons.Modules.TypeLanguage, coAll));
            return dt;
        }

        public DataTable DataUOMShortName(bool coAll)
        {
            //ID,UOMName
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetcbUOMShortName", Commons.Modules.UserName, Commons.Modules.TypeLanguage, coAll));
            return dt;
        }

        //get combo Loại thiết bị
        public DataTable DataLoaiTBByItem(bool coAll)
        {
            //MS_LOAI_MAY,TEN_LOAI_MAY
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetcbLoaiMayByItem", Commons.Modules.UserName, Commons.Modules.TypeLanguage, coAll));
            return dt;
        }

        public DataTable DataNhomTBByItem(bool coAll, string LoaiMay)
        {
            //MS_NHOM_MAY,TEN_NHOM_MAY
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetcbNhomMayByItem", LoaiMay, Commons.Modules.UserName, Commons.Modules.TypeLanguage, coAll));
            return dt;
        }

        public DataTable DataDonViThoiGian()
        {
            //ID,ItemGroupName
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetDON_VI_THOI_GIANs", Commons.Modules.TypeLanguage));
            return dt;
        }
        public DataTable DataDonViTinhRunTime()
        {
            //MS_DVT_RT,TEN_DVT_RT
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetDON_VI_TINH_RUN_TIME", Commons.Modules.TypeLanguage));
            return dt;
        }

        public DataTable DataDonViTinhTocDo()
        {
            //MS_DVT_TD,TEN_DVT_TD
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetDON_VI_TINH_TOC_DO", Commons.Modules.TypeLanguage));
            return dt;
        }

        public DataTable DataDonViTinhGio()
        {
            //MS_DVT_GIO,TEN_DVT_GO
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetDON_VI_TINH_GIO", Commons.Modules.TypeLanguage));
            return dt;
        }
        public DataTable DataNhom()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT GROUP_ID, GROUP_NAME, DESCRIPTION, TYPE_LIC FROM dbo.NHOM ORDER BY GROUP_NAME"));
            return dt;
        }
        public DataTable DataCa(bool coAll)
        {
            string sSql = "";
            if (coAll == true)
            {
                sSql = "SELECT STT,CA FROM dbo.CA UNION SELECT -1,'< ALL >' ORDER BY CA";
            }
            else
            {
                sSql = "SELECT STT,CA FROM dbo.CA UNION SELECT NULL,'' ORDER BY CA";
            }

            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
            return dt;
        }
        public DataTable DataUser(bool coAll)
        {
            string sSql = "";
            if (coAll == true)
            {
                sSql = "SELECT USERNAME,FULL_NAME FROM dbo.USERS  UNION SELECT '-1','< ALL >' ORDER BY USERNAME";
            }
            else
            {
                sSql = "SELECT USERNAME,FULL_NAME FROM dbo.USERS ORDER BY USERNAME";
            }

            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
            return dt;
        }

        public DataTable DataNguyenNhan()
        {
            //MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN FROM NGUYEN_NHAN_DUNG_MAY ORDER BY TEN_NGUYEN_NHAN"));
            return dt;
        }


        public DataTable DataNhaXuongTree(bool CoAll)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetNhaXuongTreeList", CoAll, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            return dt;
        }
        public DataTable DataHeThongTree(bool CoAll)
        {
            //MS_HE_THONG,TEN_HE_THONG
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetHeThongTreeListAll", CoAll, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            return dt;
        }

        public DataTable DataLoaiTB(bool CoAll)
        {
            DataTable dt = new DataTable();
            //GetLoaiMayAll 1,'ADMIN',1
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetLoaiMayAll", CoAll, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            return dt;
        }

        public DataTable DataHeThong()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetHeThongItem", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            return dt;
        }
        public DataTable DataLoaiMay(bool CoAll)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetLoaiMayAll", CoAll, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            return dt;
        }
        public DataTable DataNhomMay(bool CoAll, string msLoaiMay)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetNhomMayAll", CoAll, msLoaiMay, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            return dt;
        }
        public DataTable DataHeThongBySchedule()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetcbHeThongbySchedule", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            return dt;
        }

        public DataTable DataOpetator(bool coAll)
        {
            //ID,OperatorName
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetcbOperator", Commons.Modules.UserName, Commons.Modules.TypeLanguage, coAll));
            return dt;
        }

        public DataTable DataLoaiNguyenNhan(bool coAll)
        {
            //ID,DownTimeTypeName
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetLoaiNguyenNhan", Commons.Modules.UserName, Commons.Modules.TypeLanguage, coAll));
            return dt;
        }
        public DataTable DataToOperator(bool coAll)
        {
            //ID_TO,TEN_TO
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetToOperator", Commons.Modules.UserName, Commons.Modules.TypeLanguage, coAll));
            return dt;
        }

        public DataTable DataKeHoach()
        {
            //ID,KeHoach
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetKeHoach", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            return dt;
        }

        public DataTable DataProductOrDer()
        {
            // A.ID,PrOrNumber 
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetProductOrDer"));
            return dt;
        }
        public DataTable DataMay(bool CoAll)
        {
            //MS_MAY,A.TEN_MAY
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetMay", Commons.Modules.UserName, Commons.Modules.TypeLanguage, CoAll));
            return dt;
        }
        public DataTable DataMay(int Item, int DayChuyen, Int64 ProID, Int64 ItemID)
        {
            //@Item = 1 them item
            //@Item = 0 theo ProSchedule
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetMayItem", Commons.Modules.UserName, Commons.Modules.TypeLanguage, DayChuyen, Item, ProID, ItemID));
            return dt;
        }
        public DataTable DataTo()
        {
            //MS_TO, TEN_TO
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT MS_TO, TEN_TO	 FROM dbo.TO_PHONG_BAN  WHERE MS_TO <> 0 ORDER BY TEN_TO"));
            return dt;
        }
        public DataTable DataNhanVien()
        {
            //MS_CONG_NHAN, FULL_NAME
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT MS_CONG_NHAN,HO + ' ' + TEN FULL_NAME  FROM [CONG_NHAN] UNION SELECT '' MS_CONG_NHAN, '' FULL_NAME ORDER BY MS_CONG_NHAN"));
            return dt;
        }

        public DataTable DataUOMConversionGroup(bool coAll)
        {
            //ID,GroupName
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetUOMConversionGroup", Commons.Modules.UserName, Commons.Modules.TypeLanguage, coAll));
            return dt;
        }

        public DataTable DataNhanVien(bool coAll)
        {
            //MS_CONG_NHAN,TEN_CONG_NHAN
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetCongNhan", Commons.Modules.UserName, Commons.Modules.TypeLanguage, coAll));
            return dt;
        }

        public DataTable DataUOMConversionGroupDetail(Int64 idGroupUOM)
        {
            //ID,GroupName
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetUOMConversionGroupdetailByGroup", idGroupUOM));
            return dt;
        }


        #endregion

        public void MChooseGrid(bool bChose, string sCot, DevExpress.XtraGrid.Views.Grid.GridView grv)
        {
            try
            {
                int i;
                i = 0;
                for (i = 0; i <= grv.RowCount; i++)
                {
                    grv.SetRowCellValue(i, sCot, bChose);
                    grv.UpdateCurrentRow();
                }
            }
            catch
            {
            }
        }

        public void GotoHome(XtraUserControl uc)
        {
            try
            {
                foreach (Control c in uc.ParentForm.Controls)
                {
                    if (c.GetType().Name.ToString() == "TablePanel")
                    {
                        TablePanel table = c as TablePanel;
                        foreach (Control item in table.Controls)
                        {
                            if (item.GetType().Name.ToString() == "TileBar")
                            {
                                TileBar tb = item as TileBar;
                                tb.SelectedItem = tb.GetTileGroupByName("titlegroup").GetTileItemByName("58");
                            }
                        }
                    }
                }
            }
            catch { }
        }

        public SplashScreenManager splashScreenManager1;
        public SplashScreenManager ShowWaitForm(XtraUserControl a)
        {
            splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(a.ParentForm, typeof(frmWaitForm), true, true, true);
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(1000);
            return splashScreenManager1;
        }
        public SplashScreenManager ShowWaitForm(XtraForm a)
        {
            splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(a, typeof(frmWaitForm), true, true, true);
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(1000);
            return splashScreenManager1;
        }
        public void HideWaitForm()
        {
            splashScreenManager1.CloseWaitForm();
        }

        public int MGetPhanQuyen(string frm)
        {
            try
            {
                string sSql = "SELECT CASE QUYEN WHEN N'Read only' THEN 0   WHEN N'Full access' THEN 1 ELSE 2  END AS ID_PERMISSION FROM dbo.NHOM_FORM T1 INNER JOIN dbo.USERS T2 ON T1.GROUP_ID = T2.GROUP_ID WHERE T2.USERNAME = '" + Commons.Modules.UserName + "' AND T1.FORM_NAME = '" + frm + "' UNION SELECT 0 ORDER BY ID_PERMISSION DESC";
                try
                {
                    return Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql).ToString());
                }
                catch { return 0; }
            }
            catch { }
            return 1;
        }
        public string LayDuLieu(string TenFile)
        {
            StreamReader sr;
            string sText;
            sText = "";
            try
            {
                sText = Application.StartupPath.ToString() + @"\" + TenFile;
                sr = new StreamReader(sText);
                sText = "";
                sText = sr.ReadLine();
                try
                {
                    if (sText == null)
                        sText = "";
                }
                catch (Exception ex)
                {
                    sText = "";
                }
                sr.Close();
            }
            catch (Exception ex)
            {
            }
            return sText;
        }

        public void CheckUpdate()
        {
            string sSql = "";
            try
            {
                #region Lay thong tin ver server
                sSql = "SELECT TOP 1 VER FROM dbo.THONG_TIN_CHUNG";
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, System.Data.CommandType.Text, sSql));
                try
                {
                    Commons.Modules.sInfoSer = sSql.Substring(0, (sSql.Length - 4));
                    Commons.Modules.sInfoSer = Commons.Modules.sInfoSer.Substring(6, 2) + "/" + Commons.Modules.sInfoSer.Substring(4, 2) + "/" + Commons.Modules.sInfoSer.Substring(0, 4) + "." + sSql.Substring(8, sSql.Length - 8);
                }
                catch
                {
                    Commons.Modules.sInfoSer = "01/01/2000.0001";
                    sSql = "200001010001";
                }
                #endregion

                #region Lay thong tin ver client
                string sVerClient;
                sVerClient = LayDuLieu(@"Version.txt");
                try
                {
                    Commons.Modules.sInfoClient = sVerClient.Substring(0, (sVerClient.Length - 4));
                    Commons.Modules.sInfoClient = Commons.Modules.sInfoClient.Substring(6, 2) + "/" + Commons.Modules.sInfoClient.Substring(4, 2) + "/" + Commons.Modules.sInfoClient.Substring(0, 4) + "." + sVerClient.Substring(8, sVerClient.Length - 8);
                }
                catch
                {
                    Commons.Modules.sInfoClient = "01/01/2000.0001";
                    sVerClient = "200001010001";
                }
                #endregion


                try { if (double.Parse(sVerClient) == double.Parse(sSql)) return; } catch { return; }

                sSql = "SELECT TOP 1 (CONVERT(NVARCHAR,LOAI_CN) + '!' + isnull(LINK1, '-1') + '!' + isnull(LINK2, '-1') + '!' + isnull(LINK3, '-1')) AS CAPNHAT FROM THONG_TIN_CHUNG";
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, System.Data.CommandType.Text, sSql));

                string[] sArr = sSql.Split('!');
                int loai = Convert.ToInt32(sArr[0].ToString());
                String link1 = sArr[1];
                String link2 = sArr[2];
                String link3 = sArr[3];

                //Khong có loai update thi thoát
                if (loai <= -1) return;


                switch (loai)
                {
                    //Loai 2 xai link1,2 : path link tren dropbox 
                    //Loai 1 xai link3: path link tren server
                    case 1:  //Update tren server voi link3
                        {
                            if (string.IsNullOrEmpty(link3)) return;
                            if (!Directory.Exists(link3))
                            {
                                XtraMessageBox.Show("Link update : " + link3 + " không tồn tại.");
                                return;
                            }
                            MUpdate(loai, ".", ".", link3);
                            break;
                        }
                    case 2: // Updatetren dropbox
                        {
                            if (string.IsNullOrEmpty(link1)) return;
                            MUpdate(loai, link1, link2, ".");
                            break;
                        }
                    default: { break; }
                }
            }
            catch
            { }
        }
        private void MUpdate(int loai, String link1, String link2, String link3)
        {
            try
            {
                System.Diagnostics.Process.Start("Update.exe", loai.ToString() + " " + link1 + " " + link2 + " " + link3 + " " + Application.ProductName);
                //https://www.dropbox.com/s/ntwwve7ys4awrkj/Update.zip?dl=0
                //https://www.dropbox.com/s/6gppx79hbcph1qp/Version.txt?dl=0
                //VS.OEE

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

    }
}
