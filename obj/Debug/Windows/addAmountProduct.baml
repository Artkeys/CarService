   M S B A M L   `   `   `  ����E  ACarService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CarService.WindowsCarService.Windows  5   	   )    #CarService.Windows.addAmountProduct   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:CarService.Windows     5   	     � Title$#  Поставка товара��5   	   $	��250��6!   $	��400��6.   
������  � WindowStyle$
 None=�6S    � WindowStartupLocation$ CenterScreen=�6f    � AllowsTransparency . .��5	      � .+�5
   
   �� $��1��6    K� ZIndex$ 1��6%   $��Right=�66   $	��Top=�6R   $��0,5,10,0q�6j   $��30��6|    �� Orientation$ 
Horizontal=�6�   $��RightToLeft=�6�   .+�5      �� -   5         ��Name$ btnClose��5         IconButtonsStyle#��[  6'    	 close#���  6Q   
 � Tag$ IsCloseButton��6s   6�   5      �� 5   
   -   5        $��0��5       �� Padding$ 20q�6!     PrimaryBackgroundColor#���  6.   	 �� CornerRadius$	 15 15 15 15��6d   ._�5      � $��Center=�6   $��Center=�60   $��0 10 0 0q�6K   
 � RowDefinitions
 5      �� 5      6&   �� 5      6&   �� 5      6&   .+�5      �� -   5         ��Name$ TitleTb��5      $��26(�6-   $	��Top=�6;   $G��AВведите поставляемое число товаров��6S   $
��Wrap=�6}     	titleText#���  6�   ���#FF9E006�   �� 5      -   5         ��Name$ 	amountTxt��5   9   $��0 10 0 0q�6   $��1��6,     mainTextBox#���  6L   $	��250��6r   $��30��6~   6�   �� 5      $��2��6   $ 
Horizontal=�6*   $��Center=�6C   $��0 10 0 0q�6`   .+�5      �� -   5        $ SaveBtn��5      
�������$	��125��6A   $��40��6M   $��18(�6Y   $��0 10 0 0q�6g   $��Сохранить��6y     
ControlBtn#���  6�   ���#00ab5e6�   �� 5      -   5        $ 	CancelBtn��5      
�������$	��125��6C   $��40��6O   $��18(�6[   $��	20 10 0 0q�6i   $��Отмена��6|   #���  6�   ���#e639466�   5      5      5      5      5      