using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Foundation.Utils;

public class MainUIController : Foundation.UI.UITabBarController 
{
    protected override void OnTabPageChanged(int tabIndex)
    {
        if (tabIndex == 0)
            ToggleToViewController<Page1Controller>();
        else if (tabIndex == 1)
            ToggleToViewController<Page2Controller>();
    }
}