   M S B A M L   `   `   `  ����  PavilionMonitor     PavilionMonitor.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5        $��window��5   	     � Title$  监测亭子系统��5   	   $	��850��6   $
��1310��6%   .��5      �  � RowDefinitions 5   
   �� 5      .+�5   
   � $��0��6   
������� 5      �� 5      $	��170 �6    �� 5       � ColumnDefinitions 5      �� 5      $
��220* �6#   �� 5      $
��220* �6#   �� 5      $
��220* �6#   �� 5      $
��220* �6#   �� 5      $
��220* �6#   .+�5      � -   5        $��chaoda��5   |   $��Stretch=�6   $��Stretch=�62   $��0��6N   $��0��6[   $��5,5,5,5q�6k   ���	#FFFFFFFF 5      �� 5      $��25 �6$   �� 5      $��30 �6$   �� 5      $��30 �6$   �� 5      $��30 �6$   �� 5       $��30 �6$   �� 5!       5#      �� 5$      $	��100 �6'   �� 5%      $
��100* �6'   .+�5'      �� $��超大流量��6   $��Center=�6(   $��Center=�6E   $��0��6`   $��0��6m   $��2��6}   $
��Bold"�6�   �� 5(      -   5        $��JL900_Status��5(   �   $��status��6   
���  ��$��Right=�6;   $��Center=�6W   $��0��6r   $��0��6   $��2��6�   $
��Bold"�6�   6�   �� 5)      $��压力值Pa��6   $��Center=�6)   $��Center=�6F   $��1��6a   $��0��6n   �� 5*      $��瞬时流量m^3/h��6   $��Center=�6-   $��Center=�6J   $��2��6e   $��0��6r   �� 5+      $��采样体积m^3��6   $��Center=�6+   $��Center=�6H   $��3��6c   $��0��6p   �� 5,      $��采样时间��6   $��Center=�6(   $��Center=�6E   $��4��6`   $��0��6m   �� 5.      -   5        $��JL900_Presure��5.   �   $��10��6   $��Center=�6&   $��Center=�6C   $��1��6^   $��1��6k   ���	#FF3399FF6�   �� 5/      -   5        $��JL900_RealTraffic��5/   �   $��12��6   $��Center=�6&   $��Center=�6C   $��2��6^   $��1��6k   ���	#FF3399FF6�   �� 50      -   5        $��JL900_Volume��50   �   $��3��6   $��Center=�6%   $��Center=�6B   $��3��6]   $��1��6j   ���	#FF3399FF6�   �� 51      -   5        $��JL900_Keeptime��51   �   $��0:40:34��6   $��Center=�6+   $��Center=�6H   $��4��6c   $��1��6p   ���	#FF3399FF6�   53      � 55      -   5        $��ganshi��55   �   $��Stretch=�6   $��Stretch=�62   $��0��6N   $��1��6[   $��5,5,5,5q�6k   ���	#FFFFFFFF 56      �� 57      $��25 �6$   �� 58      $��30 �6$   �� 59      $��30 �6$   �� 5:      $��30 �6$   �� 5;      $��30 �6$   �� 5<       5>      �� 5?      $	��100 �6'   �� 5@      $
��100* �6'   .+�5B      �� $��干湿沉降��6   $��Center=�6)   $��Bottom=�6F   $��0��6a   $��1��6n   $
��Bold"�6~   $��1.36,0,101.36,4.88q�6�   �� 5C      -	   5        $��DryWet_Status��5C   �   $��status��6   
���  ��$��Right=�6;   $��Center=�6W   $��0��6r   $��0��6   $��2��6�   $
��Bold"�6�   6�   �� 5D      $��盖子状态��6   $��Center=�6(   $��Center=�6E   $��1��6`   $��0��6m   �� 5E      $��下雨状态��6   $��Center=�6(   $��Center=�6E   $��2��6`   $��0��6m   �� 5F      $��降雨时间 分钟��6   $��Center=�6+   $��Center=�6H   $��3��6c   $��0��6p   �� 5H      -
   5        $��DryWet_CabState��5H   �   $��开盖��6   $��Center=�6&   $��Center=�6C   $��1��6^   $��1��6k   ���	#FF3399FF6�   �� 5I      -   5        $��DryWet_RainyState��5I   �   $��降雨��6   $��Center=�6&   $��Center=�6C   $��2��6^   $��1��6k   ���	#FF3399FF6�   �� 5J      -   5        $��DryWet_RainyTime��5J   �   $��3��6   $��Center=�6%   $��Center=�6B   $��3��6]   $��1��6j   ���	#FF3399FF6�   5K      � 5M      -   5        $��rs131��5M   �   $��Stretch=�6   $��Stretch=�62   $��0��6N   $��2��6[   $��5,5,5,5q�6k   ���	#FFFFFFFF.+�5N      �� $��Center=�6   ��6:   ��  �� Path$ ActualWidth� �� ElementName$ rs131��.+�5O      �� $��RS131��6    $��Center=�6-   $
