   M S B A M L   `   `   `  ����E  ACarService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CarService.WindowsCarService.Windows  5   	   +    %CarService.Windows.AddEditOrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:CarService.Windows     5   	     � Title$  AddEditOrderWindow��5   	    � WindowStartupLocation$ CenterScreen=�6$    � WindowStyle$
 None=�6I    � AllowsTransparency . 
������ $	��700��6�   $	��600��6�   .��5	      � .+�5
   
   ��  K� ZIndex$ 1��6   $��Right=�6&   $	��Top=�6B   $��0,5,10,0q�6Z   $��30��6l    �� Orientation$ 
Horizontal=�6x   $��RightToLeft=�6�   .+�5      �� -   5         ��Name$ btnClose��5         IconButtonsStyle#��[  6'    	 close#���  6Q   
 � Tag$ IsCloseButton��6�   �� 5      -   5        $ btnMinimize��5      #���   6*     minimize#���  6U   6z   5      �� 5   
   -   5        $��2��5        PrimaryBackgroundColor#���  6"   $��1��6X    �� CornerRadius$ 25 25 25 25��6h   ._�5      �� $��Center=�6   .+�5      �� -   5        	 ��Name$	 TitleTb��5      $'��!Добавление заказа��6-     	titleText#���  6F   ���#FF9E006�   �� 5      $��	20 20 0 0q�6   $��Center=�60   .+�5      ��   
tbListView#���  6    $��28(�6E     TextSecundaryColor#���  6S   " Выберите клиента:6�   �� 5      $ 
Horizontal=�6!   .+�5      �� -   5        
 ��Name$
 	ClientTxt��5   "     mainTextBox#���  65   $��26(�6[   {�.  6}   �� 5      -   5        $ ChooseClientBtn��5   !     
ControlBtn#���  6:   
����������#00ab5e$��80��6�   $
��Left=�6�   $��5 3 0 0q�6�   .��6�   ...6�   5      5      �� 5      $��	20 20 0 0q�6   $��Center=�61   .+�5      �� #���  6    $��28(�6E   #���  6S   Авто клиента:6�   �� 5      -   5         ��Name$ AutoCmb��5       	 ComboBoxStyle#��� 	 60   $	��420��6v   $��40��6�   $��24(�6�    �� SelectedItem 6X   �� *Auto+��5      �� 5      .R�5   "   �  � ColumnDefinitions 5   &   �� 5   *   $
��auto �6;   �� 5    *   $
��auto �6;   �� 5!   *   $
��auto �6;   .+�5#   &   �� ��60   �� *Mark+�� 5$   &   $��1��60   ��6@   �� *Model+ �� StringFormat$
  {0}���� 5%   &   $��2��60   ��6@   �� *	GosNumber+$
  {0}��5&   #   5'      5)      5*      �� 5+      $��	20 20 0 0q�6   $��Center=�60   .+�5,      �� #���  6    $��28(�6E   #���  6S   Менеджер:6�   �� 5-      -   5        $ 
ManagerCmb��5-      #��� 	 63   $	��420��6~   $��40��6�   $��24(�6�    6[   �� *	Employee1+��5.      �� 5/      .R�50   "   �  51   &   �� 52   *   �� 53   *   �� 54   *   .+�56   &   �� ��60   �� *	Surname+�� 57   &   $��1��60   ��6@   �� *Name+$
  {0}���� 58   &   $��2��60   ��6@   �� *
Patronymic+$
  {0}��59   #   5:      5<      5=      �� 5>      $��	20 20 0 0q�6   $��Center=�60   .+�5?      �� #���  6    $��28(�6E   #���  6S   Автомеханик:6�   �� 5@      -	   5        $ AutoMechanicCmb��5@      #��� 	 68   $	��420��6�   $��40��6�   $��24(�6�    6`   �� *
Employee+��5A      �� 5B      .R�5C   "   �  5D   &   �� 5E   *   �� 5F   *   �� 5G   *   .+�5I   &   �� ��60   �� *	Surname+�� 5J   &   $��1��60   ��6@   �� *Name+$
  {0}���� 5K   &   $��2��60   ��6@   �� *
Patronymic+$
  {0}��5L   #   5M      5O      5P      �� 5Q      $��	20 20 0 0q�6   $��Center=�60   .+�5R      �� #���  6    $��28(�6E   #���  6S   /-Дата регистрации заказа:6�   (  "System.Windows.Controls.DatePicker  5S      -
   5          Name$ dateofRegistration��5S   !    
 DirectoryDatePicker#��� 
 6i   $��26(�6�   $	��420��6�      SelectedDate 6=   �� *DateOfRegistration+6�   5T      �� 5U      $��	20 20 0 0q�6   $��Center=�60   .+�5V      �� #���  6    $��28(�6E   #���  6S   %#Дата выдачи заказа:6�     5W      -   5        $ dateofDelivery��5W   !   #��� 
 6a   $��26(�6�   $	��420��6�    69   �� *DateOfDelivery+6�   5X      �� 5Y      $ 
Horizontal=�6   $��Center=�66   .+�5Z      �� -   5        $ SaveBtn��5Z      
�������$	��200��6A   $��45��6M   $��28(�6Y   $��0 20 0 0q�6g   $��Сохранить��6y   #���  6�   ���#00ab5e6�   �� 5[      -   5        $ 	CancelBtn��5[      
�������$	��200��6C   $��45��6O   $��28(�6[   $��	40 20 0 0q�6i   $��Отмена��6|   #���  6�   ���#e639466�   5\      5]      5^      5_      5`      