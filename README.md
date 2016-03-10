# pavilionMonitor
##从mysql数据库里来读设备的ip和端口号 ，现在的mysql服务器在实验室192.168.1.200 节点上
## 使用tcp/udp调试用具 来创建socket连接（端口号分别是：5000,4005,4001） ，来发送数据
## 发送数据，使用我们之前山哥邮件里面的的命令和返回的数据格式，循环发送来进行测试
## 至此数据流完全走通


###右键点出菜单，需要在xml文件写入类似下面的内容：
        <Grid.ContextMenu >
            <ContextMenu Background="#FF565656" BorderBrush="#FF565656" >
                <MenuItem Header="参数设置"  Background="#FF565656" Click="settings_btn_Click" Foreground="White" />
                <MenuItem Header="查看历史曲线" Background="#FF565656"  Click="history_btn_Click"  Foreground="White" BorderBrush="#FF565656" />
            </ContextMenu>
        </Grid.ContextMenu>
		
	然后具体点击事件，实现Click="some_event" 
	
	
### 报表采用 WPF DataGrid
详见：http://www.cnblogs.com/xiaogangqq123/archive/2012/05/07/2487166.html


### 1 每个设备都会在程序初始化的时候建立一个ComConnection ,然后通过发命令sendCommands（），
	2 读取数据getDevsData （设备类）
	3 解析数据，放入阿里云消息队列 sendMsg（Aliyun_ons.cs）
	
	
	
