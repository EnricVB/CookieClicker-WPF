   M S B A M L   `   `   `  ����H  DCookieClicker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CookieClickerCookieClicker  5   	   G(clr-namespace:CookieClicker.usercontrolsCookieClicker.usercontrols  5   	   -clr-namespace:CookieClickerCookieClicker  5   	       CookieClicker.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CookieClicker     5   	   =itemShop(clr-namespace:CookieClicker.usercontrols     5   	   -styleclr-namespace:CookieClicker     5   	   -   5        ���	#FF38140C  � Title$  Cookie Clicker��5   	   $
��1080��6    $
��1920��6.   ���	#FF915F30 � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	    � 	Resources 5         NoHoverButtonStyle �� 
TargetType �� Triggers P� Property P� Value �� Value	 �� Property  GrandmaBackgroundBrush
 �� ImageSource j� TileMode j� Viewport j� ViewportUnits  FarmBackgroundBrush  FactoryBackgroundBrush  MineBackgroundBrush  	ClickIcon  GrandmaIcon  FarmIcon  MineIcon 	 FactoryIcon 
 Grandma  Farm  Mine  Factory 
 Cookie  
GoldCookie 	 RedBg��%	  &	        &	     &	 �    &	     &	 �    &	 �    &	 p    &	 �    &	 [    &		 �    &	
 F    &	 �    &	 )    &	 �    &	     &	 ~    &	 �    �� 5   
   " ��65   .R�5      �� #��z��6   
������ $��0q�6Y   ._�5      �� #��z��6#   #��z��6f   5       5      P� 5       � {�$ False��6/   . �5      �� # Z�63   	 � ���� 5      # Z
�63   	 � ��5      5      �� 5   
   $"
 assets/grandmaBackground.png��64   $
 Tile=�6_   $ 
0,0,0.25,1�6o   $ RelativeToBoundingBox=�6�   �� 5    
   $
 assets/farmBackground.png��61   $
 Tile=�6Y   $ 
0,0,0.25,1�6i   $ RelativeToBoundingBox=�6   �� 5!   
   $"
 assets/factoryBackground.png��64   $
 Tile=�6_   $ 
0,0,0.25,1�6o   $ RelativeToBoundingBox=�6�   �� 5"   
   $
 assets/mineBackground.png��61   $
 Tile=�6Y   $ 
0,0,0.25,1�6i   $ RelativeToBoundingBox=�6   �� 5$   
   $
 assets/cursorIcon.png��6'   $
 None=�6K   $ 
0, 0, 1, 1�6[   $ RelativeToBoundingBox=�6q   �� 5%   
   $
 assets/grandmaIcon.png��6)   $
 Tile=�6N   $ 
0, 0, 1, 1�6^   $ RelativeToBoundingBox=�6t   �� 5&   
   $
 assets/farmIcon.png��6&   $
 Tile=�6H   $ 
0, 0, 1, 1�6X   $ RelativeToBoundingBox=�6n   �� 5'   
   $
 assets/mineIcon.png��6&   $
 Tile=�6H   $ 
0, 0, 1, 1�6X   $ RelativeToBoundingBox=�6n   �� 5(   
   $
 assets/factoryIcon.png��6)   $
 Tile=�6N   $ 
0, 0, 1, 1�6^   $ RelativeToBoundingBox=�6t   �� 5*   
   $
 assets/grandma.png��6%   $
 Tile=�6F   $ 
0, 0, 1, 1�6V   $ RelativeToBoundingBox=�6l   �� 5+   
   $
 assets/farm.png��6"   $
 Tile=�6@   $ 
0, 0, 1, 1�6P   $ RelativeToBoundingBox=�6f   �� 5,   
   $
 assets/mine.png��6"   $
 Tile=�6@   $ 
0, 0, 1, 1�6P   $ RelativeToBoundingBox=�6f   �� 5-   
   $
 assets/factory.png��6%   $
 Tile=�6F   $ 
0, 0, 1, 1�6V   $ RelativeToBoundingBox=�6l   �� 5/   
   $
 assets/cookie.png��6$   $
 None=�6D   $ 
0, 0, 1, 1�6T   $ RelativeToBoundingBox=�6j   �� 50   
   $
 assets/goldCookie.png��6(   $
 None=�6L   $ 
0, 0, 1, 1�6\   $ RelativeToBoundingBox=�6r   �� 51   
   $
 assets/bgRed.jpg��6#   $
 None=�6B   $ 
0, 0, 1, 1�6R   $ RelativeToBoundingBox=�6h   52      .��54      � -   5         �Name$ SimpleMovementBorder��54      .+�55   
   � ��56      �� 57      $
 assets/background.jpg��6    � ColumnDefinitions 5:      �� 5;      $��6* �6#   �� 5<      $��9* �6#   �� 5=      $��5* �6#   .+�5@      � -   5        $��CookieSpace��5@      $��0��6&    � RowDefinitions 5A      �� 5B      $��1* �6$   �� 5C      $��3* �6$   �� 5D      $��2* �6$   .+�5G      (� $��0��6   $��Center=�6'   $��Bottom=�6D   $��20q�6_   .��5H      �� -   5        $��CookiesPoints��5H       $
��Bold"�6y   
�������$��Global Serif)�6�   ��65   �� *CookiesAmount+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5I      �� 5J      $��1��6   ._�5K      �� -   5        $��Cookie��5K      #��[ 6+   #��[  6P   $	��250��6   $	��250��6�   6�   5L      �� 5M      -   5        $��RedBg��5M   &   $��2��6   #��[ 63   5N      � 5P      -   5        $ 	GameSpace��5P      $��1��6&    5Q      �� 5R      $��5* �6$   �� 5S      $��1* �6$   �� 5T      $	��10* �6$   �� 5U      $	��10* �6$   �� 5V      $	��10* �6$   �� 5W      $	��10* �6$   .+�5Z      �� $��1��6   $ ��assets/panelHorizontal.png��6%   $	��Top=�6I   $��50��6a   �� 5\      -   5         ��Name$ GrandmaSpace��5\      $��2��6/   #��[ 6<   ._�5]      �� -	   5         ��Name$ GrandmaCanvas��5]      5^      �� 5_      -
   5         ��Name$ GrandmeSeparator��5_      $��2��62   $ ��assets/panelHorizontal.png��6?   $��Bottom=�6c   �� 5a      -   5        $ 	FarmSpace��5a      $��3��6,   #��[ 69   ._�5b      �� -   5        $ 
FarmCanvas��5b      5c      �� 5d      -   5        $ FarmSeparator��5d      $��3��6/   $ ��assets/panelHorizontal.png��6<   $��Bottom=�6`   �� 5f      -   5        $ 	MineSpace��5f      $��4��6,   #��[ 69   ._�5g      �� -   5        $ 
MineCanvas��5g      5h      �� 5i      -   5        $ MineSeparator��5i      $��4��6/   $ ��assets/panelHorizontal.png��6<   $��Bottom=�6`   �� 5k      -   5        $ FactorySpace��5k      $��5��6/   #��[ 6<   ._�5l      �� -   5        $ FactoryCanvas��5l      5m      �� 5n      -   5        $ FactorySeparator��5n      $��5��62   $ ��assets/panelHorizontal.png��6?   $��Bottom=�6c   5o      � 5q      -   5        $ 	ShopSpace��5q      $��2��6&    5r      �� 5s      $��1* �6$   �� 5t      $��.5 �6$   �� 5u      $��1* �6$   �� 5v      $��1* �6$   �� 5w      $��1* �6$   �� 5x      $��1* �6$   �� 5y      $��1* �6$   �� 5z      $��1* �6$   .+�5}      )   #CookieClicker.usercontrols.ItemShop  -   5          Name$ 	BuyCursor��5}   e   )   #CookieClicker.usercontrols.ItemShop   MouseUp$ 	OnBuyItem��61      MouseLeftButtonUp$ OnBuyCursor��6E   $��2��6$     UnallowedButtonTile   UCBackground# [ 6x      ItemName$ Cursor��6�      ItemIcon# [ 6�      	ItemPrice 106�      ItemQuantity 06�      
Multiplier$	 1.8��6     CookiesPerItem 16    5~      -   5        $ 
BuyGrandma��5~   E   $ 	OnBuyItem��61   $��3��6$   # [ 6Y   $ Grandma��6�   # [ 6�    506�    06�   $	 2.2��6�    26�     5      -   5        $ BuyFarm��5   E   $ 	OnBuyItem��61   $��4��6$   # [ 6V   $ Farmer��6�   # [ 6�    1006�    06�   $	 2.8��6�    56�     5�      -   5        $ BuyMine��5�   E   $ 	OnBuyItem��61   $��5��6$   # [ 6V   $ Miner��6�   # [ 6�    50006�    06�   $	 3.2��6�    506�     5�      -   5        $ 
BuyFactory��5�   E   $ 	OnBuyItem��61   $��6��6$   # [ 6Y   $ Factory��6�   # [	 6�   	 150006�    06�   $	 3.8��6�    10006�   �� 5�      -   5        $��ShopRedBgTop��5�   &   $��0��6   #��[ 6:   �� 5�      -   5        $��ShopRedBgBottom��5�   &   $��7��6   #��[ 6=   5�      �� 5�      $��1��6   $��Right=�6$   $��assets/panelVertical.png��6@   �� 5�      $��1��6   $
��Left=�6$   $��assets/panelVertical.png��6?   5�      5�      5�      