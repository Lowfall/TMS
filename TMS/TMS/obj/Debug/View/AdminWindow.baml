   M S B A M L   `   `   `  ����>  :TMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TMS.ViewTMS.View  5   	       TMS.View.AdminWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TMS.View     5   	     � Title$  AdminWindow��5   	   $	��800��6   $
��1300��6*    � 
ResizeMode$ CanMinimize=�69    � WindowStartupLocation$ CenterScreen=�6S    � Icon$ /Resources/Admin.png��6x    � WindowStyle$
 None=�6�    � 	Resources 5	       �� Source�� 5
   
   $" /Dictionaries/DarkTheme.xaml?�6   %    .��5      �    backMainWindow#��[  6    � ColumnDefinitions 5   
   �� 5      $��0.25* �6   6/   �� 5      $��* �6   6+   .+�5   
   �� .+�5      �� $��Delete��6     EnteringButton#��[ 6&   $��20q�6N   ��6Z   �� *DeleteClientCommand+6�   �� 5        InputBox#��[ 6.   $��
20 20 20 0q�6P   ��6   �� *Reason+6f   �� 5      $	��Ban��6   #��[ 6#   $��20q�6K   ��6W   �� *BanClientCommand+6~   �� 5      $��Unban��6   #��[ 6%   $��20q�6M   ��6Y   �� *UnbanClientCommand+6�   �� 5      #��[ 60   $��
20 20 20 0q�6R   ��6   �� *
Password+6h   �� 5      $��Change Password��6   #��[ 6/   $��20q�6W   ��6c   �� *ChangePasswordCommand+6�   �� 5      #��[ 6-   $��
20 20 20 0q�6O   ��6   �� *Login+6e   �� 5      $��Change Login��6   #��[ 6,   $��20q�6T   ��6`   �� *ChangeLoginCommand+6�   5      �� 5   
     	textColor#��[ 6   $��0 0 2 0q�6:   6V   �� 5   
   $
��Exit��6   $��Bottom=�6      EnterButton#��[ 6<   $��20q�6a   ��6m   �� *ExitCommand+6�   �� 5   
   $��1��6\   $��30q�6l   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6y   #��[  6�     buttonHovering#��[ 6�   	 �� SelectedItem	 6   �� *SelectedClient+��6;   �� *	Clients+��5      �� 5      
 �� 
TargetType"
 ��6   .�5       ��  �� Property � �� �� Value 5!      �� 5"      .R�5#   "   ��  ��Name$ PageItem��6)   
������ #��[ 6T   $��2q�6}   $��5q�6�    �� CornerRadius$ 10��6�   ._�5$   &   � $��5q�60   .+�5%   *   � $��Center=�64   $��10 5 0 5q�6O   .+�5&   .   A� $��35��66   $��35��6B   ��6M   �� *Color+�� 5'   .    ��Name$ IdBox��68   #��[ 6b   $��30(�6�   $��Center=�6�   $��5q�6�   ��6H   �� *
ClientId+6�   �� 5(   .   $ NameBox��68   #��[ 6b   $��35(�6�   $��	 30 0 0 0q�6�   ��6K   �� *Login+6�   �� 5)   .   $ PasswordBox��68   #��[ 6h   $��35(�6�   $��	 30 0 0 0q�6�   ��6N   �� *
Password+6�   �� 5*   .   $ 	ReasonBox��68   #��[ 6c   $��35(�6�   $��	200 0 0 0q�6�   ��6K   �� *Reason+6�   5+   +   5,   '   5-   #    �� Triggers 5/   "   P� 50   &    P� Property �@J�IsMouseOver P� Value . . �51   *   ��  �� 
TargetName$ PageItem��61   # [ 6]    � ���� 52   *    �@�Cursor$
 Hand��6C   53   '   P� 54   &    �@J�	IsFocused . . �55   *   �� $ PageItem��61   # [ 6^    � ���� 56   *   $ PageItem��61   # [ 6]    � ���� 57   *   $ IdBox��61   # [  6Z    � ���� 58   *   $ NameBox��61   # [  6\    � ���� 59   *   $ PasswordBox��61   # [  6`    � ���� 5:   *   $ 	ReasonBox��61   # [  6^    � ��5;   '   5=      5?      5@      5B      5C      5D      