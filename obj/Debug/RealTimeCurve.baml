   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    PavilionMonitor#   PavilionMonitor.RealTimeCurve   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  实时曲线��5   	   $	��510��6   $	��842��6#    � WindowStartupLocation$ CenterScreen=�6/   .��5      �  � 	Resources 5   
      solidTextStyle �� 
TargetType �� Property �� Value  changedTextStyle��%�  &	        &	     �� 5      " ��6+   .�5	      ��  � ��$ 12(�6-   �� 5
       � ��$ 20��6+   �� 5       � ��$ Arial)�6/   �� 5       �@��TextAlignment$ Center=�62   �� 5       � ��$ Center=�68   �� 5       � ��$ 5q�6+   5      �� 5      " ��6-   .�5      ��  � ��$ 12(�6-   �� 5       � ��$ 20��6+   �� 5       � ��$ Arial)�6/   �� 5       � ��$
 Bold"�6/   �� 5       �@��TextAlignment$ Center=�62   �� 5       � ��$ Center=�68   �� 5       � ��$
 Wrap=�61   �� 5       � ��$ 5q�6+   5      5       � RowDefinitions 5   
   �� 5      $��44 �6   �� 5      $
��326* �6    � ColumnDefinitions 5   
   �� 5       .+�5"   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��180,2,192,0q�6L   $	��264��6a   .+�5#      �� $��设备名称��6   
�������#��[  67   $��22��6_   $��5q�6k   �� 5$      -   5        $��devname��5$      #��[ 6'   $	��198��6Q   5%      �� 5'   
   -   5        $��realTimeCurves��5'      $��1��6+   $��5q�68   5(      5)      