   M S B A M L   `   `   `  ����K  GWpf_ShapeDrawing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Wpf_ShapeDrawingWpf_ShapeDrawing  5   	   &     Wpf_ShapeDrawing.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Wpf_ShapeDrawing     5   	   -   5          �Name$  
mainWindow��5   4    � Title$ 
MainWindow��5   	   $	��500��6   $
��1000��6)    � 	Resources 5
         canvasPanelTemplate �� ElementName �� Path��%�   &	        �� 5   
   .R�5      �� 
���������6.   �� $ 
mainWindow��$ ActualWidth���6i   �� $ 
mainWindow��$ ActualHeight�5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   o� -   5         o�Name$
 menu��5      $��5,0,0,0q�6   
�����w�.@�5      m� $��	File menu��6   
�������$��20(�6=   $��0,0,7,0q�6K   
���   �.@�5      m� $	��New��6   
�������$��20(�6^    m� Command 6*   �� *NewCanvasCmd+6n   m� 5      $
��Open��6   
�������$��20(�6Y    6*   �� *	OpenCmd+6i   m� 5      $
��Save��6   
�������$��20(�6Y    6*   �� *	SaveCmd+6i   5      m� 5      -   5         m�Name$ shapes��5   ,   $��Shapes menu��6   
�������$��20(�6�   $��0,0,7,0q�6�   
���   ���6<   �� $ 	Polygones�	 �� Mode$	 TwoWay=���5      �� 5      
 �� 
TargetType"
 m�6   .�5      ��  �� Property � �� �� Value 63   �� *Id+�� 5       �@m�IsCheckable . 68   �� 5        �@m�StaysOpenOnClick . 6=   �� 5!       �@m�Command 64   �� *" DataContext.SelectPolygonCommand+ �� RelativeSource ��  �� AncestorType" �� �� Mode$ FindAncestor=��� 5"       �@m�CommandParameter 6=   �� 6Q   5#      5%      m� 5&      $
��Mode��6   
�������$��20(�68   $��0,0,7,0q�6F   
���   �.@�5'      m� -   5        $ DrawingMenu��5'      $��Drawing��60    m� 	IsChecked . 
�������$��20(�6e    m� StaysOpenOnClick . 6�   m� 5(      -   5        $ 
MovingMenu��5(      $��Moving��6/   
�������$��20(�6R    . 6�   5)      m� 5*      
���   �$
��Draw��6G   
�������$��20(�6h   $��0,0,7,0q�6v    6   �� *	DrawCmd+6v   5+      �� 5,   
   -   5        #��[  5/      $��1��6I   $��0,0,0,62q�50   @   ��6   �� $ 	Polygones���52      �� 53      .R�54      �  � Points 6   �� *Polygon.Points+��6@   �� *Polygon.Fill+��6^   �� *Polygon.Stroke+��55      �� *Polygon.StrokeThickness+56      58      59      5:      