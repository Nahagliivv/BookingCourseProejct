   M S B A M L   `   `   `  ����V  RServiceBookingCourseProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ServiceBookingCourseProject.Views!ServiceBookingCourseProject.Views  5      1    +ServiceBookingCourseProject.Views.AdminPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:ServiceBookingCourseProject.Views     5        N� Title$  	AdminPage��5	      .��5      � ���#ECF7F5.+�5   
   �� $��
47,101,0,0q�6   $
��Left=�6}   $	��Top=�6�   $	��312��6�   $	��425��6�    �� SelectedItem 6(   �� *SelectedUser+��6N   �� *	ListUsers+ �� Mode$ TwoWay=� �� View 5      �� 5      .P�5      ��  �� Width$ 40��6P    �� DisplayMemberBinding 6&   ��  �� Path$ ID�.��6[   Id6_   �� 5      $	 160��6T    6%   �� $ FullName�.��6`   ФИО6e   �� 5      $	 120��6Q    6%   �� $ Email�.��6]   Email6d   �� 5      $	 100��6S    6%   �� $ balance�.��6_   Баланс6g   5      5      �� 5   
   $��Пользователи��6   $
��Left=�6'   $��	47,31,0,0q�6B   $	��Top=�6U   $��20(�6m   �� 5   
   $��530,101,0,0q�6   $
