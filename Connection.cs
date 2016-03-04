﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace PavilionMonitor
{
 
    /**
     * 尽可能做到 PLC 串口服务器 二级子系统 3种接入方式 接口一样。
     * 
     * **/
    public class Connection
    {
        private String ip;
        private String port;
        private bool succeed; //是否连接成功
        private bool test;//是否为测试状态

        public  UInt32 receiveNullMaxCount = 5;//每个读取数据周期，最长等待时间 5*500 ms=2.5 S 


        public Connection()
        {
        }
        public Connection(String ip,String port) 
        {
            this.ip = ip;
            this.port = port;
            this.succeed = false;
        }
        /// <summary>
        /// 启动连接
        /// </summary>
        public virtual Boolean StartConnection() { return false; }
        /// <summary>
        /// 断开连接
        /// </summary>
        public virtual Boolean StopConnection() { return false; }

        /// <summary>
        /// 下发命令
        /// </summary>
        public virtual int sendCommands()
        {
            return 0;
        }
        /// <summary>
        /// 结束数据
        /// </summary>
        /// <returns></returns>
        public virtual bool getDevsData()
        {
            return true;
        }
        public String Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        public String Port
        {
            get { return port; }
            set { port = value; }
        }
        public bool Succeed
        {
            get { return succeed; }
            set { succeed = value; }
        }
        public bool Test
        {
            get { return test; }
            set { test = value; }
        }
    }
}
