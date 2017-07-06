using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forecasting {
    public partial class Form1: Form {
        private string[] dataSeries = { "Demand", "SES", "DES" };

        private Dictionary<int, float> demandData;
        private Tuple<Dictionary<int, float>, float, float> sesData;
        private Tuple<Dictionary<int, float>, float, float, float> desData;


        public Form1() {
            InitializeComponent();

            Init();
            LoadData();
            DrawGraph();
            DrawForecastInfo();
        }

        private void Init() {
            swordDemand.Series.Clear();

            swordDemand.Titles.Add("Demand of swords and SES and DES forecasting");
            swordDemand.ChartAreas[0].AxisX.Interval = 1;
            swordDemand.ChartAreas[0].AxisX.Minimum = 1;
            swordDemand.ChartAreas[0].AxisX.Maximum = Program.MAX_FORECAST_WEEK;
            swordDemand.ChartAreas[0].AxisX.Title = "Week";
            swordDemand.ChartAreas[0].AxisY.Interval = 100;
            swordDemand.ChartAreas[0].AxisY.Maximum = 500;
            swordDemand.ChartAreas[0].AxisY.Title = "Demand";

            foreach (string s in dataSeries) {
                swordDemand.Series.Add(s);
                swordDemand.Series[s].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }
        }

        private void LoadData() {
            demandData = CSVparser.GetData();
            sesData = SES.ComputeSES(demandData);
            desData = DES2.ComputeDES(demandData);
        }

        private void DrawGraph() {
            for (int i = 1; i <= demandData.Count; i++) {
                swordDemand.Series["Demand"].Points.AddXY(i, demandData[i]);
            }
            for (int i = 1; i <= Program.MAX_FORECAST_WEEK; i++) {
                swordDemand.Series["SES"].Points.AddXY(i, sesData.Item1[i]);
            }
            for (int i = 3; i <= Program.MAX_FORECAST_WEEK; i++) {
                swordDemand.Series["DES"].Points.AddXY(i, desData.Item1[i]);
            }
        }

        private void DrawForecastInfo() {
            sesAlpha.Text = sesData.Item3.ToString();
            sesError.Text = sesData.Item2.ToString();

            desAlpha.Text = desData.Item3.ToString();
            desBeta.Text = desData.Item4.ToString();
            desError.Text = desData.Item2.ToString();
        }
    }
}
