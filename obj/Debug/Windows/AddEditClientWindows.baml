   M S B A M L   `   `   `  ����E  ACarService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CarService.WindowsCarService.Windows  5   	   -    'CarService.Windows.AddEditClientWindows   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:CarService.Windows     5   	     � Title$H  BДобавление/редактирование клиентов��5   	    � WindowStartupLocation$ CenterScreen=�64    � WindowStyle$
 None=�6Y    � AllowsTransparency . 
������ $	��600��6�   $	��600��6�   .��5	      � .+�5
   
   ��  K� ZIndex$ 1��6   $��Right=�6&   $	��Top=�6B   $��0,5,10,0q�6Z   $��30��6l    �� Orientation$ 
Horizontal=�6x   $��RightToLeft=�6�   .+�5      �� -   5         ��Name$ btnClose��5         IconButtonsStyle#��[  6'    	 close#���  6Q   
 � Tag$ IsCloseButton��6s   6�   �� 5      -   5        $ btnMinimize��5      #���   6*     minimize#���  6U   6z   5      �� 5   
   -   5        $��2��5        PrimaryBackgroundColor#���  6"   $��1��6X    �� CornerRadius$ 25 25 25 25��6h   ._�5      �� $��Center=�6   .+�5      �� -   5        	 ��Name$	 TitleTb��5      $)��#Добавление клиента��6-     	titleText#���  6G   ���#FF9E006�   �� 5      $��	20 20 0 0q�6   $��Center=�60   .+�5      ��   
tbListView#���  6    $��28(�6E     TextSecundaryColor#���  6S   Фамилия:6�   �� 5      -   5        
 ��Name$
 
surnameTxt��5        mainTextBox#���  6K   $��26(�6q   ��62   �� *	Surname+6�   5      �� 5      $��	20 20 0 0q�6   $��Center=�60   .+�5      �� #���  6    $��28(�6E   #���  6S   	Имя:6�   �� 5      -   5        $
 nameTxt��5      #���  6E   $��26(�6k   ��6/   �� *Name+6�   5      �� 5      $��	20 20 0 0q�6   $��Center=�60   .+�5      �� #���  6    $��28(�6E   #���  6S   Отчество:6�   �� 5      -   5        $
 patronymicTxt��5      #���  6Q   $��26(�6w   ��65   �� *
Patronymic+6�   5      �� 5      $��	20 20 0 0q�6   $��Center=�60   .+�5      �� #���  6    $��28(�6E   #���  6S   Дата рождения:6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dateOfBirth��5   !     DirectoryDatePicker#���  6[   $��26(�6�      SelectedDate 66   �� *DateOfBirth+6�   5       �� 5!      $��	20 20 0 0q�6   $��Center=�60   .+�5"      �� #���  6    $��28(�6E   #���  6S   Телефон:6�   �� 5#      -	   5        $
 telephoneTxt��5#       �� 	MaxLength$ 11��6O   #���  6^   $��26(�6�   ��64   �� *	Telephone+6�   5$      �� 5%      $ 
Horizontal=�6   $��Center=�66   .+�5&      �� -
   5        $ SaveBtn��5&      
�������$	��200��6A   $��45��6M   $��28(�6Y   $��0 20 0 0q�6g   $��Сохранить��6y    	 
ControlBtn#��� 	 6�   ���#00ab5e6�   �� 5'      -   5        $ 	CancelBtn��5'      
�������$	��200��6C   $��45��6O   $��28(�6[   $��	40 20 0 0q�6i   $��Отмена��6|   #��� 	 6�   ���#e639466�   5(      5)      5*      5+      5,      