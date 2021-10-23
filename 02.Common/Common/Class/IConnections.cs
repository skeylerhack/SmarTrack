using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commons
{
    public class IConnections
    {
        private static string _Server;
        private static string _Database;
        private static string _Username;
        private static string _Password;

        public static string Server
        {
            get
            {
                return _Server;
            }
            set
            {
                _Server = value;
            }
        }
        public static string Database
        {
            get
            {
                return _Database;
            }
            set
            {
                _Database = value;
            }
        }
        public static string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
            }
        }
        public static string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
      
        public static string CNStr
        {
            get
            {
                return "Server=" + _Server + ";database=" + _Database + ";uid=" + _Username + ";pwd=" + _Password + ";Connect Timeout=9999;";
            }
        }

        public static DataTable MGetDataTable(SqlCommand comd)
        {
            DataTable dtTmp = new DataTable();
            using (SqlConnection connection = new SqlConnection(Commons.IConnections.CNStr))
            {
                comd.Connection = connection;
                comd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(comd);
                da.Fill(dtTmp);
                da.Dispose();

                return dtTmp;
            }
        }

        public static bool MExecuteNonQuery(string queryString)
        {
            using (SqlConnection connection = new SqlConnection(Commons.IConnections.CNStr))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = queryString;
                command.Connection = connection;
                command.CommandTimeout = 3600;
                command.Connection.Open();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    command.Connection.Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    transaction.Rollback();
                    command.Connection.Close();
                    return false;
                }
                return true;
            }
        }
        public static bool MExecuteNonQuery(SqlCommand com)
        {
            using (SqlConnection connection = new SqlConnection(Commons.IConnections.CNStr))
            {
                com.Connection = connection;
                com.CommandTimeout = 3600;
                com.Connection.Open();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction();
                com.Transaction = transaction;
                try
                {
                    com.ExecuteNonQuery();
                    transaction.Commit();
                    com.Connection.Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    transaction.Rollback();
                    com.Connection.Close();
                    return false;
                }
                return true;
            }

        }

        public static object MExecuteScalar(string queryString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Commons.IConnections.CNStr))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.CommandTimeout = 3600;
                    command.Connection.Open();
                    return command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static object MExecuteScalar(SqlCommand com)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Commons.IConnections.CNStr))
                {
                    com.Connection = connection;
                    com.CommandTimeout = 3600;
                    com.Connection.Open();
                    return com.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public static DataSet MGetDataSet(string queryString)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(Commons.IConnections.CNStr))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.CommandTimeout = 3600;
                    command.Connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(ds);
                    da.Dispose();
                    command.Connection.Close();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataSet MGetDataSet(SqlCommand com)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(Commons.IConnections.CNStr))
                {
                    com.Connection = connection;
                    com.CommandTimeout = 3600;
                    com.Connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(ds);
                    da.Dispose();
                    com.Connection.Close();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
