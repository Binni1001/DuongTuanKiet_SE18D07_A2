   M S B A M L   `   `   `  ����T  PDuongTuanKiet_SE18D07_A02, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:DuongTuanKiet_SE18D07_A02.ViewsDuongTuanKiet_SE18D07_A02.Views  5      ;    5DuongTuanKiet_SE18D07_A02.Views.BookingManagementView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:DuongTuanKiet_SE18D07_A02.Views     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��24(�6!   $
��Bold"�6/   $��0,0,0,20q�6A   ��5      �� 5       �� 
TargetType" ��6    �� Triggers 5      �� 5       �� Binding 6&   �� *	IsAdmin+ �� Value True6B   .a�5      ��  �� Property � �� �� Value$ Booking Management��65   5      �� 5       6&   �� *	IsAdmin+	 False6B   .a�5      ��  � ��$ My Booking History��65   5      5      5       � 5#   
   $��1��6   $��0,0,0,20q�6    � ColumnDefinitions 5$      �� 5%      $��* �6#   �� 5&      $
��Auto �6#   �� 5'      $
��Auto �6#   �� 5(      $
��Auto �6#   �� 5)      $
��Auto �6#   �� 5*      $
��Auto �6#   .+�5-      �� $��0��6   $��35��5.      $��Center=�6"   $
��10,0q�6D   $��0,0,10,0q�5/      $��14(�6(   ��5-   &   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5/   (   �� 51      $��1��6   $��Search��6%   $��80��52      $��35��6    $��0,0,10,0q�6,   ���#3498DB
���������51   6   �� *SearchCommand+53   *   �� 55      $��2��6   $	��Add��6%   $��80��56      $��35��6    $��0,0,10,0q�6,   ���#27AE60
���������55   3   �� *
AddCommand+y�58      �� *	IsAdmin+    BooleanToVisibilityConverter	 �� 	Converter#	 [  �� 5:      $��3��6   $
��Edit��6%   $��80��5;      $��35��6    $��0,0,10,0q�6,   ���#F39C12
���������5:   4   �� *EditCommand+y�5=      �� *	IsAdmin+#	 [  �� 5?      $��4��6   $��Delete��6%   $��80��5@      $��35��6    $��0,0,10,0q�6,   ���#E74C3C
���������5?   6   �� *DeleteCommand+y�5B      �� *	IsAdmin+#	 [  �� 5D      $��5��6   $��View Details��6%   $	��100��5E      $��35��6!   ���#9B59B6
���������5D   <   �� *ViewDetailsCommand+5F   *   5G      &   System.Windows.Controls.DataGrid  5J   
   $��2��6   
   AutoGenerateColumns$
 False��5L         CanUserAddRows$ False��6/      GridLinesVisibility$ 
Horizontal=�5M         HeadersVisibility$ Column=�64      AlternatingRowBackground �#F8F9FA   	RowHeight$ 35Q�5N   6   ��5J       �� *
Bookings+ �� SelectedItem 5K      �� *SelectedBooking+   Columns 5O      0  *System.Windows.Controls.DataGridTextColumn  5P      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Booking ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6b      
IsReadOnly$
 True��6n   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *BookingReservationId+6n     5Q      $ Customer��6%   $	 200 6\   $
 True��6h    67   �� *CustomerFullName+6h     5R      $ Email��6%   $	 200 6U   $
 True��6a    64   �� *EmailAddress+6a     5S      $ Booking Date��6%   $	 120 6t   $
 True��6�    6;   �� *BookingDate+ �� StringFormat$ 
dd/MM/yyyy��6�     5T      $ Total Price��6%   $	 120 6i   $
 True��6u    6:   �� *
TotalPrice+$ C��6u     5U      $ Status��6%   $	 100 6W   $
 True��6c    65   �� *BookingStatus+6c   5W      �� 5Z   
   $��3��6   ���#ECF0F1 �� Padding$ 10q�63   $��0,10,0,0q�6@   ._�5[      �  5\      �� 5]      $��* �6'   �� 5^      $
��Auto �6'   .+�5a      �� $��0��6   $��Center=�5b      ��5a   ,   �� *Bookings.Count+$ Total Bookings: {0}��5b      �� 5d      $��1��6   $��Refresh��6)   $��80��5e      $��30��6$   ���#95A5A6
���������5d   ;   �� *RefreshCommand+5e   E   5f      5g      �� 5j   
   $��0��6   $��4��6   ���	#80000000y�5k      �� *	IsLoading+#	 [  ._�5l      �� $��Center=�6   $��Center=�66   .+�5m      �  � IsIndeterminate$
 True��6   $	��200��65   $��20��6A   $��0,0,0,10q�6M   �� 5n      $��
Loading...��6   
�������$��Center=�6A   5o      5p      5q      5r      