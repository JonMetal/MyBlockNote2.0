   M S B A M L   `   `   `  ����F  BMyBlockNote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MyBlockNote.WindowsMyBlockNote.Windows  5   	   ,    &MyBlockNote.Windows.FontSettingsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:MyBlockNote.Windows     5   	     � Title$  Font Settings��5      $	��300��6'   $	��560��64    � WindowStartupLocation$ CenterScreen=�6@    � 
ResizeMode$ CanMinimize=�6e   .��5	      � $��Center=�6   $��0,20,0,0q�6(    � 	Resources 5
   
    �� 
TargetType �� Property �� Value��%S   '��       �� 5      " ��6   .�5      ��  � ��$	 210 �6*   5      5       � ColumnDefinitions 5   
   �� 5      �� 5      $��30 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   �� 5      $��50 �6   .+�5   
   �� -   5        $��lvFontFamilys��5      $��0��6(   $��0��68   	 �� SelectionMode$	 Single=�6�   
 �� SelectedValue
 6E   ��  �� Path$ 
FontFamily� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   -   5        $��
lvFontSize��5      $��2��6%   $��0��65   $	 Single=�6�   
 6B   �� $ FontSize�$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   -   5        $��tbSample��5   |   $��1��6   $��3��6!   $��AzByUsg��65   $��Center=�6D   $��Center=�6a   ��6�   �� $ 
FontFamily�$ TwoWay=�$ PropertyChanged=���6�   �� $ FontSize�$ TwoWay=�$ PropertyChanged=��� 5!   
   -   5        $��2��5!      $��0��6   $��3��6.   $��80��6B   $��30��6M   .��6m   Close6t   5#      5$      