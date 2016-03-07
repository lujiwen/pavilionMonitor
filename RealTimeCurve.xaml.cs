using System;
using Visifire.Charts;
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
using System.Data;
using System.Windows.Threading;



namespace PavilionMonitor
{
    /// <summary>
    /// RealTimeCurve.xaml 的交互逻辑
    /// </summary>
    /// 
    public delegate void FreshFunc(float[] values);
    public partial class RealTimeCurve : Window
    {
        VisifireChart rlvc;
        
        UInt32 devId;
        String devType;
        String dataUnit;
        DevicePavilion target_dev;
        public RealTimeCurve(DevicePavilion bind_dev)
        {
            InitializeComponent();
            devId = bind_dev.devId;
            target_dev = bind_dev;
            target_dev.rtPaint = true;
            initRLNormal();
        }
        /// <summary>
        /// 初始化实时曲线chart的常规属性
        /// </summary>
        public void initRLNormal()
        {
            rlvc = new VisifireChart();
            rlvc.Height = 400;
            rlvc.Width = 700;
            rlvc.Margin = new Thickness(5);
            rlvc.Background = new SolidColorBrush(Colors.White);
            rlvc.View3D = false;
            rlvc.AnimationEnabled = false;
            rlvc.AnimatedUpdate = true;
            rlvc.IndicatorEnabled = true;
            setDevInfoByDevId(devId);
            devname.Text = devType;
            //图表标题
            Title title = new Title();
            title.Text = "运行情况";
            //图表X轴
            Axis axisX = new Axis();
            axisX.Interval = 5;//每隔五个点显示一个时间
            axisX.Title = "日期";
            //图表Y轴
            Axis axisY = new Axis();
            axisY.Title = dataUnit;
            //添加到界面
            rlvc.Titles.Add(title);
            rlvc.AxesX.Add(axisX);
            rlvc.AxesY.Add(axisY);
            realTimeCurves.Children.Add(rlvc);
            //添加曲线
            AddSeries();
        }
        /// <summary>
        /// 设置设备的基本属性
        /// </summary>
        /// <param name="devId"></param>
        public void setDevInfoByDevId(UInt32 devId)
        {
            String[] cond = { "Id" };
            object[] value = { devId };
            String sql = DBHelper.getSelectInfoCommands("deviceinfo", cond, value);
            DataTable dt = DBHelper.selectFromDB(sql);
            foreach (DataRow row in dt.Rows)
            {
                devType = row["Type"].ToString();//类型
                dataUnit = row["DataUnit"].ToString();//单位
            }
        }
        /// <summary>
        /// 添加需要监测的曲线
        /// </summary>
        public void AddSeries()
        {
            //实时值
            DataSeries nowSeries = new DataSeries();
            nowSeries.LegendText = "压力值"; //说明文本
            nowSeries.RenderAs = RenderAs.Line;
            //平均值
            DataSeries avgSeries = new DataSeries();
            avgSeries.LegendText = "瞬时流量";
            avgSeries.RenderAs = RenderAs.Line;

            //五分钟标准差值
            DataSeries stdSeries = new DataSeries();
            stdSeries.LegendText = "采样体积";
            stdSeries.RenderAs = RenderAs.Line;

            //添加到图表
            rlvc.Series.Add(nowSeries);
            rlvc.Series.Add(avgSeries);
            rlvc.Series.Add(stdSeries);
        }
        /// <summary>
        /// 更新线程
        /// </summary>
        /// <param name="values"></param>
        public void Refresh(float[] values)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new FreshFunc(Repaint), values);
        }
        /// <summary>
        /// 刷新界面
        /// </summary>
        /// <param name="values"></param>
        public void Repaint(float[] values)
        {
            float[] tempvalues;
            tempvalues = values;
            //更新
            for (int i = 0; i < rlvc.Series.Count; i++)
            {
                DataSeries series = rlvc.Series[i];//曲线，实时值：平均值
                DataPointCollection dpc = series.DataPoints;
                int count = dpc.Count;
                //如果当前的点小于100个时，则往前移,并且要新建数据点。否则，只需要将后一个点的值赋给前一个，最后一个的值更新为新的数据
                if (count < 60)
                {
                    //向前移
                    for (int j = 0; j < count - 1; j++)
                    {
                        dpc[j].YValue = dpc[j + 1].YValue;
                        //dpc[j].XValue = dpc[j + 1].XValue;
                        dpc[j].AxisXLabel = dpc[j + 1].AxisXLabel;
                    }
                    //新建显示的点
                    DataPoint dp = new DataPoint();
                    dp.MarkerSize = 8;
                    dp.AxisXLabel = DateTime.Now.ToString("hh:mm:ss").Trim();
                    dp.YValue = tempvalues[i];
                    series.DataPoints.Add(dp);
                }
                else
                {
                    //向前移
                    for (int j = 0; j < count - 1; j++)
                    {
                        dpc[j].YValue = dpc[j + 1].YValue;
                        dpc[j].AxisXLabel = dpc[j + 1].AxisXLabel;
                    }
                    //更新数据
                    dpc[count - 1].AxisXLabel = DateTime.Now.ToString("hh:mm:ss").Trim();
                    dpc[count - 1].YValue = tempvalues[i];
                }
            }
        }

       protected override void OnClosed(EventArgs e)
        {
            target_dev.rtPaint = false;
            target_dev.Rtce -= Refresh; ;
             base.OnClosed(e);
        }

    }
}
