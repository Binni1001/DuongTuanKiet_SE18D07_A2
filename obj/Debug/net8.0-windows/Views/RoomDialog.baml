   M S B A M L   `   `   `  ����  DuongTuanKiet_SE18D07_A020    *DuongTuanKiet_SE18D07_A02.Views.RoomDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Room Details��5   	   $	��550��6   $	��450��6+    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�6-   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��18(�68   $
��Bold"�6F   $��Center=�5      $��0,0,0,20q�61   ��5   !   �� *Title+5   1   �� 5   
   $��1��6   $
��Auto=�6$   .��5      �� .+�5      �� $��Room Number:��6   $��SemiBold"�60   $��0,0,0,5q�6F   �� 5      $��35��5      $��14(�6&   $
��10,8q�64   $��0,0,0,15q�6C   ��5      �� *
RoomNumber+ �� UpdateSourceTrigger$ PropertyChanged=�5   C   �� 5      $��
Room Type:��6   $��SemiBold"�6.   $��0,0,0,5q�6D   �� 5       �� DisplayMemberPath$ RoomTypeName��5      $��35��5      $��14(�6'   $��0,0,0,15q�65   ��5      �� *	RoomTypes+ �� SelectedItem 5      �� *SelectedRoomType+5   5   �� 5"      $��Description:��6   $��SemiBold"�60   $��0,0,0,5q�6F   �� 5#      $��80��5$      $��14(�6&   $
��10,8q�64   $��0,0,0,15q�6C    �� TextWrapping$
 Wrap=�5%       �� AcceptsReturn$
 True��6.   "	 �� VerticalScrollBarVisibility$
	 Auto=�6C   ��5#      �� *RoomDetailDescription+$ PropertyChanged=�5%   C   �� 5(      $��Max Capacity:��6   $��SemiBold"�61   $��0,0,0,5q�6G   �� 5)      $��35��5*      $��14(�6&   $
��10,8q�64   $��0,0,0,15q�6C   ��5)      �� *RoomMaxCapacity+$ PropertyChanged=�5*   C   �� 5-      $��Price Per Day:��6   $��SemiBold"�62   $��0,0,0,5q�6H   �� 5.      $��35��5/      $��14(�6&   $
��10,8q�64   $��0,0,0,15q�6C   ��5.      �� *RoomPricePerDay+$ PropertyChanged=�5/   C   �� 52      $��Status:��6   $��SemiBold"�6+   $��0,0,0,5q�6A   y�53      �� *	IsNewRoom+ '  #InverseBooleanToVisibilityConverter
 �� 	Converter#
 [  �� 54      $��35��6@   $��14(�6L   $��0,0,0,15q�6Z    �� SelectedValue 6   �� *
RoomStatus+y�55      �� *	IsNewRoom+#
 [  .@�56      �� $��Active��6#   
 � Tag$ 1��64   �� 57      $��Inactive��6#   $ 0��66   58      �� 5;      
���  ��$��SemiBold"�6O   $��0,10,0,0q�5<      $
��Wrap=�6.   ��5;      �� *ValidationErrors+y�5=      �� *ValidationErrors+  StringToVisibilityConverter#
 [ 5>      5?      �� 5B   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��0,20,0,0q�6X   .+�5C      �� -   5        $
��Save��5C      $	��100��5D      $��35��6!   $��0,0,10,0q�6-   ���#27AE60
�������$��SemiBold"�5E   =   �� 5F      -   5        $��Cancel��5F      $	��100��5G      $��35��6!   ���#95A5A6
�������$��SemiBold"�5H   =   5I      5J      5K      