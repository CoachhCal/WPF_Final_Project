   M S B A M L   `   `   `  ����H  DFinal_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Final_ProjectFinal_Project  5   	       Final_Project.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Final_Project     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   o� $��0��6   .@�5      m� $
��File��6   .@�5      m� $
��Exit��6    m� Command 6)   �� *ExitCommand+6K   5      m� 5      $
��View��6   .@�5      m� $
��Home��6    6)   �� *NavigateToHomeCommand+6U   m� 5      $��View Genres��6    60   �� *NavigateToGenresCommand+6^   m� 5      $��View Movies��6    60   �� *NavigateToSearchTitlesCommand+6d   m� 5      $��View Actors��6    60   �� *NavigateToSearchActorsCommand+6d   m� 5      $��View Directors��6    63   �� *" NavigateToSearchDirectorsCommand+6j   5       5!      �� 5$   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��0��6;   $��Center=�6K   .+�5%      �� $��Final Project Title��6   $��32(�63   $��Center=�5&      $��Center=�6-   5'      �� 5)   
   $ 
Horizontal=�6   $��2��6.   $��0��6;   $��Center=�6K   .+�5*      �� $��Movies��6   $��20(�6&   $��0,0,10,0q�64   $��Center=�6F   $��Center=�6c   �� 5+      $��Actors��6   $��20(�6&   $��0,0,10,0q�64   $��Center=�6F   $��Center=�6c   �� 5,      $��Genre��6   $��20(�6%   $��0,0,10,0q�63   $��Center=�6E   $��Center=�6b   �� 5-      $��	Directors��6   $��20(�6)   $��0,0,10,0q�67   $��Center=�6I   $��Center=�6f   �� 5.      $��Writers��6   $��20(�6'   $��0,0,10,0q�65   $��Center=�6G   $��Center=�6d   5/      �� 53   
   $��3��6   $��0��6   $��4��6.   ���#e6d8bd$��
5,10,10,10q�6W   ._�54      �� ��6   �� *CurrentViewModel+55      56      57      