��Left=�6V   $	��Top=�6q   $	��312��6�   $	��246��6�    6)   �� *SelectedTypeService+��6�   �� *ListServicesTypes+ 5      �� 5      .P�5      �� $ 40��6P    6&   �� $ ID�.��6[   Id6_   �� 5      $	 200��6P    6%   �� $
 Text�.��6\   Вид услуги6h   5      5      �� 5   
   $��Виды услуг��6   $
��Left=�6%   $��
530,31,0,0q�6@   $	��Top=�6T   $��20(�6l   �� 5    
   $��839,101,0,0q�6   $
��Left=�6)   $	��Top=�6D   $	��312��6\   $	��564��6i   ��6u   �� *ListServices+ 6�   �� *SelectedService+ 5!      �� 5"      .P�5#      �� $ 40��6P    6&   �� $ ID�.��6[   Id6_   �� 5$      $	 160��6P    6%   �� $
 Name�.��6\   Название6f   �� 5%      $ 60��6P    6%   �� $
 Type�.��6[   Id Вида6d   �� 5&      $	 110��6T    6%   �� $ Capacity�.��6`   !Вместимость(чел.)6s   �� 5'      $	 110��6U    6%   �� $ 	StartDate�.��6a   Дата начала6n   �� 5(      $ 90��6Q    6%   �� $ Price�.��6\   Цена(руб.)6h   5)      5+      �� 5,   
   $��Услуги��6   $
��Left=�6!   $��
839,31,0,0q�6<   $	��Top=�6P   $��20(�6h   �� 5-   
   $��
47,556,0,0q�6   $
��Left=�6(   $	��Top=�6C   $	��232��6[   $	��286��6h    6t   �� *SelectedBookingRequest+��6�   �� *ListBookingRequests+ 5.      �� 5/      .P�50      �� $ 40��6J   $��Id��6U    6&   �� *ID+6U   �� 51      $	 120��6M   $!��Id пользователя��6Y    6%   �� *UserID+6Y   �� 52      $	 120��6P   $��Id услуги��6\    6%   �� *	ServiceID+6\   53      55      �� 56   
   $=��7Запросы на бронирование услуг��6   $
��Left=�68   $��
47,465,0,0q�6S   $	��Top=�6g   $��20(�6   �� 57   
   -   5         ��Name$ TextBоxSearchUsers��57   %   
�������$
��Left=�6B   $��25��6]    �� TextWrapping$
 Wrap=�6i   $	��Top=�6~   $	��338��6�   $��	47,73,0,0q�6�   $��15(�6�   .��6�   ��58      �� 59      .R�5:      �� 	 �� CornerRadius$	 12��6   
 �� Padding$
 2q�6/   $��1q�6;   ���#000000
�������._�5;      ��  ��Name$ PART_ContentHost��62   $��0q�6'   62   5<      5=      .��5>       5?      �� 5@   
   -   5        $ TextBоxServiceTypeSearch��5@   %   
�������$�� ��6G   $
��Left=�6P   $��25��6k   $
 Wrap=�6w   $	��Top=�6�   $	��159��6�   $��
530,73,0,0q�6�   $��15(�6�   .��6�   ��5A      �� 5B      .R�5C      �� $	 12��6   $
 2q�6/   $��1q�6;   ���#000000
�������._�5D      �� $ PART_ContentHost��62   $��0q�6'   62   5E      5F      .��5G       5H      �� 5I   
   -   5        $ TextBоxServicesSearch��5I   %   
�������$�� ��6D   $
��Left=�6M   $��25��6h   $
 Wrap=�6t   $	��Top=�6�   $	��477��6�   $��
839,73,0,0q�6�   $��15(�6�   .��6�   ��5J      �� 5K      .R�5L      �� $	 12��6   $
 2q�6/   $��1q�6;   ���#000000
�������._�5M      �� $ PART_ContentHost��62   $��0q�6'   62   5N      5O      .��5P       5Q      �� 5R   
   -   5        $" TextBоxBookingServiceSearch��5R   %   
�������$�� ��6J   $
��Left=�6S   $��25��6n   $
 Wrap=�6z   $	��Top=�6�   $	��199��6�   $��
47,518,0,0q�6�   $��15(�6�   .��6�   ��5S      �� 5T      .R�5U      �� $	 12��6   $
 2q�6/   $��1q�6;   ���#000000
�������._�5V      �� $ PART_ContentHost��62   $��0q�6'   62   5W      5X      .��5Y       5Z      �� 5[   
   -   5        $ TextBоxServiceType��5[   %   
�������$�� ��6A   $
��Left=�6J   $��25��6e   $
 Wrap=�6q   $	��Top=�6�   $	��144��6�   $��632,472,0,0q�6�   $��15(�6�   .��6�   ��5\      �� 5]      .R�5^      �� $	 12��6   $
 2q�6/   $��1q�6;   ���#000000
�������._�5_      �� $ PART_ContentHost��62   $��0q�6'   62   5`      5a      .��5b       5c      �� 5d   
   $��Вид услуги:��6   $
��Left=�6&   $��530,470,0,0q�6A   $	��Top=�6V   �� 5e   
   -   5        $;��5Удалить выбранный вид услуги��5e      $
��Left=�69   $��530,427,0,0q�6T   $	��Top=�6i   $	��246��6�   $��25��6�    �� 	IsDefault . 
���   �$��15(�6�   
�������$��0q�6�    � 	Resources 5f       �� 
TargetType �� Property �� Value��%_   '��       �� 5g      " ��6   .�5h      ��  �@��CornerRadius$ 15��65   5i      5j      5k      �� 5l   
   -   5        $*��$Добавить вид услуги��5l      $
��Left=�60   $��530,518,0,0q�6K   $	��Top=�6`   $	��246��6x   $��24��6�    . 
���   �$��15(�6�   
�������$��0q�6�    5m      ��%_   '��       �� 5n      " ��6   .�5o      ��  �@��CornerRadius$ 15��65   5p      5q      5r      �� 5s   
   -   5        $ TextBоxBalanceEdit��5s   %   
�������$�� ��6A   $
��Left=�6J   $��25��6e   $
 Wrap=�6q   $	��Top=�6�   $��86��6�   $��
47,425,0,0q�6�   $��15(�6�   .��6�   ��5t      �� 5u      .R�5v      �� $	 12��6   $
 2q�6/   $��1q�6;   ���#000000
�������._�5w      �� $ PART_ContentHost��62   $��0q�6'   62   5x      5y      .��5z       5{      �� 5|   
   -	   5        $��+��5|      $
��Left=�6   $��137,425,0,0q�69   $	��Top=�6N   $��32��6f   $��25��6q    . 
���   �$��15(�6�   
�������$��0q�6�    5}      ��%_   '��       �� 5~      " ��6   .�5      ��  �@��CornerRadius$ 15��65   5�      5�      5�      �� 5�   
   -
   5        $��-��5�      $
��Left=�6   $��174,425,0,0q�69   $	��Top=�6N   $��32��6f   $��25��6q    . 
���   �$��15(�6�   
�������$��0q�6�    5�      ��%_   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 15��65   5�      5�      5�      �� 5�   
   -   5        $)��#Подтвердить запрос��5�      $
��Left=�6/   $��
47,798,0,0q�6J   $	��Top=�6^   $	��286��6v   $��25��6�    . 
���   �$��15(�6�   
�������$��0q�6�    5�      ��%_   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 15��65   5�      5�      5�      �� 5�   
   -   5        $K��EОтклонить запрос(с возвратом средств)��5�      $
��Left=�6B   $��
47,828,0,0q�6]   $	��Top=�6q   $	��286��6�   $��25��6�    . 
���   �$��15(�6�   
�������$��0q�6�    5�      ��%_   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 15��65   5�      5�      5�      �� 5�   
   -   5        $��
Найти��5�      $
��Left=�6"   $��251,518,0,0q�6=   $	��Top=�6R   $��82��6j   $��24��6u    . 
���   �$��15(�6�   
�������$��0q�6�    5�      ��%_   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 15��65   5�      5�      5�      �� 5�   
   -   5        $��
Найти��5�      $
��Left=�6"   $��
390,74,0,0q�6=   $	��Top=�6Q   $��82��6i   $��24��6t    . 
���   �$��15(�6�   
�������$��0q�6�    5�      ��%_   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 15��65   5�      5�      5�      �� 5�   
   -   5        $��
Найти��5�      $
��Left=�6"   $��
694,74,0,0q�6=   $	��Top=�6Q   $��82��6i   $��24��6t    . 
���   �$��15(�6�   
�������$��0q�6�    5�      ��%_   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 15��65   5�      5�      5�      �� 5�   
   -   5        $��
Найти��5�      $
��Left=�6"   $��1321,72,0,0q�6=   $	��Top=�6R   $��82��6j   $��24��6u    . 
���   �$��15(�6�   
�������$��0q�6�    5�      ��%_   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 15��65   5�      5�      5�      �� 5�   
   -   5        $ TextBоxName��5�   %   
�������$�� ��6:   $
��Left=�6C   $��25��6^   $
 Wrap=�6j   $	��Top=�6   $	��453��6�   $��950,467,0,0q�6�   $��15(�6�   .��6�   ��5�      �� 5�      .R�5�      �� $	 12��6   $
 2q�6/   $��1q�6;   ���#000000
�������._�5�      �� $ PART_ContentHost��62   $��0q�6'   62   5�      5�      .��5�       5�      �� 5�   
   -   5        $  TextBоxDescriptionService��5�   %   
�������$�� ��6H   $
��Left=�6Q   $��25��6l   $
 Wrap=�6x   $	��Top=�6�   $	��453��6�   $��950,503,0,0q�6�   $��15(�6�   .��6�   ��5�      �� 5�      .R�5�      �� $	 12��6   $
 2q�6/   $��1q�6;   ���#000000
�������._�5�      �� $ PART_ContentHost��62   $��0q�6'   62   5�      5�      .��5�       5�      �� 5�   
   $$��Описание услуги:��6   $
��Left=�6+   $��839,501,0,0q�6F   $	��Top=�6[   �� 5�   
   $��Id вида услуги:��6   $
��Left=�6*   $��839,539,0,0q�6E   $	��Top=�6Z   �� 5�   
   -   5        $ TextBоxTypeId��5�   %   
�������$�� ��6<   $
��Left=�6E   $��25��6`   $
 Wrap=�6l   $	��Top=�6�   $��98��6�   $��950,541,0,0q�6�   $��15(�6�   .��6�   ��5�      �� 5�      .R�5�      �� $	 12��6   $
 2q�6/   $��1q�6;   ���#000000
�������._�5�      �� $ PART_ContentHost��62   $��0q�6'   62   5�      5�      .��5�       5�      �� 5�   
   $&�� Вместимость(чел.):��6   $
��Left=�6-   $��839,580,0,0q�6H   $	��Top=�6]   �� 5�   
   -   5        $ TextBоxCapacityHuman��5�   %   
�������$�� ��6C   $
��Left=�6L   $��25��6g   $
 Wrap=�6s   $	��Top=�6�   $��98��6�   $��950,580,0,0q�6�   $��15(�6�   .��6�   ��5�      �� 5�      .R�5�      �� $	 12��6   $
 2q�6/   $��1q�6;   ���#000000
�������._�5�      �� $ PART_ContentHost��62   $��0q�6'   62   5�      5�      .��5�       5�      (  "System.Windows.Controls.DatePicker  5�   
   -   5        $��TimePickerStartDate��5�   0   $
��Left=�6   $��950,619,0,0q�6K   $	��Top=�6`   $	��128��6x   �� 5�   
   $��Дата начала:��6   $
��Left=�6'   $��839,617,0,0q�6B   $	��Top=�6W   �� 5�   
   $��Цена(руб.):��6   $
��Left=�6&   $��839,656,0,0q�6A   $	��Top=�6V   �� 5�   
   -   5        $ TextBoxPrice��5�   %   
�������$�� ��6;   $
��Left=�6D   $��25��6_   $
 Wrap=�6k   $	��Top=�6�   $��98��6�   $��950,656,0,0q�6�   $��15(�6�   .��6�   ��5�      �� 5�      .R�5�      �� $	 12��6   $
 2q�6/   $��1q�6;   ���#000000
�������._�5�      �� $ PART_ContentHost��62   $��0q�6'   62   5�      5�      .��5�       5�      �� 5�   
   -   5        $R��LУдалить выбранную услугу(Все связи также)��5�      $
��Left=�6F   $��839,427,0,0q�6a   $	��Top=�6v   $	��564��6�   $��25��6�    . 
���   �$��15(�6�   
�������$��0q�6�    5�      ��%_   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 15��65   5�      5�      5�      �� 5�   
   -   5        $#��Добавить услугу��5�      $
��Left=�6,   $��839,761,0,0q�6G   $	��Top=�6\   $	��564��6t   $��25��6�    . 
���   �$��15(�6�   
�������$��0q�6�    5�      ��%_   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 15��65   5�      5�      5�      �� 5�   
   $%��Время начала(HH:mm):��6   $
��Left=�6/   $��1135,618,0,0q�6J   $	��Top=�6`   �� 5�   
   -   5        $ TextBoxTime��5�   %   
�������$�� ��6:   $
��Left=�6C   $��24��6^   $
 Wrap=�6j   $	��Top=�6   $	��124��6�   $��1279,619,0,0q�6�   $��15(�6�   .��6�   ��5�      �� 5�      .R�5�      �� $	 12��6   $
 2q�6/   $��1q�6;   ���#000000
�������._�5�      �� $ PART_ContentHost��62   $��0q�6'   62   5�      5�      .��5�       5�      �� 5�   
   $��Изображение:��6   $
��Left=�6'   $��839,705,0,0q�6B   $	��Top=�6W   �� 5   
   -   5        $��ServiceImage��5   +   $
��Left=�6   $��60��6?   $��965,691,0,0q�6K   $	��Top=�6`   $��60��6x   �� 5  
   -   5        $��SelectImage��5     $+��%Выбрать изображение��6%   $
��Left=�6C   $��1180,706,0,0q�6^   $	��Top=�6t   $	��223��6�   $��25��6�    . 
���   �$��15(�6�   
�������$��0q�6�    5     ��%_   '��       �� 5     " ��6   .�5     ��  �@��CornerRadius$ 15��65   5     5     5     �� 5	  
   $��Название:��6   $
��Left=�6$   $��839,465,0,0q�6?   $	��Top=�6T   5     5     