   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.Basket   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	     � Title$  Basket��5   	   $	��596��6   $	��683��6%   .��5	      � $��
0,10,10,12q�6   .+�5
   
   �� 
�������6   �� 5   
   $��BASKET��6   $��Center=�6!   $��0,40,0,0q�6>   $	��Top=�6P   $��40(�6h   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
BasketView��5   '   $��	0,168,0,0q�6      AlternatingRowBackground
 ����� J� RenderTransformOrigin$ 0.714,0.512&�6b   $��Center=�6�   $	��341��6�   $	��163��6�   $	��Top=�6�    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%X   '        �� 5      "  6   .�5      ��  � ��
 �����5      5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 61   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6<   �� *Id+  5      $ UserName��6%   $	 80 67   
 6B   �� *UserID+  5      $ 	ProductID��6%   $	 80 68   
 6C   �� *	ProductId+  5      $ Count��6%   $	 60 64   
 6?   �� *Count+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Delete��6)   $	 * 69      CellTemplate 5      �� 5      .R�5      ��  ��Name$ Delete��6%   -   5        
���  ��5       5"      5$      5'      5)      5*      