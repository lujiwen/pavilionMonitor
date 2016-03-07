using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Threading;
using System.Windows;

namespace PavilionMonitor
{
    public class DBHelper
    {
        public static string Ip;
        public static string UserName;
        public static string Password;
        public static string Database;

        private static MySqlConnection writeConnection;

        private static MySqlConnection readConnection;

        private static Thread dbService; //数据库线程
        static Queue<String> waitingInsertDBData = new Queue<string>();//入库队列
        static Mutex mx = new Mutex(); //写入数据库，互斥
        public static Boolean IsStop = false;
        /// <summary>
        /// 从配置文件中读取数据库相关参数
        /// </summary>
        public static void getConnectStrings()
        {
            Configuration cfm = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Ip = cfm.AppSettings.Settings["Ip"].Value;
            Database = cfm.AppSettings.Settings["DataBase"].Value;
            UserName = cfm.AppSettings.Settings["User"].Value;
            Password = cfm.AppSettings.Settings["PassWord"].Value;
        }
        /// <summary>
        /// 新建mySql连接
        /// </summary>
        /// <param name="IP">ip地址</param>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="Database">数据库名称</param>
        /// <returns></returns>
        public static void createSqlConnection(string IP, string UserName, string Password, string Database)
        {
            try
            {
                string connectionString = "server=" + IP + ";username=" + UserName + ";password=" + Password + ";database=" + Database + ";Charset=utf8;pooling=false";
                if (writeConnection == null)
                {
                     writeConnection = new MySqlConnection(connectionString);
                }
                if (readConnection == null){
                  readConnection = new MySqlConnection(connectionString);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 执行插入、更新、删除语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>0表示插入、更新、删除正常，1代表异常</returns>
        public static int OperateToDB(String sql)
        {
            int code = 0;
            try
            {
                createSqlConnection(Ip, UserName, Password, Database);
                if (writeConnection.State == System.Data.ConnectionState.Closed)
                {
                    writeConnection.Open();
                }
                MySqlCommand sqlCom = new MySqlCommand();
                sqlCom.CommandText = sql;
                sqlCom.Connection = writeConnection;
                sqlCom.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                if (MessageBox.Show(e.ToString(), "数据库异常", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                }
                else
                {
                };
                code = 1;
            }
            finally
            {
                writeConnection.Close();
            }
            return code;
        }
        /// <summary>
        /// 根据插入的数据，获取插入语句
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="colums">插入列名</param>
        /// <param name="values">每一列的值</param>
        public static String getInsertCommands(String tablename, String[] colums, Object[] values)
        {
            String commands = "insert into " + tablename + "(";
            for (int i = 0; i < colums.Length; i++)
            {
                if (i == colums.Length - 1)
                {
                    commands += colums[i];
                    commands += ")";
                }
                else
                {
                    commands += colums[i];
                    commands += ",";
                }
            }
            commands += " values(";
            for (int i = 0; i < values.Length; i++)
            {
                if (i == values.Length - 1)
                {
                    commands += values[i];
                    commands += ")";
                }
                else
                {
                    commands += values[i];
                    commands += ",";
                }
            }
            return commands;
        }
        /// <summary>
        /// 根据更新的数据，获取更新语句
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="colums">插入列名</param>
        /// <param name="values">每一列的值</param>
        /// <param name="colums">条件列</param>
        /// <param name="values">条件列值</param>
        public static String getUpdateCommands(String tablename, String[] colums, Object[] values
                , String[] condColums, Object[] conds)
        {
            String commands = "update " + tablename + " set ";
            for (int i = 0; i < colums.Length; i++)
            {

                commands += colums[i];
                commands += "=";
                commands += values[i];
                if (i != colums.Length - 1)
                {
                    commands += ",";
                }
            }
            commands += " where ";

            for (int i = 0; i < condColums.Length; i++)
            {
                commands += condColums[i];
                commands += "=";
                commands += conds[i];
                if (i != condColums.Length - 1)
                {
                    commands += " AND ";
                }
            }
            return commands;
        }
        /// <summary>
        /// 根据删除的数据，获取删除语句
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="colums">插入列名</param>
        public static String getDeleteCommands(String tablename, UInt32 id)
        {
            String commands = null;
            if (tablename == "CabInfo")
            {
                commands = "delete from " + tablename + " where Id=" + id;
            }
            else if (tablename == "DeviceInfo")
            {
                commands = "delete from " + tablename + " where Id=" + id;
            }
            return commands;
        }
        /// <summary>
        /// 从数据库中获取数据
        /// </summary>
        /// <param name="con">连接</param>
        /// <param name="selectsql">sql语句</param>
        /// <returns></returns>
        public static DataTable selectFromDB(String selectsql)
        {
            DataTable dt = new DataTable();
            try
            {
                createSqlConnection(Ip, UserName, Password, Database);
                if (readConnection.State == System.Data.ConnectionState.Closed)
                {
                    readConnection.Open();
                }
                MySqlCommand sqlCom = new MySqlCommand();
                sqlCom.CommandText = selectsql;
                sqlCom.Connection = readConnection;
                MySqlDataReader data = sqlCom.ExecuteReader();
                dt.Load(data);
            }
            catch (MySqlException e)
            {
                if (MessageBox.Show(e.ToString(), "数据库异常", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Thread.CurrentThread.Abort();
                }
                else
                {
                };
            }
            finally
            {
                readConnection.Close();
            }
            return dt;
        }

        /// <summary>
        /// 查询历史数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="volums"></param>
        /// <param name="id"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static String getSelectHistoryDataCommands(String tablename, String[] volums, UInt32 id,
            String startTime, String endTime)
        {
            String sql = null;
            sql = "select ";
            for (int i = 0; i < volums.Length; i++)
            {
                sql += volums[i];
                if (i != volums.Length - 1)
                {
                    sql += ",";
                }
                else
                {
                    sql += " ";
                }
            }
            sql += "from " + tablename + " where DevId=" + id;
            sql += " AND DataTime between '" + startTime + "' AND '" + endTime +"'";
            return sql;
        }
        /// <summary>
        /// 查询所有柜子或设备数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static String getSelectAllInfoCommands(String tablename)
        {
            String sql = "select * from " + tablename;
            return sql;
        }
        /// <summary>
        /// 查询柜子或设备数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static String getSelectInfoCommands(String tablename, String[] condColums, Object[] conds)
        {
            String sql = null;
            sql = "select * from " + tablename + " where ";
            for (int i = 0; i < condColums.Length; i++)
            {
                sql += condColums[i];
                sql += "=";
                sql += conds[i];
                if (i != condColums.Length - 1)
                {
                    sql += " AND ";
                }
            }
            return sql;
        }
        /// <summary>
        /// db线程用于数据写入数据库
        /// </summary>
        public static void startDbThread()
        {
            dbService = new Thread(new ThreadStart(InsertDB));
            dbService.Name = "dbThread";
            dbService.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void StopDbThread()
        {
            dbService.Join();
            dbService.Abort();
        }
        /// <summary>
        /// 向队列中添加插入数据语句
        /// </summary>
        /// <param name="sql"></param>
        public static void InsertSqlToQueue(String sql)
        {
            mx.WaitOne();
            waitingInsertDBData.Enqueue(sql);
            LogUtil.Log(0,"线程入库","线程" + Thread.CurrentThread.Name + "向入库队列插入一条语句");
            mx.ReleaseMutex();
        }
        /// <summary>
        /// 从队列中获取一个数据插入语句，写入数据库
        /// </summary>
        public static void InsertDB()
        {
            //等待1秒钟后才监测
            Thread.Sleep(500);
            while (!IsStop)
            {
                try
                {
                    while (waitingInsertDBData.Count != 0)//当插入队列中还有需要入库的数据
                    {
                        mx.WaitOne();
                        //针对所有的设备，进行入库操作
                        String sql = waitingInsertDBData.Dequeue();//一个柜子里所有设备的插入语句
                        mx.ReleaseMutex();
                        OperateToDB(sql);
                    }
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    LogUtil.Log(1, e.ToString(), "");
                }
            }
        }
    }
}
