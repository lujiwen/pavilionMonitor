# pavilionMonitor
##��mysql���ݿ��������豸��ip�Ͷ˿ں� �����ڵ�mysql��������ʵ����192.168.1.200 �ڵ���
## ʹ��tcp/udp�����þ� ������socket���ӣ��˿ںŷֱ��ǣ�5000,4005,4001�� ������������
## �������ݣ�ʹ������֮ǰɽ���ʼ�����ĵ�����ͷ��ص����ݸ�ʽ��ѭ�����������в���
## ������������ȫ��ͨ


###�Ҽ�����˵�����Ҫ��xml�ļ�д��������������ݣ�
        <Grid.ContextMenu >
            <ContextMenu Background="#FF565656" BorderBrush="#FF565656" >
                <MenuItem Header="��������"  Background="#FF565656" Click="settings_btn_Click" Foreground="White" />
                <MenuItem Header="�鿴��ʷ����" Background="#FF565656"  Click="history_btn_Click"  Foreground="White" BorderBrush="#FF565656" />
            </ContextMenu>
        </Grid.ContextMenu>
		
	Ȼ��������¼���ʵ��Click="some_event" 
	
	
### ������� WPF DataGrid
�����http://www.cnblogs.com/xiaogangqq123/archive/2012/05/07/2487166.html


### 1 ÿ���豸�����ڳ����ʼ����ʱ����һ��ComConnection ,Ȼ��ͨ��������sendCommands������
###	2 ��ȡ����getDevsData ���豸�ࣩ
###	3 �������ݣ����밢������Ϣ���� sendMsg��Aliyun_ons.cs��,ÿ��10s ���Ὣ�����豸����Ϣ�����"<package><DeviceDataBox_DryWet systemId=\"\" cabId=\"\" devId=\"\" cab_state=\"\" rainy_state=\"\" rain_time=\"\" state=\"Normal\" unit=\"\" highThreshold=\"\" lowThreshold=\"\" factor=\"\" /><DeviceDataBox_JL900 systemId=\"\" cabId=\"\" devId=\"\" presure=\"\" real_traffic=\"\" sample_volume=\"\" keep_time=\"\" state=\"Normal\" unit=\"\" highThreshold=\"\" lowThreshold=\"\" factor=\"\" /><DeviceDataASM02Box systemId=\"\" cabId=\"\" devId=\"\" val_str_set=\"\" state=\"Normal\" unit=\"\" highThreshold=\"\" lowThreshold=\"\" factor=\"\" /></package>"
��������ʽ��������������Ϣ���� .
	

�������ݣ�
	
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

Ŀǰ���ڵ����⣺ 
jl900 ��drywet �����豸�ڽ������ݵ�ʱ����е��������Ƿ���ȷ������Ҫ��һ��������

	
