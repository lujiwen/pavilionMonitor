using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ons;
using System.Threading;
using PavilionMonitor.Package;

namespace PavilionMonitor
{
    class Aliyun_ons
    {
        static ONSFactoryProperty factoryInfo;
        static ONSFactory onsfactory;
        static   Producer pProducer;
        private static Thread aliyunThread;
        static bool IsStop;

        static List<Box> dev_box_list; // 设备列表引用，用户获取box转换为阿里云中转信息 
        static Message msg;

        static void init() {

            IsStop = false;
         try
            {
              
            //producer创建和正常工作的参数，必须输入
             factoryInfo = new ONSFactoryProperty();
            factoryInfo.setFactoryProperty(factoryInfo.getProducerIdName(), "PID_SCU_APPLE_LAB_MIANYANG_TEST");//在ONS控制台申请的producerId
            factoryInfo.setFactoryProperty(factoryInfo.getPublishTopicsName(), "mianyang");// 在ONS 控制台申请的msg topic
            factoryInfo.setFactoryProperty(factoryInfo.getMsgContentName(), "input msg content");//消息内容
            factoryInfo.setFactoryProperty(factoryInfo.getAccessKeyName(), "VSU2d0h9m48FZbUZ");//ONS AccessKey
            factoryInfo.setFactoryProperty(factoryInfo.getSecretKeyName(), "JR6Ct6v6IgMLFmXXluNFNwPEgbIXI7");// ONS SecretKey
            //factoryInfo.setOnsChannel(ONSChannel.ALIYUN); //默认值为ONSChannel.ALIYUN，聚石塔用户必须设置为CLOUD，阿里云用户不需要设置(如果设置，必须设置为ALIYUN)

            //创建producer      
             onsfactory = new ONSFactory();
             pProducer = onsfactory.getInstance().createProducer(factoryInfo);

            //在发送消息前，必须调用start方法来启动Producer，只需调用一次即可。  
            pProducer.start();

             msg = new Message(
                //Message Topic
                        factoryInfo.getPublishTopics(),
                //Message Tag,可理解为Gmail中的标签，对消息进行再归类，方便Consumer指定过滤条件在ONS服务器过滤       
                        "TagA",
                //Message Body，任何二进制形式的数据，ONS不做任何干预，需要Producer与Consumer协商好一致的序列化和反序列化方式
                        factoryInfo.getMessageContent()
            );

                // 设置代表消息的业务关键属性，请尽可能全局唯一。
                // 以方便您在无法正常收到消息情况下，可通过ONS Console查询消息并补发。
                // 注意：不设置也不会影响消息正常收发
                msg.setKey("Pavilion");  // 亭子 监测车，名字 不一样
                }
             catch (ONSClientException e)
             {
                 LogUtil.Log(1, e.ToString(), "阿里云消息队列错误");
                 //异常处理
             }
        }

        static void sendMsg(string msg_info) {
            //发送消息，只要不抛异常就是成功   
            try
            {
                msg = new Message(
                    //Message Topic
                        factoryInfo.getPublishTopics(),
                    //Message Tag,可理解为Gmail中的标签，对消息进行再归类，方便Consumer指定过滤条件在ONS服务器过滤       
                        "TagA",
                    //Message Body，任何二进制形式的数据，ONS不做任何干预，需要Producer与Consumer协商好一致的序列化和反序列化方式
                        factoryInfo.getMessageContent()
            );
                msg.setKey("Pavilion");  // 亭子 监测车，名字 不一样
                // 设置代表消息的业务关键属性，请尽可能全局唯一。
                // 以方便您在无法正常收到消息情况下，可通过ONS Console查询消息并补发。
                // 注意：不设置也不会影响消息正常收发
                msg.setBody(msg_info);
                SendResultONS sendResult = pProducer.send(msg);
            }
            catch (ONSClientException e)
            {
                LogUtil.Log(1, e.ToString(), "阿里云消息队列错误");
                //异常处理
            }
        }

        static void shutDown() {
            // 在应用退出前，必须销毁Producer对象，否则会导致内存泄露等问题
            pProducer.shutdown();

        }

        static void AliyunHandler() {
            Thread.Sleep(500);
            while (!IsStop)
            {
                try
                {              
                    // 
                   string total_msg= BoxPackageUtil.Pack(dev_box_list);
                   sendMsg(total_msg); //向阿里云更新当前设备最新数据 

                    Thread.Sleep(10000); //10S 定时更新数据,需可动态配置扫描间隔时间
                }
                catch (Exception e)
                {
                    LogUtil.Log(1, e.ToString(), "");
                }
            }
        }
       public static void startAliyunThread(List<Box>box_list) {

            init();
            dev_box_list = box_list;
            aliyunThread = new Thread(new ThreadStart(AliyunHandler));
            aliyunThread.Name = "aliyunThread";
            aliyunThread.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void StopDbThread()
        {
            IsStop = true;
            aliyunThread.Join();
            aliyunThread.Abort();
        }


    }
}
