   M S B A M L   `   `   `  ����>  :TMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TMS.View.PagesTMS.View.Pages  5      !    TMS.View.Pages.MeetingsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      (localclr-namespace:TMS.View.Pages  5        N� Title$  MeetingsPage��5
       � 	Resources 5       �� Source�� 5   
   $" /Dictionaries/DarkTheme.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      $
��0.6* �6   6,   �� 5      $
��0.4* �6   6,   .+�5   
   �� $��20q�6   
������    	textColor#��[  6�   ��6   �� *MeetingsList+ �� SelectedItem 6D   �� *SelectedMeeting+��5      �� 5      .R�5      � $
��Left=�6    $��Center=�6;   $��10q�6V   6d   5      ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value 5      �� 5      .R�5   "   ��  ��Name$ 
backOfItem��6)   #��[  6=   $��10 0 0 0q�6e   $	��300��6w   $	��350��6�   	 �� CornerRadius$	 10��6�   $��1q�6�   ._�5   &   �� $��15q�61   $��Center=�6=   .+�5    *   � .+�5!   .   �� $��/Resources/user.png��64   $	��100��6Q   6`   �� 5"   .   $��31(�6U   $��30 0 0 0q�6c   $
��Bold"�6u   ��68   �� *
PersonName+6�   5#   +   � 5$   *   $��0 3 0 0q�64   .+�5%   .   �� $��
Location: ��68   $��25(�6J   $
��Bold"�6X   $��Center=�6j   6�   �� 5&   .   $��21(�6R   $��Center=�6`   ��68   �� *
Location+6}   5'   +   � 5(   *   $��0 5 0 0q�64   .+�5)   .   �� $��Date and time: ��68   $��15(�6O   $
��Bold"�6]   $��Center=�6o   6�   �� 5*   .   $��15(�6X   $��Center=�6f   ��68   �� *TimeOfMeeting+6�   5+   +   �� 5,   *   $��Notes ��64   $��15(�6B   $��Center=�6P   $��0 15 0 0q�6l   $
��Bold"�6~   6�   �� 5-   *   $��1q�61   ���#000000._�5.   .   �� $
��Wrap=�6O   $��1q�6c   ��68   �� *Note+6q   5/   +   51   '   52   #   
 �� Triggers
 53   "   P� 54   &    P� Property �@J�	IsFocused P� Value . . �55   *   ��  �� 
TargetName$ 
backOfItem��61     buttonHovering# [ 6_    � ��56   '   P� 57   &    �@J�IsMouseOver . . �58   *   ��  �@�Cursor$
 Hand��6C   �� 59   *   $ 
backOfItem��61   # [ 6`    � ��5:   '   5<      5>      5?      5A      � 5B   
   $��1��6   $��5q�6    � ColumnDefinitions 5C      �� 5D      6%   �� 5E      6%   �� 5F      6%   .+�5H      �� $��Center=�6   .+�5I      �� $��Person  Name��6   $��Center=�6/   #��[  6L   $��35(�6t   6�   �� 5J        InputBox#��[ 6   ��6<   �� *Name+6T   �� 5K      $��Location��6   $��Center=�6+   #��[  6H   $��35(�6p   $��0 20 0 0q�6~   6�   �� 5L      #��[ 6   ��6<   �� *
Location+6X   5M      �� 5N      $��1��6   $��Center=�6)   .+�5O      �� $��Date and time��6   $��Center=�60   #��[  6M   $��35(�6u   6�   &   Xceed.Wpf.Toolkit.DateTimePicker  5P      $��30(�6&   $��
10 20 10 0q�64   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text 6H   �� *DateandTime+6g   �� 5Q      $��0 30 0 0q�6   $��50(�6*   #��[  6X   $��Center=�6�   ��68   �� *CurrentTime+6�   � 5R      $��Center=�6   .+�5S      �� $��Center=�6     EnteringButton#��[ 66   $��Show today's meetings��6^   $��5 0 5 0q�6�   ��6~   �� *showTodaysMeetingsCommand+6�   �� 5T      $��Center=�6   #��[ 6:   $	��All��6b   $��5 0 5 0q�6�   ��6p   �� *showMeetingsCommand+6�   5U      5V      � 5W      $��2��6    5X      �� 5Y      $
��0.1* �6$   64   �� 5Z      $
��0.2* �6$   64   �� 5[      $
��0.1* �6$   64   .+�5]      �� $
��Note��6   $��Center=�6'   $��Center=�6E   #��[  6`   $��35(�6�   6�   �� 5^       �� 	MaxLength$ 90��60   $��20(�6?   $��1��6M   
������ #��[  6s   $��10q�6�    �� 
CaretBrush# [  6�    �� TextWrapping$
 Wrap=�6�   #��[  6�   ��6   �� *Note+6  � 5_      $��2��6    5`      �� 5a      6-   �� 5b      6-   .+�5d      �� $	��Add��6   $��1��6+   #��[ 6;   ��6d   �� *addMeetingCommand+6�   �� 5e      $��Delete��6   #��[ 6.   ��6V   �� *deleteMeetingCommand+6�   5f      5g      5h      5i      5j      