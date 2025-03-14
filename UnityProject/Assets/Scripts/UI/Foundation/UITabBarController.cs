using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.UI
{
    public class UITabBarController : UIViewController
    {
        [SerializeField]
        private UITabBar m_TabBar;
        [SerializeField] 
        private RectTransform m_TabContainer;

        private Dictionary<string, UIViewController> m_TabViewControllers = new Dictionary<string, UIViewController>();
        
        public override void OnInit()
        {
        }

        public override void OnEnter()
        {
            m_TabBar.onTabPageChanged += OnTabPageChanged;
        }

        public override void OnExit()
        {
            m_TabBar.onTabPageChanged -= OnTabPageChanged;
        }

        public override void PushViewController(UIViewController viewController)
        {
            PushViewControllerTo(viewController, m_TabContainer);
        }

        public override void PopViewController(UIViewController viewController)
        {
        }

        protected void ToggleToViewController<T>() where T : UIViewController
        {
            if (!m_TabViewControllers.TryGetValue(typeof(T).Name, out var viewController))
            {
                viewController = Utils.AssetLoader.GetInstance().LoadUI<T>();
                m_TabViewControllers.Add(typeof(T).Name, viewController);
            }
            PushViewController(viewController);
        }

        protected virtual void OnTabPageChanged(int tabIndex)
        {
        }
    }
}