��Bold"�6K   �� 5P      -   5        $��RS131_Status��5P   �   $�� ��6    
���  ��$��Right=�69   $��Center=�6U   $��0��6p   $��0��6}   $��2��6�   $
��Bold"�6�   6�   5Q      5R      � 5T      -   5        $��	yuliangji��5T   �   $��Stretch=�6   $��Stretch=�62   $��0��6N   $��3��6[   $��5,5,5,5q�6k   ���	#FFFFFFFF.+�5U      �� $��Center=�6   ��6:   �� $ ActualWidth�$ 	yuliangji��.+�5V      �� $��	雨量计��6    $��Center=�6+   $
��Bold"�6I   �� 5W      -   5        $��YuLiangji_Status��5W   �   $�� ��6    
���  ��$��Right=�69   $��Center=�6U   $��0��6p   $��0��6}   $��2��6�   $
��Bold"�6�   6�   5X      5Y      � 5[      -   5        $��	quanchuan��5[   �   $��Stretch=�6   $��Stretch=�62   $��0��6N   $��4��6[   $��5,5,5,5q�6k   ���	#FFFFFFFF.+�5\      �� $��Center=�6   ��6:   �� $ ActualWidth�$ 	quanchuan��.+�5]      �� $��全氚取样器��6    $��Center=�6-   $
��Bold"�6J   �� 5^      -   5        $��QuanChuan_Status��5^   �   $�� ��6    
���  ��$��Right=�69   $��Center=�6U   $��0��6p   $��0��6}   $��2��6�   $
��Bold"�6�   6�   5_      5`      � 5c      -   5        $��
qirongjiao��5c   �   $��Stretch=�6   $��Stretch=�62   $��1��6N   $��0��6[   $��5��6k   $��5,5,5,5q�6   ���	#FFFFFFFF 5e      �� 5f      $��25 �6$   �� 5g      $��70 �6$   �� 5h      $��70 �6$   �� 5i      $��70 �6$   �� 5j      $��70 �6$   �� 5k      $��70 �6$   �� 5l      $��70 �6$   �� 5m      $��70 �6$   �� 5n      $��70 �6$   �� 5o       5q      �� 5r      $��30 �6'   �� 5s      $	��128 �6'   �� 5t      $	��128 �6'   �� 5u      $	��128 �6'   �� 5v      $	��128 �6'   �� 5w      $	��128 �6'   �� 5x      $	��128 �6'   �� 5y      $	��128 �6'   �� 5z      $	��128 �6'   �� 5{      $	��128 �6'   �� 5|      $	��128 �6'    � ContextMenu 5~      �� 5�      .@�5�      m� -   5        $��AsmViewHistory��5�   3   $��查询历史记录��6#   ���	#FF5656566a   5�      .+�5�      �� $��	气溶胶��6   $��Center=�6(   $��Center=�6E   $��0��6`   $��0��6m   $��11��6}   $
��Bold"�6�   �� 5�      -   5        $��ASM02_Status��5�   �   $�� ��6   
���  ��$��Right=�65   $��Center=�6Q   $��0��6l   $��0��6y   $��10��6�   $
��Bold"�6�   6�   �� 5�      $��Ab��6   $��Center=�6'   $��Center=�6D   $��1��6_   $��0��6l   $
��Bold"�6}   �� 5�      $��Ec��6   $��Center=�6'   $��Center=�6D   $��2��6_   $��0��6l   $
��Bold"�6}   �� 5�      $��Fl��6   $��Center=�6'   $��Center=�6D   $��3��6_   $��0��6l   $
��Bold"�6}   �� 5�      $��Ga��6   $��Center=�6'   $��Center=�6D   $��4��6_   $��0��6l   $
��Bold"�6}   �� 5�      $��Gi��6   $��Center=�6'   $��Center=�6D   $��5��6_   $��0��6l   $
��Bold"�6}   �� 5�      $��Me��6   $��Center=�6'   $��Center=�6D   $��6��6_   $��0��6l   $
��Bold"�6}   �� 5�      $��Oi��6   $��Center=�6'   $��Center=�6D   $��7��6_   $��0��6l   $
��Bold"�6}   �� 5�      $��Rn��6   $��Center=�6'   $��Center=�6D   $��8��6_   $��0��6l   $
��Bold"�6}   �� 5�      $��11��6   $
��Left=�61   $��3��6L   $��8,0.2,-5.2,0q�6W   $��1��6m   $	��Top=�6z   $
��1300��6�   �� 5�      $��11��6   $
��Left=�61   $��3��6L   $��8,0.2,-5.2,0q�6W   $��2��6m   $	��Top=�6z   $
��1300��6�   �� 5�      $��11��6   $
��Left=�61   $��3��6L   $��8,0.2,-5.2,0q�6W   $��3��6m   $	��Top=�6z   $
��1300��6�   �� 5�      $��11��6   $
��Left=�61   $��3��6L   $��8,0.2,-5.2,0q�6W   $��4��6m   $	��Top=�6z   $
��1300��6�   �� 5�      $��11��6   $
��Left=�61   $��3��6L   $��8,0.2,-5.2,0q�6W   $��5��6m   $	��Top=�6z   $
��1300��6�   �� 5�      $��11��6   $
��Left=�61   $��3��6L   $��8,0.2,-5.2,0q�6W   $��6��6m   $	��Top=�6z   $
��1300��6�   �� 5�      $��11��6   $
��Left=�61   $��3��6L   $��8,0.2,-5.2,0q�6W   $��7��6m   $	��Top=�6z   $
��1300��6�   �� 5�      $��11��6   $
��Left=�61   $��3��6L   $��8,0.2,-5.2,0q�6W   $��8��6m   $	��Top=�6z   $
��1300��6�   �� 5�      $��11��6   $
��Left=�61   $��3��6L   $��8,0.2,-5.2,0q�6W   $��9��6m   $	��Top=�6z   $
��1300��6�   �� 5�      $��1��6   $��1��6*   .+�5�      �� $&�� Artificial α min. Concentration��6    $
��Wrap=�6G   $��Center=�6[   $��Center=�6x   $��5,5,5,5q�6�   �� 5�      -   5        $
��ab_1��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��1��6   $��2��6*   .+�5�      �� $&�� Artificial α max. Concentration��6    $
��Wrap=�6G   $��Center=�6[   $��Center=�6x   $��5,5,5,5q�6�   �� 5�      -   5        $
��ab_2��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��1��6   $��3��6*   .+�5�      �� $#��Deviation of α Concentration��6    $
��Wrap=�6D   $��Center=�6X   $��Center=�6u   $��5,5,5,5q�6�   �� 5�      -   5        $
��ab_3��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��1��6   $��4��6*   .+�5�      �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Artificial α LD�� 6�   6�   �� 5�      -   5        $
��ab_4��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��1��6   $��5��6*   .+�5�      �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Artificial β�� 6�   Concentration min6�   �� 5�      -   5        $
��ab_5��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��1��6   $��6��6*   .+�5�      �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Artificial β�� 6�   Concentration max6�   �� 5�      -   5        $
��ab_6��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��1��6   $��7��6*   .+�5�      �� $#��Deviation of β Concentration��6    $
��Wrap=�6D   $��Center=�6X   $��Center=�6u   $��5,5,5,5q�6�   �� 5�      -   5        $
��ab_7��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��1��6   $��8��6*   .+�5�      �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Artificial β LD�� 6�   6�   �� 5�      -   5        $
��ab_8��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��2��6   $��1��6*   .+�5�      �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   
Filter NO.�� 6�   6�   �� 5�      -   5        $
��ec_1��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��2��6   $��2��6*   .+�5�      �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Detector ID�� 6�   6�   �� 5�      -   5        $
��ec_2��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��2��6   $��3��6*   .+�5�      �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   	Isotope�� 6�   6�   �� 5�      -    5        $
��ec_3��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��2��6   $��4��6*   .+�5�      �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   " ByHalfLifeCorrected Activity[Bq]6�   �� 5�      -!   5        $
��ec_4��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��2��6   $��5��6*   .+�5�      �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Deviation of Activity [%]6�   �� 5�      -"   5        $
��ec_5��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��2��6   $��6��6*   .+�5�      �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Measured Activity [Bq]6�   �� 5�      -#   5        $
��ec_6��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��2��6   $��7��6*   .+�5�      �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Deviation of Measures [%]6�   �� 5�      -$   5        $
��ec_7��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��2��6   $��8��6*   .+�5�      �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   %#DeviationFromCorrected Activity [%]6�   �� 5�      -%   5        $
��ec_8��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��3��6   $��1��6*   .+�5�      �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Elapsed Cycle Time sec6�   �� 5�      -&   5        $
��fl_1��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��3��6   $��2��6*   .+�5�      �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Flow Volume m3�� 6�   6�   �� 5�      -'   5        $
��fl_2��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��3��6   $��3��6*   .+�5�      �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Inlet Temp.°C�� 6�   6�   �� 5�      -(   5        $
��fl_3��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��3��6   $��4��6*   .+�5�      �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Int. Temp °C�� 6�   6�   �� 5�      -)   5        $
��fl_4��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��3��6   $��5��6*   .+�5�      �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Cryo.Temp.°C�� 6�   6�   �� 5�      -*   5        $
��fl_5��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��3��6   $��6��6*   .+�5�      �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Flow.resistance R1�� 6�   6�   �� 5�      -+   5        $
��fl_6��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��3��6   $��7��6*   .+�5�      �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Flow.resistance R2�� 6�   6�   �� 5�      -,   5        $
��fl_7��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��3��6   $��8��6*   .+�5�      �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Flow.resistance R3�� 6�   6�   �� 5�      --   5        $
��fl_8��5�   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�      �� 5�      $��3��6   $��9��6*   .+�5�      �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Aer. filter No.�� 6�   6�   �� 5      -.   5        $
��fl_9��5   �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5     �� 5     $��3��6   $��10��6*   .+�5     �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Iod filter No.�� 6�   6�   �� 5     -/   5        $��fl_10��5  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5     �� 5	     $��4��6   $��1��6*   .+�5
     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Nuclide of Contamination6�   �� 5     -0   5        $
��ga_1��5  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5     �� 5     $��4��6   $��2��6*   .+�5     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Artificial min. Concentration6�   �� 5     -1   5        $
��ga_2��5  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5     �� 5     $��4��6   $��3��6*   .+�5     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Artificial max. Concentration6�   �� 5     -2   5        $
��ga_3��5  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5     �� 5     $��4��6   $��4��6*   .+�5     �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Deviation of Concentration6�   �� 5     -3   5        $
��ga_4��5  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5     �� 5     $��4��6   $��5��6*   .+�5     �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   	Cs-137 LD�� 6�   6�   �� 5     -4   5        $
��ga_5��5  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5     �� 5     $��4��6   $��6��6*   .+�5     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Cs-137 Equ..Conc.min6�   �� 5     -5   5        $
��ga_6��5  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5      �� 5!     $��4��6   $��7��6*   .+�5"     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Cs-137 Equ..Conc.max6�   �� 5#     -6   5        $
��ga_7��5#  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5$     �� 5(     $��5��6   $��1��6*   .+�5)     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Nuclide of Contamination6�   �� 5*     -7   5        $
��gi_1��5*  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5+     �� 5,     $��5��6   $��2��6*   .+�5-     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Artificial min.Concentration6�   �� 5.     -8   5        $
��gi_2��5.  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5/     �� 50     $��5��6   $��3��6*   .+�51     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Artificial max.Concentration6�   �� 52     -9   5        $
��gi_3��52  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   53     �� 54     $��5��6   $��4��6*   .+�55     �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Deviation of Concentration6�   �� 56     -:   5        $
��gi_4��56  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   57     �� 58     $��5��6   $��5��6*   .+�59     �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   	I-131 LD.�� 6�   6�   �� 5:     -;   5        $
��gi_5��5:  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5;     �� 5<     $��5��6   $��6��6*   .+�5=     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   I-131 Equ.Conc.min�� 6�   6�   �� 5>     -<   5        $
��gi_6��5>  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5?     �� 5@     $��5��6   $��7��6*   .+�5A     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   I-131Equ..Conc.max�� 6�   6�   �� 5B     -=   5        $
��gi_7��5B  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5C     �� 5F     $��6��6   $��1��6*   .+�5G     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Dose-rate(Sv/h)�� 6�   6�   �� 5H     ->   5        $
��me_1��5H  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5I     �� 5J     $��6��6   $��2��6*   .+�5K     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Rain�� 6�   6�   �� 5L     -?   5        $
��me_2��5L  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5M     �� 5N     $��6��6   $��3��6*   .+�5O     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Rain Status�� 6�   6�   �� 5P     -@   5        $
��me_3��5P  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5Q     �� 5R     $��6��6   $��4��6*   .+�5S     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Temperature1(°C)�� 6�   6�   �� 5T     -A   5        $
��me_4��5T  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5U     �� 5V     $��6��6   $��5��6*   .+�5W     �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Temperature2(°C)�� 6�   6�   �� 5X     -B   5        $
��me_5��5X  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5Y     �� 5Z     $��6��6   $��6��6*   .+�5[     �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Direction of Wind(°)�� 6�   6�   �� 5\     -C   5        $
��me_6��5\  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5]     �� 5^     $��6��6   $��7��6*   .+�5_     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Velocity of Wind(m/s)6�   �� 5`     -D   5        $
��me_7��5`  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5a     �� 5b     $��6��6   $��8��6*   .+�5c     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Pressure(mBar)�� 6�   6�   �� 5d     -E   5        $
��me_8��5d  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5e     �� 5f     $��6��6   $��9��6*   .+�5g     �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Relative Humidity(%)6�   �� 5h     -F   5        $
��me_9��5h  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5i     �� 5j     $��6��6   $��10��6*   .+�5k     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Container Temperature(°C)6�   �� 5l     -G   5        $��me_10��5l  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5m     �� 5p     $��7��6   $��1��6*   .+�5q     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Nuclide of Contamination6�   �� 5r     -H   5        $
��oi_1��5r  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5s     �� 5t     $��7��6   $��2��6*   .+�5u     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Artificial min.Concentration6�   �� 5v     -I   5        $
��oi_2��5v  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5w     �� 5x     $��7��6   $��3��6*   .+�5y     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Artificial max.Concentration6�   �� 5z     -J   5        $
��oi_3��5z  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5{     �� 5|     $��7��6   $��4��6*   .+�5}     �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Deviation of Concentration6�   �� 5~     -K   5        $
��oi_4��5~  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5     �� 5�     $��7��6   $��5��6*   .+�5�     �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   	I-131 LD.�� 6�   6�   �� 5�     -L   5        $
��oi_5��5�  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�     �� 5�     $��7��6   $��6��6*   .+�5�     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   I-131 Equ.Conc.min�� 6�   6�   �� 5�     -M   5        $
��oi_6��5�  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�     �� 5�     $��7��6   $��7��6*   .+�5�     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   I-131Equ..Conc.max�� 6�   6�   �� 5�     -N   5        $
��oi_7��5�  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�     �� 5�     $��8��6   $��1��6*   .+�5�     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   	Radom EEC�� 6�   6�   �� 5�     -O   5        $
��rn_1��5�  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�     �� 5�     $��8��6   $��2��6*   .+�5�     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   Radom EEC Deviation[%]6�   �� 5�     -P   5        $
��rn_2��5�  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�     �� 5�     $��8��6   $��3��6*   .+�5�     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   
Radon LD�� 6�   6�   �� 5�     -Q   5        $
��rn_3��5�  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�     �� 5�     $��8��6   $��4��6*   .+�5�     �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   
Thoron EEC�� 6�   6�   �� 5�     -R   5        $
��rn_4��5�  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�     �� 5�     $��8��6   $��5��6*   .+�5�     �� $
��Wrap=�6    $��Center=�64   $��Center=�6Q   $��5,5,5,5q�6l   Thoron EEC Deviation[%]6�   �� 5�     -S   5        $
��rn_5��5�  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�     �� 5�     $��8��6   $��6��6*   .+�5�     �� $
��Wrap=�6!   $��Center=�65   $��Center=�6R   $��5,5,5,5q�6m   	Thoron LD�� 6�   6�   �� 5�     -T   5        $
��rn_6��5�  �   $��3.12e23��6    $
��Wrap=�6/   $��Center=�6C   $��Center=�6`   $��5,5,5,5q�6{   ���	#FF3399FF6�   5�     5�     5�     5�     5�     