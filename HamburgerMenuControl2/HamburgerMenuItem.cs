﻿using System.Windows;
using System.Windows.Controls;

namespace HamburgerMenuControl2
{
    public class HamburgerMenuItem : RadioButton
    {
        static HamburgerMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HamburgerMenuItem), new FrameworkPropertyMetadata(typeof(HamburgerMenuItem)));
        }
    }
}
