   M S B A M L   `   `   `  ����T  PDuongTuanKiet_SE18D07_A02, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:DuongTuanKiet_SE18D07_A02.ViewsDuongTuanKiet_SE18D07_A02.Views  5      8    2DuongTuanKiet_SE18D07_A02.Views.RoomManagementView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:DuongTuanKiet_SE18D07_A02.Views     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Room Management��6!   $��24(�5      $
��Bold"�6"   $��0,0,0,20q�64   � 5   
   $��1��6   $��0,0,0,20q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5       �� $��0��6   $��35��5!      $��Center=�6"   $
��10,0q�6D   $��0,0,10,0q�5"      $��14(�6(   ��5    &   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5"   (   �� 5$      $��1��6   $��Search��6%   $��80��5%      $��35��6    $��0,0,10,0q�6,   ���#3498DB
���������5$   6   �� *SearchCommand+5&   *   �� 5(      $��2��6   $	��Add��6%   $��80��5)      $��35��6    $��0,0,10,0q�6,   ���#27AE60
���������5(   3   �� *
AddCommand+5*   *   �� 5,      $��3��6   $
��Edit��6%   $��80��5-      $��35��6    $��0,0,10,0q�6,   ���#F39C12
���������5,   4   �� *EditCommand+5.   *   �� 50      $��4��6   $��Delete��6%   $��80��51      $��35��6    ���#E74C3C
���������50   6   �� *DeleteCommand+52   *   53      &   System.Windows.Controls.DataGrid  56   
   $��2��6      AutoGenerateColumns$ False��58         CanUserAddRows$ False��6/      GridLinesVisibility$ 
Horizontal=�59         HeadersVisibility$ Column=�64      AlternatingRowBackground �#F8F9FA   	RowHeight$ 35Q�5:   6   ��56       �� *Rooms+	 �� SelectedItem	 57      �� *SelectedRoom+
   Columns
 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6L      
IsReadOnly$
 True��6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *RoomId+6W     5=      $ Room Number��6%   $	 120 6Y   $
 True��6e    6:   �� *
RoomNumber+6e     5>      $ Description��6%   $	 200 6d   $
 True��6p    6:   �� *RoomDetailDescription+6p     5?      $ Capacity��6%   $ 80 6[   $
 True��6f    67   �� *RoomMaxCapacity+6f     5@      $ 	Room Type��6%   $	 120 6Y   $
 True��6e    68   �� *RoomTypeName+6e     5A      $ 	Price/Day��6%   $	 100 6l   $
 True��6x    68   �� *RoomPricePerDay+ �� StringFormat$ C��6x   4  .System.Windows.Controls.DataGridTemplateColumn  5B      $ Status��6)   $ 80 69      CellTemplate 5C      �� 5D      .R�5E      �� $��Center=�5G   (   $��Center=�6E   ��5E   (   �� *
RoomStatus+   StatusConverter �� 	Converter# [  ��5F   (   �� *
RoomStatus+  StatusColorConverter# [ 5G   E   5H      5J      5L      �� 5O   
   $��3��6   ���#ECF0F1 �� Padding$ 10q�63   $��0,10,0,0q�6@   ._�5P      �  5Q      �� 5R      $��* �6'   �� 5S      $
��Auto �6'   .+�5V      �� $��0��6   $��Center=�5W      ��5V   ,   �� *Rooms.Count+$ Total Rooms: {0}��5W      �� 5Y      $��1��6   $��Refresh��6)   $��80��5Z      $��30��6$   ���#95A5A6
���������5Y   ;   �� *RefreshCommand+5Z   E   5[      5\      �� 5_   
   $��0��6   $��4��6   ���	#80000000y�5`      �� *	IsLoading+   BooleanToVisibilityConverter# [ ._�5a      �� $��Center=�6   $��Center=�66   .+�5b      �  � IsIndeterminate$
 True��6   $	��200��65   $��20��6A   $��0,0,0,10q�6M   �� 5c      $��
Loading...��6   
�������$��Center=�6A   5d      5e      5f      5g      