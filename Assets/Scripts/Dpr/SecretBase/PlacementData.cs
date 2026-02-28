using System.Runtime.InteropServices;
using UnityEngine;
using XLSXContent;

namespace Dpr.SecretBase
{
	public class PlacementData
	{
		public StatueItemData data;
		public FieldCursor cursor;
		private Transform statueModel;
		private Transform pedestalModel;
		private StatueEffectData statue;
		public Pedestal.SheetInfo pedestal;
		private NGMotionMono ngMotionPlayer;
		
		public bool isLoading { get; private set; }
		public Vector3 Position { get => cursor.transform.position; }
		
		public PlacementData(PlacementData prev, RectInt rect, FieldCursor origin, Transform root)
		{
			data = prev.data;
			statue = prev.statue;
			pedestal = prev.pedestal;

			var go = Object.Instantiate(origin, root);
			go.SetActive(true);
			cursor = go.GetComponent<FieldCursor>();
			cursor.SetRect(rect);

			SetDisplayCursor(!SecretBaseSaveDataWork.ViewMode);

			if (prev.statueModel != null)
			{
				statueModel = prev.statueModel;
				statueModel.SetParent(cursor.StatueRoot);
			}

			if (prev.pedestalModel != null)
			{
                pedestalModel = prev.pedestalModel;
                pedestalModel.SetParent(cursor.StatueRoot);
            }

			var boxCollider = cursor.BoxCollider;
			if (boxCollider != null)
			{
                boxCollider.enabled = true;
				boxCollider.center = new Vector3(0.0f, 0.5f, 0.0f);
				boxCollider.size = new Vector3(statue.rawData.width, 1.0f, statue.rawData.height);
				boxCollider.gameObject.layer = LayerMask.NameToLayer("Obstacle");
            }

			UpdateGraphic();
            cursor.StatueRoot.gameObject.AddComponent<SetMotionMono>();
		}
		
		public PlacementData(GameObject model, StatueItemData value, StatueEffectData statue, Pedestal.SheetInfo pedestal, RectInt rect, FieldCursor origin, bool bIsCursorCopy, [Optional] Transform root)
		{
			data = value;
            this.statue = statue;
			this.pedestal = pedestal;

			if (bIsCursorCopy)
			{
				var go = root != null ? Object.Instantiate(origin.gameObject) : Object.Instantiate(origin.gameObject, root, false);
				go.SetActive(true);
				cursor = go.GetComponent<FieldCursor>();
				cursor.SetRect(rect);
			}
            else
            {
                cursor = origin;
            }

            var boxCollider = cursor.BoxCollider;
            if (boxCollider != null)
            {
                boxCollider.enabled = true;
                boxCollider.center = new Vector3(0.0f, 0.5f, 0.0f);
                boxCollider.size = new Vector3(statue.rawData.width, 1.0f, statue.rawData.height);
                boxCollider.gameObject.layer = LayerMask.NameToLayer("Obstacle");
            }

            SetDisplayCursor(!SecretBaseSaveDataWork.ViewMode);

			statueModel = model.transform;
			statueModel.SetParent(cursor.StatueRoot);

			if (data.pedestalId > 0)
				SetPedestal(pedestal);

            UpdateGraphic(!bIsCursorCopy);
        }
		
		public PlacementData(StatueModelLoader modelLoader, StatueItemData value, StatueEffectData statue, Pedestal.SheetInfo pedestal, RectInt rect, FieldCursor origin, bool bIsCursorCopy, [Optional] Transform root)
		{
            data = value;
            this.statue = statue;
            this.pedestal = pedestal;

            if (bIsCursorCopy)
            {
                var go = root != null ? Object.Instantiate(origin.gameObject) : Object.Instantiate(origin.gameObject, root, false);
                go.SetActive(true);
                cursor = go.GetComponent<FieldCursor>();
                cursor.SetRect(rect);
            }
			else
			{
				cursor = origin;
			}

            SetDisplayCursor(!SecretBaseSaveDataWork.ViewMode);
			isLoading = true;

			modelLoader.Load(statue, cursor.StatueRoot, gameObject =>
			{
				if (isLoading)
				{
					statueModel = gameObject.transform;

					if (data.pedestalId > 0)
						SetPedestal(pedestal);

					UpdateGraphic(!bIsCursorCopy);
					isLoading = false;
				}
				else
				{
					Object.Destroy(gameObject);
				}
			});
        }
		
		// TODO
		public void SetParent(FieldCursor parent) { }
		
		// TODO
		public void SetPedestal(Pedestal.SheetInfo pedestal) { }
		
		// TODO
		public void UpdateGraphic(bool pickup = false) { }
		
		// TODO
		public void Destroy(bool bCursor) { }
		
		// TODO
		public void SetActive(bool value) { }
		
		// TODO
		public void SetDisplayCursor(bool isView) { }
		
		// TODO
		public bool IsRotation() { return default; }
		
		// TODO
		public void PlayNGMotion() { }
		
		// TODO
		public void StopNGMotion() { }

		private class SetMotionMono : MonoBehaviour
		{
			private float timer;
			private float height = 0.05f;
			private readonly float g = 10.0f;
			private float v0;
			private int bound;
			
			// TODO
			private void Start() { }
			
			private void Update()
			{
				if (this.isPlaying) {
				  PlayUpdate();
				}
			}
		}

		private class NGMotionMono : MonoBehaviour
		{
			private readonly float length = 0.02f;

			private int count;
			private Vector3 basePos;
			private bool isPlaying;
			
			// TODO
			public void Play() { }
			
			// TODO
			public void Stop() { }
			
			private void Update()
			{
				if (this.isPlaying) {
				  PlayUpdate();
				}
			}
			
			// TODO
			private void PlayUpdate() { }
		}
	}
}