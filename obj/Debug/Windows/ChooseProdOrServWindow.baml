   M S B A M L   `   `   `  ����E  ACarService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CarService.WindowsCarService.Windows  5   	   /    )CarService.Windows.ChooseProdOrServWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:CarService.Windows     5   	     � Title$  ChooseProdOrServWindow��5   	   $	��820��6(   $
��1140��65   
������  � WindowStyle$
 None=�6[    � WindowStartupLocation$ CenterScreen=�6n    � AllowsTransparency . .��5	      �� -   5        ._�5
   
   �  � RowDefinitions 5      �� 5      $
��0.2* �6    60   �� 5      6"   .+�5      ��  K� ZIndex$ 1��6   $��Right=�6*   $	��Top=�6F   $��0,5,10,0q�6^   $��30��6p    �� Orientation$ 
Horizontal=�6|   $��RightToLeft=�6�   .+�5      �� -   5         ��Name$ btnClose��5         IconButtonsStyle#��[  6+    	 close#���  6U   
 � Tag$ IsCloseButton��6w   6�   �� 5      -   5        $ btnMinimize��5      #���   6.     minimize#���  6Y   6~   5      �� 5        PrimaryBackgroundColor#���  6   .+�5      �� $9��3Товары и услуги автосервиса��6     tbTitlePage#���  6?   6g   �� 5      $��Center=�6   $ 
Horizontal=�6:   .+�5      ��   
tbListView#���  6    $��28(�6E     TextSecundaryColor#���  6S   #!Поиск по названию:6�   �� 5      -   5        	 ��Name$	 	searchTxt��5        mainTextBox#���  61   $��26(�6W   $��	10 0 20 0q�6e   6�   �� 5      #���  6    $��28(�6E   #���  6S   Наличие:6�   �� 5      -   5        
 ��Name$
 AvailabilityCheckBox��5      $��26(�6=   $��2 0 0 0q�6K   {�.   d� 	IsChecked$
 TrueY�6n    � LayoutTransform 5      �� 5       �� ScaleX$ 2Q�6-    �� ScaleY$ 2Q�68   6E   5      �� 5      -   5        $ resetBtn��5        
ControlBtn#���  6/   $��26(�6T   $��10 0 0 0q�6b   $	��200��6t    	 ThirdOrangeColor#��� 	 6�   .��6�   
Сброс6�   5      5       �� 5!      -   5         ��Name$ productListView��5!      $��1��60   ���#f9f9f9$��Disabled=�6R   ��5"      �� 5#      .R�5$      �  � Orientation$ 
Horizontal=�6$   $
��Left=�6=   6Z   5%      ��5'      �� 5(      .R�5)      � $��20q�6   $	��300��6+    5*      �� 5+   "   $��45 �60   6>   �� 5,   "   $	��150 �60   6?   �� 5-   "   $
��auto �60   6@   �� 5.   "   $
��auto �60   6@   �� 5/   "   $
��auto �60   6@   .+�51      �� $��0��6(   $��Center=�6K   $��18(�6h   $
��Bold"�6v   $	��Top=�6�   $
��Wrap=�6�   ��65   �� *Name+ � ToolTip 6�   ��  �� Path$
 Name�6�   �� 52      $��1��6$   $	��150��62   $	��150��6>   $��UniformToFill=�6K   $��Center=�6c   $��5q�6�   ��6�   �� *pathImageProducts+53      �� 54      $��2��6(   #���  65   $��Center=�6�   ��6Z   �� *Amount+ �� StringFormat$! В наличие: {0}шт.��6�   �� 55      $��3��6(   #���  65   $��Center=�6�   ��6Z   �� *Price+$ Цена: {0}руб.��6�   �� 56      $��4��6)   $ 
Horizontal=�66   $��Center=�6O   $��0 10 0 0q�6l   .+�57   "   �� $ 	ChooseBtn��6)   -   5        #���  57   <   ���#48cfad$	��135��6v   $��40��6�   .��6�   Выбрать6�   58      59      5:      5<      5=      5>      5?      