   M S B A M L   `   `   `  ����  DuongTuanKiet_SE18D07_A02:    4DuongTuanKiet_SE18D07_A02.Views.BookingDetailsDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Booking Details��5   	   $	��500��6!   $	��600��6.    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�6-   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Booking Details��6!   $��18(�68   $
��Bold"�6F   $��Center=�5      $��0,0,0,20q�61   �� 5   
   $��1��6   $
��Auto=�6$   .��5      �� .+�5      �� $��Booking ID:��6   $��SemiBold"�6/   $��0,0,0,5q�6E   �� 5      $��0,0,0,15q�6B   ��6   �� *BookingReservationId+6B   �� 5      $��	Customer:��6   $��SemiBold"�6-   $��0,0,0,5q�6C   �� 5      $��0,0,0,15q�6>   ��6   �� *CustomerFullName+6>   �� 5      $��Email:��6   $��SemiBold"�6*   $��0,0,0,5q�6@   �� 5      $��0,0,0,15q�6:   ��6   �� *EmailAddress+6:   �� 5      $��Booking Date:��6   $��SemiBold"�61   $��0,0,0,5q�6G   �� 5      $��0,0,0,15q�6R   ��6   �� *BookingDate+ �� StringFormat$ 
dd/MM/yyyy��6R   �� 5!      $��Total Price:��6   $��SemiBold"�60   $��0,0,0,5q�6F   �� 5"      $��0,0,0,15q�6H   ��6   �� *
TotalPrice+$ C��6H   �� 5$      $��Status:��6   $��SemiBold"�6+   $��0,0,0,5q�6A   �� 5%      $��0,0,0,15q�6;   ��6   �� *BookingStatus+6;   5&      5'      �� 5*   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��0,20,0,0q�6X   .+�5+      �� -   5        $��Close��5+      $	��100��5,      $��35��6!   ���#95A5A6
�������$��SemiBold"�5-   =   5.      5/      50      