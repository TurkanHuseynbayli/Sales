   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.Product   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   -   5          � Title$  Product��5   	   $	��450��6   $	��800��6&   .��5	      � -   5        $��MainGrid��5	      $��	0,0,-53,0q�6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridView��5
   �   $	��251��6      SelectionUnit$ FullRow=�6!   $	��Top=�69      CanUserAddRows .  $��52,82,136,0q�6i      AlternatingRowBackground
 �����   AutoGenerateColumns .     SelectionMode$ Single=�60   � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property	 �� Value��%X   '        �� 5      "  6   .�5      ��  � ��
	 �����5      5      5      
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6&      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 62      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Id+6T     5      $
 Name��6&   $ 70 64    .  6?   �� *Name+6Z     5      $ Price��6%   $ 50 64    .  6?   �� *Price+6Y     5      $ Description��6%   $ 80 6:    .  6E   �� *Description+6e     5      $ Count��6%   $ 50 64    .  6?   �� *Count+6Y     5      $ Status��6%   $ 50 65    .  6@   �� *Status+6[     5      $ TaxRate��6%   $ 60 66    .  6A   �� *	TaxRate+6]     5      $
 Code��6%   $ 50 63    .  6>   �� *Code+6W     5      $ CreatedDate��6%   $	 100 6:    .  6F   �� *CreatedDate+6f   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Edit��6)   $ 40 67      CellTemplate 5      �� 5       .R�5!      ��  ��Name$ btnEdit��6%   -   5        
���� ��5#      5%      5'        5)      $ Delete��6)   $ * 69    5*      �� 5+      .R�5,      �� $ Delete��6%   -   5        
���  ��5.      50      52      56      �� 57   
   -   5        $��btnAdd��57   �   $	��ADD��6   
����� �$
��Left=�61   $��379,364,0,0q�6L   $	��Top=�6a   $��34��6y   $��45��6�   6�   �� 58   
   $��PRODUCTS��6   $
��Left=�6#   $��
313,16,0,0q�6>   $	��Top=�6R   $��40(�6j   �� 59   
   -   5        $��btnSales��59   �   $��SALES��6   
�������$
��Left=�6<   $��
630,32,0,0q�6W   $	��Top=�6k   $��34��6�   $��45��6�   6�   5>      5?      