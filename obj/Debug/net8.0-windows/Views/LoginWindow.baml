   M S B A M L   `   `   `  ����  DuongTuanKiet_SE18D07_A021    +DuongTuanKiet_SE18D07_A02.Views.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$"  FU Mini Hotel System - Login��5   	   $	��600��5   	   $	��500��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5	      � ���#F5F5F5 � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   ���#2C3E50 �� Padding$ 20q�63   ._�5      �� $%��FU Mini Hotel Management System��6   $��24(�5      $
��Bold"�6&   
�������$��Center=�5   +   5      �� 5   
   $��1��6   $��50q�6   
������� �� CornerRadius$ 10��5      ���#BDC3C7$��1q�69   ._�5      �� $��40q�6   $��Center=�6%   .+�5      �� $��Login��6   $��20(�6)   $
��Bold"�67   $��Center=�5      $��0,0,0,30q�69   �� 5      $��Email:��6   $��SemiBold"�6*   $��0,0,0,5q�6@   �� 5       $��35��5!      $��14(�6&   $
��10,8q�64   ��5       �� *Email+ �� UpdateSourceTrigger$ PropertyChanged=�5!   4   �� 5$      $��	Password:��6   $��SemiBold"�6-   $��0,15,0,5q�6C   G� 5%      -   5         G�Name$ PasswordBox��5%      $��35��63   $��14(�6?   $
��10,8q�6M   5&      �� 5)      
���  ��$��SemiBold"�5*   -   $��0,10,0,0q�5+      $
��Wrap=�6.   ��5)      �� *ErrorMessage+y�5,      �� *ErrorMessage+   StringToVisibilityConverter �� 	Converter# [  �� 5/      	 �� Orientation$	 
Horizontal=�6   $��Center=�66   $��0,20,0,0q�6S   .+�50      �� $��Login��6   $	��100��51      $��35��6)   $��0,0,10,0q�65   ���#3498DB
�������$��SemiBold"�52   E   ��50   -   �� *LoginCommand+{�53      �� *	IsLoading+  InverseBooleanConverter# [ �� 54      $
��Exit��6   $	��100��55      $��35��6)   ���#E74C3C
�������$��SemiBold"�56   E   ��54   ,   �� *ExitCommand+56   E   57      �� 5:      $��Logging in...��6   $��Center=�61   $��0,10,0,0q�5;      $��Italic$�6.   y�5<      �� *	IsLoading+   BooleanToVisibilityConverter# [ 5=      5>      �� 5A   
   $��2��6   ���#34495E$ 10q�63   ._�5B      �� $=��7Default Admin: admin@FUMiniHotelSystem.com / @@abc123@@��6   
�������$��Center=�5C   +   $��12(�6H   5D      5E      5F      