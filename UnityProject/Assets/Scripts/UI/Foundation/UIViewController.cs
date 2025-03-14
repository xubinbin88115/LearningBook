using System;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class UIViewController : MonoBehaviour 
    {
        private LinkedList<UIViewController> m_ViewControllers = new LinkedList<UIViewController>();

        protected virtual void PushViewControllerTo(UIViewController viewController, RectTransform parent)
        {
            if (!m_ViewControllers.Contains(viewController))
            {
                m_ViewControllers.AddLast(viewController);
                
                var rectTransform = viewController.GetComponent<RectTransform>();
                rectTransform.SetParent(parent, false);
                rectTransform.anchorMin = Vector2.zero;
                rectTransform.anchorMax = Vector2.one;
                rectTransform.offsetMin = Vector2.zero;
                rectTransform.offsetMax = Vector2.zero;
            }

            foreach (var controller in m_ViewControllers)
            {
                if (controller.isActiveAndEnabled && controller != viewController)
                {
                    controller.OnHide();
                    controller.enabled = false;
                    controller.gameObject.SetActive(controller.enabled);
                }
            }

            if (!viewController.isActiveAndEnabled)
            {
                viewController.enabled = true;
                viewController.gameObject.SetActive(viewController.enabled);
            }
            viewController.OnInit();
            viewController.OnEnter();
        }

        public virtual void PushViewController(UIViewController viewController)
        {
            PushViewControllerTo(viewController, GetComponent<RectTransform>());
        }

        public virtual void PopViewController(UIViewController viewController)
        {
            if (!m_ViewControllers.Contains(viewController))
                return;

            m_ViewControllers.Remove(viewController);
            viewController.OnHide();
            viewController.OnExit();
            Destroy(viewController.gameObject);
        }
        
        // =========================================== 生命周期函数 =============================================
        public virtual void OnInit()
        {
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnShow()
        {
        }

        public virtual void OnHide()
        {
        }

        public virtual void OnResize()
        {
        }

        public virtual void OnExit()
        {
        }
    }
}
