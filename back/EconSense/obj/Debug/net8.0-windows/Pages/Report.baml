   M S B A M L   `   `   `  ����D  @EconSense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:EconSense.PagesEconSense.Pages  5          EconSense.Pages.Report   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:EconSense.Pages     5        N� Title$  Report��5	      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63    �� RelativeTransform 5      V� 5      .~�5      ��  �� CenterY$	 0.5Q�6)    �� CenterX$	 0.5Q�67   �� 5       �� CenterX$	 0.5Q�6(    �� CenterY$	 0.5Q�66   �� 5       �� Angle$	 270Q�6*   	 �� CenterX$		 0.5Q�66   
 �� CenterY$	
 0.5Q�6D   T� 5      5      .��5      �  � Color$ 	#FFA8E6CF��6   � 5      $ White��6    � Offset$ 1Q�6-   5      .+�5   
   �� -   5         ��Name$ ViewWayb��5      $��	0,442,0,0q�6%   $��24(�6N   ��68   Z�  �� View 5      �� 5      .P�5      �� $��ФИО водителя��6%    �� Width$	 400��6g    �� DisplayMemberBinding 6;   �� *
DriverName+6g   �� 5      $��Транспорт��6%   $	 200��6c    68   �� *	Transport+6c   �� 5      $'��!Название маршрута��6%   $	 300��6k    6@   �� *	RouteName+6k   �� 5       $'��!Время отправления��6%   $	 300��6o    6@   �� *DepartureTime+6o   �� 5!      $!��Время прибытия��6%   $	 300��6j    6=   �� *ArrivalTime+6j   5"      5$      �� 5%   
   $��
Отчет��6   $��Center=�6    $��0,48,0,0q�6=   $	��Top=�6O   $��36(�6g   (  "System.Windows.Controls.DatePicker  5&   
   -   5          Name$ Start��5&      $
��Left=�6$   $��472,211,0,0q�6?   $	��Top=�6T   $��24(�6l   $	��188��6z   �� 5'   
   $��Начало��6   $
��Left=�6!   $��341,204,0,0q�6<   $	��Top=�6Q   $��36(�6i     5(   
   -   5        $	 End��5(      $
��Left=�6"   $��912,211,0,0q�6=   $	��Top=�6R   $��24(�6j   $	��188��6x   �� 5)   
   $��
Конец��6   $
��Left=�6    $��803,204,0,0q�6;   $	��Top=�6P   $��36(�6h   �� 5*   
   -   5        $#��Составить отчет��5*      $��Center=�6+   $��	0,348,0,0q�6H   $	��Top=�6[   $��24(�6s   $��50��6�   6�   5,      5-      