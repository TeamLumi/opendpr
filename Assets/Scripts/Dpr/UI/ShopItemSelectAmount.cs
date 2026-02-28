using System;
using System.Runtime.InteropServices;

namespace Dpr.UI
{
    public class ShopItemSelectAmount : ItemSelectAmount
    {
        private const int ChangeAmountValue = 1;
        private const int ChangeLotAmountValue = 10;
        private Action<int> onDecideSelectAmountCallback;
        private Action onCancelSelectAmountCallback;
        private Action<int> onSelectAmountValueChangedCallback;
        private UIInputController _input = new UIInputController();

        // TODO
        public void OnUpdate() { }

        // TODO
        public void ShowSelectAmount(int min, int max, Action<int> onDecide, Action onCancel, [Optional] Action<int> onAmountValueChanged) { }

        // TODO
        public void ChangeSelectAmount(bool isAdd, bool isLot) { }

        // TODO
        public void ResumeSelectAmountChange() { }

        public void DecideSelectAmount()
        {
        	ItemSelectAmount.Hide();
        	if (this.onDecideSelectAmountCallback != null) {
        	  var uVar1 = this.CurrentAmount;
        	  Action<int>.Invoke(this.onDecideSelectAmountCallback,uVar1);
        	}
        }

        public void CancelSelectAmount()
        {
        	ItemSelectAmount.Hide();
        	if (this.onCancelSelectAmountCallback != null) {
        	  this.onCancelSelectAmountCallback.Invoke();
        	}
        }

        // TODO
        public void SetSelectAmountDescriptionText(string text) { }
    }
}