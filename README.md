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
###	2 读取数据getDevsData （设备类）
###	3 解析数据，放入阿里云消息队列 sendMsg（Aliyun_ons.cs）,每过10s 都会将所有设备的信息打包成"<package><DeviceDataBox_DryWet systemId=\"\" cabId=\"\" devId=\"\" cab_state=\"\" rainy_state=\"\" rain_time=\"\" state=\"Normal\" unit=\"\" highThreshold=\"\" lowThreshold=\"\" factor=\"\" /><DeviceDataBox_JL900 systemId=\"\" cabId=\"\" devId=\"\" presure=\"\" real_traffic=\"\" sample_volume=\"\" keep_time=\"\" state=\"Normal\" unit=\"\" highThreshold=\"\" lowThreshold=\"\" factor=\"\" /><DeviceDataASM02Box systemId=\"\" cabId=\"\" devId=\"\" val_str_set=\"\" state=\"Normal\" unit=\"\" highThreshold=\"\" lowThreshold=\"\" factor=\"\" /></package>"
这样的形式，发给阿里云消息队列 .
	

测试数据：
	
4001 JL900

967 668.4 440.1 0:39:38!
06 39 37 30 20 36 36 39 2E 33 20 34 34 31 2E 32 20 30 3A 33 39 3A 34 34 03 28 
949 661.8 443.2 0:39:55#
958 665.1 445.3 0:40:06!
966 667.9 445.4 0:40:07 
973 670.5 445.7 0:40:08"
06 39 35 33 20 36 36 33 2E 33 20 34 34 39 2E 34 20 30 3A 34 30 3A 32 38 03 29 


4005 drywet 
0032cda03b3030303830313130303132025701 

ASM 5000 

目前存在的问题： 
jl900 ，drywet 两个设备在接受数据的时候进行的正误检查是否正确，还需要进一步分析。

	
