using UnityEngine.Events;

namespace Foundation.UI
{
    public class UITabBar : UIView
    {
        [UnityEngine.SerializeField]
        private UITabButton[] m_TabButtons;
        private int m_TabIndex;
    
        public event UnityAction<int> onTabPageChanged;
        
        protected override void OnInit()
        {
            for (int i = 0; i < m_TabButtons.Length; ++i)
            {
                var tabButton = m_TabButtons[i];
                tabButton.tabIndex = i;
                tabButton.onTabButtonClick += OnTabButtonClicked;
            }
        }

        protected override void OnEnter()
        {
            m_TabButtons[m_TabIndex]?.SetActived(true);
        }

        protected override void OnExit()
        {
        }

        private void OnTabButtonClicked(int tabIndex)
        {
            m_TabIndex = tabIndex;
            onTabPageChanged?.Invoke(tabIndex);
        }
    }
}

