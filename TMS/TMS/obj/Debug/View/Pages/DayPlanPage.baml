   M S B A M L   `   `   `  ����>  :TMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TMS.View.PagesTMS.View.Pages  5           TMS.View.Pages.DayPlanPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TMS.View.Pages     5        N� Title$  DayPlanPage��5	       � 	Resources 5
       �� Source�� 5   
   $" /Dictionaries/DarkTheme.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $
��0.4* �6   6.   .+�5   
   �� $��1��6   $��20q�6%   .+�5      �� $��Center=�6   $��	Task name��61   $��40(�6E      	textColor#��[  6S   6}   �� 5      $��28(�6,    �� 	MaxLength$ 12��6:   ��6   �� *Name+6K   �� 5      $��Center=�6   $��
Importance��61   $��37(�6F   #��[  6T   6~   � 5      $��10q�6   $��Center=�6$   .+�5      	�   RadioLowPriority#��[ 6    	� 	GroupName$ Priority��6I   ��6^   �� *SetStateLowCommand+6�   	� 5        RadioMidPriority#��[ 6   $ Priority��6I   ��6^   �� *SetStateMidCommand+6�   	� 5        RadioHighPriority#��[ 6   $ Priority��6I   ��6^   �� *SetStateHighCommand+6�   5      �� 5      $��Center=�6   $��WorkingTime��61   $��35(�6G   #��[  6U   6   �� 5        backLeftMenuBar#��[ 6    �� CornerRadius$ 5��6C   ._�5      �� $��10q�6   .+�5      �� $��Center=�6   $
��FROM��69   $��20(�6H   #��[  6V   6�   �� 5      $��	60 0 60 0q�6   $��20(�61     InputBox#��[ 6Y   $ 5��6{   ��6?   �� *
FromTime+6�   �� 5       $��Center=�6   $��TO��69   $��20(�6F   #��[  6T   6~   �� 5!      $��
60 0 60 30q�6   $��20(�62   #��[ 6X   $ 5��6z   ��6@   �� *ToTime+6�   5"      5#      �� 5%      $	��Add��6     EnteringButton#��[ 6M   $��
30 20 30 0q�6u   ��6#   �� *AddDayPlanTaskCommand+6�   �� 5&      $��Delete��6   #��[ 6S   $��
30 20 30 0q�6{   ��6&   �� *DeleteDayPlanTaskCommand+6�   �� 5'      $��Bottom=�6   #��[  6/   $��20(�6W   $��0 30 0 0q�6e   $��Right=�6w   ��6�   �� *CurrentTime+6�   5(      �� 5)   
   $��40q�6b   
������  �� SelectedItem 6   �� *SelectedTask+��69   �� *DayPlanTasksList+��5*      �� 5+       �� 
TargetType" ��6   .�5,      �� 	 �� Property	 � ��
 �� Value
 5-      �� 5.      .R�5/   "   ��  ��Name$ PageItem��6)   
������ #��[  6T   $��0 1 0 1q�6}   $��5q�6�   $ 5��6�   ._�50   &   � $��Center=�60   $��10 5 0 5q�6K   .+�51   *   A� $��35��62   $��35��6>   ��6I   �� *Color+�� 52   *   #��[  6J   $��25(�6r   $��Center=�6�   $��	10 0 10 0q�6�   ��64   �� *Name+6�   �� 53   *   $��From:��64   #��[  6A   $��15(�6i   $��Center=�6w   $��	10 0 10 0q�6�   6�   �� 54   *   #��[  6O   $��20(�6w   $��Center=�6�   ��65   �� *
FromTime+6�   �� 55   *   $	��To:��64   #��[  6?   $��15(�6g   $��Center=�6u   $��	10 0 10 0q�6�   6�   �� 56   *   #��[  6M   $��20(�6u   $��Center=�6�   ��65   �� *ToTime+6�   �� 57   *   #��[  6L   $��30(�6t   $��Center=�6�   $��Right=�6�   $��30 0 0 0q�6�   ��65   �� *State+6�   58   '   59   #    �� Triggers 5:   "   P� 5;   &    P� Property �@J�IsMouseOver P� Value . . �5<   *   ��  �� 
TargetName$ PageItem��61     buttonHovering#
 [ 6]   	 � ���� 5=   *   	 �@�Cursor$

 Hand��6C   5>   '   P� 5?   &    �@J�	IsFocused . . �5@   *   �� $ PageItem��61   #
 [ 6]   	 � ��5A   '   5C      5E      5F      5H      5I      5J      