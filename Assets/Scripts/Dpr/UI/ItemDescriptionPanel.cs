using Dpr.Item;
using Pml;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class ItemDescriptionPanel : MonoBehaviour
    {
        [SerializeField]
        protected Image itemIconImage;
        [SerializeField]
        protected UIText itemNameText;
        [SerializeField]
        protected UIText wazaNameText;
        [SerializeField]
        protected UIText descriptionText;
        [SerializeField]
        protected GameObject wazaBattleObject;
        [SerializeField]
        protected GameObject wazaContestObject;
        [SerializeField]
        protected WazaCategoryPanel wazaCategoryPanel;
        [SerializeField]
        protected TypePanel wazaTypePanel;
        [SerializeField]
        protected UIText wazaPowerValueText;
        [SerializeField]
        protected UIText wazaHitValueText;
        [SerializeField]
        protected UIText wazaPpValueText;
        [SerializeField]
        protected TypePanel contestWazaTypePanel;
        [SerializeField]
        protected Image contestWazaConditionImage;
        [SerializeField]
        protected Image[] contestWazaAppealPointImages;
        [SerializeField]
        protected Sprite appealPointEmptySprite;
        [SerializeField]
        protected Sprite appealPointFullSprite;
        protected bool isShowWazaDescription;
        protected internal bool isShowWazaContest;
        protected ItemInfo currentItemInfo;

        // TODO
        public void Clear() { }

        // TODO
        public void Set(ItemInfo item, bool isChangeShowWaza = true) { }

        // TODO
        public void SwitchWazaDescrption() { }

        // TODO
        protected void SetWazaDescription(ItemInfo item) { }

        // TODO
        protected virtual void SetWazaPower(WazaNo wazaNo, string messageLabel = "SS_bag_015", string messageLabelInvalid = "SS_bag_018") { }

        // TODO
        protected virtual void SetWazaHitPer(WazaNo wazaNo, string messageLabel = "SS_bag_017", string messageLabelInvalid = "SS_bag_018") { }

        // TODO
        protected void SetAppealPoint(int point) { }

        // TODO
        protected void ShowWazaDescriptionPanel() { }

        protected void HideWazaDescriptionPanel()
        {
        	this.isShowWazaDescription = false;
        	this.wazaBattleObject.SetActive(0);
        	this.wazaContestObject.SetActive(0);
        }

        // TODO
        protected void UpdateDescriptionText() { }
    }
}