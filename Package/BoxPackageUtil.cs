using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace PavilionMonitor.Package
{
    /// <summary>
    /// 未采用互斥量的发送控制中心
    /// </summary>
    public class BoxPackageUtil
    {
        static Thread packSendReceiveService;
        static Boolean isSendTure =true;//是否向外发送
        static Boolean isStop = false;//是否停止发送
        //static IPEndPoint recivepoint = new IPEndPoint(
        //    new IPAddress(ASCIIEncoding.ASCII.GetBytes("192.168.1.110")),8000);   //对应的IP和端口号
        static UdpClient udpconnect;
        static String remotecontrolcenterIp = "192.168.1.8";//远程ip
        static int remotecontrolcenterPort = 58888; //远程端口
        static Queue<String> waitingSendReceiveDatas = new Queue<string>();//发送控制中心数据队列
        /// <summary>
        /// db线程用于数据写入数据库
        /// </summary>
        public static void startPackSendReceiveThread()
        {
            packSendReceiveService = new Thread(new ThreadStart(Send208Data));
            isStop = false;
            udpconnect = new UdpClient();
            packSendReceiveService.Name = "packSendReceive";
            packSendReceiveService.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void stopPackSendReceiveThread()
        {
            isStop = true;
            if (udpconnect != null)
                udpconnect.Close();
            try
            {
                packSendReceiveService.Join();
                packSendReceiveService.Abort();//终止线程
            }
            catch (Exception ex)
            {
                String logstr = "异常终止发送控制中心数据线程" + ex.ToString();
            }
        }
        /// <summary>
        /// 向队列中添加插入数据语句
        /// </summary>
        /// <param name="sql"></param>
        public static void InsertSendReceive(String sendReceiveData)
        {
            waitingSendReceiveDatas.Enqueue(sendReceiveData);
        }
        /// <summary>
        /// 从队列中获取一个数据插入语句，写入数据库
        /// </summary>
        public static void Send208Data()
        {
            //等待1秒钟后才监测
            Thread.Sleep(500);
            while (!isStop)
            {
                try
                {
                    Thread.Sleep(500);
                    while (isSendTure && waitingSendReceiveDatas.Count != 0)
                    {
                        String datas = waitingSendReceiveDatas.Dequeue();//
                        Byte[] senddatasBytes = ASCIIEncoding.ASCII.GetBytes(datas);
                        if (udpconnect != null)
                        {
                            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(remotecontrolcenterIp), remotecontrolcenterPort);
                            int res = udpconnect.Send(senddatasBytes, senddatasBytes.Length, endPoint);
                        }
                        else
                        {
                            udpconnect = new UdpClient();
                            udpconnect.Send(senddatasBytes, senddatasBytes.Length, remotecontrolcenterIp, remotecontrolcenterPort);
                        }
                        Thread.Sleep(50);
                    }
                }
                catch (Exception e)
                {
                }
            }
        }

        /// <summary>
        /// 组包
        /// </summary>
        /// <param name="boxes"></param>
        /// <returns></returns>
        public static string Pack(List<Box> boxes)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("package");
            foreach (Box box in boxes)
            {
                XmlElement element = box.toXmlElement(doc);
                root.AppendChild(element);
            }
            doc.AppendChild(root);
            return doc.OuterXml;
        }
    }
}
