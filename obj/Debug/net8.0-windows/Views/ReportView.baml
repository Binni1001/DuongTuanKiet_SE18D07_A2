   M S B A M L   `   `   `  ����T  PDuongTuanKiet_SE18D07_A02, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:DuongTuanKiet_SE18D07_A02.ViewsDuongTuanKiet_SE18D07_A02.Views  5      0    *DuongTuanKiet_SE18D07_A02.Views.ReportView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:DuongTuanKiet_SE18D07_A02.Views     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Booking Statistics Report��6!   $��24(�5      $
��Bold"�6"   $��0,0,0,20q�64   �� 5   
   $��1��6   ���#F8F9FA �� Padding$ 15q�63   $��0,0,0,20q�6@    �� CornerRadius$ 5��6R   ._�5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $	��200 �6'   �� 5      $
��Auto �6'   �� 5      $	��200 �6'   �� 5      $
��Auto �6'   �� 5       $
��Auto �6'   .+�5#      �� $��0��6   $��Start Date:��6,   $��Center=�6?   $��SemiBold"�5$      $��0,0,10,0q�62   (  "System.Windows.Controls.DatePicker  5%      $��1��6   $��35��5&      $��0,0,20,0q�6(      SelectedDate 5%   -   �� *	StartDate+   DateOnlyToDateTimeConverter �� 	Converter# [  5&   (   �� 5(      $��2��6   $��	End Date:��6,   $��Center=�6=   $��SemiBold"�5)      $��0,0,10,0q�62     5*      $��3��6   $��35��5+      $��0,0,20,0q�6(    5*   -   �� *	EndDate+# [  5+   (   �� 5-      $��4��6   $��Generate Report��6)   $	��120��5.      $��35��6%   $��0,0,10,0q�61   ���#3498DB
�������$��SemiBold"�5/   A   ��5-   C   �� *GenerateReportCommand+5/   A   �� 51      $��5��6   $��Export��6)   $��80��52      $��35��6$   ���#27AE60
�������$��SemiBold"�53   A   ��51   :   �� *ExportReportCommand+53   A   54      55      �� 58   
   $��2��6   ���#ECF0F1$ 15q�63   $��0,0,0,20q�6@   $ 5��6R   ._�59      �  5:      �� 5;      $��* �6'   �� 5<      $��* �6'   �� 5=      $��* �6'   .+�5@      �� $��0��6   $��Center=�6-   .+�5A      �� $��Total Bookings��6    $��SemiBold"�66   $��Center=�6L   �� 5B      $��24(�6?   $
��Bold"�6M   ���#3498DB$��Center=�5C   5   ��5B       �� *TotalBookings+5C   5   5D      �� 5F      $��1��6   $��Center=�6-   .+�5G      �� $��Total Revenue��6    $��SemiBold"�65   $��Center=�6K   �� 5H      $��24(�6N   $
��Bold"�6\   ���#27AE60$��Center=�5I   5   ��5H       �� *TotalRevenue+ �� StringFormat$ C��5I   5   5J      �� 5L      $��2��6   $��Center=�6-   .+�5M      �� $��Average per Booking��6    $��SemiBold"�6;   $��Center=�6Q   �� 5N      $��$0.00��6    $��24(�6-   $
��Bold"�6;   ���#F39C12$��Center=�5O   5   5P      5Q      5R      &   System.Windows.Controls.DataGrid  5U   
   $��3��6      AutoGenerateColumns$ False��5V         CanUserAddRows$ False��6/   	   
IsReadOnly$
	 True��6F   
   GridLinesVisibility$
 
Horizontal=�5W         HeadersVisibility$ Column=�64      AlternatingRowBackground �#F8F9FA   	RowHeight$ 35Q�5X   6   ��5U       �� *
ReportData+   Columns 5Y      0  *System.Windows.Controls.DataGridTextColumn  5Z      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Booking ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *BookingReservationId+6b     5[      $ Customer��6%   $	 200 6\    67   �� *CustomerFullName+6\     5\      $ Email��6%   $	 200 6U    64   �� *EmailAddress+6U     5]      $ Booking Date��6%   $	 120 6t    6;   �� *BookingDate+$ 
dd/MM/yyyy��6t     5^      $ Total Price��6%   $	 120 6i    6:   �� *
TotalPrice+$ C��6i     5_      $ Status��6%   $	 100 6W    65   �� *BookingStatus+6W   5a      �� 5d   
   $��4��6   ���#ECF0F1$ 10q�63   $��0,10,0,0q�6@   ._�5e      �  5f      �� 5g      $��* �6'   �� 5h      $
��Auto �6'   .+�5k      �� $��0��6   $��Center=�5l      ��5k   ,   �� *ReportData.Count+$ Total Records: {0}��5l      �� 5n      $��1��6   $��Refresh��6)   $��80��5o      $��30��6$   ���#95A5A6
���������5n   ;   �� *RefreshCommand+5o   E   5p      5q      �� 5t   
   $��0��6   $��5��6   ���	#80000000y�5u      �� *	IsLoading+   BooleanToVisibilityConverter# [ ._�5v      �� $��Center=�6   $��Center=�66   .+�5w      �  � IsIndeterminate$
 True��6   $	��200��65   $��20��6A   $��0,0,0,10q�6M   �� 5x      $��Generating Report...��6   
�������$��Center=�6K   5y      5z      5{      5|      