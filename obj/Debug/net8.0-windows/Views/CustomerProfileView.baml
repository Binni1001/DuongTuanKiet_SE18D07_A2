   M S B A M L   `   `   `  ����T  PDuongTuanKiet_SE18D07_A02, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:DuongTuanKiet_SE18D07_A02.ViewsDuongTuanKiet_SE18D07_A02.Views  5      9    3DuongTuanKiet_SE18D07_A02.Views.CustomerProfileView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:DuongTuanKiet_SE18D07_A02.Views     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��
My Profile��6!   $��24(�5      $
��Bold"�6"   $��0,0,0,30q�64   �� 5   
   $��1��6   $
��Auto=�6$   .��5      �� ���#F8F9FA �� Padding$ 30q�6*    �� CornerRadius$ 10��67   $	��500��6I   $��Center=�6X   ._�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��0,0,0,30q�6W   .+�5      A� $��80��6"   $��80��6-   ���#3498DB$��0,0,20,0q�6H   �� 5      $��Center=�6%   .+�5      �� $��20(�6J   $
��Bold"�6X   ��6(   �� *CustomerFullName+6X   �� 5      $��14(�6F   
���������6(   �� *EmailAddress+6T   5      5       �� 5#      $��
Full Name:��6    $��SemiBold"�62   $��0,0,0,5q�6H   �� 5$      $��40��5%      $��14(�6*   $
��10,8q�68   $��0,0,0,20q�6G   ��5$      �� *CustomerFullName+ �� UpdateSourceTrigger$ PropertyChanged=� �� 
IsReadOnly 5&      �� *	IsEditing+   InverseBooleanConverter �� 	Converter# [  �� 5)      $��Email Address:��6    $��SemiBold"�66   $��0,0,0,5q�6L   �� 5*      $��40��5+      $��14(�6*   $
��10,8q�68   $��0,0,0,20q�6G   ��5*      �� *EmailAddress+$ PropertyChanged=� 5,      �� *	IsEditing+# [  �� 5/      $��Phone Number:��6    $��SemiBold"�65   $��0,0,0,5q�6K   �� 50      $��40��51      $��14(�6*   $
��10,8q�68   $��0,0,0,20q�6G   ��50      �� *	Telephone+$ PropertyChanged=� 52      �� *	IsEditing+# [  �� 55      $��	Birthday:��6    $��SemiBold"�61   $��0,0,0,5q�6G   (  "System.Windows.Controls.DatePicker  56      $��40��57       $��14(�6,   $��0,0,0,20q�6:      SelectedDate 56   !   �� *CustomerBirthday+  DateOnlyToDateTimeConverter# [ {�58       �� *	IsEditing+�� 5;      
���  ��$��SemiBold"�6S   $��	0,10,0,20q�5<       $
��Wrap=�63   ��5;       �� *ValidationErrors+y�5=       �� *ValidationErrors+  StringToVisibilityConverter# [ �� 5@      $ 
Horizontal=�6!   $��Center=�6:   $��0,20,0,0q�6W   .+�5B      �� $ 
Horizontal=�6%   y�5C   %   �� *	IsEditing+   BooleanToVisibilityConverter# [ .+�5D      �� $
��Save��6%   $	��100��5E   %   $��40��61   $��0,0,10,0q�6=   ���#27AE60
�������$��SemiBold"�5F   M   ��5D   4   �� *SaveCommand+5F   M   �� 5G      $��Cancel��6%   $	��100��5H   %   $��40��61   ���#95A5A6
�������$��SemiBold"�5I   M   ��5G   6   �� *CancelCommand+5I   M   5J      �� 5M      $ 
Horizontal=�6%   y�5N   %   �� *	IsEditing+ ' #InverseBooleanToVisibilityConverter# [ .+�5O      �� $��Edit Profile��6%   $	��120��5P   %   $��40��61   $��0,0,10,0q�6=   ���#3498DB
�������$��SemiBold"�5Q   M   ��5O   <   �� *EditCommand+5Q   M   �� 5R      $��Change Password��6%   $	��140��5S   %   $��40��61   ���#F39C12
�������$��SemiBold"�5T   M   ��5R   ?   �� *ChangePasswordCommand+5T   M   5U      5V      5W      5X      5Y      �� 5\   
   $��0��6   $��3��6   ���	#80000000y�5]      �� *	IsLoading+# [ ._�5^      �� $��Center=�6   $��Center=�66   .+�5_      �  � IsIndeterminate$
 True��6   $	��200��65   $��20��6A   $��0,0,0,10q�6M   �� 5`      $��Updating Profile...��6   
�������$��Center=�6J   5a      5b      5c      5d      