   M S B A M L   `   `   `  ����T  PDuongTuanKiet_SE18D07_A02, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:DuongTuanKiet_SE18D07_A02.ViewsDuongTuanKiet_SE18D07_A02.Views  5      <    6DuongTuanKiet_SE18D07_A02.Views.CustomerManagementView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:DuongTuanKiet_SE18D07_A02.Views     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Customer Management��6!   $��24(�5      $
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
Horizontal=�59         HeadersVisibility$ Column=�64      AlternatingRowBackground �#F8F9FA   	RowHeight$ 35Q�5:   6   ��56       �� *	Customers+	 �� SelectedItem	 57      �� *SelectedCustomer+
   Columns
 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6P      
IsReadOnly$
 True��6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
CustomerId+6[     5=      $ 	Full Name��6%   $	 200 6]   $
 True��6i    68   �� *CustomerFullName+6i     5>      $ Email��6%   $	 250 6U   $
 True��6a    64   �� *EmailAddress+6a     5?      $ Phone��6%   $	 120 6R   $
 True��6^    64   �� *	Telephone+6^     5@      $ Birthday��6%   $	 100 6u   $
 True��6�    67   �� *CustomerBirthday+ �� StringFormat$ 
dd/MM/yyyy��6�   4  .System.Windows.Controls.DataGridTemplateColumn  5A      $ Status��6)   $ 80 69      CellTemplate 5B      �� 5C      .R�5D      �� $��Center=�5F   (   $��Center=�6E   ��5D   (   �� *CustomerStatus+   StatusConverter �� 	Converter# [  ��5E   (   �� *CustomerStatus+  StatusColorConverter# [ 5F   E   5G      5I      5K      �� 5N   
   $��3��6   ���#ECF0F1 �� Padding$ 10q�63   $��0,10,0,0q�6@   ._�5O      �  5P      �� 5Q      $��* �6'   �� 5R      $
��Auto �6'   .+�5U      �� $��0��6   $��Center=�5V      ��5U   ,   �� *Customers.Count+$ Total Customers: {0}��5V      �� 5X      $��1��6   $��Refresh��6)   $��80��5Y      $��30��6$   ���#95A5A6
���������5X   ;   �� *RefreshCommand+5Y   E   5Z      5[      �� 5^   
   $��0��6   $��4��6   ���	#80000000y�5_      �� *	IsLoading+   BooleanToVisibilityConverter# [ ._�5`      �� $��Center=�6   $��Center=�66   .+�5a      �  � IsIndeterminate$
 True��6   $	��200��65   $��20��6A   $��0,0,0,10q�6M   �� 5b      $��
Loading...��6   
�������$��Center=�6A   5c      5d      5e      5f      