   M S B A M L   `   `   `  ����E  ACarService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CarService
CarService  5   	       CarService.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:CarService     5   	     � Title$  
MainWindow��5   	   $	��900��6   $
��1300��6)    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�6.   
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	    � WindowState$ Normal=�6   .��5      �� -   5         �� CornerRadius$ 8��5         PrimaryBackgroundColor#���   6   ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      .+�5      �� $ 8 0 0 8��6     SecundaryBackgroundColor#���  6,   ._�5      � -   5         �Name$ gridMenu��5      $��60��6)   	 � RowDefinitions	 5      �� 5      $��60 �6(   �� 5      $��80 �6(   �� 5      $
��Auto �6(   �� 5      .+�5      �� $��1��6!   
 �� Orientation$
 
Horizontal=�6.   $	��Top=�6G   .+�5      �� $��/Resources/logo.png��6    $��7 0 0 0q�6=   $
��Fill=�6N   $��45��6]   $��45��6h   $
��Left=�6t   �� 5      $��Автосервис��6      PrimaryBlueColor#���  65   $
��Bold"�6e   $��20(�6w   $��Center=�6�   $
��Left=�6�   $
��Left=�6�   $��14 0 0 0q�6�   5      d� 5!      -   5         d�Name$ btnMenu��5!   #   $��Right=�65   $��0q�6Q   
������ $��Center=�6~     MenuIconStyle#��[ 6�   $��0 0 15 0q�6�    � Triggers 5"      :� 5#       :� RoutedEvent$ ToggleButton.Unchecked��6+   .[�5$   "   �� .��5%   &   �� -   5         ��Name$ HideStackPanel��5%   1   .��5&   *   W�  �� 
TargetName$ gridMenu��6:    �� TargetProperty$ Width�6[    g� 	BeginTime$ 0:0:0X�6}    W� From$	 200X�6�   	 W� To$ 60X�6�    g� Duration$ 0:0:0.3D�6�   5'   +   5(   '   5)   #   5*      :� 5+      $ ToggleButton.Checked��6+   .[�5,   "   �� .��5-   &   �� -   5        $ ShowStackPanel��5-   1   .��5.   *   W� $ gridMenu��6:   $ Width�6[   $ 0:0:0X�6}   $ 60X�6�   $	 200X�6�   $ 0:0:0.3D�6�   5/   +   50   '   51   #   52      54      �� 56      $��3��6!   .+�57      	� -   5         	�Name$ 	clientBtn��57   &   $��Клиенты��69     MenuRadioButtonStyle#���  6K    
 client
 � Tag# �  6z   6�   	� 58      -   5        $ productsBtn��58   &   $��Продукты��6;   #���  6N     product# �  6}   $��0 5 0 5q�6�   6�   	� 59      -   5        $ employeeBtn��59   &   $��Сотрудники��6;   #���  6P     employee# �  6   6�   	� 5:      -	   5        $ 	ordersBtn��5:   &   $��Заказы��69   #���  6J    	 order# �  6y   $��0 5 0 5q�6�   6�   	� 5;      -
   5        $ 
reportsBtn��5;   &   $��Отчёты��6:   #���  6K    
	 report# � 	 6z   $��0 5 0 5q�6�   6�   	� 5<      -   5        $ employmentBtn��5<   &   $��Занятость��6=   #���  6Q    
 
employment# � 
 6�   $��0 5 0 5q�6�   5=      �� 5?      $��4��6!   $��Bottom=�6.   $
 Vertical=�6I   $	��200��6`   $��0 0 0 20q�6l   .+�5@      �� $
 
Horizontal=�6%   .+�5A      A� $��40��6&   $��40��61   $��10 0 0 0q�6=   ��5B   "   �� 5C   &   -   5        
profileImg��5C   G   5E      �� 5F      $
 Vertical=�6)   $��8 0 0 0q�6@   .+�5G   "   �� -   5         ��Name$ FIOLbl��5G   (     TextPrimaryColor#���  68   $��14(�6h   $��SemiBold"�6v   $��Center=�6�   $
��Left=�6�   �� 5H   "   -   5        $ RolesLbl��5H   (     PrimaryOrangeColor#���  6:   $��11(�6l   $��Regular"�6z   $��Center=�6�   $
��Left=�6�   $��	0 -10 0 0q�6�   5I      5J      	� 5K      -   5        $ 
singOutBtn��5K   &   $��
Выйти��6:   #���  6J    	 login# �  6y   $��0 20 0 5q�6�   6�   5L      5M      5N      � 5P      $��1��6   	 5Q      �� 5R      $��60 �6$   �� 5S      .+�5W      �� $��0��6   $��4��6*   $��Right=�6:   $	��Top=�6V   $��0,5,10,0q�6n   $��30��6�   $
 
Horizontal=�6�   $��RightToLeft=�6�   .+�5X      �� -   5         ��Name$ btnClose��5X        IconButtonsStyle#��[ 6/    	 close#���  6Y   $ IsCloseButton��6{    � Cursor$
 Hand��6�   �� 5Y      -   5        $ btnMinimize��5Y      #���  62     minimize#���  6]   6�   5Z      �� 5\      $��1��6   $��10q�6&   ._�5]       � -   5          �Name$ PagesNavigationFrame��5]        � NavigationUIVisibility$ Hidden=�6:   #���   6Z   5_      5`      5a      5b      5c      5d      