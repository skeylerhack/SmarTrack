using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraCharts;

namespace VS.OEE
{
    public partial class ucChart : DevExpress.XtraEditors.XtraForm
    {
        public ucChart()
        {
            InitializeComponent();
            loadchart1();
        }
        private void loadchart1()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT B.TEN_HIEN_TRANG ,COUNT(*) AS Value FROM dbo.MAY A INNER JOIN  dbo.HIEN_TRANG_SU_DUNG_MAY B ON B.MS_HIEN_TRANG = A.MS_HIEN_TRANG GROUP BY TEN_HIEN_TRANG"));
            Series series1 = new Series("Land Area by Country", ViewType.Pie);
            // Bind the series to data.
            series1.DataSource = dt;
            chartControl1.Titles.Add(new ChartTitle() { Text = "User by status" });
            series1.ArgumentDataMember = "TEN_HIEN_TRANG";
            series1.ValueDataMembers.AddRange(new string[] { "Value" });
            //text ghi chu
            series1.LegendTextPattern = "{A}";
            //fort mat text hien thi
            series1.Label.TextPattern = "{VP:p0} ({V})";
            PieSeriesView myView = (PieSeriesView)series1.View;
            chartControl1.Series.Add(series1);
        }
    }
}
