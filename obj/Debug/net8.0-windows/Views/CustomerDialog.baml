   M S B A M L   `   `   `  ����  DuongTuanKiet_SE18D07_A024    .DuongTuanKiet_SE18D07_A02.Views.CustomerDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Customer Details��5   	   $	��600��6"   $	��500��6/    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�6-   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��18(�68   $
��Bold"�6F   $��Center=�5      $��0,0,0,20q�61   ��5   !   �� *Title+5   1   �� 5   
   $��1��6   $
��Auto=�6$   .��5      �� .+�5      �� $��
Full Name:��6   $��SemiBold"�6.   $��0,0,0,5q�6D   �� 5      $��35��5      $��14(�6&   $
��10,8q�64   $��0,0,0,15q�6C   ��5      �� *CustomerFullName+ �� UpdateSourceTrigger$ PropertyChanged=�5   C   �� 5      $��Email Address:��6   $��SemiBold"�62   $��0,0,0,5q�6H   �� 5      $��35��5      $��14(�6&   $
��10,8q�64   $��0,0,0,15q�6C   ��5      �� *EmailAddress+$ PropertyChanged=�5   C   �� 5       $��Phone Number:��6   $��SemiBold"�61   $��0,0,0,5q�6G   �� 5!      $��35��5"      $��14(�6&   $
��10,8q�64   $��0,0,0,15q�6C   ��5!      �� *	Telephone+$ PropertyChanged=�5"   C   �� 5%      $��	Birthday:��6   $��SemiBold"�6-   $��0,0,0,5q�6C   (  "System.Windows.Controls.DatePicker  5&      $��35��5'      $��14(�6(   $��0,0,0,15q�66      SelectedDate 5&      �� *CustomerBirthday+   DateOnlyToDateTimeConverter �� 	Converter# [  5'   6   �� 5*      $��	Password:��6   $��SemiBold"�6-   $��0,0,0,5q�6C   y�5+      �� *IsNewCustomer+   BooleanToVisibilityConverter# [ G� 5,      -   5         G�Name$ PasswordBox��5,      $��35��63   $��14(�6?   $
��10,8q�6M   $��0,0,0,15q�6\   y�5-      �� *IsNewCustomer+# [ 5.      �� 51      $��Status:��6   $��SemiBold"�6+   $��0,0,0,5q�6A   y�52      �� *IsNewCustomer+ ' #InverseBooleanToVisibilityConverter# [ �� 53      $��35��6D   $��14(�6P   $��0,0,0,15q�6^    �� SelectedValue 6   �� *CustomerStatus+y�54      �� *IsNewCustomer+# [ .@�55      �� $��Active��6#   
	 � Tag$	 1��64   �� 56      $��Inactive��6#   $	 0��66   57      �� 5:      
���  ��$��SemiBold"�6O   $��0,10,0,0q�5;      $
��Wrap=�6.   ��5:      �� *ValidationErrors+y�5<      �� *ValidationErrors+  StringToVisibilityConverter# [ 5=      5>      �� 5A   
   $��2��6   
 �� Orientation$
 
Horizontal=�6"   $��Center=�6;   $��0,20,0,0q�6X   .+�5B      �� -   5        $
��Save��5B      $	��100��5C      $��35��6!   $��0,0,10,0q�6-   ���#27AE60
�������$��SemiBold"�5D   =   �� 5E      -   5        $��Cancel��5E      $	��100��5F      $��35��6!   ���#95A5A6
�������$��SemiBold"�5G   =   5H      5I      5J      