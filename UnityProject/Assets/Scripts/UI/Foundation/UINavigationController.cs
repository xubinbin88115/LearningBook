using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.UI
{
    public class UINavigationController : UIViewController
    {
        private Stack<UIPageViewController> m_PageViewControllers = new Stack<UIPageViewController>();
        
        // public override void OnInit()
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public override void OnEnter()
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public override void OnExit()
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}
