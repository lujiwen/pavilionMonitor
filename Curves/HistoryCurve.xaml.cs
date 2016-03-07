using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using PavilionCollect.Model;
using Visifire.Charts;
using PavilionCollect.Util;
using System.Data;

namespace PavilionCollect.Curves
{
    /// <summary>
    /// HistoryCurve.xaml 的交互逻辑
    /// </summary>
    public partial class HistoryCurve : Window
    {
        private VisifireChart hvc; //历史曲线
        private UInt32 devId;
        private String devType;
        private String dataUnit;
        private Title title;//图标标题
        public HistoryCurve(String uid)
        {
            InitializeComponent();
            devId = Convert.ToUInt32(uid);
            initHCNormal();
        }
        /// <summary>
        /// 初始化历史曲线chart的常规属性
        /// </summary>
        public void initHCNormal()
        {
            hvc = new VisifireChart();
            hvc.Height = 400;
            hvc.Width = 700;
            hvc.Margin = new Thickness(5);
            hvc.Background = new SolidColorBrush(Colors.White);
            hvc.View3D = false;
            hvc.AnimationEnabled = false;
            hvc.AnimatedUpdate = true;
            hvc.IndicatorEnabled = true;
            setDevInfoByDevId(devId);
            devname.Text = devType;
            //图表标题
            title = new Title();
            //图表X轴
            Axis axisX = new Axis();
            axisX.Title = "日期";
            //图表Y轴
            Axis axisY = new Axis();
            axisY.Title = dataUnit;

            hvc.Titles.Add(title);
            hvc.AxesX.Add(axisX);
            hvc.AxesY.Add(axisY);
            historyCurves.Children.Add(hvc);

        }
        /// <summary>
        /// 设置设备的基本属性
        /// </summary>
        /// <param name="devId"></param>
        public void setDevInfoByDevId(UInt32 devId)
        {
            String sql = DBHelper.getSelectAllInfoCommands("deviceinfo");
            DataTable dt = DBHelper.selectFromDB(sql);
            foreach (DataRow row in dt.Rows)
            {
                devType = row["Type"].ToString();
                dataUnit = row["DataUnit"].ToString();
            }
        }

        /// <summary>
        /// 启动查询细粒度查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void start_Click(object sender, RoutedEventArgs e)
        {
            title.Text = "实时运行情况";
            DataTable dt = SelectHistoryByDevId((UInt32)Convert.ToInt32(devId));
            AddSeries(dt);
        }
        /// <summary>
        /// 根据当前设备Id号来查询详细历史记录
        /// </summary>
        public DataTable SelectHistoryByDevId(UInt32 devId)
        {
            DataTable dt = new DataTable();
            String[] colums = {"DataTime","DoseNow","DoseAvg","DoseStd","RainValue"};
            String starttime = startTime.Text.ToString(); //开始时间
            DateTime st = Convert.ToDateTime(starttime);
            
            String endtime = endTime.Text.ToString(); //终止时间
            DateTime et = Convert.ToDateTime(endtime);

            String sql = DBHelper.getSelectHistoryDataCommands("devicehistorydata",colums,devId,st.ToString(),et.ToString());
            dt = DBHelper.selectFromDB(sql);
            return dt;
        }

        /// <summary>
        /// 添加曲线
        /// </summary>
        public void AddSeries(DataTable dt)
        {
            //实时值
            DataSeries nowSeries = new DataSeries();  
            nowSeries.LegendText = "实时值";        
            nowSeries.RenderAs = RenderAs.Line;
            //平均值
            DataSeries avgSeries = new DataSeries();
            avgSeries.LegendText = "平均值";        //说明文本
            avgSeries.RenderAs = RenderAs.Line;
            
            //五分钟标准
            DataSeries stdSeries = new DataSeries();
            stdSeries.LegendText = "标准差值";        //说明文本
            stdSeries.RenderAs = RenderAs.Line;
            //雨量
            DataSeries rvSeries = new DataSeries();
            rvSeries.LegendText = "雨量";        //说明文本
            rvSeries.RenderAs = RenderAs.Line;

            foreach (DataRow item in dt.Rows)
            {
                //实时值
                DataPoint nowdataPoint = new DataPoint();//数据点
                nowdataPoint.MarkerSize = 8;
                nowdataPoint.AxisXLabel = Convert.ToString(item["DataTime"]);
                nowdataPoint.YValue = Convert.ToDouble(item["DoseNow"]);
                nowSeries.DataPoints.Add(nowdataPoint);//数据点添加到数据系列
                //平均值
                DataPoint avgdataPoint = new DataPoint();//数据点
                avgdataPoint.MarkerSize = 8;
                avgdataPoint.AxisXLabel = Convert.ToString(item["DataTime"]);
                avgdataPoint.YValue = Convert.ToDouble(item["DoseAvg"]);
                avgSeries.DataPoints.Add(avgdataPoint);
                //五分钟标准差值
                DataPoint stddataPoint = new DataPoint();//数据点
                stddataPoint.MarkerSize = 8;
                stddataPoint.AxisXLabel = Convert.ToString(item["DataTime"]);
                stddataPoint.YValue = Convert.ToDouble(item["DoseStd"]);
                stdSeries.DataPoints.Add(stddataPoint);
                //雨量
                DataPoint rvdataPoint = new DataPoint();//数据点
                rvdataPoint.MarkerSize = 8;
                rvdataPoint.AxisXLabel = Convert.ToString(item["DataTime"]);
                rvdataPoint.YValue = Convert.ToDouble(item["RainValue"]);
                rvSeries.DataPoints.Add(rvdataPoint);
                
            }
            //添加到图表
            hvc.Series.Add(nowSeries);
            hvc.Series.Add(avgSeries);
            hvc.Series.Add(stdSeries);
            hvc.Series.Add(rvSeries);
        }

