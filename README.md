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
	2 ��ȡ����getDevsData ���豸�ࣩ
	3 �������ݣ����밢������Ϣ���� sendMsg��Aliyun_ons.cs��
	
	
	
