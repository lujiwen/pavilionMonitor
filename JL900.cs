﻿using PavilionMonitor.Package;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PavilionMonitor
{
    // 超大流量
    class JL900 : DevicePavilion, INotifyPropertyChanged
    {

        private int presure;


        private float real_traffic, sample_volume; // 实时流量 采样体积


        private string keep_time = ""; // 降雨时间

        public DeviceDataJL900Box jl900_box = new DeviceDataJL900Box();



        public JL900(UInt32 id, String ip, String port)
            : base(id, ip, port)       
        {
            presure = 0;
            real_traffic = 0.0f;
            sample_volume = 0;
            keep_time = "00:00:00";

        }


        //判定值是否改变，用于实时显示
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



      public override void setDevState(string state)
        {
            DevState = state;  // 糟糕的设计。父类引用更新子类成员，触发界面更新
        }
      public String DevState
      {
          get { return devState; }
          set
          {
              devState = value;
              if (this.PropertyChanged != null)
              {
                  this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("DevState"));
              }
          }
      }
        public float Real_traffic
        {
            get { return real_traffic; }
            set { real_traffic = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Real_traffic"));
                }
            }
        }
        public int Presure
        {
            get { return presure; }
            set { presure = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Presure"));
                }
            }
        }

        public float Sample_volume
        {
            get { return sample_volume; }
            set
            {
                sample_volume = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Sample_volume"));
                }
            }
        }
        public string Keep_time
        {
            get { return keep_time; }
            set { keep_time = value;
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Keep_time"));
            }
            }
        }


        public override bool isDataRight(byte[] flowBytes,int len)
        {
            bool dataright = true;

            if ( len == 26) // 不能仅仅用长度判断
                return dataright;
            else
                return false;
        }


        public override void AnalysisPavilionData(byte[] flowBytes,int len)
        {
            byte [] buffer = new byte[24];  // 去除首尾 无效 1字节
            Array.Copy(flowBytes,1,buffer,0,23); // 结果为ASCII，去除头部多余1字节与尾部2字节
            buffer[23] = 0;

            String data_str = Encoding.ASCII.GetString(buffer);
            string[] str_arr = data_str.Split(' ');
            if (str_arr.Length == 4)
            {
                Presure = Convert.ToInt32(str_arr[0]); // 压差
                Real_traffic = (float)Convert.ToDouble(str_arr[1]); //实时流量
                Sample_volume = (float)Convert.ToDouble(str_arr[2]); //采样体积
                if(str_arr[3].Length>=7)
                    Keep_time = str_arr[3].Substring(0,7) ; // 只有7个长度
                //keep_time = 0;
                //string[] time_arr = str_arr[3].Split(':');
                //if (time_arr.Length == 3) {
                //    keep_time += Convert.ToInt32(time_arr[0]) * 3600; // 小时数
                //    keep_time += Convert.ToInt32(time_arr[1]) * 60;  //分钟数
                //    keep_time += Convert.ToInt32(time_arr[2]);
                //}
            }


        }

        // 更新最新的数据
        public override void getAliyunUpdateStr()
        {
            State current_dev_state = State.Normal;
            if (DevState.Equals("掉线"))
                current_dev_state = State.DevError;
            //只更新数据
            jl900_box.load("运输部亭子", "1", "" + devId,current_dev_state,""+Presure,""+Real_traffic,""+Sample_volume,Keep_time,"","","","");

        }
        public override String getHistoryDataSql()
        {
            if (rtPaint)
            { //该设备正在绘制实时曲线
                float[] dosevalues = new float[3];
                // 如何绑定显示 ？？？？ 显示变量统一用字符串？？？？？

                dosevalues[0] = presure;//压力值 
                dosevalues[1] = real_traffic;//实时流量
                dosevalues[2] = sample_volume; //采样体积

                Rtce(dosevalues);
            }
            DateTime dt = DateTime.Now;
            String[] colums = { "DevId", "val1", "val2", "val3", "val4", "str_val5", "DataTime", "State" }; // 4个float+ 1个字符串 +单位 状态 
            Object[] values = { devId, presure,real_traffic,sample_volume, 0, "'" + keep_time + "'", "'" + dt.ToString() + "'", "'" + DevState + "'" };
            String sql = DBHelper.getInsertCommands("monthhistorydata", colums, values);
            sql += ";";
            sql += DBHelper.getInsertCommands("historydata", colums, values); // 复制两条sql ？？？  历史数据库

            return sql;
        }

        public override String getExcepDataSql()
        {
            DateTime dt = DateTime.Now;
            String[] colums = { "DevId", "val1", "val2", "val3", "val4", "str_val5", "DataTime", "State" }; // 4个float+ 1个字符串 +单位 状态 
            Object[] values = { devId, presure, real_traffic, sample_volume, 0, "'" + keep_time + "'", "'" + dt.ToString() + "'",  "'" + DevState + "'" };
            String sql = DBHelper.getInsertCommands("exceptionhistorydata", colums, values);

            return sql;
        }



        /// <summary>
        /// 2115房间数据或参数读取命令生成。
        /// </summary>
        /// <returns></returns>
        public override byte[] ToReadDataCommand()
        {
            byte[] command = {0x80,0x4D,0x45,0x41,0x20,0x53,0x43,0x41,0x4E,0x20,0x31,0x20,0x34,0x03,0x70}; // 超大流量15字节命令
            // 固定内容
            return command;
        }

        public override void doWork()
        {


        }


    }
}
