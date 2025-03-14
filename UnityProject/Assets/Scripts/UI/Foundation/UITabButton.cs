using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Foundation.UI
{
    [RequireComponent(typeof(Button))]
    public class UITabButton : UIView
    {
        public int tabIndex { get; set; }

        public event UnityAction<int> onTabButtonClick;
        
        protected override void OnInit()
        {
        }

        protected override void OnEnter()
        {
            GetComponent<Button>().onClick.AddListener(OnButtonClicked);
        }

        protected override void OnExit()
        {
            GetComponent<Button>().onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            onTabButtonClick?.Invoke(tabIndex);
        }

        public void SetActived(bool notifyUpdate = false)
        {
            if (notifyUpdate)
                onTabButtonClick?.Invoke(tabIndex);
        }

        public void SetUnactived()
        {
            // button按钮状态
        }
    }
}
