   M S B A M L   `   `   `  ����E  ACarService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CarService.WindowsCarService.Windows  5   	   +    %CarService.Windows.ChooseClientWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:CarService.Windows     5   	     � Title$  ChooseClientWindow��5   	   $	��820��6$   $
��1000��61   
������  � WindowStyle$
 None=�6W    � WindowStartupLocation$ CenterScreen=�6j    � AllowsTransparency . .��5	      �� -   5           PrimaryBackgroundColor#���   5	   *   ._�5
      �  � RowDefinitions 5      �� 5      $
��0.2* �6    60   �� 5      $
��0.1* �6    60   �� 5      6"   .+�5      ��  K� ZIndex$ 1��6   $��Right=�6*   $	��Top=�6F   $��0,5,10,0q�6^   $��30��6p    �� Orientation$ 
Horizontal=�6|   $��RightToLeft=�6�   .+�5      �� -   5         ��Name$ btnClose��5        IconButtonsStyle#��[ 6+    	 close#���  6U   
 � Tag$ IsCloseButton��6w   6�   �� 5      -   5        $ btnMinimize��5      #���  6.     minimize#���  6Y   6~   5      �� 5      #���   6   .+�5      �� $+��%Клиенты автосервиса��6     tbTitlePage#���  67   6_   �� 5      $��Center=�6   $ 
Horizontal=�6:   .+�5      ��   
tbListView#���  6    $��28(�6E     TextSecundaryColor#���  6S   Поиск:6�   �� 5      -   5        	 ��Name$	 	searchTxt��5        mainTextBox#���  61   $��26(�6W   $��10 0 0 0q�6e   6�   �� 5      -   5        $ resetBtn��5        
ControlBtn#���  6/   $��26(�6T   $��10 0 0 0q�6b   $	��200��6t    	 ThirdOrangeColor#��� 	 6�   .��6�   
Сброс6�   5      5      �� 5      $ 
Horizontal=�6   $��1��62   $��20 0 0 0q�6?   $��20��6Q   .+�5      �� -   5        
 ��Name$
 FIOTb��5      $	��300��6+    
 
tbAtribute#��� 
 67    � Cursor$
 Hand��6\   
ФИО ⇅6�   �� 5      -   5        $
 dateTb��5      $	��250��6,   #��� 
 68   $
 Hand��6]   Дата рождения ⇅6�   �� 5       $	��200��6   #��� 
 6(   Телефон6V   �� 5!      $	��220��6   #��� 
 6(   
Выбор6T   5"      �� 5$      -   5         ��Name$ clientsListView��5$      $��2��60   
������   SecundaryBackgroundColor#���  6W   ��5%      �� 5&      .R�5'      �� $ 
Horizontal=�6%   $��15 0 0 0q�6>   .+�5(      �� $
 	FIOClient��6(   #���  6;   $��30��6`   $	��300��6l   ��5)   "   `� 5*   &    �� StringFormat$ {0} {1} {2}��63   .1�5+   *   ��  �� Path$ Surname�62   6C   �� 5,   *   $
 Name�62   6@   �� 5-   *   $ 
Patronymic�62   6F   5.   '   50      �� 51      #���  6(   $	��250��6�   ��6M   �� *DateOfBirth+$ {0:dd.MM.yyyy}��6�   �� 52      #���  6(   $	��155��6|   ��6M   �� *	Telephone+$	 {0}��6�   �� 53      $��30��6)   $	��140��65   .+�54   "   �� $ 	chooseBtn��6)   -	   5        #���  54   <   
�������$��20(�6�   $	��130��6�   $��30��6�   $��Выбрать��6�   ���#00ab5e6�   55      56      57      59      5:      5;      5<      