        private void dayBt_Click(object sender, RoutedEventArgs e)
        {
            title.Text = "每天运行情况";
            DataTable dt = SelectstatisticHistoryByDevId((UInt32)Convert.ToInt32(devId), "dayhistorydata");
            AddStatisticSeries(dt);
        }
        
        private void monthBt_Click(object sender, RoutedEventArgs e)
        {
            title.Text = "每月运行情况";
            DataTable dt = SelectstatisticHistoryByDevId((UInt32)Convert.ToInt32(devId), "monthhistorydata");
            AddStatisticSeries(dt);
        }

        private void weekBt_Click(object sender, RoutedEventArgs e)
        {
            title.Text = "每周运行情况";
            DataTable dt = SelectstatisticHistoryByDevId((UInt32)Convert.ToInt32(devId), "weekhistorydata");
            AddStatisticSeries(dt);
        }

        /// <summary>
        /// 根据当前设备Id号和表名来查询统计数据
        /// </summary>
        public DataTable SelectstatisticHistoryByDevId(UInt32 devId, String tablename)
        {
            DataTable dt = new DataTable();
            String[] colums = { "DataTime", "maxdosenowvalue", "mindosenowvalue", "avgdosenowvalue" };
            String starttime = startTime.Text.ToString(); //开始时间
            DateTime st = Convert.ToDateTime(starttime);

            String endtime = endTime.Text.ToString(); //终止时间
            DateTime et = Convert.ToDateTime(endtime);

            String sql = DBHelper.getSelectHistoryDataCommands(tablename, colums, devId, st.ToString(), et.ToString());
            dt = DBHelper.selectFromDB(sql);
            return dt;
        }
        /// <summary>
        /// 添加统计曲线
        /// </summary>
        public void AddStatisticSeries(DataTable dt)
        {
            //最大值
            DataSeries maxSeries = new DataSeries();
            maxSeries.LegendText = "最大值";
            maxSeries.RenderAs = RenderAs.Line;
            //最小值
            DataSeries minSeries = new DataSeries();
            minSeries.LegendText = "最小值";        //说明文本
            minSeries.RenderAs = RenderAs.Line;

            //平均值
            DataSeries avgSeries = new DataSeries();
            avgSeries.LegendText = "平均值";        //说明文本
            avgSeries.RenderAs = RenderAs.Line;

            foreach (DataRow item in dt.Rows)
            {
                //最大值
                DataPoint maxdataPoint = new DataPoint();//数据点
                maxdataPoint.MarkerSize = 8;
                maxdataPoint.AxisXLabel = Convert.ToString(item["DataTime"]);
                maxdataPoint.YValue = Convert.ToDouble(item["maxdosenowvalue"]);
                maxSeries.DataPoints.Add(maxdataPoint);//数据点添加到数据系列
                
                //最小值
                DataPoint mindataPoint = new DataPoint();//数据点
                mindataPoint.MarkerSize = 8;
                mindataPoint.AxisXLabel = Convert.ToString(item["DataTime"]);
                mindataPoint.YValue = Convert.ToDouble(item["mindosenowvalue"]);
                avgSeries.DataPoints.Add(mindataPoint);
                //平均值
                DataPoint avgdataPoint = new DataPoint();//数据点
                avgdataPoint.MarkerSize = 8;
                avgdataPoint.AxisXLabel = Convert.ToString(item["DataTime"]);
                avgdataPoint.YValue = Convert.ToDouble(item["avgdosenowvalue"]);
                minSeries.DataPoints.Add(avgdataPoint);
            }
            //添加到图表
            hvc.Series.Add(maxSeries);
            hvc.Series.Add(minSeries);
            hvc.Series.Add(avgSeries);
        }
    }
}
