using PavilionMonitor.Package;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/**
 * 亭子程序说明
 * 针对亭子，极个别会用到曲线查看数据外，还有一些设备应该会用到 数据表绘制（文本内容呈现）。
后期也会有数据导出，这个功能由你们去完成吧。
  亭子代码说明：
   由于asm02气溶胶数据项目太多，所以界面不是灵活绑定，而是做成了固定样式。这对于后期如果有扩展设备可能
会不太方便。不过目前看来，每个地方设备是固定的，不过还有未调试的设备（rs131,雨量计，jr7000），这个后面
可以仿照之前设备代码，添加代码。
   针对串口服务器接入方式，每一个设备通过一个tcp连接（COMConnection）接入进来，系统全局管理这个COMConnection
列表，每一个COMConnection对象管理一个具体的设备类。具体设备类实现不同的命令生成，解析与sql生成代码。
  ASM02部署说明：需要王屯屯的asm02本地读取服务程序作为tcp server:5000端口 运行，亭子监测程序以客户端形式请求数据。
  运行环境要求：由于阿里云消息队列接口目前只尝试过x64位版本（xp没有64bit），所以建议 亭子相关电脑装 win7 64位。
  git 项目名：监测亭程序： PavilionMonitor；  asm02本地服务程序：LocalASM02Server
  数据库设计。设备历史数据（4个double变量+1个字符串型）。具体sql文件会上传到代码文件夹啊。
 * 每条数据存放两次（历史总表和月表同时插入一条记录）
 * 
 * 
 * **/


