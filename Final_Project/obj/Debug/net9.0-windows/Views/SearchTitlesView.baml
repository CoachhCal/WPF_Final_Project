   M S B A M L   `   `   `  ����H  DFinal_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Final_Project.ViewsFinal_Project.Views  5      C&clr-namespace:Final_Project.ViewModelsFinal_Project.ViewModels  5      *    $Final_Project.Views.SearchTitlesView   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Final_Project.Views     5      5vm&clr-namespace:Final_Project.ViewModels     5      
����ح�.��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .+�5      �� $��Titles��6   $��24(�6&   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��
10,10,10,0q�6;   .+�5      �� $��Search by Title Name:   ��6   �� 5      $	��200��6   ��6"   �� *SearchQueryTitle+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $��2��6   $��10q�6G   ��6    �� *FilteredTitles+ �� SelectedItem 6S   �� *SelectedTitle+��5      �� 5      .R�5      �� $��5q�6?   ��6    �� *OriginalTitle+6?   5      5       5"      5#      