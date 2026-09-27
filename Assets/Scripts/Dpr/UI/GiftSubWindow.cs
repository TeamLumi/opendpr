using UnityEngine.Events;

namespace Dpr.UI
{
	public abstract class GiftSubWindow : UIWindow
	{
		public void Initialize(UnityAction<UIWindow> onClosedCallback)
		{
			onClosed = onClosedCallback;
			OnInitialize();
        }

		protected abstract void OnInitialize();

		public abstract void OnUpdate(float deltaTime);
		
		public virtual void Show()
		{
			gameObject.SetActive(true);
		}
		
		public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
		
		protected void SetupKeyguide(KeyguideID[] keyguideIDs)
		{
			var keyguide = UIManager.Instance.GetKeyguide(null, true);

			keyguide.transform.SetParent(transform, false);
			var param = new Keyguide.Param();

			for (int i=0; i<keyguideIDs.Length; i++)
				param.itemParams.Add(new KeyguideItem.Param()
				{
					keyguideId = keyguideIDs[i],
				});
		}
	}
}