using TMPro;
using UnityEngine;

namespace Dpr.UI
{
    public class ItemSelectAmount : MonoBehaviour
    {
        [SerializeField]
        protected RectTransform upArrowRectTransform;
        [SerializeField]
        protected RectTransform downArrowRectTransform;
        [SerializeField]
        protected TextMeshProUGUI amountValueText;
        [SerializeField]
        protected TextMeshProUGUI descriptionText;
        [SerializeField]
        protected IndexSelector indexSelector;

        public bool IsShow { get; protected set; }
        public int CurrentAmount { get => indexSelector.CurrentIndex; }

        // TODO
        public void Show() { }

        // TODO
        public void Hide() { }

        // TODO
        public void Set(int min, int max) { }

        // TODO
        public void SetDescriptionText(string text) { }

        // TODO
        public bool ChangeAmount(int value) { return false; }

        public void ResumeChangeAmount()
        {
        	uint uVar2;
        	if (this.indexSelector.moveState == 1) {
        	  uVar2 = 0;
        	}
        	else {
        	  if (this.indexSelector.moveState != 2) {
        	  }
        	  uVar2 = 3;
        	}
        	this.indexSelector.moveState = uVar2;
        }

        protected bool AddAmount(int value)
        {
        	if ((this.indexSelector.Move() & 1) != 0) {
        	  UpdateAmountValueText();
        	  return true;
        	}
        	return false;
        }

        // TODO
        protected void UpdateAmountValueText() { }
    }
}