namespace PavilionMonitor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        JL900 jl90;  // 界面是单独处理，所以需要分别获取对象引用
        DryWet drywet;
        ASM02 asm02;
        // 待集成 
        RSS131 rss131;
        H3R7000 h3r7000;

        List<DevicePavilion> device_list;
        List<COMConnection> connection_list; // 连接集合，每一个连接关联一个设备
        static List<Box> box_list; //用于 阿里云数据中转更新的box 列表

        int device_num = 3;
        /// <summary>
        /// 绑定
        /// </summary>
        public void initBinding()
        {

            // 界面是单独处理，所以需要分别获取对象引用
            for (int j = 0; j < device_list.Count;j++ )
            {
                DevicePavilion dev=device_list[j];
                switch (dev.devType) {
                    case "RSS131":
                        rss131 = (RSS131)dev;
                        break;
                    case "JL900":
                        jl90 = (JL900)dev;
                        break;
                    case "H3R7000":
                        h3r7000 = (H3R7000)dev;
                        break;
                    case "ASM02":
                        asm02 = (ASM02)dev;
                        break;
                    case "DryWet":
                        drywet = (DryWet)dev;
                        break;               

                }

            }
            // jl90
            Binding bind_jl_p = new Binding();
            bind_jl_p.Source = jl90;
            bind_jl_p.Path = new PropertyPath("Presure");
            JL900_Presure.SetBinding(TextBlock.TextProperty,bind_jl_p);

            Binding bind_jl_rtrfc = new Binding();
            bind_jl_rtrfc.Source = jl90;
            bind_jl_rtrfc.Path = new PropertyPath("Real_traffic");
            JL900_RealTraffic.SetBinding(TextBlock.TextProperty, bind_jl_rtrfc);

            Binding bind_jl_spvl = new Binding();
            bind_jl_spvl.Source = jl90;
            bind_jl_spvl.Path = new PropertyPath("Sample_volume");
            JL900_Volume.SetBinding(TextBlock.TextProperty, bind_jl_spvl);

            Binding bind_jl_kpt = new Binding();
            bind_jl_kpt.Source = jl90;
            bind_jl_kpt.Path = new PropertyPath("Keep_time");
            JL900_Keeptime.SetBinding(TextBlock.TextProperty, bind_jl_kpt);

            Binding bind_jl_status = new Binding();
            bind_jl_status.Source = jl90;
            bind_jl_status.Path = new PropertyPath("DevState");
            JL900_Status.SetBinding(TextBlock.TextProperty, bind_jl_status);
            

            // drywet
            Binding bind_dw_cb_s = new Binding();
            bind_dw_cb_s.Source = drywet;
            bind_dw_cb_s.Path = new PropertyPath("Cab_state");
            DryWet_CabState.SetBinding(TextBlock.TextProperty, bind_dw_cb_s);

            Binding bind_dw_ra_s = new Binding();
            bind_dw_ra_s.Source = drywet;
            bind_dw_ra_s.Path = new PropertyPath("Rainy_state");
            DryWet_RainyState.SetBinding(TextBlock.TextProperty, bind_dw_ra_s);

            Binding bind_dw_ra_time = new Binding();
            bind_dw_ra_time.Source = drywet;
            bind_dw_ra_time.Path = new PropertyPath("Rain_time");
            DryWet_RainyTime.SetBinding(TextBlock.TextProperty, bind_dw_ra_time);

            Binding bind_dw_status = new Binding();
            bind_dw_status.Source = jl90;
            bind_dw_status.Path = new PropertyPath("DevState");
            DryWet_Status.SetBinding(TextBlock.TextProperty, bind_dw_status);



            // asm02   ab 8
            Binding bind_asm02_status = new Binding();
            bind_asm02_status.Source = jl90;
            bind_asm02_status.Path = new PropertyPath("DevState");
            ASM02_Status.SetBinding(TextBlock.TextProperty, bind_asm02_status);


            Binding bind_ab_1 = new Binding();
            bind_ab_1.Source = asm02;
            bind_ab_1.Path = new PropertyPath("Ab_1");
            ab_1.SetBinding(TextBlock.TextProperty, bind_ab_1);
            Binding bind_ab_2 = new Binding();
            bind_ab_2.Source = asm02;
            bind_ab_2.Path = new PropertyPath("Ab_2");
            ab_2.SetBinding(TextBlock.TextProperty, bind_ab_2);
            Binding bind_ab_3 = new Binding();
            bind_ab_3.Source = asm02;
            bind_ab_3.Path = new PropertyPath("Ab_3");
            ab_3.SetBinding(TextBlock.TextProperty, bind_ab_3);
            Binding bind_ab_4 = new Binding();
            bind_ab_4.Source = asm02;
            bind_ab_4.Path = new PropertyPath("Ab_4");
            ab_4.SetBinding(TextBlock.TextProperty, bind_ab_4);
            Binding bind_ab_5 = new Binding();
            bind_ab_5.Source = asm02;
            bind_ab_5.Path = new PropertyPath("Ab_5");
            ab_5.SetBinding(TextBlock.TextProperty, bind_ab_5);
            Binding bind_ab_6 = new Binding();
            bind_ab_6.Source = asm02;
            bind_ab_6.Path = new PropertyPath("Ab_6");
            ab_6.SetBinding(TextBlock.TextProperty, bind_ab_6);
            Binding bind_ab_7 = new Binding();
            bind_ab_7.Source = asm02;
            bind_ab_7.Path = new PropertyPath("Ab_7");
            ab_7.SetBinding(TextBlock.TextProperty, bind_ab_7);
            Binding bind_ab_8 = new Binding();
            bind_ab_8.Source = asm02;
            bind_ab_8.Path = new PropertyPath("Ab_8");
            ab_8.SetBinding(TextBlock.TextProperty, bind_ab_8);

            // ec  8
            Binding bind_ec_1 = new Binding();
            bind_ec_1.Source = asm02;
            bind_ec_1.Path = new PropertyPath("Ec_1");
            ec_1.SetBinding(TextBlock.TextProperty, bind_ec_1);
            Binding bind_ec_2 = new Binding();
            bind_ec_2.Source = asm02;
            bind_ec_2.Path = new PropertyPath("Ec_2");
            ec_2.SetBinding(TextBlock.TextProperty, bind_ec_2);
            Binding bind_ec_3 = new Binding();
            bind_ec_3.Source = asm02;
            bind_ec_3.Path = new PropertyPath("Ec_3");
            ec_3.SetBinding(TextBlock.TextProperty, bind_ec_3);
            Binding bind_ec_4 = new Binding();
            bind_ec_4.Source = asm02;
            bind_ec_4.Path = new PropertyPath("Ec_4");
            ec_4.SetBinding(TextBlock.TextProperty, bind_ec_4);
            Binding bind_ec_5 = new Binding();
            bind_ec_5.Source = asm02;
            bind_ec_5.Path = new PropertyPath("Ec_5");
            ec_5.SetBinding(TextBlock.TextProperty, bind_ec_5);
            Binding bind_ec_6 = new Binding();
            bind_ec_6.Source = asm02;
            bind_ec_6.Path = new PropertyPath("Ec_6");
            ec_6.SetBinding(TextBlock.TextProperty, bind_ec_6);
            Binding bind_ec_7 = new Binding();
            bind_ec_7.Source = asm02;
            bind_ec_7.Path = new PropertyPath("Ec_7");
            ec_7.SetBinding(TextBlock.TextProperty, bind_ec_7);
            Binding bind_ec_8 = new Binding();
            bind_ec_8.Source = asm02;
            bind_ec_8.Path = new PropertyPath("Ec_8");
            ec_8.SetBinding(TextBlock.TextProperty, bind_ec_8);

            // fl  10
            Binding bind_fl_1 = new Binding();
            bind_fl_1.Source = asm02;
            bind_fl_1.Path = new PropertyPath("Fl_1");
            fl_1.SetBinding(TextBlock.TextProperty, bind_fl_1);
            Binding bind_fl_2 = new Binding();
            bind_fl_2.Source = asm02;
            bind_fl_2.Path = new PropertyPath("Fl_2");
            fl_2.SetBinding(TextBlock.TextProperty, bind_fl_2);
            Binding bind_fl_3 = new Binding();
            bind_fl_3.Source = asm02;
            bind_fl_3.Path = new PropertyPath("Fl_3");
            fl_3.SetBinding(TextBlock.TextProperty, bind_fl_3);
            Binding bind_fl_4 = new Binding();
            bind_fl_4.Source = asm02;
            bind_fl_4.Path = new PropertyPath("Fl_4");
            fl_4.SetBinding(TextBlock.TextProperty, bind_fl_4);
            Binding bind_fl_5 = new Binding();
            bind_fl_5.Source = asm02;
            bind_fl_5.Path = new PropertyPath("Fl_5");
            fl_5.SetBinding(TextBlock.TextProperty, bind_fl_5);
            Binding bind_fl_6 = new Binding();
            bind_fl_6.Source = asm02;
            bind_fl_6.Path = new PropertyPath("Fl_6");
            fl_6.SetBinding(TextBlock.TextProperty, bind_fl_6);
            Binding bind_fl_7 = new Binding();
            bind_fl_7.Source = asm02;
            bind_fl_7.Path = new PropertyPath("Fl_7");
            fl_7.SetBinding(TextBlock.TextProperty, bind_fl_7);
            Binding bind_fl_8 = new Binding();
            bind_fl_8.Source = asm02;
            bind_fl_8.Path = new PropertyPath("Fl_8");
            fl_8.SetBinding(TextBlock.TextProperty, bind_fl_8);
            Binding bind_fl_9 = new Binding();
            bind_fl_9.Source = asm02;
            bind_fl_9.Path = new PropertyPath("Fl_9");
            fl_9.SetBinding(TextBlock.TextProperty, bind_fl_9);
            Binding bind_fl_10 = new Binding();
            bind_fl_10.Source = asm02;
            bind_fl_10.Path = new PropertyPath("Fl_10");
            fl_10.SetBinding(TextBlock.TextProperty, bind_fl_10);

            // ga 7
            Binding bind_ga_1 = new Binding();
            bind_ga_1.Source = asm02;
            bind_ga_1.Path = new PropertyPath("Ga_1");
            ga_1.SetBinding(TextBlock.TextProperty, bind_ga_1);
            Binding bind_ga_2 = new Binding();
            bind_ga_2.Source = asm02;
            bind_ga_2.Path = new PropertyPath("Ga_2");
            ga_2.SetBinding(TextBlock.TextProperty, bind_ga_2);
            Binding bind_ga_3 = new Binding();
            bind_ga_3.Source = asm02;
            bind_ga_3.Path = new PropertyPath("Ga_3");
            ga_3.SetBinding(TextBlock.TextProperty, bind_ga_3);
            Binding bind_ga_4 = new Binding();
            bind_ga_4.Source = asm02;
            bind_ga_4.Path = new PropertyPath("Ga_4");
            ga_4.SetBinding(TextBlock.TextProperty, bind_ga_4);
            Binding bind_ga_5 = new Binding();
            bind_ga_5.Source = asm02;
            bind_ga_5.Path = new PropertyPath("Ga_5");
            ga_5.SetBinding(TextBlock.TextProperty, bind_ga_5);
            Binding bind_ga_6 = new Binding();
            bind_ga_6.Source = asm02;
            bind_ga_6.Path = new PropertyPath("Ga_6");
            ga_6.SetBinding(TextBlock.TextProperty, bind_ga_6);
            Binding bind_ga_7 = new Binding();
            bind_ga_7.Source = asm02;
            bind_ga_7.Path = new PropertyPath("Ga_7");
            ga_7.SetBinding(TextBlock.TextProperty, bind_ga_7);

            // gi  7
            Binding bind_gi_1 = new Binding();
            bind_gi_1.Source = asm02;
            bind_gi_1.Path = new PropertyPath("Gi_1");
            gi_1.SetBinding(TextBlock.TextProperty, bind_gi_1);
            Binding bind_gi_2 = new Binding();
            bind_gi_2.Source = asm02;
            bind_gi_2.Path = new PropertyPath("Gi_2");
            gi_2.SetBinding(TextBlock.TextProperty, bind_gi_2);
            Binding bind_gi_3 = new Binding();
            bind_gi_3.Source = asm02;
            bind_gi_3.Path = new PropertyPath("Gi_3");
            gi_3.SetBinding(TextBlock.TextProperty, bind_gi_3);
            Binding bind_gi_4 = new Binding();
            bind_gi_4.Source = asm02;
            bind_gi_4.Path = new PropertyPath("Gi_4");
            gi_4.SetBinding(TextBlock.TextProperty, bind_gi_4);
            Binding bind_gi_5 = new Binding();
            bind_gi_5.Source = asm02;
            bind_gi_5.Path = new PropertyPath("Gi_5");
            gi_5.SetBinding(TextBlock.TextProperty, bind_gi_5);
            Binding bind_gi_6 = new Binding();
            bind_gi_6.Source = asm02;
            bind_gi_6.Path = new PropertyPath("Gi_6");
            gi_6.SetBinding(TextBlock.TextProperty, bind_gi_6);
            Binding bind_gi_7 = new Binding();
            bind_gi_7.Source = asm02;
            bind_gi_7.Path = new PropertyPath("Gi_7");
            gi_7.SetBinding(TextBlock.TextProperty, bind_gi_7);

            //me  9
            Binding bind_me_1 = new Binding();
            bind_me_1.Source = asm02;
            bind_me_1.Path = new PropertyPath("Me_1");
            me_1.SetBinding(TextBlock.TextProperty, bind_me_1);
            Binding bind_me_2 = new Binding();
            bind_me_2.Source = asm02;
            bind_me_2.Path = new PropertyPath("Me_2");
            me_2.SetBinding(TextBlock.TextProperty, bind_me_2);
            Binding bind_me_3 = new Binding();
            bind_me_3.Source = asm02;
            bind_me_3.Path = new PropertyPath("Me_3");
            me_3.SetBinding(TextBlock.TextProperty, bind_me_3);
            Binding bind_me_4 = new Binding();
            bind_me_4.Source = asm02;
            bind_me_4.Path = new PropertyPath("Me_4");
            me_4.SetBinding(TextBlock.TextProperty, bind_me_4);
            Binding bind_me_5 = new Binding();
            bind_me_5.Source = asm02;
            bind_me_5.Path = new PropertyPath("Me_5");
            me_5.SetBinding(TextBlock.TextProperty, bind_me_5);
            Binding bind_me_6 = new Binding();
            bind_me_6.Source = asm02;
            bind_me_6.Path = new PropertyPath("Me_6");
            me_6.SetBinding(TextBlock.TextProperty, bind_me_6);
            Binding bind_me_7 = new Binding();
            bind_me_7.Source = asm02;
            bind_me_7.Path = new PropertyPath("Me_7");
            me_7.SetBinding(TextBlock.TextProperty, bind_me_7);
            Binding bind_me_8 = new Binding();
            bind_me_8.Source = asm02;
            bind_me_8.Path = new PropertyPath("Me_8");
            me_8.SetBinding(TextBlock.TextProperty, bind_me_8);
            Binding bind_me_9 = new Binding();
            bind_me_9.Source = asm02;
            bind_me_9.Path = new PropertyPath("Me_9");
            me_9.SetBinding(TextBlock.TextProperty, bind_me_9);
            Binding bind_me_10 = new Binding();
            bind_me_10.Source = asm02;
            bind_me_10.Path = new PropertyPath("Me_10");
            me_10.SetBinding(TextBlock.TextProperty, bind_me_10);

            //oi 7
            Binding bind_oi_1 = new Binding();
            bind_oi_1.Source = asm02;
            bind_oi_1.Path = new PropertyPath("Oi_1");
            oi_1.SetBinding(TextBlock.TextProperty, bind_oi_1);
            Binding bind_oi_2 = new Binding();
            bind_oi_2.Source = asm02;
            bind_oi_2.Path = new PropertyPath("Oi_2");
            oi_2.SetBinding(TextBlock.TextProperty, bind_oi_2);
            Binding bind_oi_3 = new Binding();
            bind_oi_3.Source = asm02;
            bind_oi_3.Path = new PropertyPath("Oi_3");
            oi_3.SetBinding(TextBlock.TextProperty, bind_oi_3);
            Binding bind_oi_4 = new Binding();
            bind_oi_4.Source = asm02;
            bind_oi_4.Path = new PropertyPath("Oi_4");
            oi_4.SetBinding(TextBlock.TextProperty, bind_oi_4);
            Binding bind_oi_5 = new Binding();
            bind_oi_5.Source = asm02;
            bind_oi_5.Path = new PropertyPath("Oi_5");
            oi_5.SetBinding(TextBlock.TextProperty, bind_oi_5);
            Binding bind_oi_6 = new Binding();
            bind_oi_6.Source = asm02;
            bind_oi_6.Path = new PropertyPath("Oi_6");
            oi_6.SetBinding(TextBlock.TextProperty, bind_oi_6);
            Binding bind_oi_7 = new Binding();
            bind_oi_7.Source = asm02;
            bind_oi_7.Path = new PropertyPath("Oi_7");
            oi_7.SetBinding(TextBlock.TextProperty, bind_oi_7);

            // rn 6
            Binding bind_rn_1 = new Binding();
            bind_rn_1.Source = asm02;
            bind_rn_1.Path = new PropertyPath("Rn_1");
            rn_1.SetBinding(TextBlock.TextProperty, bind_rn_1);
            Binding bind_rn_2 = new Binding();
            bind_rn_2.Source = asm02;
            bind_rn_2.Path = new PropertyPath("Rn_2");
            rn_2.SetBinding(TextBlock.TextProperty, bind_rn_2);
            Binding bind_rn_3 = new Binding();
            bind_rn_3.Source = asm02;
            bind_rn_3.Path = new PropertyPath("Rn_3");
            rn_3.SetBinding(TextBlock.TextProperty, bind_rn_3);
            Binding bind_rn_4 = new Binding();
            bind_rn_4.Source = asm02;
            bind_rn_4.Path = new PropertyPath("Rn_4");
            rn_4.SetBinding(TextBlock.TextProperty, bind_rn_4);
            Binding bind_rn_5 = new Binding();
            bind_rn_5.Source = asm02;
            bind_rn_5.Path = new PropertyPath("Rn_5");
            rn_5.SetBinding(TextBlock.TextProperty, bind_rn_5);
            Binding bind_rn_6 = new Binding();
            bind_rn_6.Source = asm02;
            bind_rn_6.Path = new PropertyPath("Rn_6");
            rn_6.SetBinding(TextBlock.TextProperty, bind_rn_6);

            //Thread th = new Thread(new ThreadStart(update_data));
            //th.Start();
        }

        //public void update_data()
        //{
        //    while (true)
        //    {
        //        jl90.Real_traffic += 1;
        //        drywet.Rain_time += 3; ;
        //        asm02.Ec_3 = "23";

        //        Thread.Sleep(500);

        //    }
        //}
        public MainWindow()
        {
            //string te = "Ab:,,,3.13E-003,,,,1.85E-002;Ec:,,,,,,,;Fl:01200,002.8,27.0,35.0,000.0,31.7,16.1,01.2,3,401;Ga:,,,,3.60E-001,,;Gi:,,,,1.98E-002,,;Me:0.00e+000,0.0,0,,+0.0,0.0,000,,,;Oi:,,,,,,;Rn:4.82E+000,2.12E-001,,1.31E-001,2.15E-001,";
            //string[] te_arr = te.Split(';');
            //for (int i = 0; i < te_arr.Length; i++)
            //{
            //    string target = te_arr[i];
            //    int cc = te_arr[i].IndexOf(':') + 1;
            //    string result = te_arr[i].Substring(cc, te_arr[i].Length - cc);
            //    string[] re_arrrs = result.Split(',');
            //    for (int k = 0; k < re_arrrs.Length; k++) { 
            //        string outputs=re_arrrs[k];
            //        LogUtil.Log(1,outputs,"ff");
            //    }
            //}

                InitializeComponent();
            // 读取数据库，初始化相关设备对象 
            DBHelper.getConnectStrings();
            device_list = GetDevicesFromDB();
            device_num = device_list.Count;

            // 界面初始化 
            initBinding();

            // 开启循环数据请求线程  一个线程对应一个连接            
            // 创建网络连接对象，关联设备
            connection_list = new List<COMConnection>();
            for (int k = 0; k < device_num; k++)
            {
                COMConnection dev_con = new COMConnection(device_list[k]);
                connection_list.Add(dev_con);
                dev_con.NewMonitorData += DBHelper.InsertSqlToQueue;
                dev_con.StartConnection(); // 开启请求数据线程 
            }
            //启动数据库操作
            DBHelper.startDbThread();

            // 关联 阿里云更新数据的box列表
            box_list = new List<Box>();
            box_list.Add(drywet.drywet_box);
            box_list.Add(jl90.jl900_box);
            box_list.Add(asm02.asm02_box);

            //启动阿里云中转数据线程
           Aliyun_ons.startAliyunThread(box_list);

        }

        private List<DevicePavilion> GetDevicesFromDB()
        {
            //RSS131
            //JL900
            //H3R7000
            //ASM02
            //DryWet
            List<DevicePavilion> devices = new List<DevicePavilion>();
            String selectsql = DBHelper.getSelectAllInfoCommands("deviceinfo");
            DataTable dt = DBHelper.selectFromDB(selectsql);
            foreach (DataRow row in dt.Rows)
            {
                UInt32 id = (UInt32)Convert.ToInt32(row[0]);
                String type = row[1].ToString();
                String location = row[2].ToString();
                String ip = row[3].ToString();
                String port = row[4].ToString();
                Double highThresthold = Convert.ToDouble(row[5]);
                Double lowThreasthold = Convert.ToDouble(row[6]);
                Double correctFactor = Convert.ToDouble(row[7]);
                String dataUnit = row[8].ToString();
                int scanTime = Convert.ToInt32(row[11]);
                string deviceStatus = row[12].ToString();
                // 只初始化 有效设备 
                if (deviceStatus.Equals("valid")) {
                    //DevicePavilion device = new DevicePavilion(id, ip, port);
                    Type tp = Type.GetType("PavilionMonitor." + type);
                    Type[] types = new Type[3];
                    types[0] = typeof(UInt32);
                    types[1] = typeof(String);
                    types[2] = typeof(String);
                    //有参构造
                    ConstructorInfo ct = tp.GetConstructor(types);
                    Object[] paras = new Object[3];
                    paras[0] = id;
                    paras[1] = ip;
                    paras[2] = port;
                    DevicePavilion device = (DevicePavilion)ct.Invoke(paras);

                    device.thresholdHigh = highThresthold;
                    device.thresholdLow = lowThreasthold;
                    device.correctFactor = correctFactor;
                    device.devUnit = dataUnit;
                    device.periodInterval = scanTime;
                    device.devType = type;
                    devices.Add(device);                
                }              
            }

            return devices;
        }

        protected override void OnClosed(EventArgs e)
        {
            try
            {
                base.OnClosed(e);
                //结束通信线程
                for (int k = 0; k < connection_list.Count; k++) {
                    connection_list[k].StopConnection();
                }
                //结束数据线程
                DBHelper.IsStop = true;
                DBHelper.StopDbThread();
                //当前应用主进程结束
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                //LogUtil.WriteLog(typeof(MainWindow),ex.ToString());
                LogUtil.Log(1, ex.ToString(), "");
            }
        
        }

        private void chaoda_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 目前只有超大流量需要绘制曲线。其他设备以后扩展
            RealTimeCurve real_window = new RealTimeCurve(jl90); // 以后扩展，传递其他设备id
            jl90.Rtce += real_window.Refresh;
            real_window.Show();


        }

    }
}
