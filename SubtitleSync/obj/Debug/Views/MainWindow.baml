   M S B A M L   `   `   `  ����G  CSubtitleSync, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SubtitleSyncSubtitleSync  5   	   A%clr-namespace:SubtitleSync.ViewModelsSubtitleSync.ViewModels  5   	       SubtitleSync.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SubtitleSync     5   	   4vm%clr-namespace:SubtitleSync.ViewModels     5   	     � Title$  Subtitle Sync��5	   	   $	��600��5
   	   $	��540��5   	   $	��600��5   	   $	��540��5   	   $	��600��5   	   $	��540��5   	    � 	Resources 5      *   $SubtitleSync.ViewModels.MainWindowVM   vm��%   &	          5   
   6   5      .��5      � $��Stretch=�6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5       $��* �6   �� 5!      $��* �6   �� 5"      $��* �6   �� 5#      $��* �6   .+�5%   
   �� $��../images/Subtitle2.png��5&      $��2��5'      $��17,10,74,67q�5(      $��2��6"   �� 5)   
    �� 
IsReadOnly . 
�������$��Italic$�5,      $��2��5-      $��
17,18,8,18q�5.      $��1��5/      ��5)      �� *
OriginPath+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�5/      �� 50   
   $��SELECT��6   $��15,18,15,18q�52      $��0q�53      $��Calibri)�54      $
��Bold"�55      $��2��6#   $��1��63   ��51      �� *SelectOriginCommand+55   3   �� 56   
    . 
�������$��Italic$�59      $��2��5:      $��
17,18,8,18q�5;      $��2��5<      ��56      �� *DestinationPath+$ OneWay=�$ PropertyChanged=�5<      �� 5=   
   $��SELECT��6   $��15,17,15,18q�5?      $��0q�5@      $��2��5A      $��Calibri)�5B      $��Black"�5C      $��2��6$   ��5>      �� *SelectDestinationCommand+5C   $   �� 5D   
   $��2��5E      $��10,18,15,18q�5F      $��3��5G      $��1��6   ��5D      �� *
TimeSpan+ �� StringFormat$ {0:hh\:mm\:ss\.fff}��.��5G   /   5H      �� 5I   
    �� SelectedValuePath$	 Key��5K      	 �� DisplayMemberPath$	 Value��5L      $��10,17,15,17q�5M      $��4��5N      $��1��5O      $��2��5P      $��Calibri)�5Q      $��15(�5R      
 �� SelectedItem
 5I      ��  �� Path$ SelectedEncoding�$ TwoWay=�$ PropertyChanged=���5J      �� $ ComboBoxValues�$ OneTime=�5R      �� 5S   
   $��EXECUTE��6   $��1��5V      $��0q�5W      $
��Bold"�5X      $��10,15,10,15q�5Y      $��5��5Z      ��5T      �� *ExecuteCommand+��5U      �� *
OriginPath+5Z      �� 5[   
   $��preview��6   $��1��5]      $��0q�5^      $��10, 1, 10, 30q�5_      $��15(�5`      ���#E0771C$��6��5b      
������ ��5\      �� *OpenPreviewWindowCommand+5c      �� 5d   
   $��	TIMESPAN:��6   $��17,17,13,18q�5e       �� TextAlignment$ Center=�5f      $��15(�5g      $��3��5h      $
��Bold"�5i      $��Calibri)�5j      
�������$��Center=�5k       �� 5l   
   $��	ENCODING:��6   $��	17,0,13,0q�5m      $ Center=�5n      $��15(�5o      $��4��5p      $
��Bold"�5q      $��Calibri)�5r      
�������$��Center=�5s       5t      5u      