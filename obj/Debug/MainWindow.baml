   M S B A M L   `   `   `  ����H  DMyAgriculture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MyAgricultureMyAgriculture  5   	   D @FluentWPF, Version=0.6.1.0, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF 5	   	       MyAgriculture.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:MyAgriculture     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ?fw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF  5	   	   J FWpfAnimatedGif, Version=1.4.18.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5
   	   )  #SourceChord.FluentWPF.AcrylicWindow    Enabled  .    ShowTitleBar .   � Title$
 Main��5   	   $	��500��6   $	��900��6#    � 
ResizeMode$ NoResize=�6/    � WindowStyle$
 None=�6E    � WindowStartupLocation$ CenterScreen=�6X   .��5      � $	��470��6   $��Bottom=�6    � BindingGroup 5   
   &   System.Windows.Data.BindingGroup  5       � ColumnDefinitions 5   
   �� 5      -   5         �Name$ Slide��5      $	��150 �6,   �� 5      $��* �6    .+�5   
   � *  $SourceChord.FluentWPF.PointerTracker	   Enabled	 . ���	#01FFFFFF
 � RowDefinitions
 5      �� 5      $��60 �6    �� 5      $��* �6    .+�5      � -   5        $��grid0��5      $��0��6    .+�5      �� ._�5       �� -   5        $��AgricultureImage��5    F   $1��+Image/Logo_Agriculture_Strategies_600px.png��6^   $
��Left=�6�   $��60��6�   $	��Top=�6�   $	��140��6�   5!      5#      � 5$      -   5        $��grid1��5$      $��1��6    .+�5%      �� .+�5&      ��  �� Orientation$ 
Horizontal=�6!   .+�5'      �� 
���   ���64   Z� ��6J   Z� .��5(      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Dropbox=�66   5)      �� 5*      $��Gestion Du Stockage��6$   $��12(�6?   $��10q�6M   $��Center=�6Y   5+      �� 5,      -   5        $��
Pesticides��5,   /   $��0q�6#    � ToolTip$ 
Pesticides��6A   .��5-      �� $ 
Horizontal=�6%   .+�5.        $ FlowerTulip=�66   $��15q�6I   �� 5/      $��Les Pesticides��6(   $��Center=�6>   50      51      �� 52      -   5        $��Engrais��52   /   $��0q�6#   $ Les Engrais��6>   .��53      �� $ 
Horizontal=�6%   .+�54        $ Filter=�66   $��15q�6D   �� 55      $��Les Engrais��6(   $��Center=�6;   56      57      �� 58      -   5        $��
Irrigation��58   /   $��0q�6#   $! Irrigation Goutte à Goutte��6A   .��59      �� $ 
Horizontal=�6%   .+�5:        $ Water=�66   $��15q�6C   �� 5;      $��
Irrigation��6(   $��Center=�6:   5<      5=      �� 5>      $ 
Horizontal=�6!   .+�5?      �� 
���   ���64   Z� ��6J   Z� .��5@        $ Monitor=�66   5A      �� 5B      $��System��6$   $��12(�62   $��10q�6@   $��Center=�6L   5C      �� 5D      -   5        $��Statistiques��5D   /   $��1q�6#   $ Les Statistiques��6C   .��5E      �� $ 
Horizontal=�6%   .+�5F        $ ChartBar=�66   $��15q�6F   �� 5G      $��Les Statistiques��6(   $��Center=�6@   5H      5I      �� 5J      -	   5        $��Revenus��5J   /   $��1q�6#   $ Revenus��6>   .��5K      �� $ 
Horizontal=�6%   .+�5L        $
 Euro=�66   $��15q�6B   �� 5M      $��Revenus��6(   $��Center=�67   5N      5O      �� 5P      -
   5        $��GFacturation��5P   /   $��1q�6#   $ Gestion de Facturation��6C   .��5Q      �� $ 
Horizontal=�6%   .+�5R        $ PaperclipHorizontal=�66   $��15q�6Q   �� 5S      $��Facturation��6(   $��Center=�6;   5T      5U      5V      5W      5X      � 5Y   
   -   5        $��mainGrid��5Y      $��1��6   
�������$��0,0,0,31q�6B   .+�5[      �� -   5        $��Footer��5[      $
��Left=�6'   $��31��6B   $��0,439,0,-31q�6N   $	��Top=�6c   $	��750��6{   ��5\      �� 5]       �� EndPoint$ 450,30&�6*    �� 
StartPoint$ 450,0&�6<    � MappingMode$ Absolute=�6O    �� RelativeTransform 5^      V� 5_      .~�5`   "   ��  �� CenterY$	 0.5Q�61    �� CenterX$	 0.5Q�6?   �� 5a   "    �� CenterY$	 0.5Q�60    �� CenterX$	 0.5Q�6>   �� 5b   "    �� Angle$ 431.565Q�62    �� CenterY$	 0.5Q�6B    �� CenterX$	 0.5Q�6P   T� 5c   "   5d      .��5f      �  � Offset$ 1Q�6'   � 5g       � Color$ 	#FF1586C7��6'   5h      5j      �� 5k      -   5        $��
mainBorder��5k   8   ���#f8f8f8._�5l      �� -   5        $��	MainImage��5l      $��Uniform=�6+   "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ Image/layers-animat.gif��6=   $��Stretch=�6y   $	��439��6�   $	��Top=�6�   $	��747��6�    J� OpacityMask �	#FFD413136�   5m      5o      �� 5p   
   $��2��6   $
��Left=�6)   $��30��6D   $��	0,-30,0,0q�6P   $	��Top=�6c   $	��900��6{   ��5q      �� 5r      $ 450,30&�6&   $ 450,0&�68   $ Absolute=�6K    5s      V� 5t      .~�5u      �� $	 0.5Q�6-   $	 0.5Q�6;   �� 5v      $	 0.5Q�6,   $	 0.5Q�6:   �� 5w      $ 431.565Q�6.   $	 0.5Q�6>   $	 0.5Q�6L   T� 5x      5y      .��5{      � $ 1Q�6#   � 5|      $ 	#FF1586C7��6#   5}      .+�5      �� -   5        $��CloseListViewItem��5   I   $��0 0 0 0q�6   $��Right=�6-   .��5�      �� $ 
Horizontal=�6   .+�5�        
���  ��
�������$ Close=�6S   $��0 0 0 0q�6`   $��30��6q   $��30��6}   5�      5�      �� 5�      -   5        $��MinimizedListViewItem��5�   L   $��Right=�6   $��
0,-32,30,0q�68   .��5�      �� .+�5�        
�������$ Minus=�6C   $��30��6P   $��30��6\   5�      5�      5�      5�      5�      