   M S B A M L   `   `   `  ����F  BPieControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:PieControls;assembly=PieControlsPieControls  5   	   ! StaticSourceCodeSmellAnalysis.   (StaticSourceCodeSmellAnalysis.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   >pie.clr-namespace:PieControls;assembly=PieControls     5   	     � Title$  Source Code Risk Analysis��5   	   $	��700��6+   $	��800��68   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5	      $��* �6   6)   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   .+�5      �� $��5q�6   $��Center=�6   $��16(�6<   .��6J   Code Smell Detector6_   � 5       � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $
��Auto �6'   66   .+�5      �� -   5         ��Name$ PathTextBox��5      $��5q�6/   $��Stretch=�6:   6�   �� 5      -   5         ��Name$ AnalyzeButton��5   )   $��1��6   $��5q�6@   {�.  .��6y   	Analyze6�   5      �� 5      -   5        $��DetailPanel��5      $y�	Collapsed=�6,   $ 
Horizontal=�6D   $��Center=�6]   .+�5      �� .��6   Number of Files:6*   �� 5      -   5        $��
FilesLabel��5      6,   �� 5      .��6   Number of Classes:6,   �� 5      -   5        $��ClassesLabel��5      6.   �� 5      .��6   Number of Methods:6,   �� 5      -   5        $��MethodLabel��5      6-   �� 5      .��6   Number of Lines:6*   �� 5      -   5        $��
LinesLabel��5      6,   5      5      �� 5!   
   -   5        $��ReportViewer��5!      $y�	Collapsed=�6+   $
��Auto=�6B   $��1��6e   .��5"      �� .+�5#      �� -	   5         ��Name$ ClassWiseReportPanel��5#      .+�5$      �� $��5q�6   
�������._�5%      �� $��Center=�6    $��14(�6=   .��6K   Class Wise Report6^   5&      � 5(       5)      �� 5*      61   �� 5+      61   .+�5-      �� $	��Top=�6%   $��5q�6=   $��0��6H   
�������.+�5.         PieControls.PieChart  -
   5          Name$ GodClassChart��5.   +   $	��250��6B   $	��200��6N      PieWidth$	 150Q�6[   	   	PieHeight$		 150Q�6j   �� 5/      $��Center=�6$   $��14(�6A   .��6O   	God Class6Z   50      �� 51      $	��Top=�6%   $��5q�6=   $��1��6H   
�������.+�52        -   5        $ LazyClassChart��52   +   $	��250��6C   $	��200��6O   $	 150Q�6\   $		 150Q�6k   �� 53      $��Center=�6$   $��14(�6A   .��6O   
Lazy Class6[   54      55      56      �� 58      -   5        $ MethodWiseReportPanel��58      .+�59      �� $��5q�6   
�������._�5:      �� $��Center=�6    $��14(�6=   .��6K   Method Wise Report6_   5;      � 5=       5>      �� 5?      61   �� 5@      61   �� 5A      61   .+�5C      �� 
�������$	��Top=�6=   $��0��6U   $��5q�6e   .+�5D        -   5        $ LongMethodChart��5D   +   $	��200��6D   $	��160��6P   $	 120Q�6]   $		 120Q�6l   �� 5E      $��Center=�6$   $��14(�6A   .��6O   Long Method6\   5F      �� 5G      
�������$	��Top=�6=   $��1��6U   $��5q�6e   .+�5H        -   5        $ LongParameterListChart��5H   +   $	��200��6K   $	��160��6W   $	 120Q�6d   $		 120Q�6s   �� 5I      $��Center=�6$   $��14(�6A   .��6O   Long Parameter List6d   5J      �� 5K      
�������$	��Top=�6=   $��2��6U   $��5q�6e   .+�5L        -   5        $ SwitchStatementChart��5L   +   $	��200��6I   $	��160��6U   $	 120Q�6b   $		 120Q�6q   �� 5M      $��Center=�6$   $��14(�6A   .��6O   Switch Statement6a   5N      5O      5Q      �� 5S      $ 
Horizontal=�6   $��Center=�66   .+�5T      �� -   5        $ FilterClassesButton��5T      $��5q�6:   $
��Left=�6E   .��6�   Class Level Smells6�   �� 5U      -   5        $ FilterMethodsButton��5U      $��5q�6:   $
��Left=�6E   .��6�   Methods Level Smells6�   �� 5V      -   5        $ FilesButton��5V      $��5q�62   $
��Left=�6=   .��6r   Files Detail6�   �� 5W      -   5        $ ClassesButton��5W      $��5q�64   $
��Left=�6?   .��6v   Class Detail6�   �� 5X      -   5        $ MethodsButton��5X      $��5q�64   $
��Left=�6?   .��6v   Method Detail6�   5Y      &   System.Windows.Controls.DataGrid  5[      -   5        
  Name$
 DataGrid��5[   (   $	��500��6   $��5q�6:   $��Stretch=�6E   6e   5\      5]      5_      5`      