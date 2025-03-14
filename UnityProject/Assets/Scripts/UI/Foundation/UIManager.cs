using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.UI
{
    public class UIManager
    {
        private static UIManager s_Manager;

        public static UIManager GetInstance()
        {
            if (s_Manager == null)
                s_Manager = new UIManager();
            return s_Manager;
        }

        public void PushController(UIViewController viewController)
        {
            // this.rootViewController.Push<>();
            // this.rootViewController.PushViewController(
            // this.PushViewController(..)
            // this.PushUI<>("");
            // this.PopUI<>("");
        }

        public void PopController(UIViewController viewController)
        {
        }
    }
}